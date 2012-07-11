using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.IO;
using System.Text.RegularExpressions;
using Dal_io;

namespace AD.admin
{
    public partial class ad_in_new : BasePage
    {
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
                select();
            }
        }
        private void select()
        {
            List<T_ad_type> list = ad_main.admin_select_type();
            ddltype.DataSource = list;
            ddltype.DataTextField = "atype_name";
            ddltype.DataValueField = "id";
            ddltype.DataBind();
            ListItem item = new ListItem("", "");
            ddltype.Items.Insert(0, item);
        }
        protected void butsubmint_Click(object sender, EventArgs e)
        {
            T_ad_news model = new T_ad_news();
            model.Type_id = a.normal.toInt(ddltype.SelectedValue);
            model.New_info = Server.HtmlEncode(content1.InnerHtml);
            model.New_Summary = str();
            model.New_admin = "东方广告";
            model.New_info = content1.InnerHtml;
            model.New_title = txttitle.Text.Trim();
            if (Radiotrue.Checked)
            {
                model.New_img = img(File1);
            }
            else
            {
                model.New_img = "";
            }
            if (ad_main.admin_in_new(model) > 0)
            {
                txttitle.Text = "";
                ddltype.SelectedIndex = 0;
                content1.InnerHtml = "";
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("网络链接错,添加失败", this);
            }
        }

        protected void butback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_new.aspx");
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