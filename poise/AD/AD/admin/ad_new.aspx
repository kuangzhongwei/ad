<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_new.aspx.cs" Inherits="AD.admin.ad_new" %>
<%@ Register Assembly="Util" Namespace="Util" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .baiducss{ width:300px; height:20px; font-size:20px;}    
 </style>
 <table width="100%" border="0" cellpadding="2" cellspacing="1" align="center" style="margin-top:8px">
 <tr>
    <td colspan="10">
        <span style="font-size:25px;">
            网站信息
        </span>
        </td>
 </tr>
    <tr>
        <td style=" width:200px;">
            网站框架信息:
        </td>
        <td >
            <asp:DropDownList ID="ddltype" runat="server">
            </asp:DropDownList>
        </td>
        <td  style=" width:200px;">
             关键字查询:
        </td>
        <td >
            <asp:TextBox ID="txtkey" runat="server" Width="160px"></asp:TextBox>
        </td>
        <td  colspan="5">
            <asp:Button ID="butselect" runat="server" Text=" 查 询 " 
                onclick="butselect_Click" />
        </td>
    </tr>
           <tr>
                <th>系统编号</th>
                <th>类型</th>
                <th>标题</th>
                <th>发布时间</th>
                <th>浏览次数</th>
                <th>发布人</th>
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
               <asp:Label ID="lbl2" runat="server" Text='<%# Eval("type_name")%>'></asp:Label>
            </td>
            <td align="center">
             <a href="ad_up_new.aspx?aid=<%# Eval("id") %>" title="点击修改"><%# Eval("new_title")%></a>
           </td>
           <td align="center">
                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("new_time")%>'></asp:Label>
           </td>
           <td align="center">
                 <asp:Label ID="Label5" runat="server" Text='<%# Eval("new_num")%>'></asp:Label>
           </td>
            <td align="center">
                 <asp:Label ID="Label6" runat="server" Text='<%# Eval("new_admin")%>'></asp:Label>
           </td>
           <td>
               <asp:LinkButton ID="buttdelete" runat="server" CommandName="delete" OnClientClick="return confirm('您确定删除,删除了就无法恢复.')" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton> |
               <a href="ad_up_new.aspx?aid=<%# Eval("id") %>">修改</a>
           </td>
          </tr>
           </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="8" align="center">
                  <cc1:pager ID="Pager1" runat="server" oncommand="Pager1_Command" />
            </td>
        </tr>
    </table> 
</asp:Content>
