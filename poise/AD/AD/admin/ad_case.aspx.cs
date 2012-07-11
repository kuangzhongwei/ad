using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.IO;
using Dal_io;

namespace AD.admin
{
    public partial class ad_case : BasePage
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
        private void bind()
        {
            int pagecount = 0;
            string where = " 1=1 ";
            string key = txtkey.Text.Trim();
            if (key != "")
                where += " and ((id like '%" + key + "%') or (ad_name like '%" + key + "%') or (ad_num ='" + key + "'))";
            List<T_ad_case> list = ad_main.admin_select_case("T_ad_case", "id", 20, Pager1.CurrentIndex, " id desc", where, out pagecount);
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
            int id = a.normal.toInt(e.CommandArgument);
            if (e.CommandName == "delete")
            {
                string path1 = ad_main.admin_delete_img(id, "post_job", "T_ad_case");
                string path2 = ad_main.admin_delete_img(id, "post_summary", "T_ad_case");
                if (path1 != "")
                {
                    File.Delete(Server.MapPath(path1));
                    File.Delete(Server.MapPath(path2));
                    if (ad_main.admin_delete_id(id, "T_ad_case") > 0)
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
                    if (ad_main.admin_delete_id(id, "T_ad_case") > 0)
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

        protected void butselect_Click(object sender, EventArgs e)
        {
            bind();
        }
    }
}