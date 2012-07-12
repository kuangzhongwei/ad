using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Model;

namespace Dal_io
{
    public class dal_user
    {
        public static T_ad_keys user_se_key()
        {
            StringBuilder str = new StringBuilder();
            string sql = "select top 1 * from t_ad_keys order by id desc";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql))
            {
                T_ad_keys model = null;
                if (dr.Read())
                {
                    model = new T_ad_keys();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Key_keys = a.normal.toString(dr["key_keys"]);
                    model.Key_back = a.normal.toString(dr["key_back"]);

                }
                dr.Close();
                dr.Dispose();
                return model;
            }
        }
        public static List<T_ad_news> user_se_news(int ShowRows, string where)
        {
            string sql = "select " + (ShowRows > 0 ? " top " + ShowRows.ToString() : "") + " a.id aid, a.type_id, new_title, new_Summary,b.type_name,new_info, new_img, new_time, new_admin, new_num from t_ad_news a  left join t_ad_type b on a.type_id=b.id  " + where + " order by a.id desc";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql))
            {
                List<T_ad_news> list = new List<T_ad_news>();
                while (dr.Read())
                {
                    T_ad_news model = new T_ad_news();
                    model.Id = a.normal.toInt(dr["aid"]);
                    model.Type_id = a.normal.toInt(dr["type_id"]);
                    model.New_title = a.normal.toString(dr["new_title"]);
                    model.New_Summary = a.normal.toString(dr["new_Summary"]);
                    model.Type_name = a.normal.toString(dr["type_name"]);
                    model.New_img = a.normal.toString(dr["new_img"]);
                    model.New_time = a.normal.toDateTime(dr["new_time"]).ToString("yyyy-MM-dd");
                    model.New_admin = a.normal.toString(dr["new_admin"]);
                    model.New_info = a.normal.toString(dr["new_info"]);
                    model.New_num = a.normal.toInt(dr["new_num"]);
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                return list;
            }
        }
        public static T_ad_img user_se_ad_img()
        {
            string sql = "select * from t_ad_img  order by id desc";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql))
            {
                T_ad_img model = null;
                while (dr.Read())
                {
                    model = new T_ad_img();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Path_img1 = a.normal.toString(dr["Path_img1"]);
                    model.Path_img2 = a.normal.toString(dr["Path_img2"]);
                    model.Path_img3 = a.normal.toString(dr["Path_img3"]);
                    model.Path_img4 = a.normal.toString(dr["Path_img4"]);
                    model.Path_img5 = a.normal.toString(dr["Path_img5"]);
                }
                dr.Close();
                dr.Dispose();
                return model;
            }
        }
    }
}
