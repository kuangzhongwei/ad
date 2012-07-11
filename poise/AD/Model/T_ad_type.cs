using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class T_ad_type
    {

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int type_father_id;
        public int Type_father_id
        {
            get { return type_father_id; }
            set { type_father_id = value; }
        }
        private string atype_name;
        public string Atype_name
        {
            get { return atype_name; }
            set { atype_name = value; }
        }
        private string btype_name;
        public string Btype_name
        {
            get { return btype_name; }
            set { btype_name = value; }
        }
    }

}
