<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet"  href="./public/css/home.css"/>
</head>
<body>
    <form class="content" id="form1" runat="server">
        <div class="nav">
            <div class="nav__main">
                <div class="nav__item active"><a href="Home.aspx">Home</a></div>
                <div class="nav__item"><a href="Attendance.aspx">Attendance</a></div>
            </div>
            <div runat="server" id="btnLogout" class="nav__item" ><a>Logout</a></div>
        </div>
        <div class="main">
            <h3 class="main__heading">Welcome 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </h3>
        </div>
    </form>
</body>
</html>
