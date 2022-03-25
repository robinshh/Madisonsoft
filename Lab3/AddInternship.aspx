<%--Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
Date: 2/27/2022
File Purpose: This file is the webform for adding an internship--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddInternship.aspx.cs" Inherits="Lab2.AddInternship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     
            <asp:Label ID="Label2" runat="server" Text="InternshipName"></asp:Label>
            <asp:TextBox ID="txtInternshipName" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqSchName" ControlToValidate="txtInternshipName" Text="(Required)" runat="server" ForeColor="HotPink" />
      <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="InternshipYear"></asp:Label>
            <asp:TextBox ID="txtInternshipYear" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtInternshipYear" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    
    <asp:Label ID="Label5" runat="server" Text="InternshipDateStart"></asp:Label>
            <asp:TextBox ID="txtInternshipDateStart" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtInternshipDateStart" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    <asp:Label ID="Label1" runat="server" Text="InternshipDateEnd"></asp:Label>
            <asp:TextBox ID="txtInternshipDateEnd" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtInternshipDateEnd" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    <asp:ListBox ID="lstInternships" runat="server"></asp:ListBox>
            <br />

    <asp:Button ID="btnAddInternship" runat="server" Text="Add Internship" OnClick="btnAddInternship_Click"/> 
    <%--<asp:Button ID="btnSave" runat="server" Text="Save" />--%> 
    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false"/>
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
   <%-- <asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click" />--%>
  <asp:SqlDataSource 
        ID="sqlsrcInternshipTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT InternshipName,InternshipID FROM Internships"> 

    </asp:SqlDataSource>







</asp:Content>
