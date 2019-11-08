using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Configuration;

namespace XF.BLL
{
    public class LoginHandler
    {
        public LoginHandler() { }

        /// <summary>
        /// 初始化菜单权限
        /// </summary>
        /// <param name="ModuleTag">菜单标识</param>
        public static void InitModule(string ModuleTag)
        {

            XF.BLL.XF_Modules bll = new XF.BLL.XF_Modules();
            XF.BLL.XF_Roles Rolebll = new XF.BLL.XF_Roles();
            //判断菜单是否启用
            if (bll.IsModule(ModuleTag))
            {
                if (!(bool)LoginInfo.IsLimit)
                {
                    ArrayList Mlists = new ArrayList();//菜单权限
                    ArrayList Ulists = new ArrayList();//用户的菜单权限

                    //读取菜单权限
                    int id = bll.GetModuleID(ModuleTag);
                    DataSet MALds = bll.GetAuthorityList(id);

                    for (int i = 0; i < MALds.Tables[0].Rows.Count; i++)
                    {
                        Mlists.Add(MALds.Tables[0].Rows[i]["AuthorityTag"].ToString());
                    }
                    LoginOptioner.RemoveModuleList();              //先清空Session中的列表
                    LoginOptioner.CreateModuleList(Mlists);        //登记新的列表

                    #region 读取用户的所有权限

                    //读取用户角色拥有的该菜单权限
                    if (ConfigurationManager.AppSettings["RoleGrant"].ToString().ToLower() == "true")
                    {
                        ArrayList rid = LoginInfo.RoleID;
                        for (int ri = 0; ri < rid.Count; ri++)
                        {
                            DataSet RALds = Rolebll.GetRoleAuthorityList(int.Parse(rid[ri].ToString().Split(',')[0]), id);
                            for (int i = 0; i < RALds.Tables[0].Rows.Count; i++)
                            {
                                if (!ModuleTagExists(Ulists, RALds.Tables[0].Rows[i]["AuthorityTag"].ToString()))
                                    Ulists.Add(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                            }
                        }
                    }

                    //读取用户分组拥有的该菜单权限
                    //if (ConfigurationManager.AppSettings["GroupGrant"].ToString().ToLower() == "true")
                    //{
                    //    DataSet RALds = Rolebll.GetGroupAuthorityList(SessionBox.GetUserSession().GroupID, id);
                    //    for (int i = 0; i < RALds.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (!ModuleTagExists(Ulists, RALds.Tables[0].Rows[i]["AuthorityTag"].ToString()))
                    //            Ulists.Add(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                    //    }
                    //}

                    ////读取用户拥有的该菜单权限
                    //if (ConfigurationManager.AppSettings["UserGrant"].ToString().ToLower() == "true")
                    //{
                    //    DataSet RALds = Rolebll.GetUserAuthorityList((int)LoginInfo.LoginId, id);
                    //    for (int i = 0; i < RALds.Tables[0].Rows.Count; i++)
                    //    {
                    //        if (!ModuleTagExists(Ulists, RALds.Tables[0].Rows[i]["AuthorityTag"].ToString()))
                    //        {
                    //            if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() == "true")
                    //            {
                    //                Ulists.Add(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                    //            }
                    //        }
                    //        else
                    //        {
                    //            if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() != "true")
                    //            {
                    //                Ulists.Remove(RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToLower());
                    //            }
                    //        }
                    //    }
                    //}

                    #endregion

                    LoginOptioner.RemoveAuthority();
                    LoginOptioner.CreateAuthority(Ulists);
                }
            }
            else
            {
                throw new Exception("此功能不存在");
            }

        }

        /// <summary>
        /// 校验用户是否对菜单有该权限
        /// </summary>
        /// <param name="tag">权限标识</param>
        /// <returns></returns>
        public static bool ValidationHandle(string ModuleTag)
        {
            bool ret = false;
            if (!(bool)LoginInfo.IsLimit) //判断用户是否授权限限制
            {
                ArrayList Mlist = LoginOptioner.GetModuleList();
                ArrayList Ulist = LoginOptioner.GetAuthority();

                for (int i = 0; i < Mlist.Count; i++)
                {
                    if (Mlist[i].ToString().ToLower() == ModuleTag.ToLower())//是否在菜单存在
                    {
                        for (int j = 0; j < Ulist.Count; j++)
                        {
                            if (Ulist[j].ToString().ToLower() == ModuleTag.ToLower())//是否在用户权限表中
                            {
                                ret = true;
                            }
                        }
                    }
                }
            }
            else
            {
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 判断是否有菜单访问权限
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        public static bool ValidationModule(int ModuleID, string AuthorityTag)
        {
            bool ret = false;
            XF.BLL.XF_Roles bll = new XF.BLL.XF_Roles();
            XF.Model.XF_RoleAuthorityList model = new XF.Model.XF_RoleAuthorityList();
            ArrayList rid = LoginInfo.RoleID;
            for (int ri = 0; ri < rid.Count; ri++)
            {
                model.UserID = 0;
                model.RoleID = int.Parse(rid[ri].ToString().Split(',')[0]);
                model.ModuleID = ModuleID;
                model.AuthorityTag = AuthorityTag;
                if (bll.RoleAuthorityExists(model))
                {
                    //只要有一个角色有操作权限都会返回真
                    ret = true;
                    break;
                }
            }

            //读取用户拥有的该菜单权限
            if (ConfigurationManager.AppSettings["UserGrant"].ToString().ToLower() == "true")
            {
                DataSet RALds = bll.GetUserAuthorityList((int)LoginInfo.LoginId, ModuleID);
                for (int i = 0; i < RALds.Tables[0].Rows.Count; i++)
                {
                    //判断菜单的浏览权限
                    if (RALds.Tables[0].Rows[i]["AuthorityTag"].ToString().ToUpper() == "RGP_BROWSE")
                    {
                        if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() == "true")//允许查看
                        {
                            ret = true;
                            break;
                        }
                        else if (RALds.Tables[0].Rows[i]["Flag"].ToString().ToLower() != "true")//禁止收查看
                        {
                            ret = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 返回对应的状态字符串
        /// </summary>
        /// <param name="n">状态标识</param>
        /// <returns></returns>
        public static string ReturnState(int n)
        {
            string ret = "";
            switch (n)
            {
                case 0:
                    ret = "禁止登录";
                    break;
                case 1:
                    ret = "允许登录";
                    break;
                case 2:
                    ret = "锁定";
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 检测标识在列表中是否存在
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ModuleTag"></param>
        /// <returns></returns>
        public static bool ModuleTagExists(ArrayList list, string ModuleTag)
        {
            bool ret = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (ModuleTag.ToLower() == list[i].ToString().ToLower())
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
