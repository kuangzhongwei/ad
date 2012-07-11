<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ad_login.aspx.cs" Inherits="AD.admin.ad_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">/*<![CDATA[*/
			@import "css/login.css";
		/*]]>*/</style>
    <script type="text/javascript">
        function Verification() {
            var txtLoginName = document.getElementById("txtLoginName").value;
            var txtPwd = document.getElementById("txtPwd").value;
            if (txtLoginName.length < 1) {
                alert("请输入用户名");
                return false;
            }
            if (txtPwd.length < 1) {
                alert("请输入密码");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return Verification()">
    <div id="container">
		<h1>Black Admin v2</h1>
		<div id="box">
			<p class="main">
				<label>Username: </label>
                <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
				<label>Password: </label>
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
			</p>
			<p class="space">
				<span><input type="checkbox" />Remember me</span>
				<asp:Button ID="Submit" runat="server" Text="Login" class="login" 
                    onclick="Submit_Click"/>
			</p>
			
		</div>
	</div>
    </form>
</body>
</html>

