using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class T_ad_ad
    {
        private int ad_num;

        public int Ad_num
        {
            get { return ad_num; }
            set { ad_num = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string ad_name;
        public string Ad_name
        {
            get { return ad_name; }
            set { ad_name = value; }
        }
        private string ad_img;
        public string Ad_img
        {
            get { return ad_img; }
            set { ad_img = value; }
        }
        private string ad_text;
        public string Ad_text
        {
            get { return ad_text; }
            set { ad_text = value; }
        }
        private string ad_weizhi;

        public string Ad_weizhi
        {
            get { return ad_weizhi; }
            set { ad_weizhi = value; }
        }
    }

}
