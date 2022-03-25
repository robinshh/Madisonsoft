<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Member Login Page
    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--login page for the member--%>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />
          
             <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
              <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblCreateMember" runat="server" Text="Don't have an account?"></asp:Label>
            <asp:Button ID="btnRegisterMember" runat="server" Text="Create Account" OnClick="btnRegisterMember_Click" />

        </div>
    </form>
</body>
</html>
