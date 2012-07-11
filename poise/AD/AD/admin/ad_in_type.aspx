<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_in_type.aspx.cs" Inherits="AD.admin.ad_in_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#D1DDAA"
        style="margin-top: 8px">
        <tr>
            <td colspan="4">
               <span style=" font-size:20px;">框架信息添加</span>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; width: 100px;">
                框架名称:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txttitle"
                    Text="*" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txttitle" Width="450px" runat="server"></asp:TextBox>
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
