using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
using Shop.Common;

namespace Shop.Web{
    /// <summary>
    /// 文件上传帮助类
    /// 
    /// tomCat 
    /// 2014-4-1
    /// </summary>
    public class UpLoad
    {

        /// <summary>
        /// 裁剪图片并保存
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="cropWidth"></param>
        /// <param name="cropHeight"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public bool cropSaveAs(string fileName, string newFileName, int maxWidth, int maxHeight, int cropWidth, int cropHeight, int X, int Y)
        {
            string fileExt = Path.GetExtension(fileName); //文件扩展名，含“.”
            if (!IsImage(fileExt))
            {
                return false;
            }
            string newFileDir = WebHandle.GetMapPath(Path.GetDirectoryName(newFileName));
            //检查是否有该路径，没有则创建
            if (!Directory.Exists(newFileDir))
            {
                Directory.CreateDirectory(newFileDir);
            }
            try
            {
                string fileFullPath = WebHandle.GetMapPath(fileName);
                string toFileFullPath = WebHandle.GetMapPath(newFileName);
                return Thumbnail.MakeThumbnailImage(fileFullPath, toFileFullPath, 180, 180, cropWidth, cropHeight, X, Y);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex);
                return false;
            }
        }


        /// <summary>
        /// 文件上传方法
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="isThumbnail">是否生成缩略图</param>
        /// <param name="isWater">是否打水印</param>
        /// <param name="isImage">是否上传必须是图片</param>
        /// <param name="isReOriginal">是否返回文件原名称</param>
        /// <returns></returns>
        public UploadCallback fileSaveAs(HttpPostedFileBase postedFile, bool isThumbnail, bool isWater, bool isImage = false, bool isReOriginal = false)
        {
            UploadCallback callback = new UploadCallback();
            callback.status = -1;
            try
            {
                string fileExt = Path.GetExtension(postedFile.FileName); //文件扩展名，含“.”
                string originalFileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(@"\") + 1); //取得文件原名
                string fileName = Guid.NewGuid().ToString() + fileExt; //随机文件名
                string dirPath = GetUpLoadPath(); //上传目录相对路径

                //检查文件扩展名是否合法
                if (!CheckFileExt(fileExt))
                {
                    callback.msg = "不允许上传" + fileExt + "类型的文件！";
                    return callback;
                }
                //检查是否必须上传图片
                if (isImage && !IsImage(fileExt))
                {
                    callback.msg = "对不起，仅允许上传图片文件！";
                    return callback;
                }
                //检查文件大小是否合法
                if (!CheckFileSize(fileExt, postedFile.ContentLength))
                {
                    callback.msg = "文件超过限制的大小啦！";
                    return callback;
                }
                //获得要保存的文件路径
                string serverFileName = dirPath + fileName;
                string serverThumbnailFileName = dirPath + "small_" + fileName;
                string returnFileName = serverFileName;
                //物理完整路径                    
                string toFileFullPath = WebHandle.GetMapPath(dirPath);
                //检查有该路径是否就创建
                if (!Directory.Exists(toFileFullPath))
                {
                    Directory.CreateDirectory(toFileFullPath);
                }
                //保存文件
                postedFile.SaveAs(toFileFullPath + fileName);
                //如果是图片，检查图片尺寸是否超出限制
                if (IsImage(fileExt) && (BaseData.SiteConfig.AttachImgHeight > 0 || BaseData.SiteConfig.AttachImgWidth > 0))
                {
                    Thumbnail.MakeThumbnailImage(toFileFullPath + fileName, toFileFullPath + fileName, BaseData.SiteConfig.AttachImgWidth, BaseData.SiteConfig.AttachImgHeight, "Cut");
                }
                //是否生成缩略图
                if (IsImage(fileExt) && isThumbnail && BaseData.SiteConfig.ThumbnailWidth > 0 && BaseData.SiteConfig.ThumbnailHeight > 0)
                {
                    Thumbnail.MakeThumbnailImage(toFileFullPath + fileName, toFileFullPath + "small_" + fileName, BaseData.SiteConfig.ThumbnailWidth, BaseData.SiteConfig.ThumbnailHeight, "Cut");
                }
                else
                {
                    serverThumbnailFileName = returnFileName;
                }
                //是否打图片水印
                if (IsWaterMark(fileExt) && isWater)
                {
                    WaterMark.AddImageSignPic(serverFileName, serverFileName, BaseData.SiteConfig.WatermarkPicPath, 9, 90, 6);
                }
                callback.status = 1;
                callback.msg = "上传成功!";
                callback.data = new UploadData
                {
                    newFileName = returnFileName,
                    thumbnailFileName = serverThumbnailFileName,//返回缩略图
                    originalFileName = isReOriginal ? originalFileName : "" //如果需要返回原文件名,返回原文件名
                };
                return callback;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex);
                callback.status = -1;
                callback.msg = "上传过程中发生意外错误!";
                return callback;
            }
        }
        /// <summary>
        /// 上传图片的数据
        ///  
        /// tomCat
        /// 2014-4-3
        /// </summary>


        #region 私有方法

        /// <summary>
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        private string GetUpLoadPath()
        {
            return BaseData.SiteConfig.AttachPath.TrimEnd('/') + "/" + DateTime.Now.ToString("yyyyMMdd") + "/"; //上传目录
        }

        /// <summary>
        /// 是否需要打水印
        /// </summary>
        /// <param name="_fileExt">文件扩展名，含“.”</param>
        private bool IsWaterMark(string _fileExt)
        {
            //判断是否开启水印
            if (!string.IsNullOrWhiteSpace(BaseData.SiteConfig.WatermarkPicPath))
            {
                //判断是否可以打水印的图片类型
                ArrayList al = new ArrayList();
                al.Add(".bmp");
                al.Add(".jpeg");
                al.Add(".jpg");
                al.Add(".png");
                if (al.Contains(_fileExt.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为图片文件
        /// </summary>
        /// <param name="_fileExt">文件扩展名，含“.”</param>
        private bool IsImage(string _fileExt)
        {
            ArrayList al = new ArrayList();
            al.Add(".bmp");
            al.Add(".jpeg");
            al.Add(".jpg");
            al.Add(".gif");
            al.Add(".png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        private bool CheckFileExt(string _fileExt)
        {
            //检查危险文件
            string[] excExt = { ".asp", ".aspx", ".php", ".jsp", ".htm", ".html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = BaseData.SiteConfig.AttachExtension.Split(';');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == "*" + _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查文件大小是否合法
        /// </summary>
        /// <param name="_fileExt">文件扩展名，含“.”</param>
        /// <param name="_fileSize">文件大小(KB)</param>
        private bool CheckFileSize(string _fileExt, int _fileSize)
        {
            //判断是否为图片文件
            if (IsImage(_fileExt))
            {
                if (BaseData.SiteConfig.AttachImgSize > 0 && _fileSize > BaseData.SiteConfig.AttachImgSize * 1024)
                {
                    return false;
                }
            }
            else
            {
                if (BaseData.SiteConfig.AttachSize > 0 && _fileSize > BaseData.SiteConfig.AttachSize * 1024)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

    }

    /// <summary>
    /// 上传返回消息
    /// </summary>
    public class UploadCallback
    {
        /// <summary>
        /// 状态 1成功 -1错误
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public UploadData data { get; set; }
    }

    public class UploadData
    {
        /// <summary>
        /// 上传成功后的文件的相对路径
        /// </summary>
        public string newFileName { get; set; }

        /// <summary>
        /// 缩略图相对路径
        /// </summary>
        public string thumbnailFileName { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string originalFileName { get; set; }
    }
}