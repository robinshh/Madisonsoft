<%--Name: Dana El-Zoobi and Madeleine Duley and Kit Harmon
Date: 2/27/2022
File Purpose: This file is the webform for adding a scholarship--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddScholarship.aspx.cs" Inherits="Lab2.AddScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
     
            <asp:Label ID="Label2" runat="server" Text="ScholarshipName"></asp:Label>
            <asp:TextBox ID="txtScholarshipName" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqSchName" ControlToValidate="txtScholarshipName" Text="(Required)" runat="server" ForeColor="HotPink" />
    
      <asp:Label ID="lblError" runat="server" Text=""></asp:Label>  
            <br />
            <asp:Label ID="Label3" runat="server" Text="ScholarshipAmount"></asp:Label>
            <asp:TextBox ID="txtScholarshipAmount" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtScholarshipAmount" Text="(Required)" runat="server" ForeColor="HotPink" />
    
            <br />
    
    <asp:Label ID="Label5" runat="server" Text="ScholarshipYear"></asp:Label>
            <asp:TextBox ID="txtScholarshipYear" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtScholarshipYear" Text="(Required)" runat="server" ForeColor="HotPink" />
    
            <br />
    
            <br />
    <asp:ListBox ID="lstScholarship" runat="server"></asp:ListBox>
            <br />
     
    <asp:Button ID="btnAddScholarship" runat="server" Text="Add Scholarship" OnClick="btnAddScholarship_Click"/> 
   <%-- <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/> --%>
    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false"/>
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
   <%-- <asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click" />--%>

  <asp:SqlDataSource 
        ID="sqlsrcScholarshipTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT ScholarshipName,ScholarshipID FROM COMPANY"> 

    </asp:SqlDataSource>
   
     
    




</asp:Content>
