using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal_io;
using Model;

namespace AD
{
    public partial class _default : BasePage
    {
        public string CSS = "";
        public string KEYWORDS = "";
        public string DESCRIPTION = "";
        public string JAVASCRIPT = "";
        public string DAOHANG = "";
        public string GONGSITITLE = "";
        public string GONGSITEXT = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            JAVASCRIPT = Server.HtmlDecode(loadhtml.js());
            CSS = Server.HtmlDecode(loadhtml.css());
            T_ad_keys listkey = dal_user.user_se_key();
            DAOHANG = Server.HtmlDecode(loadhtml.daohang());
            KEYWORDS = Server.HtmlDecode(listkey.Key_keys);
            DESCRIPTION = Server.HtmlDecode(listkey.Key_back);
            List<T_ad_news> gongsilinian = dal_user.user_se_news(1, " where type_id=6");
            GONGSITITLE= gongsilinian[0].New_title;
            GONGSITEXT = gongsilinian[0].New_info;
            List<T_ad_news> listnew = dal_user.user_se_news(4, " where type_id=5");
            StringBuilder newlist = new StringBuilder();
            for (int i = 0; i < listnew.Count; i++)
            {
                newlist.Append("\t<li class=\"col1-4\">\n");
                newlist.AppendFormat("\t<h4><a href=\"{0}\">{1}</a></h4>\n", listnew[i].Id, listnew[i].New_title);
                newlist.AppendFormat("\t\t<p class=\"bottom-20\">{0} ...</p>\n", strtext(listnew[i].New_Summary));
                newlist.Append("\t\t<div class=\"post-info clearfix\">\n");
                newlist.AppendFormat("\t\t<p><span>On: <a href=\"javascript:void(0)\">{0}</a></span>\n", listnew[i].New_time);
                newlist.Append("\t\t<span>Author: Fireform</span> <span>In: <a href=\"/\">东方广告</a></span></p>\n");
                newlist.Append("\t\t\t<div class=\"comments-more\">\n");
                newlist.AppendFormat("\t\t\t<span class=\"comm\">{0}</span> <a href=\"{1}\" class=\"more\"></a>\n", listnew[i].New_num, listnew[i].Id);
                newlist.Append("\t\t</div>\n");
                newlist.Append("\t</div>\n");
                newlist.Append("\t</li>\n");
            }
            new_list.Text = newlist.ToString();

            T_ad_img modelimg = dal_user.user_se_ad_img();
            StringBuilder img = new StringBuilder();
            if (modelimg.Path_img1 != null || modelimg.Path_img1 != "")
            {
                img.AppendFormat("\t<li class=\"block\"><img src\"{0}\" alt=\"\"  /></li>\n", modelimg.Path_img1);
            }
            if (modelimg.Path_img2 != null || modelimg.Path_img2 != "")
            {
                img.AppendFormat("\t\t<li class=\"block\"><img src\"{0}\" alt=\"\"  /></li>\n", modelimg.Path_img2);
            } 
            if (modelimg.Path_img3 != null || modelimg.Path_img3 != "")
            {
                img.AppendFormat("\t\t<li class=\"block\"><img src\"{0}\" alt=\"\" /></li>\n", modelimg.Path_img3);
            } 
            if (modelimg.Path_img4 != null || modelimg.Path_img4 != "")
            {
                img.AppendFormat("\t\t<li class=\"block\"><img src\"{0}\" alt=\"\" /></li>\n", modelimg.Path_img4);
            }
            if (modelimg.Path_img5 != null || modelimg.Path_img5 != "")
            {
                img.AppendFormat("\t\t<li class=\"block\"><img src\"{0}\" alt=\"\"  /></li>\n", modelimg.Path_img5);
            }
            titleimg.Text = img.ToString();
        }






















        public string strtext(string str)
        {
            string s = "";
            if (str.Length > 35)
                s = str.Substring(0, 35);
            else
                s = str;
            return s;
        }
    }
}