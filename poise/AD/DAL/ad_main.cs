using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Data;
using Dal_io;

namespace DAL
{
    public class ad_main
    {
        #region 后台操作方法

        public static bool login(string name, string pwd)
        {
            try
            {
                string sql = "select count(*) from t_ad_user where user_name=@name and user_pwd=@pwd";
                SqlParameter[] p = new SqlParameter[]{
                  new SqlParameter("@name",name),
                  new SqlParameter("@pwd",pwd)
                };
                object obj = a.data.mssql.ExecuteScalar(0, sql, p);
                return a.normal.toInt(obj.ToString()) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<T_ad_type> admin_type_all(string tblName, string fldName, int PageSize, int PageIndex, string OrderType, string strWhere, out int Count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),					
					new SqlParameter("@strOrder", SqlDbType.VarChar,100),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Count", SqlDbType.Int),
					};
            parameters[0].Value = tblName;
            parameters[1].Value = "*";
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            List<T_ad_type> list = new List<T_ad_type>();
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[UP_PaginationAnyOrderCount]", parameters))
            {
                while (dr.Read())
                {
                    T_ad_type model = new T_ad_type();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Atype_name = a.normal.toString(dr["atype_name"]);
                    model.Btype_name = a.normal.toString(dr["atype_name"]);
                    model.Type_father_id = a.normal.toInt(dr["Type_father_id"]);
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                Count = a.normal.toInt(parameters[7].Value);
                return list;
            }
        }

        public static int admin_delete_id(int id, string table)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-table-delete-id]", new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@tabname", table) });
        }

        public static List<T_ad_type> admin_select_type()
        {
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, "select * from t_ad_type"))
            {
                List<T_ad_type> list = new List<T_ad_type>();
                while (dr.Read())
                {
                    T_ad_type model = new T_ad_type();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Atype_name = a.normal.toString(dr["type_name"]);
                    model.Type_father_id = a.normal.toInt(dr["Type_father_id"]);
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                return list;
            }
        }

        public static int admin_update_type(int id, string type_name)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-update-type-id]", new SqlParameter[] { new SqlParameter("@id", id), new SqlParameter("@type_name", type_name) });
        }

        public static List<T_ad_news> admin_new_all(string tblName, string fldName, int PageSize, int PageIndex, string OrderType, string strWhere, out int Count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),					
					new SqlParameter("@strOrder", SqlDbType.VarChar,100),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Count", SqlDbType.Int),
					};
            parameters[0].Value = tblName;
            parameters[1].Value = "*";
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[UP_PaginationAnyOrderCount]", parameters))
            {
                List<T_ad_news> list = new List<T_ad_news>();
                while (dr.Read())
                {
                    T_ad_news model = new T_ad_news();
                    model.Id = a.normal.toInt(dr["aid"]);
                    model.New_admin = a.normal.toString(dr["new_admin"]);
                    model.New_img = a.normal.toString(dr["new_img"]);
                    model.New_info = a.normal.toString(dr["new_info"]);
                    model.New_num = a.normal.toInt(dr["new_num"]);
                    model.New_Summary = a.normal.toString(dr["new_summary"]);
                    model.New_time = a.normal.toDateTime(dr["new_time"]).ToString("yyyy-MM-dd") ;
                    model.New_title = a.normal.toString(dr["new_title"]);
                    model.Type_name = a.normal.toString(dr["type_name"]);
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                Count = a.normal.toInt(parameters[7].Value);
                return list;
            }
        }

        public static int admin_in_new(T_ad_news model)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-in-new]", new SqlParameter[]{
                    new SqlParameter("@type_id",model.Type_id),
                    new SqlParameter("@title",model.New_title),
                    new SqlParameter("@summary",model.New_Summary),
                    new SqlParameter("@info",model.New_info),
                    new SqlParameter("@img",model.New_img),
                    new SqlParameter("@name",model.New_admin)
            });
        }

        public static int admin_up_new(T_ad_news model)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-up-new]", new SqlParameter[]{
                    new SqlParameter("@id",model.Id),
                    new  SqlParameter("@type_id",model.Type_id),
                    new SqlParameter("@title",model.New_title),
                    new SqlParameter("@summary",model.New_Summary),
                    new SqlParameter("@info",model.New_info),
                    new SqlParameter("@img",model.New_img),
                    new SqlParameter("@num",model.New_num)
            });
        }

        public static T_ad_news admin_sel_new_id(int id)
        {
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[p-sel-new-id]", new SqlParameter[] { new SqlParameter("@id", id) }))
            {
                T_ad_news model = null;
                while (dr.Read())
                {
                    model = new T_ad_news();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.New_img = a.normal.toString(dr["new_img"]);
                    model.New_info = a.normal.toString(dr["new_info"]);
                    model.New_num = a.normal.toInt(dr["new_num"]);
                    model.New_time = a.normal.toDateTime(dr["new_time"]).ToString("yyyy-MM-dd");
                    model.New_title = a.normal.toString(dr["new_title"]);
                    model.Type_id = a.normal.toInt(dr["type_id"]);
                }
                dr.Close();
                dr.Dispose();
                return model;

            }
        }

        public static List<T_ad_team> admin_select_team(string tblName, string fldName, int PageSize, int PageIndex, string OrderType, string strWhere, out int Count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),					
					new SqlParameter("@strOrder", SqlDbType.VarChar,100),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Count", SqlDbType.Int),
					};
            parameters[0].Value = tblName;
            parameters[1].Value = "*";
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[UP_PaginationAnyOrderCount]", parameters))
            {
                List<T_ad_team> list = new List<T_ad_team>();
                while (dr.Read())
                {
                    T_ad_team model = new T_ad_team();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Post_img = a.normal.toString(dr["post_img"]);
                    model.Post_info = a.normal.toString(dr["post_info"]);
                    model.Post_job = a.normal.toString(dr["post_job"]);
                    model.Post_num = a.normal.toInt(dr["post_num"]);
                    model.Post_summary = a.normal.toString(dr["Post_summary"]);
                    model.Post_time = a.normal.toDateTime(dr["post_time"]);
                    model.Team_name = a.normal.toString(dr["team_name"]);
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                Count = a.normal.toInt(parameters[7].Value);
                return list;
            }
        }

        public static T_ad_team admin_select_team_id(int id)
        {
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[p-sys-team-id]", new SqlParameter[] { new SqlParameter("@id", id) }))
            {
                T_ad_team model = null;
                while (dr.Read())
                {
                    model = new T_ad_team();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Post_img = a.normal.toString(dr["post_img"]);
                    model.Post_info = a.normal.toString(dr["post_info"]);
                    model.Post_job = a.normal.toString(dr["post_job"]);
                    model.Post_num = a.normal.toInt(dr["post_num"]);
                    model.Post_summary = a.normal.toString(dr["Post_summary"]);
                    model.Post_time = a.normal.toDateTime(dr["post_time"]);
                    model.Team_name = a.normal.toString(dr["team_name"]);
                }
                dr.Close();
                dr.Dispose();
                return model;
            }
        }

        public static int admin_up_team_id(T_ad_team model)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-up-team-id]", new SqlParameter[]{
                 new SqlParameter("@id",model.Id), 
                 new SqlParameter("@team_name",model.Team_name), 
                 new SqlParameter("@post_job",model.Post_job), 
                 new SqlParameter("@post_summary",model.Post_summary), 
                 new SqlParameter("@post_info",model.Post_info), 
                 new SqlParameter("@post_img",model.Post_img), 
                 new SqlParameter("@post_num",model.Post_num) 
            });
        }

        public static string admin_delete_img(int id, string filename, string tablename)
        {
            return a.normal.toString(a.data.mssql.ExecuteScalar(1, "[p-sys-delete-img]", new SqlParameter[]{
                new SqlParameter("@id",id),
                new SqlParameter("@filename",filename),
                new SqlParameter("@tablename",tablename)
            }));
        }

        public static int admin_in_team(T_ad_team model)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-in-team]", new SqlParameter[]{
                new SqlParameter("@team_name",model.Team_name),
                new SqlParameter("@post_job",model.Post_job),
                new SqlParameter("@post_summary",model.Post_summary),
                new SqlParameter("@post_info",model.Post_info),
                new SqlParameter("@post_img",model.Post_img)
            });
        }

        public static List<T_ad_ad> admin_ad_ad(string tblName, string fldName, int PageSize, int PageIndex, string OrderType, string strWhere, out int Count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),					
					new SqlParameter("@strOrder", SqlDbType.VarChar,100),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Count", SqlDbType.Int),
					};
            parameters[0].Value = tblName;
            parameters[1].Value = "*";
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[UP_PaginationAnyOrderCount]", parameters))
            {
                List<T_ad_ad> list = new List<T_ad_ad>();
                while (dr.Read())
                {
                    T_ad_ad model = new T_ad_ad();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Ad_img = a.normal.toString(dr["ad_img"]);
                    model.Ad_name = a.normal.toString(dr["ad_name"]);
                    model.Ad_text = a.normal.toString(dr["ad_text"]);
                    model.Ad_weizhi = io_io.io_weizhi(a.normal.toInt(dr["Ad_weizhi"]));
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                Count = a.normal.toInt(parameters[7].Value);
                return list;
            }
        }

        public static T_ad_ad admin_ad_id(int id)
        {
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[p-sys-ad-all]", new SqlParameter[] { new SqlParameter("@id", id) }))
            {
                T_ad_ad model = null;
                while (dr.Read())
                {
                    model = new T_ad_ad();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Ad_img = a.normal.toString(dr["ad_img"]);
                    model.Ad_name = a.normal.toString(dr["ad_name"]);
                    model.Ad_text = a.normal.toString(dr["ad_text"]);
                }
                dr.Close();
                dr.Dispose();
                return model;
            }
        }

        public static int admin_up_ad(T_ad_ad model)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-up-ad-id]", new SqlParameter[] {
                new SqlParameter("@id",model.Id),
                new SqlParameter("@ad_name",model.Ad_name),
                new SqlParameter("@ad_num",model.Ad_num),
                new SqlParameter("@ad_img",model.Ad_img),
                new SqlParameter("@ad_text",model.Ad_text)
            });
        }

        public static int admin_in_ad(T_ad_ad ad)
        {
            return a.data.mssql.ExecuteNonQuery(1, "[p-sys-in-ad]", new SqlParameter[] { 
                new SqlParameter("@ad_name",ad.Ad_name),
                new SqlParameter("@ad_text",ad.Ad_text),
                new SqlParameter("@ad_img",ad.Ad_img),
                new SqlParameter("@ad_weizhi",ad.Ad_weizhi)
            });
        }

        public static int admin_in_img(T_ad_img model, int i)
        {
            int k = 0;
            if (i == 1)
            {
                string sql = @"update  t_ad_img  set path_img1=@path_img1 where id=1";
                k = a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@path_img1", model.Path_img1) });
            }
            else if (i == 2)
            {
                string sql = @"update  t_ad_img  set path_img2=@path_img2 where id=1";
                k = a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@path_img2", model.Path_img2) });
            }
            else if (i == 3)
            {
                string sql = @"update  t_ad_img  set path_img3=@path_img3 where id=1";
                k = a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@path_img3", model.Path_img3) });
            }
            else if (i == 4)
            {
                string sql = @"update  t_ad_img  set path_img4=@path_img4 where id=1";
                k = a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@path_img4", model.Path_img4) });
            }
            else if (i == 5)
            {
                string sql = @"update  t_ad_img  set path_img5=@path_img5 where id=1";
                k = a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@path_img5", model.Path_img5) });
            }
            return k;
        }

        public static T_ad_img admin_select_img()
        {
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, "select * from t_ad_img"))
            {
                T_ad_img img = null;
                while (dr.Read())
                {
                    img = new T_ad_img();
                    img.Path_img1 = a.normal.toString(dr["Path_img1"]);
                    img.Path_img2 = a.normal.toString(dr["Path_img2"]);
                    img.Path_img3 = a.normal.toString(dr["Path_img3"]);
                    img.Path_img4 = a.normal.toString(dr["Path_img4"]);
                    img.Path_img5 = a.normal.toString(dr["Path_img5"]);
                }
                dr.Close();
                dr.Dispose();
                return img;
            }
        }

        public static List<T_ad_case> admin_select_case(string tblName, string fldName, int PageSize, int PageIndex, string OrderType, string strWhere, out int Count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),					
					new SqlParameter("@strOrder", SqlDbType.VarChar,100),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Count", SqlDbType.Int),
					};
            parameters[0].Value = tblName;
            parameters[1].Value = "*";
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[UP_PaginationAnyOrderCount]", parameters))
            {
                List<T_ad_case> list = new List<T_ad_case>();
                while (dr.Read())
                {
                    T_ad_case model = new T_ad_case();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Case_name = a.normal.toString(dr["Case_name"]);
                    model.Post_info = a.normal.toString(dr["Post_info"]);
                    model.Post_job = a.normal.toString(dr["Post_job"]);
                    model.Post_summary = a.normal.toString(dr["Post_summary"]);
                    model.Post_time = a.normal.toDateTime(dr["Post_time"]).ToString("yyyy-MM-dd");
                    model.Type_id = a.normal.toString(dr["Type_id"]);
                    list.Add(model);
                }
                dr.Close();
                dr.Dispose();
                Count = a.normal.toInt(parameters[7].Value);
                return list;
            }
        }

        public static int admin_insert_type(string name)
        {
            string sql = "insert into t_ad_type (type_name,type_father_id) values(@name,0)";
            return a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@name", name) });
        }

        public static List<T_ad_keys> admin_key(string tblName, string fldName, int PageSize, int PageIndex, string OrderType, string strWhere, out int Count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),					
					new SqlParameter("@strOrder", SqlDbType.VarChar,100),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1500),
                    new SqlParameter("@Count", SqlDbType.Int),
					};
            parameters[0].Value = tblName;
            parameters[1].Value = "*";
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(1, "[UP_PaginationAnyOrderCount]", parameters))
            {
                List<T_ad_keys> list = new List<T_ad_keys>();
                while (dr.Read())
                {
                    T_ad_keys key = new T_ad_keys();
                    key.Id = a.normal.toInt(dr["id"]);
                    key.Key_back = a.normal.toString(dr["Key_back"]);
                    key.Key_keys = a.normal.toString(dr["Key_keys"]);
                    list.Add(key);
                }
                dr.Close();
                dr.Dispose();
                Count = a.normal.toInt(parameters[7].Value);
                return list;
            }
        }

        public static int admin_in_key(string keywords, string description)
        {
            string sql = "insert into t_ad_keys (key_keys,key_back) values(@key_keys,@key_back)";
            return a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@key_keys", keywords), new SqlParameter("@key_back", description) });
        }
        public static int admin_up_key(int id, string keywords, string description)
        {
            string sql = "update t_ad_keys set key_keys=@key_keys,key_back=@key_back where id=@id";
            return a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@key_keys", keywords),
                new SqlParameter("@key_back",description), new SqlParameter("@id",id) });
        }
        public static T_ad_keys admin_se_keys(int id)
        {
            string sql = "select * from t_ad_keys where id=@id";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql, new SqlParameter[] { new SqlParameter("@id", id) }))
            {
                T_ad_keys key = null;
                while (dr.Read())
                {
                    key = new T_ad_keys();
                    key.Id = a.normal.toInt(dr["id"]);
                    key.Key_back = a.normal.toString(dr["Key_back"]);
                    key.Key_keys = a.normal.toString(dr["Key_keys"]);
                }
                dr.Close();
                dr.Dispose();
                return key;
            }
        }

        public static T_ad_case admin_se_case(int id)
        {
            string sql = "select * from t_ad_case where id=@id";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql, new SqlParameter[] { new SqlParameter("@id", id) }))
            {
                T_ad_case model = null;
                if (dr.Read())
                {
                    model = new T_ad_case();
                    model.Id = a.normal.toInt(dr["id"]);
                    model.Post_info = a.normal.toString(dr["Post_info"]);
                    model.Post_job = a.normal.toString(dr["Post_job"]);
                    model.Post_summary = a.normal.toString(dr["Post_summary"]);
                    model.Post_time = a.normal.toDateTime(dr["Post_time"]).ToString("yyyy-MM-dd");
                    model.Type_id = a.normal.toString(dr["Type_id"]);
                    model.Case_name = a.normal.toString(dr["Case_name"]);
                }
                dr.Close();
                dr.Dispose();
                return model;
            }
        }
        public static List<T_ad_type> admin_se_type()
        {
            string sql = "select * from t_type";
            using (SqlDataReader dr = a.data.mssql.ExecuteReader(0, sql))
            {
                List<T_ad_type> list = new List<T_ad_type>();
                while (dr.Read())
                {
                    T_ad_type type = new T_ad_type();
                    type.Id = a.normal.toInt(dr["id"]);
                    type.Atype_name = a.normal.toString(dr["type_name"]);
                    list.Add(type);
                }
                dr.Close();
                dr.Dispose();
                return list;
            }
        }
        public static bool admin_type_id(string name)
        {
            string sql = "insert into t_type (type_name) values(@type_name)";
            return a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[] { new SqlParameter("@type_name", name) }) > 0;
        }
        public static bool admin_in_case(T_ad_case model)
        {
            string sql = "insert into t_ad_case (type_id,case_name,post_job,post_summary,post_info,post_time) values(@type_id,@case_name,@post_job,@post_summary,@post_info,default)";
            return a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[]{
                new SqlParameter("@type_id",model.Type_id),
                new SqlParameter("@case_name",model.Case_name),
                new SqlParameter("@post_job",model.Post_job),
                new SqlParameter("@post_summary",model.Post_summary),
                new SqlParameter("@post_info",model.Post_info)
            }) > 0;
        }
        public static bool admin_up_case(T_ad_case model)
        {
            string sql = "update t_ad_case set type_id=@type_id,case_name=@case_name,post_job=@post_job,post_summary=@post_summary,post_info=@post_info,post_time=getdate() where id=@id";
            return a.data.mssql.ExecuteNonQuery(0, sql, new SqlParameter[]{
                new SqlParameter("@type_id",model.Type_id),
                new SqlParameter("@case_name",model.Case_name),
                new SqlParameter("@post_job",model.Post_job),
                new SqlParameter("@post_summary",model.Post_summary),
                new SqlParameter("@post_info",model.Post_info),
                new SqlParameter("@id",model.Id)
            }) > 0;
        }
        #endregion
    }
}
