
<%--
Date: 2/27/2022
    Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
File Purpose: This file is the webform for adding a user--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Lab2.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <asp:Label ID="Label7" runat="server" Text="Major"></asp:Label>
            <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtMajor" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    <asp:Label ID="Label8" runat="server" Text="InternshipStatus"></asp:Label>
            <asp:TextBox ID="txtInternshipStatus" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtInternshipStatus" Text="(Required)" runat="server" ForeColor="HotPink" />
   
            <br />
    <asp:Label ID="Label9" runat="server" Text="EmploymentStatus"></asp:Label>
            <asp:TextBox ID="txtEmploymentStatus" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtEmploymentStatus" Text="(Required)" runat="server" ForeColor="HotPink" />
  
            <br />
    
            <br />
    <asp:ListBox ID="lstUsersDynamic" runat="server"></asp:ListBox>
            <br />
     
    <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" />
  <%-- <asp:Button ID="btnSave" runat="server" Text="Save" OnClick ="btnSave_Click" /> --%>
    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
<%--    <asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click"/>--%>

    <asp:SqlDataSource 
        ID="sqlsrcStudentTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT FirstName + ' ' + LastName AS StudentInfo, StudentID FROM Students"> 

    </asp:SqlDataSource>



</asp:Content>
