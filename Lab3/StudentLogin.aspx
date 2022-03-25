<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentLogin.aspx.cs" Inherits="Lab2.StudentLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="lblUser" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLog" runat="server" Text="Login" OnClick="btnLog_Click" />
            <br />
            <br />
            <asp:Label ID="lblStat" runat="server" Text="Please login to continue"></asp:Label>

            <br />
            <br />
            <asp:Label ID="lblCreateStudent" runat="server" Text="Don't have an account?"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnRegisterStudent" runat="server" Text="Create Account" OnClick="btnRegisterStudent_Click" />
        </div>
    </form>
</body>
</html>
