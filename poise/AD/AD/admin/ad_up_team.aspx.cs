using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Text.RegularExpressions;
using System.IO;
using Dal_io;

namespace AD.admin
{
    public partial class ad_up_team : BasePage
    {
        private static string path = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            a.Users user = new a.Users("login");
            if (user.get("loginname") == "")
            {
                Response.Redirect("ad_login.aspx");
            }
            if (!IsPostBack)
            {
                SavePageStateToPersistenceMedium("__VIEWSTATE");
                bind();
            }
        }
        private void bind()
        {
            int id = a.query.toInt("aid");
            T_ad_team model = ad_main.admin_select_team_id(id);
            txtjob.Text = a.normal.toString(model.Post_job);
            txtname.Text = a.normal.toString(model.Team_name);
            path = model.Post_img;
            txtnum.Text = a.normal.toString(model.Post_num);
            Image1.ImageUrl = a.normal.toString(model.Post_img);
            content1.InnerHtml = a.normal.toString(model.Post_info);
        }

        protected void butback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_team.aspx");
        }

        protected void butsubmint_Click(object sender, EventArgs e)
        {
            T_ad_team model = new T_ad_team();
            model.Id = a.query.toInt("aid");
            if (File1.FileName == "")
            {
                model.Post_img = path;
            }
            else
            {
                if (path != "")
                {
                    File.Delete(Server.MapPath(path));
                }
                model.Post_img = img(File1);
            }
            model.Post_info = a.normal.toString(content1.InnerHtml);
            model.Post_job = a.normal.toString(txtjob.Text.Trim());
            model.Post_num = a.normal.toInt(txtnum.Text.Trim());
            model.Post_summary = str();
            model.Team_name = a.normal.toString(txtname.Text.Trim());
            if (ad_main.admin_up_team_id(model) > 0)
            {
                txtname.Text = "";
                txtnum.Text = "";
                txtjob.Text = "";
                content1.InnerHtml = "";
                MessShowBox.show("修改成功", this);
                Response.Redirect("ad_team.aspx");
            }
            else
            {
                MessShowBox.show("网络链接错误,修改失败", this);
            }
          
        }
        public string img(FileUpload upload)
        {
            string str = "";
            string filename = upload.FileName;
            if (filename.Equals(""))
            {
                MessShowBox.show("图片不能为空", this);
            }
            else
            {
                string type = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                if (type == "jpg" || type == "bmp" || type == "gif" || type == "png")
                {
                    str = "/public/user_img/" + DateTime.Now.ToString("yyyyMMddhhmmss") + filename;
                    if (!File.Exists(filename))
                    {
                        upload.SaveAs(MapPath(str));
                    }
                    else
                    {
                        MessShowBox.show("文件已存在，请重命名后再上传", this);
                    }
                }
                else
                {
                    MessShowBox.show("上传的图片个是不正确,图片格式必须是|jpg|bmp|gif|png", this);
                }
            }
            return str;
        }
        public string str()
        {
            string Htmlstring = content1.InnerText;
            //删除脚本 
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML 
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            if (Htmlstring.Length > 50)
            {
                return Htmlstring.Substring(0, 32);
            }
            else
            {
                return Htmlstring;
            }
        }
    }
}