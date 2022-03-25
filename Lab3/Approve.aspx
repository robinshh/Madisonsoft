<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="Lab3.Approve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <asp:Label ID="Label1" runat="server" Text="Unapproved Members: "></asp:Label>
    <br />
        <asp:DropDownList
           
            ID="ddlMemberUnapprovedList"
            runat="server"
            DataSourceID="dtasrcMemberList"
            DataTextField="Username"
            DataValueField="Pass"
            AutopostBack="true" ></asp:DropDownList>
   



     <asp:SqlDataSource 
        ID="dtasrcMemberList"
        runat="server"
       ConnectionString ="<%$ ConnectionStrings:AUTH %>"
         SelectCommand ="select Username,Pass from UnapprovedCredentials">

    </asp:SqlDataSource>


    
    
    <asp:Button ID="btnAllow" runat="server" Text="Approve Member" OnClick="btnAllow_Click" />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
    <br />
     <asp:Label ID="Label2" runat="server" Text="Unapproved Students: "></asp:Label>
    <br />
        <asp:DropDownList
           
            ID="ddlStudentUnapprovedList"
            runat="server"
            DataSourceID="dtasrcStudentList"
            DataTextField="Username"
            DataValueField="Pass"
            AutopostBack="true" ></asp:DropDownList>


     <asp:SqlDataSource 
        ID="dtasrcStudentList"
        runat="server"
       ConnectionString ="<%$ ConnectionStrings:AUTH %>"
         SelectCommand ="select Username,Pass from UnapprovedStudents">

    </asp:SqlDataSource>
     <asp:Button ID="btnAllowS" runat="server" Text="Approve Student" OnClick="btnAllowS_Click" />
    <asp:Label ID="lblError2" runat="server" Text=""></asp:Label>

</asp:Content>
