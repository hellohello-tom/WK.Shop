// ==========================================================================
//  All Rights Reserved , Copyright (C) 2014 , Team.
//
//  名    称：SysAdmin 控制器
//  作    者：tomCat
//  添加时间：2014-03-06 17:23:25
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
	/// SysAdmin控制器
	/// </summary>
	public class SysAdminController:Controller
	{	     
		private readonly SysAdminBLL bll=new SysAdminBLL();
        private readonly SysRoleBLL roleBLL = new SysRoleBLL();
        private readonly SysDicDetailBLL dicDetailBLL = new SysDicDetailBLL();
        private readonly SysOrgBLL orgBLL = new SysOrgBLL();
	
		/// <summary>
        /// 分页列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(DWZPageInfo page, string username = "", string realname = "",int role=0, int enabled = 1)
        {
            #region 搜索条件
            WhereClip where = null;
            //账号
            if (!string.IsNullOrEmpty(username))
                where &= SysAdmin._.UserName.Like("%" + username + "%");
            //姓名
            if (!string.IsNullOrEmpty(realname))
                where &= SysAdmin._.RealName.Like("%" + realname + "%");
            //角色
            if (role > 0)
                where &= SysAdmin._.RoleIds.Like(",%" + role.ToString() + "%,");
            //状态
            if (enabled >= 0)
                where &= SysAdmin._.Enabled == enabled;

            ViewBag.UserName = username;
            ViewBag.RealName = realname;
            ViewBag.Role = role;
            ViewBag.Enabled = enabled;
            #endregion

            //角色列表
            ViewBag.RoleList = roleBLL.GetList(SysRole._.Enabled == 1)?? new List<SysRole>();
            var adminPage = bll.GetPageList(page.NumPerPage, page.PageNum, where,SysAdmin._.RoleIds.Asc);
            return View(adminPage);
        }
        /// <summary>
        /// 选择角色
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectRole(string roleIds,string code="" ,string name="")
        {
            #region 搜索条件
            WhereClip where = SysRole._.Enabled == 1;
            //编码
            if (!string.IsNullOrEmpty(code))
                where &= SysRole._.Code.Like("%" + code + "%");
            //名称
            if (!string.IsNullOrEmpty(name))
                where &= SysRole._.Name.Like("%" + name + "%");

            ViewBag.Code = code;
            ViewBag.Name = name;
            #endregion
            var list = roleBLL.GetList(where);
            
            roleIds = string.Format(",{0},",roleIds.Trim(','));
            ViewBag.CheckRoleIds = roleIds;
            return View(list);
        }
        
        #region  添加 编辑
        /// <summary>
        /// 添加 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create(int id=0)
        {
            Model.SysAdmin model = null;

            if (id > 0)
            {
                model = bll.GetModel(id);
                var roleList = roleBLL.GetList(SysRole._.Id.In(model.RoleIds.Split(',')));
                string roleNames = "";
                roleList.ForEach(x => roleNames += x.Name + ",");
                ViewBag.RoleNames = roleNames.Trim(',');
                model.Org = orgBLL.GetModelByUserId(model.Id);
            }
            else
            {
                model = new Model.SysAdmin();
                model.Enabled = 1;
                model.RoleIds = " ";
            }
            var orgList = orgBLL.GetList(SysOrg._.Enabled == 1, SysOrg._.Relation.Asc);
            foreach (var org in orgList)
	        {
                if (org.Level >= 2)
                {
                    string space = string.Empty;
                    for (int i = 0; i < org.Level-1; i++)
                    {
                        space += "━";
                    }
                    org.Name = "┗" + space + org.Name;
                }
            }
            ViewBag.OrgList =orgList;

            return View(model);
        } 
        
        /// <summary>
        /// 添加 编辑操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Model.SysAdmin model)
        {
            bool flag = false;
            DWZCallbackInfo callback = null;
            if (!bll.Exists(SysAdmin._.UserName == model.UserName && SysAdmin._.Id != model.Id))//用户名要唯一
            {
                model.RoleIds = "," + model.RoleIds.Trim(',') + ",";
                if (model.Id > 0)//修改
                {
                    var tempModel = bll.GetModel(model.Id);//原信息
                    tempModel.UserName = model.UserName;
                    tempModel.RealName = model.RealName;
                    tempModel.RoleIds = model.RoleIds;
                    tempModel.Enabled = model.Enabled;
                    tempModel.UpdateTime = DateTime.Now;
                    tempModel.UpdateUser = UserContext.CurUserInfo.UserName;
                    tempModel.Org = new SysOrg() { Id = model.Org.Id };

                    if (!string.IsNullOrEmpty(model.PassWord))//密码不为空，才是修改密码
                        tempModel.PassWord = Md5.Encrypt(model.PassWord);
                    flag = bll.UpdateAdmin(tempModel);
                }
                else//添加
                {
                    model.LoginTimes = 0;
                    model.AddTime = DateTime.Now;
                    model.AddUser = UserContext.CurUserInfo.UserName;

                    if (string.IsNullOrEmpty(model.PassWord))//密码为空，默认为123456
                        model.PassWord = "123456";
                    model.PassWord = Md5.Encrypt(model.PassWord);

                    flag = bll.Add(model) > 0;
                }


                if (flag)
                    callback = DWZMessage.Success("操作成功!", "SysManage_SysAdmin", true);
                else
                    callback = DWZMessage.Faild();
            }
            else
            {
                callback = DWZMessage.Faild("操作失败！用户名已存在！");
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