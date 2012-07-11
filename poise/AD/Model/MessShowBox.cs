using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Model
{
    public class MessShowBox
    {
        /// <summary>
        /// 弹消息对话框
        /// </summary>
        /// <param name="message">显示的信息内容</param>
        /// <param name="page">this</param>
        public static void show(string message, Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(),"","<script>alert('"+message+"')</script>");   
        }
    }
}
