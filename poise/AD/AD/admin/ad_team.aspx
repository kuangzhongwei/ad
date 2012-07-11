<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_team.aspx.cs" Inherits="AD.admin.ad_team" %>
<%@ Register Assembly="Util" Namespace="Util" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .baiducss{ width:300px; height:20px; font-size:20px;}    
 </style>
 <table width="100%" border="0" cellpadding="2" cellspacing="1" align="center" style="margin-top:8px">
 <tr>
    <td colspan="6">
        <span style="font-size:25px;">
            团队信息
        </span>
        </td>
 </tr>
    <tr>
        <td  style=" width:200px;">
             关键字查询:
        </td>
        <td >
            <asp:TextBox ID="txtkey" runat="server" Width="160px"></asp:TextBox>
        </td>
        <td  colspan="4">
            <asp:Button ID="butselect" runat="server" Text=" 查 询 " 
                onclick="butselect_Click" />
        </td>
    </tr>
           <tr>
                <th>系统编号</th>
                <th>名称</th>
                <th>职位</th>
                <th>浏览数</th>
                <th>时间</th>
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
             <a href="ad_up_team.aspx?aid=<%# Eval("id") %>" title="点击修改"><%# Eval("team_name")%></a>
           </td>
           <td align="center">
                 <asp:Label ID="Label4" runat="server" Text='<%# Eval("post_job")%>'></asp:Label>
           </td>
           <td align="center">
                 <asp:Label ID="Label5" runat="server" Text='<%# Eval("post_num")%>'></asp:Label>
           </td>
            <td align="center">
                 <asp:Label ID="Label6" runat="server" Text='<%# Eval("post_time")%>'></asp:Label>
           </td>
           <td>
               <asp:LinkButton ID="buttdelete" runat="server" CommandName="delete" OnClientClick="return confirm('您确定删除,删除了就无法恢复.')" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton> |
               <a href="ad_up_team.aspx?aid=<%# Eval("id") %>">详细</a>
           </td>
          </tr>
           </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="6" align="center">
                  <cc1:pager ID="Pager1" runat="server" oncommand="Pager1_Command" />
            </td>
        </tr>
    </table> 
</asp:Content>
