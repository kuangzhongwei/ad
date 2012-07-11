using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal_io;
using Model;
using DAL;

namespace AD.admin
{
    public partial class ad_in_type : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SavePageStateToPersistenceMedium("__VIEWSTATE");
            }
        }

        protected void butsubmint_Click(object sender, EventArgs e)
        {
            string name = txttitle.Text.Trim();
            if (DAL.ad_main.admin_insert_type(name) > 0)
            {
                txttitle.Text = "";
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("网络链接错误,添加失败",this);
            }
        }

        protected void butback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_type.aspx");
        }
    }
}