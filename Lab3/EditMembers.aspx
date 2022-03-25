<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditMembers.aspx.cs" Inherits="Lab3.EditMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Select Member to Edit"></asp:Label>
    <br />
     <asp:ListBox ID="lstEdit" runat="server" OnSelectedIndexChanged="lstEdit_SelectedIndexChanged" AutoPostBack="true"  >

    </asp:ListBox>
  <br /> 
    
     <asp:Label ID="Label2" runat="server" Text="FirstName"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    
            <br />
            <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    
            <br />
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
   
            <br />
    <asp:Label ID="Label6" runat="server" Text="GradYear"></asp:Label>
            <asp:TextBox ID="txtGradYear" runat="server"></asp:TextBox>
    
            <br />
    <asp:Label ID="Label7" runat="server" Text="JobTitle"></asp:Label>
            <asp:TextBox ID="txtJobTitle" runat="server"></asp:TextBox>
   
            <br />
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    
</asp:Content>
