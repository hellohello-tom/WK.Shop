using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Areas.Common.Controllers
{
    [AuthorizeType(NeedLogin = false)]
    public class UploadController : Controller
    {
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
    }
}
