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
    public partial class ad_ad : BasePage
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
                bind();
            }
        }
        public void bind()
        {
            int pagecount = 0;
            string where = " 1=1 ";
            string key = txtkey.Text.Trim();
            if (key != "")
                where += " and ((id like '%" + key + "%') or (ad_name like '%" + key + "%') or (ad_num ='" + key + "'))";
            List<T_ad_ad> list = ad_main.admin_ad_ad("t_ad_ad", "id", 10, Pager1.CurrentIndex, " id desc", where, out pagecount);
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
                string path = ad_main.admin_delete_img(id, "ad_img", "t_ad_ad");
                if (path != "")
                {
                    File.Delete(Server.MapPath(path));
                    if (ad_main.admin_delete_id(id, "t_ad_ad") > 0)
                    {
                        MessShowBox.show("删除成功", this);
                    }
                    else
                    {
                        MessShowBox.show("网络链接失败,删除失败", this);
                    }
                }
                else
                {
                    if (ad_main.admin_delete_id(id, "t_ad_ad") > 0)
                    {
                        MessShowBox.show("删除成功", this);
                    }
                    else
                    {
                        MessShowBox.show("网络链接失败,删除失败", this);
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