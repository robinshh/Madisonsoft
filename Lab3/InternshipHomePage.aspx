<%--
Date: 2/27/2022
    Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
File Purpose: This file is the webform for the internship home page--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InternshipHomePage.aspx.cs" Inherits="Lab2.InternshipHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dana El-Zoobi & Madeleine Duley
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    
    <br />
    <asp:Button ID="btnAddInternship" runat="server" Text="Add Internship" OnClick="btnAddInternship_Click" />
    <asp:Button ID="btnAward" runat="server" Text="Award Internship" OnClick="btnAward_Click"/>
   
    <br />

    <fieldset> 
<legend> Select Internship to View Details</legend>
        <asp:DropDownList 
            ID="ddlInternshipList"
            runat="server"
            DataSourceID="dtasrcInternshipList"
            DataTextField="InternshipName"
            DataValueField="InternshipID"
            AutopostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnLoadInternshipData" runat="server" Text="Show Internship" OnClick="btnLoadInternshipData_Click"/>
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Internships" OnClick="btnShowAll_Click"/>

    </fieldset>
    <br />
    <fieldset>
<legend> Information for Selected Internship</legend>
        <asp:GridView 
            runat="server"
           ID="grdInternshipResults"
            AlternatingRowStyle-BackColor="#eaaaff"
            EmptyDataText="No Internship Selected!"
             
           
            ></asp:GridView>

    </fieldset>
    <asp:SqlDataSource 
        ID="dtasrcInternshipList"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT InternshipName, InternshipID FROM Internships"
        UpdateCommand="UPDATE Internships SET InternshipName=@InternshipName, InternshipYear=@InternshipYear, DateStart=@DateStart, DateEnd=@DateEnd WHERE InternshipID=@InternshipID"> 
         <UpdateParameters>
    <asp:Parameter Type="String" Name="InternshipID" />
    <asp:Parameter Type="String" Name="InternshipName" />
    <asp:Parameter Type="String" Name="InternshipYear" />
    <asp:Parameter Type="String" Name="DateStart" />
    <asp:Parameter Type="String" Name="DateEnd" />
    

</UpdateParameters>
    </asp:SqlDataSource>

  

    <asp:DetailsView 
        ID="dtlInternship" DataSourceID ="srcInternship" DataKeyNames="InternshipID" AllowPaging="true" AutoGenerateRows="false" runat="server">
<Fields>
    <asp:BoundField DataField="InternshipID" HeaderText="InternshipID:" ReadOnly="true" InsertVisible="false" Visible="false" />
    <asp:BoundField DataField="InternshipName" HeaderText="Internship Name:" />
    <asp:BoundField DataField="InternshipYear" HeaderText="Internship Year:" />
    <asp:BoundField DataField="DateStart" HeaderText="DateStart:" />
    <asp:BoundField DataField="DateEnd" HeaderText="DateEnd:" />
    

</Fields>
    </asp:DetailsView>
    <asp:SqlDataSource 
        ID="srcInternship"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
       SelectCommand ="SELECT * FROM Internships"
        UpdateCommand= "UPDATE Internships SET InternshipName=@InternshipName, InternshipYear=@InternshipYear, DateStart=@DateStart, DateEnd=@DateEnd WHERE InternshipID=@InternshipID">
         <UpdateParameters>
    <asp:Parameter Type="String" Name="InternshipID" />
    <asp:Parameter Type="String" Name="InternshipName" />
    <asp:Parameter Type="String" Name="InternshipYear" />
    <asp:Parameter Type="String" Name="DateStart" />
    <asp:Parameter Type="String" Name="DateEnd" />
    

</UpdateParameters>
    </asp:SqlDataSource>

      <br />
         <br />
     <asp:Label ID="Label4" runat="server" Text="Select Internship to Edit"></asp:Label>
    <br />
    <asp:ListBox ID="lstEdit" runat="server" OnSelectedIndexChanged="lstEdit_SelectedIndexChanged" AutoPostBack="true">

    </asp:ListBox>
    <br />
     
            <asp:Label ID="Label2" runat="server" Text="InternshipName"></asp:Label>
            <asp:TextBox ID="txtInternshipName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="InternshipYear"></asp:Label>
            <asp:TextBox ID="txtInternshipYear" runat="server"></asp:TextBox>
            <br />
    
    <asp:Label ID="Label5" runat="server" Text="InternshipDateStart"></asp:Label>
            <asp:TextBox ID="txtInternshipDateStart" runat="server"></asp:TextBox>
            <br />
    <asp:Label ID="Label1" runat="server" Text="InternshipDateEnd"></asp:Label>
            <asp:TextBox ID="txtInternshipDateEnd" runat="server"></asp:TextBox>
       
            <br />
     <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    



   

    







</asp:Content>
