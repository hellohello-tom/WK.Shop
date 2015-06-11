using Shop.BLL;
using Shop.Common;
using Shop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Areas.Common.Controllers
{
    [AuthorizeType(NeedLogin = false)]
    public class UploadController : Controller
    {
        private FileAttrBLL _fileAttrBLL = new FileAttrBLL();

        /// <summary>
        /// 上传单文件
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="reFilePath">文本框中原来图片的相对路径，用来上传新图片后，将旧的图片删除</param>
        /// <param name="isWater">默认不打水印</param>
        /// <param name="isThumbnail">默认不生成缩略图</param>
        /// <param name="isImage">上传文件是否必须是图片</param>
        /// <param name="isReOriginal">是否返回文件原名称</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SingleFile(HttpPostedFileBase fileData, string reFilePath = "", int isWater = 0, int isThumbnail = 0, int isImage = 0, int isReOriginal = 0)
        {
            UploadCallback callback = null;
            if (fileData == null || fileData.ContentLength == 0)
            {
                callback = new UploadCallback();
                callback.status = -1;
                callback.msg = "请选择要上传文件!";
            }
            else
            {
                UpLoad upFiles = new UpLoad();
                callback = upFiles.fileSaveAs(fileData, isThumbnail == 1, isWater == 1, isImage == 1, isReOriginal == 1);
                if (callback.status == 1)
                {
                    //删除已存在的旧文件
                    var oldFile = WebHandle.GetMapPath(reFilePath);
                    if (!string.IsNullOrEmpty(oldFile))
                        System.IO.File.Delete(oldFile);
                }
            }
            return Json(callback);
        }

        /// <summary>
        /// 上传多文件处理
        /// </summary>
        /// <param name="isWater">默认不打水印</param>
        /// <param name="isThumbnail">默认不生成缩略图</param>
        /// <param name="isImage">上传文件是否必须是图片</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MultipleFile(HttpPostedFileBase fileData, int isWater = 0, int isThumbnail = 0, int isImage = 0)
        {
            UploadCallback callback = null;
            if (fileData == null || fileData.ContentLength == 0)
            {
                callback = new UploadCallback();
                callback.status = -1;
                callback.msg = "请选择要上传文件!";
            }
            UpLoad upFiles = new UpLoad();
            callback = upFiles.fileSaveAs(fileData, isThumbnail == 1, isWater == 1, isImage == 1);
            //返回成功信息
            return Json(callback);
        }

        /// <summary>
        /// xhedit编辑器上传处理
        /// </summary>
        /// <param name="isWater">默认不打水印</param>
        /// <param name="isThumbnail">默认不生成缩略图</param>
        /// <param name="isImage">上传文件是否必须是图片</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditorFile(HttpPostedFileBase fileData, int isWater = 0, int isThumbnail = 0, int isImage = 0)
        {
            object errMsg;
            if (fileData == null)
            {
                errMsg = new { err = "请选择要上传文件!", msg = "" };
            }
            else
            {
                UpLoad upFiles = new UpLoad();
                var callback = upFiles.fileSaveAs(fileData, isThumbnail == 1, isWater == 1, isImage == 1);
                if (1 == callback.status)
                {
                    errMsg = new
                    {
                        err = "",
                        msg = new { url = "!" + callback.data.newFileName, thumbnailFileName = callback.data.thumbnailFileName, originalFileName = callback.data.originalFileName, id = "1" }//id参数固定不变，仅供演示，实际项目中可以是数据库ID
                    };
                }
                else
                {
                    errMsg = new
                    {
                        err = callback.msg
                    };
                }
            }
            return Json(errMsg);
        }


        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteFile(int id)
        {
            DWZCallbackInfo callback = null;
            var fileModel = _fileAttrBLL.GetModel(id);
            if (fileModel.FileAttr_User == UserContext.CurUserInfo.Id)
            {
                if (_fileAttrBLL.Delete(id))
                {
                    callback = DWZMessage.Success("删除成功!");
                    System.IO.File.Delete(Server.MapPath(fileModel.FileAttr_Path));
                }
                else
                    callback = DWZMessage.Faild("删除失败!");
            }
            else
            {
                callback = DWZMessage.Faild("您没有权限删除他人文件!");
            }
            return Json(callback);
        }

        /// <summary>
        /// 将已经保存在服务端的图片存入数据库
        /// </summary>
        /// <param name="newFileName">保存在服务端的路径包含文件名</param>
        /// <param name="originalFileName">上传前的文件名</param>
        /// <returns></returns>
        public ActionResult AddPic(string newFileName, string originalFileName)
        {
            var statusCode = DWZStatusCode.Error.ToString();
            var msg = string.Empty;
            var id = 0;
            try
            {
                var serverPath = Server.MapPath(newFileName);
                if (System.IO.File.Exists(serverPath))
                {
                    using (var fileInfo = System.IO.File.OpenRead(serverPath))
                    {
                        if (fileInfo.Length > 0)
                        {
                            var fileModel = new FileAttr
                            {
                                FileAttr_CreateTime = DateTime.Now,
                                FileAttr_Path = newFileName,
                                FileAttr_Name = originalFileName,
                                FileAttr_Size = Convert.ToInt32(fileInfo.Length),
                                FileAttr_BussinessCode = BizCode.Commodity.ToString(),
                                FileAttr_IsDel = false,
                                FileAttr_User = UserContext.CurUserInfo.Id,
                                FileAttr_Ext = Path.GetExtension(serverPath),
                                FileAttr_Sort = 0
                            };
                            id = _fileAttrBLL.Add(fileModel);
                            if (id > 0)
                            {
                                statusCode = DWZStatusCode.Ok.ToString();
                            }
                            else
                            {
                                msg = originalFileName + "数据插入失败";
                            }
                        }
                        else
                        {
                            msg = originalFileName + "文件字节长度为0";
                        }
                    }
                }
                else
                {
                    msg = originalFileName + "文件不存在";
                }
            }
            catch (Exception ex)
            {
                msg = originalFileName + ex.Message;
            }
            return Json(new { statusCode = statusCode, msg = msg, id = id });
        }
    }
}
