using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class T_ad_case
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
        private string type_id;
        public string Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }
        private string post_time;
        public string Post_time
        {
            get { return post_time; }
            set { post_time = value; }
        }
        private string case_name;
        public string Case_name
        {
            get { return case_name; }
            set { case_name = value; }
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
        private string type_name;

        public string Type_name
        {
            get { return type_name; }
            set { type_name = value; }
        }
    }
	
}
