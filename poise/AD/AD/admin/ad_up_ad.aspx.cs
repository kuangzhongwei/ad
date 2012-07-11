using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.IO;
using Dal_io;

namespace AD.admin
{
    public partial class ad_up_ad : BasePage
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
                bind();
            }
        }
        private void bind()
        {
            int id = a.query.toInt("aid");
            T_ad_ad ad = ad_main.admin_ad_id(id);
            txtnum.Text = ad.Ad_num.ToString();
            txttitle.Text = a.normal.toString(ad.Ad_name);
            content1.InnerHtml = a.normal.toString(ad.Ad_text);
            if (ad.Ad_img == "")
            {
                Image1.Visible = false;
                Radiotrue.Checked = false;
            }
            else
            {
                if (ad.Ad_weizhi != "" || ad.Ad_weizhi != null)
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = ad.Ad_img;
                    Radiotrue.Checked = true;
                }
               
            }
        }
        protected void butsubmint_Click(object sender, EventArgs e)
        {
            T_ad_ad ad = new T_ad_ad();
            ad.Id = a.query.toInt("aid");
            ad.Ad_num = a.normal.toInt(txtnum.Text.Trim());
            ad.Ad_name = a.normal.toString(txttitle.Text.Trim());
            ad.Ad_text = a.normal.toString(content1.InnerHtml);
            if (Radiotrue.Checked)
            {
                ad.Ad_img = img(File1);
            }
            else
            {
                ad.Ad_img = "";
            }
            if (ad_main.admin_up_ad(ad) > 0)
            {
                Response.Redirect("ad_ad.aspx");
            }
            else
            {
                MessShowBox.show("网络链接错误,修改失败",this);
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
        protected void butback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_ad.aspx");
        }
    }
}