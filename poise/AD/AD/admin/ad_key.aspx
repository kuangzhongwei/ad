<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_key.aspx.cs" Inherits="AD.admin.ad_key" %>
<%@ Register Assembly="Util" Namespace="Util" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellpadding="2" cellspacing="1" align="center" style="margin-top:8px">
 <tr>
    <td colspan="4">
        <span style="font-size:25px;">
            关键字管理
        </span>
        </td>
 </tr>
           <tr>
                <th>系统编号</th>
                <th>keywords</th>
                <th>description</th>
                <th>操作</th>
           </tr>
         <asp:Repeater ID="rptUser" runat="server" 
         onitemcommand="rptUser_ItemCommand">
          <ItemTemplate>
            <tr onmouseover="this.style.backgroundColor='FloralWhite'" onmouseout="this.style.backgroundColor='' ">
            <td align="center">
                <asp:Label ID="lbl1" runat="server" Text='<%# Eval("id")%>'></asp:Label>
            </td>
           <td align="center">
                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("key_keys")%>'></asp:Label>
           </td>
            <td align="center">
                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("key_back")%>'></asp:Label>
           </td>
           <td>
               <asp:LinkButton ID="buttdelete" runat="server" CommandName="delete" OnClientClick="return confirm('您确定删除,删除了就无法恢复.')" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton> |
               <a href="ad_in_key.aspx?aid=<%# Eval("id") %>&t=u">详细</a>
           </td>
          </tr>
           </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="4" align="center">
                  <cc1:pager ID="Pager1" runat="server" oncommand="Pager1_Command" />
            </td>
        </tr>
    </table> 
</asp:Content>
