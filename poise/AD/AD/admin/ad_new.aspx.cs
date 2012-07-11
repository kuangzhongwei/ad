using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using System.IO;
using Dal_io;

namespace AD.admin
{
    public partial class ad_new : BasePage
    {
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
                select();
                bind();
            }
        }
        private void select()
        {
            List<T_ad_type> list = ad_main.admin_select_type();
            ddltype.DataSource = list;
            ddltype.DataTextField = "atype_name";
            ddltype.DataValueField = "id";
            ddltype.DataBind();
            ListItem item = new ListItem("", "");
            ddltype.Items.Insert(0, item);
        }
        private void bind()
        {
            int pagecount = 0;
            string where = " 1=1 ";
            string key = txtkey.Text.Trim();
            string ddl = a.normal.toString(ddltype.SelectedItem.Text);
            if (key != "")
                where += " and ((aid like '%" + key + "%') or (new_title like '%" + key + "%') or (new_num  like '%" + key + "%'))";
            if (ddl != "")
                where += " and type_name='" + ddl + "'";
            List<T_ad_news> list = ad_main.admin_new_all("v-sys-select-new-type", " aid ", 20, Pager1.CurrentIndex, " aid desc,new_time asc", where, out pagecount);
            rptUser.DataSource = list;
            rptUser.DataBind();
            Pager1.ItemCount = pagecount;

        }
        protected void butselect_Click(object sender, EventArgs e)
        {
            bind();
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = a.normal.toInt(e.CommandArgument);
            if (e.CommandName == "delete")
            {
                string path = ad_main.admin_delete_img(id, "new_img", "t_ad_news");
                if (path != "")
                {
                    File.Delete(Server.MapPath(path));
                    if (ad_main.admin_delete_id(id, "t_ad_news") > 0)
                    {
                        MessShowBox.show("删除成功", this);
                    }
                    else
                    {
                        MessShowBox.show("网络链接错误,删除失败!", this);
                    }
                }
                else
                {
                    if (ad_main.admin_delete_id(id, "t_ad_news") > 0)
                    {
                        MessShowBox.show("删除成功", this);
                    }
                    else
                    {
                        MessShowBox.show("网络链接错误,删除失败!", this);
                    }
                }
            }
            bind();
        }

        protected void Pager1_Command(object sender, CommandEventArgs e)
        {
            int pageCurrent = Convert.ToInt32(e.CommandArgument);
            this.Pager1.CurrentIndex = pageCurrent;
            bind();
        }
    }
}