<%--Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
Date: 2/27/2022
File Purpose: This file is the webform for adding a member--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddMember.aspx.cs" Inherits="Lab2.AddMember" %>
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
    <asp:Label ID="Label7" runat="server" Text="JobTitle"></asp:Label>
            <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtJobTitle" Text="(Required)" runat="server" ForeColor="HotPink" />
   
            <br />
    
            <br />
    <asp:ListBox ID="lstMembersDynamic" runat="server"></asp:ListBox>
            <br />
     
    <asp:Button ID="btnAddmember" runat="server" Text="Add Member" OnClick="btnAddmember_Click" /> 
    <%--<asp:Button ID="btnSave" runat="server" Text="Save" /> --%>
    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
   <%-- <asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click"/>--%>
  <asp:SqlDataSource 
        ID="sqlsrcMemberTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT FirstName + ' ' + LastName AS MemberInfo, MemberID FROM Members"> 

    </asp:SqlDataSource>




</asp:Content>
