using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class T_ad_team
    {

        private string post_info;
        public string Post_info
        {
            get { return post_info; }
            set { post_info = value; }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int post_num;
        public int Post_num
        {
            get { return post_num; }
            set { post_num = value; }
        }
        private DateTime post_time;
        public DateTime Post_time
        {
            get { return post_time; }
            set { post_time = value; }
        }
        private string team_name;
        public string Team_name
        {
            get { return team_name; }
            set { team_name = value; }
        }
        private string post_job;
        public string Post_job
        {
            get { return post_job; }
            set { post_job = value; }
        }
        private string post_summary;
        public string Post_summary
        {
            get { return post_summary; }
            set { post_summary = value; }
        }
        private string post_img;
        public string Post_img
        {
            get { return post_img; }
            set { post_img = value; }
        }
    }

}
