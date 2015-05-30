// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysRole 控制器
//  作    者：tomCat
//  添加时间：2014-03-06 17:23:41
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
using System.Text;

namespace Shop.Web.Areas.SysManage.Controllers
{
	/// <summary>
	/// SysRole控制器
	/// </summary>
	public class SysRoleController:Controller
	{	     
		private readonly SysRoleBLL bll=new SysRoleBLL();
        private readonly SysModuleBLL moduleBll = new SysModuleBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="page"> 分页信息</param>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string code = "", string name = "", int enabled = 1)
        {
            #region 搜索条件
            WhereClip where = null;
            //编码
            if (!string.IsNullOrEmpty(code))
                where &= SysRole._.Code.Like("%" + code + "%");
            //名称
            if (!string.IsNullOrEmpty(name))
                where &= SysRole._.Name.Like("%" + name + "%");
            //状态
            if (enabled >= 0)
                where &= SysRole._.Enabled == enabled;

            ViewBag.Code = code;
            ViewBag.Name = name;
            ViewBag.Enabled = enabled;
            #endregion
            var usersPage = bll.GetPageList(page.NumPerPage, page.PageNum, where);
            
            return View(usersPage);
        }


        #region 选择模块
        /// <summary>
        /// 选择模块
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectModule(string moduleIds="")
        {
            string checkModuleIds = string.Format(",{0},", moduleIds.Trim(','));//已选择的模块

            //----模块列表
            var moduleList = moduleBll.GetList(SysModule._.Enabled == 1); 

            StringBuilder sbHtml = new StringBuilder();
            var firstModuleList = moduleList.FindAll(x => x.ParentId == 0);//第一级
            List<Shop.Model.SysModule> childModuleList = null;//子级 临时变量

            //第1级
            sbHtml.AppendFormat("<ul class='tree  expand treeCheck'>");
            foreach (var root in firstModuleList)
            {
                sbHtml.AppendFormat("<li><a href='javascript:;' {0} tname='selectModule' tvalue='{{\"Id\":\"{1}\",\"Name\":\"{2}\"}}' >{2}</a>{3}</li>",
                                           checkModuleIds.Contains("," + root.Id + ",") ? "checked='checked'" : "",
                                            root.Id,
                                            root.Name,
                                            GetChildHtml(moduleList, root.Id, checkModuleIds)
                                       );
            }
            sbHtml.Append("</ul>");
            ViewBag.ModuleHtml = sbHtml.ToString();

            return View();
        }
        /// <summary>
        /// 获取子菜单html
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private string GetChildHtml(List<Shop.Model.SysModule> moduleList, int pid, string checkModuleIds)
        {
            var childModuleList = moduleList.FindAll(x => x.ParentId == pid);//子集

            StringBuilder sbHtml = new StringBuilder();
            if (childModuleList.Count > 0)
            {
                sbHtml.Append("<ul>");
                foreach (var item in childModuleList)
                {
                    sbHtml.AppendFormat("<li><a href='javascript:;' {0} tname='selectModule' tvalue='{{\"Id\":\"{1}\",\"Name\":\"{2}\"}}' >{2}</a>{3}</li>",
                                            checkModuleIds.Contains("," + item.Id + ",") ? "checked='checked'" : "",
                                             item.Id,
                                             item.Name,
                                             GetChildHtml(moduleList, item.Id, checkModuleIds)
                                        );
                }
                sbHtml.Append("</ul>");
            }
            return sbHtml.ToString();
        }
        #endregion


        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id=0)
        {
            Model.SysRole model = null;
            if (id > 0)
            {
                model = bll.GetModel(id);

                var moduleList= moduleBll.GetList(SysModule._.Id.In(model.ModuleIds.Split(',')));
                string moduleNames="";
                moduleList.ForEach(x => moduleNames+=x.Name+",");
                ViewBag.ModuleNames = moduleNames.Trim(',');
            }
            else
            {
                model = new SysRole();
                model.Enabled = 1;
                model.ModuleIds = " ";
            }
            return View(model);
        } 
        
        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.SysRole model)
        {
            bool flag = false;
			DWZCallbackInfo callback=null;
            if (!bll.Exists(SysRole._.Code == model.Code && SysRole._.Id != model.Id))
            {
                #region 勾选模块后，自动将其父级模块也勾选上
                string selectModuleIds = model.ModuleIds.Trim(',');//所选模块id
                var selectModeules = moduleBll.GetList(SysModule._.Enabled == 1 && SysModule._.Id.In(selectModuleIds.Split(',')));//所选模块
                
                string allModuleIds="";//根据所选模块的层级关系字段，取出所有的父级id
                foreach (var item in selectModeules)
                {
                    allModuleIds += item.Relation;
                }

                //将所有模块id去重
                List<string> allModuleIdList = allModuleIds.Split(',').ToList();
                allModuleIdList= allModuleIdList.Distinct().ToList();
                allModuleIds = ",";
                foreach (var item in allModuleIdList)
                {
                    if (item == "")
                        continue;
                    allModuleIds += item+",";
                }
                #endregion

                model.ModuleIds = allModuleIds;

                if (model.Id > 0)//修改
                    flag = bll.Update(model);
                else//添加
                    flag = bll.Add(model) > 0;

                if (flag)
                    callback = DWZMessage.Success("操作成功!", "SysManage_SysRole", true);
                else
                    callback = DWZMessage.Faild();

            }
            else
            {
                callback = DWZMessage.Faild("操作失败!角色编码已存在");
            }
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

            if (bll.Delete(id))
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
           
            int count=bll.Delete(ids) ;
            if (count > 0)
                callback = DWZMessage.Success(string.Format("删除成功！共删除{0}条！", count));
            else
                callback = DWZMessage.Faild("删除失败!");

            return Json(callback);
        }
        
        #endregion
	}
}