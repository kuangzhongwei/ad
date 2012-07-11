<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="ad_case.aspx.cs" Inherits="AD.admin.ad_case" %>
<%@ Register Assembly="Util" Namespace="Util" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellpadding="2" cellspacing="1" align="center" style="margin-top:8px">
 <tr>
    <td colspan="4">
        <span style="font-size:25px;">
            成功案例信息
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
        <td  colspan="2">
            <asp:Button ID="butselect" runat="server" Text=" 查 询 " 
                onclick="butselect_Click" />
        </td>
    </tr>
           <tr>
                <th>系统编号</th>
                <th>公司名称</th>
                <th>发布时间</th>
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
               <asp:Label ID="Label3" runat="server" Text='<%# Eval("case_name")%>'></asp:Label>
           </td>
           <td align="center">
                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("post_time")%>'></asp:Label>
           </td>
           <td>
               <asp:LinkButton ID="buttdelete" runat="server" CommandName="delete" OnClientClick="return confirm('您确定删除,删除了就无法恢复.')" CommandArgument='<%# Eval("id") %>'>删除</asp:LinkButton> |
               <a href="ad_case_ad.aspx?aid=<%# Eval("id") %>&t=u">详细</a>
           </td>
          </tr>
           </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="4" align="center">
                  <cc1:pager ID="Pager1" runat="server" oncommand="Pager1_Command" 
                      PageSize="20" />
            </td>
        </tr>
    </table> 
</asp:Content>
