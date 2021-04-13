<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet"  href="./public/css/login.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 414px">
            <asp:Panel ID="Panel1" runat="server" Height="253px" style="margin-left: 497px; margin-top: 57px" Width="540px">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtUsername" runat="server" Height="23px" Width="346px"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" Height="23px" Width="342px"></asp:TextBox>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="Login" Width="93px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
