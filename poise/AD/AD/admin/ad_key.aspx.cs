using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Dal_io;
using Model;

namespace AD.admin
{
    public partial class ad_key : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SavePageStateToPersistenceMedium("__VIEWSTATE");
                bind();
            }
        }
        public void bind()
        {
            int pagecout = 0;
            List<T_ad_keys> list = ad_main.admin_key("t_ad_keys", "id", 10, Pager1.CurrentIndex, "id desc", "", out pagecout);
            rptUser.DataSource = list;
            rptUser.DataBind();
            Pager1.ItemCount = pagecout;
        }
        protected void Pager1_Command(object sender, CommandEventArgs e)
        {
            int pageCurrent = Convert.ToInt32(e.CommandArgument);
            this.Pager1.CurrentIndex = pageCurrent;
            bind();
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = a.normal.toInt(e.CommandArgument);
            if (e.CommandName == "delete")
            {
                if (ad_main.admin_delete_id(id, "t_ad_keys") > 0)
                {
                    MessShowBox.show("删除成功",this);
                }
            }
            bind();
        }
    }
}