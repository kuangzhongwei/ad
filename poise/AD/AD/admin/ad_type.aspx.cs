using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using Dal_io;

namespace AD.admin
{
    public partial class ad_type :BasePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            a.Users user = new a.Users("login");
            if (user.get("loginname") == "")
            {
                Response.Redirect("ad_login.aspx");
            }
            if (!IsPostBack)
            {
                SavePageStateToPersistenceMedium("__VIEWSTATE");
                bind();
            }
        }
        private void bind()
        {
            int pagecount = 0;
            List<T_ad_type> list = ad_main.admin_type_all("p-type-all-view", "id", 10, Pager1.CurrentIndex, " id desc", "", out pagecount);
            rptUser.DataSource = list;
            rptUser.DataBind();
            Pager1.ItemCount = pagecount;
        }
        protected void Pager1_Command(object sender, CommandEventArgs e)
        {
            int pageCurrent = Convert.ToInt32(e.CommandArgument);
            this.Pager1.CurrentIndex = pageCurrent;
            bind();
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int aid = a.normal.toInt(e.CommandArgument);
            if (e.CommandName == "Edit")
            {
                id = int.Parse(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Cancel")
            {
                id = -1;
            }
            else if (e.CommandName == "delete")
            {
                if (ad_main.admin_delete_id(aid, "t_ad_type") > 0)
                {
                    MessShowBox.show("删除成功", this);
                }
                else
                {
                    MessShowBox.show("网络链接失败,删除失败", this);
                }
            }
            else if (e.CommandName == "Update")
            {
                string type_name = ((TextBox)e.Item.FindControl("txttype")).Text;
                if (ad_main.admin_update_type(aid, type_name) > 0)
                {
                    id = -1;
                    MessShowBox.show("修改成功", this);
                }
                else
                {
                    MessShowBox.show("网络链接错误,修改失败",this);
                }
            }
            bind();
        }

        protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                T_ad_type record = (T_ad_type)e.Item.DataItem;
                int userId = int.Parse(record.Id.ToString());
                if (userId != id)
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = true;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = false;
                }
                else
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = false;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = true;
                }
            }
        }
    }
}