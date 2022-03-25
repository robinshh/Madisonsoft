<%--
Date: 2/27/2022
    Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
File Purpose: This file is the webform for the company home page--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CompanyHomePage.aspx.cs" Inherits="Lab2.CompanyHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dana El-Zoobi & Madeleine Duley
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
    
    <br />  
    
    <br />
    <asp:Button ID="btnAddCompany" runat="server" Text="Add New Company" OnClick="btnAddCompany_Click" />
    
    <br />

    <fieldset> 
<legend> Select Company to View Details</legend>
        <asp:DropDownList 
            ID="ddlCompanyList"
            runat="server"
            DataSourceID="dtasrcCompanyList"
            DataTextField="CompanyName"
            DataValueField="CompanyID"
            AutopostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnLoadCompanyData" runat="server" Text="Show Company" OnClick="btnLoadCompanyData_Click" />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Companies" OnClick="btnShowAll_Click" />

    </fieldset>
    <br />
    <fieldset>
<legend> Information for Selected Company</legend>
        <asp:GridView 
            runat="server"
           ID="grdCompanyResults"
            AlternatingRowStyle-BackColor="#eaaaff"
            EmptyDataText="No Company Selected!"
             
           
            ></asp:GridView>

    </fieldset>
    <asp:SqlDataSource 
        ID="dtasrcCompanyList"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT CompanyName,CompanyID FROM Company"
        UpdateCommand="UPDATE Company SET CompanyName=@CompanyName, CompanyAddress=@CompanyAddress, Phone=@Phone WHERE CompanyID=@CompanyID"> 
        <UpdateParameters>
    <asp:Parameter Type="String" Name="CompanyID" />
    <asp:Parameter Type="String" Name="CompanyName" />
    <asp:Parameter Type="String" Name="CompanyAddress" />
    <asp:Parameter Type="String" Name="Phone" />
   

</UpdateParameters>
    </asp:SqlDataSource>

  

    <asp:DetailsView 
        ID="dtlCompany" DataSourceID ="srcCompany" DataKeyNames="CompanyID" AllowPaging="true" AutoGenerateRows="false" runat="server">
<Fields>
    <asp:BoundField DataField="CompanyID" HeaderText="CompanyID:" ReadOnly="true" InsertVisible="false" Visible="false" />
   <asp:BoundField DataField="CompanyName" HeaderText="Company Name:" />
    <asp:BoundField DataField="CompanyAddress" HeaderText="Company Address:" />
    
    <asp:BoundField DataField="Phone" HeaderText="Phone:" />
    
    

</Fields>
    </asp:DetailsView>
    <asp:SqlDataSource 
        ID="srcCompany"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
       SelectCommand ="SELECT * FROM Company"
        UpdateCommand="UPDATE Company SET CompanyName=@CompanyName, CompanyAddress=@CompanyAddress, Phone=@Phone WHERE CompanyID=@CompanyID"> 
         <UpdateParameters>
    <asp:Parameter Type="String" Name="CompanyID" />
    <asp:Parameter Type="String" Name="CompanyName" />
    <asp:Parameter Type="String" Name="CompanyAddress" />
    <asp:Parameter Type="String" Name="Phone" />
   

</UpdateParameters>
    </asp:SqlDataSource>



<br />
     <asp:Label ID="lbl" runat="server" Text="Select Company to Edit"></asp:Label>
     <br />
    <asp:ListBox ID="lstCompanies" runat="server" OnSelectedIndexChanged="lstCompanies_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <br />
     
            <asp:Label ID="Label2" runat="server" Text="CompanyName"></asp:Label>
            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
    <br />
            <asp:Label ID="Label3" runat="server" Text="CompanyAddress"></asp:Label>
            <asp:TextBox ID="txtCompanyAddress" runat="server"></asp:TextBox>
            <br />
    
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
     <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    
    
           
     







</asp:Content>
