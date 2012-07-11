<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_up_team.aspx.cs" Inherits="AD.admin.ad_up_team" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="../plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="../kindeditor.js" type="text/javascript"></script>
    <script src="../lang/zh_CN.js" type="text/javascript"></script>
    <script src="../plugins/code/prettify.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#ContentPlaceHolder1_content1', {
                cssPath: '/plugins/code/prettify.css',
                uploadJson: '/admin/upload_json.ashx',
                fileManagerJson: '/admin/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_Radiotrue").click(function () {
                $("#ContentPlaceHolder1_File1").attr("readonly", false);
            });
            $("#ContentPlaceHolder1_Radiofalse").click(function () {
                $("#ContentPlaceHolder1_File1").attr("readonly", true);
            });
        });
    </script>
    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#D1DDAA"
        style="margin-top: 8px">
        <tr>
            <td colspan="4">
               <span style=" font-size:20px;">信息修改</span>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                名称:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtname"
                    Text="*" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtname" Width="200px" runat="server"></asp:TextBox>
            </td>
            <tr>
                <td style="text-align: center;">
                    职位<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtjob"
                        Text="*" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtjob" Width="200px" runat="server"></asp:TextBox>
                </td>
            </tr>
        </tr>
        <tr>
            <td style="text-align: center;">浏览数:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtnum"
                 Text="*" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td>
                <asp:TextBox ID="txtnum" onkeyup="if(isNaN(value))execCommand('undo')" onafterpaste="if(isNaN(value))execCommand('undo')" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                图片路径:
            </td>
            <td>
                <asp:FileUpload ID="File1" Width="400px" runat="server" />
                <asp:Image ID="Image1" Width="120px" Height="80px" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; vertical-align: top;">
                正文介绍:
            </td>
            <td>
                <textarea id="content1" style="width: 90%; height:500px;  visibility: hidden;" name="content1"
                    runat="server"></textarea>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="butsubmint" runat="server" Text=" 确 定 " 
                    onclick="butsubmint_Click" />
                <asp:Button ID="butback" runat="server" Text=" 返 回 " onclick="butback_Click" 
                    CausesValidation="False" />
            </td>
        </tr>
    </table>
</asp:Content>
