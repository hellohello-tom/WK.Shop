using Shop.BLL;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop.Web.Areas.Phone.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Phone/Search/
        private SysDicDetailBLL _dicDetailBLL = new SysDicDetailBLL();
        private SysDicTypeBLL _dicTypeBLL = new SysDicTypeBLL();
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult GetDrugList(string query)
         {
            var sourceData = new List<DrugKeyWord>();
            try
            {
                var parmater = "keyword=" + Server.UrlEncode(query);
                var request = HttpWebRequest.Create(new Uri("http://www.7lk.com/search/result"));
                request.Method = "POST";
                byte[] PostData = System.Text.Encoding.UTF8.GetBytes(parmater);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = parmater.Length;
                //将POST参数写入请求流
                Stream requestStream = request.GetRequestStream();        //获取请求流
                requestStream.Write(PostData, 0, PostData.Length);        //将参数字节数组写入到请求流里
                requestStream.Close();                                    //关闭请求流
                using (HttpWebResponse myrp = (HttpWebResponse)request.GetResponse())
                {
                    //获取响应流
                    Stream stream = myrp.GetResponseStream();
                    //创建流读取对象
                    StreamReader sr = new StreamReader(stream);
                    var returnVal = sr.ReadToEnd();
                    //读取响应流
                    var jss = new JavaScriptSerializer();
                    sourceData = (List<DrugKeyWord>)jss.Deserialize(returnVal, typeof(List<DrugKeyWord>)) ?? default(List<DrugKeyWord>);
                    var model = _dicTypeBLL.GetModel(SysDicType._.Code=="CommodityKeyWord");
                    var list = new List<SysDicDetail>();
                    foreach (var item in sourceData) 
                    {
                        list.Add(new SysDicDetail
                        {
                            DicTypeId = model.Id,
                            Enabled = 1,
                            Name = Server.UrlDecode(item.keyword),
                            ParentId = 0
                        });
                    }
                    _dicDetailBLL.AddList(list);
                }
            }
            catch
            { 
            }
            return Json(sourceData);
        }

    }
    public class DrugKeyWord
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string keyword { get; set; }
    }
}
