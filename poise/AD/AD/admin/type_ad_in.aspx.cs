using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal_io;
using DAL;
using Model;

namespace AD.admin
{
    public partial class type_ad_in : BasePage
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
            if (ad_main.admin_type_id(name))
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
            Response.Redirect("type_ad.aspx");
        }
    }
}