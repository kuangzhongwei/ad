using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal_io
{
    public static class io_io
    {
        public static string io_weizhi(int id)
        {
            string str = "";
            switch (id)
            { 
                case 0:
                    str = "首页显示";
                    break;
                case 1:
                    str = "内容页显示";
                    break;
                default :
                    str = "";
                    break;
            }
            return str;
        }
    }
}
