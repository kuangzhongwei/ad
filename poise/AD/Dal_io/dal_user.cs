using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Dal_io
{
    public class dal_user
    {
        /// <summary>
        /// 设置接收的容器
        /// </summary>
        public string TemplateRows = "";
        public int top = 0;
        public int ShowRows = 0;
        public string where = " 1=1 ";
        public int TitleMaxLength = 0;
        public string user_se_key()
        {
            StringBuilder str = new StringBuilder();
            string sql = "select top 1 * from t_ad_keys order by id desc";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql))
            {
                if (dr.Read())
                {
                    int id = a.normal.toInt(dr["id"]);
                    string keywords = a.normal.toString(dr["key_keys"]);
                    string description = a.normal.toString(dr["key_back"]);
                    str.Append(TemplateRows.Replace("{ID}", id.ToString())).Replace("{KEYWORDS}", keywords).Replace("{DESCRIPTION}", description);
                }
                dr.Close();
                dr.Dispose();
                return str.ToString();
            }
        }
        public string user_se_news()
        {
            StringBuilder str = new StringBuilder();
            string sql = "select " + (ShowRows > 0 ? " top " + ShowRows.ToString() : "") + " a.id aid, a.type_id, new_title, new_Summary,b.type_name,new_info, new_img, new_time, new_admin, new_num from t_ad_news a  left join t_ad_type b on a.type_id=b.id  " + where + " order by a.id desc";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql))
            {
                if (dr.Read())
                {
                    int id = a.normal.toInt(dr["aid"]);
                    int type_id = a.normal.toInt(dr["type_id"]);
                    string title = a.normal.toString(dr["new_title"]);
                    string summary = a.normal.toString(dr["new_Summary"]);
                    string type_name = a.normal.toString(dr["type_name"]);
                    string new_img = a.normal.toString(dr["new_img"]);
                    string new_time = a.normal.toDateTime(dr["new_time"]).ToString("yyyy-MM-dd");
                    string new_admin = a.normal.toString(dr["new_admin"]);
                    string new_info =a.normal.toString(dr["new_info"]);
                    int new_num = a.normal.toInt(dr["new_num"]);
                    if (TitleMaxLength > 0)
                    {
                        summary = summary.Substring(0, 140);
                    }
                    str.Append(TemplateRows.Replace("{ID}", id.ToString())).Replace("{TYPE_ID}", type_id.ToString()).Replace("{TITLE}", title).Replace("{NEW_INFO}", new_info.ToString()).Replace("{SUMMARY}", summary).Replace("{TYPE_NAME}", type_name).Replace("{NEW_IMG}", new_img).Replace("{NEW_ADMIN}", new_admin).Replace("{NEW_NUM}", new_num.ToString());
                }
                dr.Close();
                dr.Dispose();
                return str.ToString();
            }
        }
    }
}
