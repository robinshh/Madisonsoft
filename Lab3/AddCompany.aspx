<%--Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
Date: 2/27/2022
File Purpose: This file is our webform for adding a company--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="Lab2.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
     
            <asp:Label ID="Label2" runat="server" Text="CompanyName"></asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqSchName" ControlToValidate="txtCompanyName" Text="(Required)" runat="server" ForeColor="HotPink" />
     <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <br />
            <asp:Label ID="Label3" runat="server" Text="CompanyAddress"></asp:Label>
            <asp:TextBox ID="txtCompanyAddress" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCompanyAddress" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPhone" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    
            <br />
    <asp:ListBox ID="lstCompanies" runat="server"></asp:ListBox>
            <br />
     
    <asp:Button ID="btnAddCompany" runat="server" Text="Add Company" OnClick="btnAddCompany_Click"/> 
   <%-- <asp:Button ID="btnSave" runat="server" Text="Save" /> --%>
    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
    <%--<asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click" />--%>
  <asp:SqlDataSource 
        ID="sqlsrcCompanyTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT CompanyName,CompanyID FROM COMPANY"> 

    </asp:SqlDataSource>





</asp:Content>
