// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysDicDetail 控制器
//  作    者：tomCat
//  添加时间：2014-03-06 17:23:29
// ==========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//引用
using Shop.BLL;
using Shop.Model;
using Shop.Common;
using MySoft.Data;

namespace Shop.Web.Areas.SysManage.Controllers
{
    /// <summary>
    /// 字典管理控制器
    /// </summary>
    public class SysDicController : Controller
    {
        private readonly SysDicTypeBLL bllType = new SysDicTypeBLL();//字典分类名称
        private readonly SysDicDetailBLL bllDetail = new SysDicDetailBLL();//字典子项目详细


        #region SysDicType 父级信息
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="numPerPage"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string code = "", string name = "", int enabled = 1)
        {
            #region 检索条件
            WhereClip where = null;
            OrderByClip orderBy = SysDicType._.OrderNum.Asc;//排序
            //编码
            if (!string.IsNullOrEmpty(code))
            {
                where = SysDicType._.Code.Like("%" + code.Trim() + "%");
            }
            //名称
            if (!string.IsNullOrEmpty(name))
            {
                where &= SysDicType._.Name.Like("%" + name.Trim() + "%");
            }
            //状态
            if (enabled >= 0)
            {
                where &= SysDicType._.IsEnabled == enabled;
            }
            ViewBag.Code = code;
            ViewBag.Name = name;
            ViewBag.Enabled = enabled;
            #endregion
            var usersPage = bllType.GetPageList(page.NumPerPage, page.PageNum, where, orderBy);

            return View(usersPage);
        }

        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id = 0)
        {
            Model.SysDicType model = new SysDicType(); ;
            if (id > 0)//修改
            {
                model = bllType.GetModel(id);
                return View(model);
            }
            //新增
            else
            {
                model.OrderNum = 0;//默认排序号为0
                model.IsEnabled = 1;//默认状态为启用
                return View(model);
            }
        }

        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.SysDicType model)
        {
            bool flag = false;
            DWZCallbackInfo callback = null;
            if (model.Id > 0)//修改
                flag = bllType.Update(model);
            else//添加
                flag = bllType.Add(model) > 0;

            if (flag)
                callback = DWZMessage.Success("操作成功!", "SysManage_SysDic", true);
            else
                callback = DWZMessage.Faild();

            return Json(callback);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var detailList = bllDetail.GetList(SysDicDetail._.DicTypeId == id); ;
            DWZCallbackInfo callback = null;
            if (detailList != null && detailList.Count > 0)
            {
                callback = DWZMessage.Faild("请先删除子模块下信息!");
            }
            else
            {
                if (bllType.Delete(id))
                    callback = DWZMessage.Success("删除成功!");
                else
                    callback = DWZMessage.Faild("删除失败!");
            }
            return Json(callback);
        }

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteList(int[] ids)
        {

            DWZCallbackInfo callback = null;

            string idString = "";
            for (int i = 0; i < ids.Length; i++)
            {
                idString += ids[i] + ",";
            }
            WhereClip where = new WhereClip(" DicTypeId in(" + idString.TrimEnd(',') + ")");
            var detailList = bllDetail.GetList(where);
            if (detailList != null && detailList.Count > 0)//说明客服分组下有客服信息 
            {
                callback = DWZMessage.Faild("请先删除子模块下信息!");
            }
            else
            {
                int count = bllType.Delete(ids);
                if (count > 0)
                    callback = DWZMessage.Success(string.Format("删除成功！共删除{0}条！", count));
                else
                    callback = DWZMessage.Faild("删除失败!");
            }
            return Json(callback);
        }

        #endregion

        #endregion

        #region SysDicDetail 子项信息
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="numPerPage"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public ActionResult DetailIndex(DWZPageInfo page, int id = 0, string name = "", int enabled = -1)
        {
            #region  检索条件
            WhereClip where = null;
            where = SysDicDetail._.DicTypeId == id;//where条件

            if (!String.IsNullOrEmpty(name))
            {
                where &= SysDicDetail._.Name.Like("%" + name.Trim() + "%");

            }
            //状态
            if (enabled >= 0)
            {
                where &= SysDicDetail._.Enabled == enabled;
            }
            #endregion
            ViewBag.Name = name;
            var usersPage = bllDetail.GetPageList(page.NumPerPage, page.PageNum, where, SysDicDetail._.Relation.Asc);
            ViewBag.TypeId = id;
            ViewBag.Enabled = enabled;
            return View(usersPage);
        }

        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DetailCreate(int typeId, int flag = 0, int id = 0, int DicTypeId = 0)
        {
            Model.SysDicDetail model = null;
            if (id > 0)//修改
            {
                model = bllDetail.GetModel(id);
            }
            else//新增
            {
                model = new SysDicDetail();
                if (flag == 2)
                {
                    model.DicTypeId = typeId;
                    model.ParentId = 0;
                }
                else if (flag == 1)
                {
                    model.DicTypeId = DicTypeId;
                    model.ParentId = typeId;

                }
                model.Enabled = 1;//默认状态启用
            }
            if (flag == 1)//增加子项目
            {
                ViewBag.Typename = bllDetail.GetModel(typeId).Name;
            }
            else if (flag == 2)//2级所用
            {
                ViewBag.Typename = bllType.GetModel(typeId).Name;
            }
            else if (flag == 3)//》=3级使用
            {
                ViewBag.Typename = bllDetail.GetModel(typeId).Name;
            }
            model.Id = id;
            return View(model);
        }

        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DetailCreate(Model.SysDicDetail model)
        {
            bool flag = false;
            DWZCallbackInfo callback = null;

            if (model.Id > 0)//修改
                flag = bllDetail.Update(model);
            else//添加
                flag = bllDetail.SysDicDetailAdd(model) > 0;

            if (flag)
                callback = DWZMessage.Success("操作成功!", "SysManage_SysDic_DetailIndex", true);
            else
                callback = DWZMessage.Faild();

            return Json(callback);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DetailDelete(int id)
        {
            DWZCallbackInfo callback = null;

            if (bllDetail.Delete(id))
                callback = DWZMessage.Success("删除成功!");
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }

        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DetailDeleteList(int[] ids)
        {
            DWZCallbackInfo callback = null;

            int count = bllDetail.Delete(ids);
            if (count > 0)
                callback = DWZMessage.Success(string.Format("删除成功！共删除{0}条！", count));
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }

        #endregion

        #endregion
    }
}