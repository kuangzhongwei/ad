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
    public partial class ad_in_key :BasePage
    {
        private static string type = "";
        private static int id = 0;
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
             type = a.query.toString("t");
             id = a.query.toInt("aid");
            if (type.Equals("i"))
            { 
            
            }
            else if (type.Equals("u"))
            {
                T_ad_keys key = ad_main.admin_se_keys(id);
                txtdescription.Text = a.normal.toString(key.Key_back);
                txtkeywords.Text = a.normal.toString(key.Key_keys);
            }
            else
            {
                Response.Redirect("ad_key.aspx");
            }
        }
        protected void butsubmint_Click(object sender, EventArgs e)
        {
            string keywords = txtkeywords.Text.Trim();
            string description = txtdescription.Text.Trim();
            if (type.Equals("i"))
            {
                if (ad_main.admin_in_key(keywords, description) > 0)
                {
                    txtdescription.Text = "";
                    txtkeywords.Text = "";
                    MessShowBox.show("添加成功", this);
                }
                else
                {
                    MessShowBox.show("网络链接错误,添加失败",this);
                }
            }
            else if (type.Equals("u"))
            {
                if (ad_main.admin_up_key(id, keywords, description) > 0)
                {
                    MessShowBox.show("修改成功", this);
                    Response.Redirect("ad_key.aspx");
                }
                else
                {
                    MessShowBox.show("网络链接错误,修改失败",this);
                }
            }
            else
            {
                Response.Redirect("ad_key.aspx");
            }
        }

        protected void butback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_key.aspx");
        }
    }
}