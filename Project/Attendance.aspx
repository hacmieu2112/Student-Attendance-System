<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="Project.Attendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance</title>
    <link rel="stylesheet"  href="./public/css/home.css"/>
</head>
<body>
    <form class="content" id="form1" runat="server">
         <div class="nav">
            <div class="nav__main">
                <div class="nav__item"><a href="Home.aspx">Home</a></div>
                <div class="nav__item active"><a href="Attendance.aspx">Attendance</a></div>
            </div>
            <div runat="server" id="btnLogout" class="nav__item" ><a>Logout</a></div>
        </div>
        <div class="main">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="297px">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="216px">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" CssClass="attTable">
            </asp:GridView>
            <br />
            <br />
            <br />
            <br />
        </div>

    </form>
</body>
</html>
