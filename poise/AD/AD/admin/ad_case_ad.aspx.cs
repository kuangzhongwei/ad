using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Model;
using Dal_io;
using System.IO;

namespace AD.admin
{
    public partial class ad_case_ad : BasePage
    {
        private static string tyep = "";
        private static int id = 0;
        private static string xiao = "";
        private static string da = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tyep = a.query.toString("t");
                id = a.query.toInt("aid");
                SavePageStateToPersistenceMedium("__VIEWSTATE");
                select();
                if (tyep.Equals("u"))
                {
                    bind();
                }
                else
                {
                    Image1.Visible = false;
                    Image2.Visible = false;
                }
            }
        }
        public void select()
        {
            List<T_ad_type> list = ad_main.admin_se_type();
            DropDownList1.DataSource = list;
            DropDownList1.DataTextField = "Atype_name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
        }
        public void bind()
        {
            T_ad_case model = ad_main.admin_se_case(id);
            txttitle.Text = model.Case_name;
            content1.InnerHtml = model.Post_info;
            Image1.ImageUrl = model.Post_job;
            xiao = model.Post_job;
            da = model.Post_summary;
            Image2.ImageUrl = model.Post_summary;
            string type = model.Type_id;
            string[] ty = type.Split(',');
            for (int i = 0; i < ty.Length-1; i++)
            {
                int k =a.normal.toInt(ty[i]);
                DropDownList1.Items[k-1].Selected = true;
            }
        }
        protected void butsubmint_Click(object sender, EventArgs e)
        {
            
            if (tyep.Equals("i"))
            {
                T_ad_case model = new T_ad_case();
                model.Case_name = txttitle.Text.Trim();
                if (img(File1) == "" || img(File2) == "")
                {
                    MessShowBox.show("图片不能为空", this);
                    return;
                }
                else
                {
                    model.Post_summary = img(File2);
                    model.Post_job = img(File1);
                }
                string s_v = "";
                for (int i = 0; i < DropDownList1.Items.Count; i++)
                {
                    if (DropDownList1.Items[i].Selected)
                    {
                        s_v += DropDownList1.Items[i].Value + ",";
                    }
                }
                if (s_v == "")
                {
                    MessShowBox.show("服务类型还没选择,你可以按住Ctrl键实现多选", this);
                    return;
                }
                model.Type_id = s_v;
               
                model.Post_info = content1.InnerHtml;
                if (ad_main.admin_in_case(model))
                {
                    txttitle.Text = "";
                    content1.InnerHtml = "";
                    DropDownList1.SelectedIndex = 0;
                    MessShowBox.show("添加成功", this);
                }
                else
                {
                    MessShowBox.show("网络链接错误,添加失败", this);
                }
            }
            else if (tyep.Equals("u"))
            {
                T_ad_case model = new T_ad_case();
                model.Case_name = txttitle.Text.Trim();
                string s_v = "";
                for (int i = 0; i < DropDownList1.Items.Count; i++)
                {
                    if (DropDownList1.Items[i].Selected)
                    {
                        s_v += DropDownList1.Items[i].Value + ",";
                    }
                }
                if (s_v == "")
                {
                    MessShowBox.show("服务类型还没选择,你可以按住Ctrl键实现多选", this);
                    return;
                }
                model.Type_id = s_v;
                model.Post_info = content1.InnerHtml;
                model.Id = id;
                if (File1.FileName == "" || File2.FileName == "")
                {
                   
                    model.Post_job = xiao;
                    model.Post_summary = da;
                }
                else
                {
                    File.Delete(Server.MapPath(xiao));
                    File.Delete(Server.MapPath(da));
                    model.Post_summary = img(File2);
                    model.Post_job = img(File1);
                }
                if (ad_main.admin_up_case(model))
                {
                    MessShowBox.show("修改成功", this);
                    Response.Redirect("ad_case.aspx");
                }
                else
                {
                    MessShowBox.show("网络链接失败,修改失败", this);
                }
            }
            else
            {
                Response.Redirect("ad_case.aspx");
            }
        }
        public string img(FileUpload upload)
        {
            string str = "";
            string filename = upload.FileName;
            string type = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            if (type == "jpg" || type == "bmp" || type == "gif" || type == "png")
            {
                str = "/public/user_img/" + DateTime.Now.ToString("yyyyMMddmmhhss") + "." + type;
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
        protected void butback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ad_case.aspx");
        }
    }
}