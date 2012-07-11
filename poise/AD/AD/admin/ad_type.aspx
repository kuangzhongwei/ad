<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_type.aspx.cs" Inherits="AD.admin.ad_type" %>
<%@ Register Assembly="Util" Namespace="Util" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .baiducss{ width:300px; height:20px; font-size:20px;}    
 </style>
 <table width="100%" border="0" cellpadding="2" cellspacing="1" align="center" style="margin-top:8px">
    <tr>
        <td colspan="5"><span style="font-size:25px;">
            网站整体框架结构
        </span></td>
    </tr>
           <tr>
                <th>系统编号</th>
                <th>框架名称</th>
                <th>父级编号</th>
                <th>父级名称</th>
                <th>操作</th>
           </tr>
         <asp:Repeater ID="rptUser" runat="server" onitemcommand="rptUser_ItemCommand" 
               onitemdatabound="rptUser_ItemDataBound">
          <ItemTemplate>
            <asp:Panel ID="plItem" runat="server">
            <tr onmouseover="this.style.backgroundColor='FloralWhite'" onmouseout="this.style.backgroundColor='' ">
            <td align="center">
                <asp:Label ID="lbl1" runat="server" Text='<%# Eval("id")%>'></asp:Label>
            </td>
            <td align="center">
               <asp:Label ID="lbl2" runat="server" Text='<%# Eval("atype_name")%>'></asp:Label>
            </td>
            <td align="center">
             <asp:Label ID="Label2" runat="server" Text='<%# Eval("type_father_id")%>'></asp:Label>
           </td>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("btype_name")%>'></asp:Label>
           </td>
            <td align="center">
                <asp:LinkButton runat="server" ID="lbtEdit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'
                     CommandName="Edit" Text="编辑"></asp:LinkButton> |
                <asp:LinkButton ID="butdelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("id") %>' OnClientClick="return confirm('您确定删除嘛??')">删除</asp:LinkButton>
            </td>
          </tr>
         </asp:Panel>
            <asp:Panel ID="plEdit" runat="server">
            <tr  bgcolor="#E7E7E7" onmouseover="this.style.backgroundColor='FloralWhite'" onmouseout="this.style.backgroundColor='' ">
            <td align="center">
               <asp:Label ID="lbl5" runat="server" Text='<%# Eval("id")%>'></asp:Label>
           </td>
           <td align="center">
               <asp:TextBox ID="txttype" Text='<%#Eval("atype_name") %>' runat="server"></asp:TextBox>
            </td>
            <td align="center">
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("type_father_id")%>'></asp:Label>
            </td>
            <td align="center">
             <asp:Label ID="Label4" runat="server" Text='<%# Eval("btype_name")%>'></asp:Label>
               
           </td>
            <td align="center">
               <asp:LinkButton runat="server" ID="lbtUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'
               CommandName="Update" Text="更新"></asp:LinkButton> &nbsp;
                  <asp:LinkButton runat="server"  ID="lbtCancel" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'
              CommandName="Cancel" Text="取消" CausesValidation="False"></asp:LinkButton>
            </td>
           </tr>
            </asp:Panel>
           </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="5" align="center">
                  <cc1:Pager ID="Pager1" runat="server" oncommand="Pager1_Command" />
            </td>
        </tr>
    </table> 
</asp:Content>
