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
    public partial class ad_in_ad :BasePage
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
            }
        }

        protected void butsubmint_Click(object sender, EventArgs e)
        {
            T_ad_ad mo = new T_ad_ad();
            mo.Ad_name = txttitle.Text.Trim();
            mo.Ad_text = content1.InnerHtml;
            if (Radiotrue.Checked)
            {
                mo.Ad_img = img(File1);
                if (Radio1.Checked)
                {
                    mo.Ad_weizhi = "0";
                }
                else if (Radio2.Checked)
                {
                    mo.Ad_weizhi = "1";
                }
                else
                {
                    MessShowBox.show("你还没选择广告投放的位置",this);
                    return;
                }
            }
            else
            {
                mo.Ad_img = "";
            }
            if (ad_main.admin_in_ad(mo) > 0)
            {
                txttitle.Text = "";
                content1.InnerHtml = "";
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("网络链接错误,添加失败",this);
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