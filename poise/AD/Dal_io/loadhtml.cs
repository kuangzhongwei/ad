using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Dal_io
{
    public class loadhtml
    {
       
        private  static string templatedir = "/html/";
        private static string texthtml = "";
        /// <summary>
        /// 读取静态页面的方法
        /// </summary>
        /// <param name="file">存放静态页面的文件夹的名称</param>
        /// <param name="htm">静态页面的名称</param>
        /// <returns></returns>
        public static string html(string file, string htm)
        {

            htm = htm.ToUpper();
            //if (b.Exists(htm))
            //{
            //    return b.GetString(htm);
            //}
            //else
            {
                string path = HttpContext.Current.Server.MapPath(templatedir + "/" + folder(file) + "/" + htm + ".htm");
                //定义接收页面元素的字符串
                string htmltext = "";
                //把html页面写如缓存
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("gb2312")))
                {
                    htmltext = sr.ReadToEnd();
                    if (htmltext != "")
                    {
                        texthtml = htmltext;
                    }
                    //关闭流
                    sr.Close();
                    sr.Dispose();
                }
                return texthtml;
            }

        }
        public static string js()
        {
            string str = loadhtml.html("js", "javascript"); ;
            return str;
        }
        public static string daohang()
        {
            string str=loadhtml.html("static","daohang");
            return str;
        }
        public static string css()
        {
            string str = loadhtml.html("CSS", "css"); //读取到的css部分
            return str;
        }
        private  static string folder(string file)
        {
            string str = "";
            switch (file)
            {
                case "CSS":

                    str = "CSS";
                    break;
                case "demo":
                    str = "demo";
                    break;
                case "js":
                    str = "javascript";
                    break;
                case "top":
                    str = "top";
                    break;
                case "static":
                    str = "static";
                    break;
                default:
                    str = "";
                    break;
            }
            return str;
        }
    }

}
