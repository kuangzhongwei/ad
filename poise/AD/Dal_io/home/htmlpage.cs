using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Dal_io;

namespace Dal_io.home
{
    public class htmlpage
    {
        /// <summary>
        /// 首页数据的方法
        /// </summary>
        /// <param name="file">文件夹的名称</param>
        /// <param name="html">页面的名称</param>
        /// <returns></returns>
        public static string page_default(string file, string html)
        {
            dal_user dalkeyword = new dal_user();
            string index = ""; //定义介绍首页的全部字符串
            index = loadhtml.html(file, html); //读到首页静态页面上所有的字符
            index = index.Replace("{CSS}", loadhtml.css()).Replace("{JAVASCRIPT}", loadhtml.js());
            dalkeyword.TemplateRows = "{KEYWORDS}";
            dal_user dalcon = new dal_user();
            dalcon.TemplateRows = "{DESCRIPTION}";


            dal_user dal2 = new dal_user();
            dal2.TemplateRows = "{TITLE}";
            dal2.top = 1;
            dal2.where=" and type_id=6";
            index = index.Replace("{new_title}", dal2.user_se_news());

            dal_user dal3 = new dal_user();
            dal3.top = 1;
            dal3.where = " and type_id=6";
            dal3.TemplateRows = "{NEW_INFO}";
            index = index.Replace("{new_info}", dal3.user_se_news());


            index = index.Replace("{KEYWORDS}", dalkeyword.user_se_key()).Replace("{DESCRIPTION}",dalcon.user_se_key());
            return index;
        }
        
    }
}
