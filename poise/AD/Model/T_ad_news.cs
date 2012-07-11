using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class T_ad_news
    {
        private string type_name;

        public string Type_name
        {
            get { return type_name; }
            set { type_name = value; }
        }
        private string new_Summary;
        public string New_Summary
        {
            get { return new_Summary; }
            set { new_Summary = value; }
        }
        private string new_info;
        public string New_info
        {
            get { return new_info; }
            set { new_info = value; }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int type_id;
        public int Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }
        private int new_num;
        public int New_num
        {
            get { return new_num; }
            set { new_num = value; }
        }
        private DateTime new_time;
        public DateTime New_time
        {
            get { return new_time; }
            set { new_time = value; }
        }
        private string new_title;
        public string New_title
        {
            get { return new_title; }
            set { new_title = value; }
        }
        private string new_img;
        public string New_img
        {
            get { return new_img; }
            set { new_img = value; }
        }
        private string new_admin;
        public string New_admin
        {
            get { return new_admin; }
            set { new_admin = value; }
        }
    }

}
