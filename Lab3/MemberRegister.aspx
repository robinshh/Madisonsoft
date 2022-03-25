<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegister.aspx.cs" Inherits="Lab3.MemberRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
     
            <asp:Label ID="Label2" runat="server" Text="FirstName"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqSchName" ControlToValidate="txtFirstName" Text="(Required)" runat="server" ForeColor="HotPink" />
      <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLastName" Text="(Required)" runat="server" ForeColor="HotPink" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEmail" Text="(Required)" runat="server" ForeColor="HotPink" />
    
            <br />
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPhone" Text="(Required)" runat="server" ForeColor="HotPink" />
   
            <br />
    <asp:Label ID="Label6" runat="server" Text="GradYear"></asp:Label>
            <asp:TextBox ID="txtGradYear" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtGradYear" Text="(Required)" runat="server" ForeColor="HotPink" />
    
            <br />
    <asp:Label ID="Label7" runat="server" Text="JobTitle"></asp:Label>
            <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtJobTitle" Text="(Required)" runat="server" ForeColor="HotPink" />
   
            <br />
             <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtUsername" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
             <asp:Label ID="Label8" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtPassword" Text="(Required)" runat="server" ForeColor="HotPink" />
    
            <br />
  
            <br />

            <asp:Button ID="btnCreateMember" runat="server" Text="Create Member" OnClick="btnCreateMember_Click" />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
             <%--<asp:SqlDataSource 
        ID="sqlsrcMemberTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT FirstName + ' ' + LastName AS MemberInfo, MemberID FROM Members"> 

    </asp:SqlDataSource>--%>




        </div>
    </form>
</body>
</html>
