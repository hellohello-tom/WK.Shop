// ==========================================================================
//  All Rights Reserved , Copyright (C) 2015 , Kingroad Group.
//
//  名    称：Menu 控制器
//  作    者：cat
//  添加时间：2015-06-17 10:59:26
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
using Shop.Web;

namespace Shop.Web.Areas.FlashSales.Controllers
{
    /// <summary>
    /// Menu控制器
    /// </summary>
    public class MenuController : Controller
    {
        private readonly MenuBLL bll = new MenuBLL();

        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string name="")
        {
            #region 搜索条件
            //只去一级目录菜单
            WhereClip where = Menu._.Menu_IsDel == false
                && Menu._.Menu_Type == MenuType.FlashSalues.ToString()
                && Menu._.Menu_ParentId == 0;
            if (!string.IsNullOrEmpty(name))
                where &= Menu._.Menu_Name.Like("%" + name + "%");
            ViewBag.Name = name;
            #endregion
            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum, where, Menu._.Id.Desc);
            return View(usersPage);
        }

        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id = 0)
        {
            Model.Menu model = bll.GetModel(id) ?? new Menu();
            if (id > 0)
            {
            }
            else
            {
                model.Menu_Type = MenuType.FlashSalues.ToString();
                model.Menu_ParentId = 0;
                model.Menu_Sort = 1;
            }
            return View(model);
        }

        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Model.Menu model)
        {
            bool flag = false;
            DWZCallbackInfo callback = null;
            if (ModelState.IsValid)
            {
                if (model.Id > 0)//修改
                    flag = bll.Update(model);
                else//添加
                {
                    model.Menu_Type = MenuType.FlashSalues.ToString();
                    model.Menu_ParentId = 0;
                    model.Menu_CreateTime = DateTime.Now;
                    model.Menu_CreateUser = UserContext.CurUserInfo.Id;
                    model.Menu_IsDel = false;
                    flag = bll.Add(model) > 0;
                }
            }
            if (flag)
                callback = DWZMessage.Success("操作成功", "FlashSales_Menu", true);
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
            DWZCallbackInfo callback = null;
            if (bll.Update(new Dictionary<Field, object> { { Menu._.Menu_IsDel, true } }, Menu._.Id == id))
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
        public ActionResult DeleteList(int[] ids)
        {
            DWZCallbackInfo callback = null;

            if (bll.Update(new Dictionary<Field, object> { { Menu._.Menu_IsDel, true } }, Menu._.Id.In(ids)))
            {
                callback = DWZMessage.Success(string.Format("删除成功！共删除{0}条！", ids.Length));
            }
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }

        #endregion
    }
}