using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Model;

namespace AD.admin
{
    public partial class ad_in_img : System.Web.UI.Page
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
                bind();
                SavePageStateToPersistenceMedium("__VIEWSTATE");
            }
        }
        public void bind()
        {
            T_ad_img img= DAL.ad_main.admin_select_img();
            Image1.ImageUrl = img.Path_img1;
            Image2.ImageUrl = img.Path_img2;
            Image3.ImageUrl = img.Path_img3;
            Image4.ImageUrl = img.Path_img4;
            Image5.ImageUrl = img.Path_img5;
        }
        protected void butsubmint_Click(object sender, EventArgs e)
        {
            T_ad_img mo = new T_ad_img();
            mo.Path_img1 = img(FileUpload1, 1);
            if (DAL.ad_main.admin_in_img(mo,1) > 0)
            {
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("添加失败", this);
            }
        }
        public string img(FileUpload upload, int i)
        {
            string str = "";
            string filename = upload.FileName;
            string type = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            if (type == "jpg" || type == "bmp" || type == "gif" || type == "png")
            {
                str = "/public/img/" + i + "." + type;
                if (!File.Exists(filename))
                {
                    upload.SaveAs(MapPath(str));
                }
                else
                {
                    MessShowBox.show("文件已存在，请重命名后再上传", this);
                }
            }
            return str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            T_ad_img mo = new T_ad_img();
            mo.Path_img2 = img(FileUpload2, 2);
            if (DAL.ad_main.admin_in_img(mo,2) > 0)
            {
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("添加失败", this);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            T_ad_img mo = new T_ad_img();
            mo.Path_img3 = img(FileUpload3, 3);
            if (DAL.ad_main.admin_in_img(mo,3) > 0)
            {
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("添加失败", this);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            T_ad_img mo = new T_ad_img();
            mo.Path_img4 = img(FileUpload4, 4);
            if (DAL.ad_main.admin_in_img(mo,4) > 0)
            {
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("添加失败", this);
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            T_ad_img mo = new T_ad_img();
            mo.Path_img5 = img(FileUpload5, 5);
            if (DAL.ad_main.admin_in_img(mo,5) > 0)
            {
                MessShowBox.show("添加成功", this);
            }
            else
            {
                MessShowBox.show("添加失败", this);
            }
        }
    }
}