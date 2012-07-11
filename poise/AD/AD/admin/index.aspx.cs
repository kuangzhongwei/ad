using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Dal_io;

namespace AD.admin
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            a.Users user = new a.Users("login");
            if (user.get("loginname") == "" )
            {
                Response.Redirect("ad_login.aspx");
            }
        }
    }
}