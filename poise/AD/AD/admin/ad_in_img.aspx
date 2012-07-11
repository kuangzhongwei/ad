<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_in_img.aspx.cs" Inherits="AD.admin.ad_in_img" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#D1DDAA"
        style="margin-top: 8px">
        <tr>
            <td colspan="2">
               <span style=" font-size:20px;">首页轮播图片</span>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                图片路径1:
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="FileUpload1" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
                <asp:FileUpload ID="FileUpload1" Width="400px" runat="server" />
                (940*400)
                <asp:Button ID="butsubmint" runat="server" Text=" 上传一 " 
                    onclick="butsubmint_Click" ValidationGroup="1" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
               &nbsp; <asp:Image ID="Image1" Width="200px" Height="100px" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                图片路径2:
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="FileUpload2" ErrorMessage="*" ValidationGroup="2"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
                <asp:FileUpload ID="FileUpload2" Width="400px" runat="server" />
                (940*400)<asp:Button ID="Button1" runat="server" Text="上传二" 
                    onclick="Button1_Click" ValidationGroup="2" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
               &nbsp; <asp:Image ID="Image2" Width="200px" Height="100px" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                图片路径3:
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="FileUpload3" ErrorMessage="*" ValidationGroup="3"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
                <asp:FileUpload ID="FileUpload3" Width="400px" runat="server" />
                (940*400)<asp:Button ID="Button2" runat="server" Text="上传三" 
                    onclick="Button2_Click" ValidationGroup="3" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
               &nbsp; <asp:Image ID="Image3" Width="200px" Height="100px" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                图片路径4:
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="FileUpload4" ErrorMessage="*" ValidationGroup="4"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
                <asp:FileUpload ID="FileUpload4" Width="400px" runat="server" />
                (940*400)<asp:Button ID="Button3" runat="server" Text="上传四" 
                    onclick="Button3_Click" ValidationGroup="4" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
               &nbsp; <asp:Image ID="Image4" Width="200px" Height="100px" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                图片路径5:
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="FileUpload5" ErrorMessage="*" ValidationGroup="5"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;
                <asp:FileUpload ID="FileUpload5" Width="400px" runat="server" />
                (940*400)<asp:Button ID="Button4" runat="server" Text="上传五" 
                    onclick="Button4_Click" ValidationGroup="5" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
              &nbsp;  <asp:Image ID="Image5" Width="200px" Height="100px" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
