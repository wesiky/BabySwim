using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XF.BaseFunction
{
    public class Entry
    {
        public Form ChangePassword()
        {
            FrmChangePassword frm = new FrmChangePassword();
            return frm;
        }

        public Form UsersList()
        {
            FrmUsersList frm = new FrmUsersList();
            return frm;
        }

        public Form GroupsList()
        {
            FrmGroupsList frm = new FrmGroupsList();
            return frm;
        }

        public Form RolesList()
        {
            FrmRolesList frm = new FrmRolesList();
            return frm;
        }

        public Form Modules()
        {
            FrmModules frm = new FrmModules();
            return frm;
        }

        public Form RolesAuthorizedRel()
        {
            FrmRolesAuthorizedRel frm = new FrmRolesAuthorizedRel();
            return frm;
        }

        public Form AuthorityList()
        {
            FrmAuthorityList frm = new FrmAuthorityList();
            return frm;
        }

        public Form ConfigList()
        {
            FrmConfigList frm = new FrmConfigList();
            return frm;
        }
    }
}
