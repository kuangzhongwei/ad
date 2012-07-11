using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using Dal_io;

namespace AD.admin
{
    public partial class ad_login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLoginName.Focus();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string name = txtLoginName.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            if (ad_main.login(name, pwd))
            {
                a.Users user = new a.Users("login");
                int uid = 1;
                user.save(uid,new a.item[]{
                    new a.item("loginname",name),
                });
                Response.Redirect("index.aspx");
            }
            else
            {
                MessShowBox.show("帐号或者密码不对",this);
            }
        }
    }
}