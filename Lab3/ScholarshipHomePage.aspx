<%--
Date: 2/27/2022
    Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
File Purpose: This file is the webform for the scholarships home page--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ScholarshipHomePage.aspx.cs" Inherits="Lab2.ScholarshipHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dana El-Zoobi & Madeleine Duley
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <br />
    
    <br />  
    
    <br />
    <asp:Button ID="btnAddScholarship" runat="server" Text="Add New Scholarship" OnClick="btnAddScholarship_Click"/>
    <asp:Button ID="btnAward" runat="server" Text="Award Scholarship" OnClick="btnAward_Click" />
    <%-- <asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click"/>--%>
    <br />
    <fieldset> 
<legend> Select Scholarship to View Details</legend>
        <asp:DropDownList 
            ID="ddlScholarshipList"
            runat="server"
            DataSourceID="dtasrcScholarshipList"
            DataTextField="ScholarshipName"
            DataValueField="ScholarshipID"
            AutopostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnLoadScholarshipData" runat="server" Text="Show Scholarship" OnClick="btnLoadScholarshipData_Click" />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Scholarships" OnClick="btnShowAll_Click" />

    </fieldset>
    <br />
    <fieldset>
<legend> Information for Selected Scholarship</legend>
        <asp:GridView 
            runat="server"
           ID="grdScholarshipResults"
            AlternatingRowStyle-BackColor="#eaaaff"
            EmptyDataText="No Company Selected!"
             
           
            ></asp:GridView>

    </fieldset>
    <asp:SqlDataSource 
        ID="dtasrcScholarshipList"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT ScholarshipName,ScholarshipID FROM Scholarships"
        UpdateCommand="UPDATE Scholarships SET ScholarshipName=@ScholarshipName, ScholarshipAmount=@ScholarshipAmount, ScholarshipYear=@ScholarshipYear WHERE ScholarshipID=@ScholarshipID"> 
         <UpdateParameters>
    <asp:Parameter Type="String" Name="ScholarshipID" />
    <asp:Parameter Type="String" Name="ScholarshipName" />
    <asp:Parameter Type="String" Name="ScholarshipAmount" />
    <asp:Parameter Type="String" Name="ScholarshipYear" />
   

</UpdateParameters>
    </asp:SqlDataSource>

  

    <asp:DetailsView 
        ID="dtlScholarship" DataSourceID ="srcScholarship" DataKeyNames="ScholarshipID" AllowPaging="true" AutoGenerateRows="false" runat="server">
<Fields>
    <asp:BoundField DataField="ScholarshipID" HeaderText="ScholarshipID:" ReadOnly="true" InsertVisible="false" Visible="false" />
   <asp:BoundField DataField="ScholarshipName" HeaderText="Scholarship Name:" />
    <asp:BoundField DataField="ScholarshipAmount" HeaderText="Scholarship Amount:" />
     <asp:BoundField DataField="ScholarshipYear" HeaderText="Scholarship Year:" />

    
    
    

</Fields>
    </asp:DetailsView>
    <asp:SqlDataSource 
        ID="srcScholarship"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
       SelectCommand ="SELECT * FROM Scholarships"
        UpdateCommand="UPDATE Scholarships SET ScholarshipName=@ScholarshipName, ScholarshipAmount=@ScholarshipAmount, ScholarshipYear=@ScholarshipYear WHERE ScholarshipID=@ScholarshipID"> 
         <UpdateParameters>
    <asp:Parameter Type="String" Name="ScholarshipID" />
    <asp:Parameter Type="String" Name="ScholarshipName" />
    <asp:Parameter Type="String" Name="ScholarshipAmount" />
    <asp:Parameter Type="String" Name="ScholarshipYear" />
   

</UpdateParameters>
    </asp:SqlDataSource>

    <br />
            <asp:Label ID="La" runat="server" Text="Select Scholarship To Edit"></asp:Label>

    <br />
     <asp:ListBox ID="lstScholarship" runat="server" OnSelectedIndexChanged="lstScholarship_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <br />
     
            <asp:Label ID="Label2" runat="server" Text="ScholarshipName"></asp:Label>
            <asp:TextBox ID="txtScholarshipName" runat="server"></asp:TextBox>
    
            <br />
            <asp:Label ID="Label3" runat="server" Text="ScholarshipAmount"></asp:Label>
            <asp:TextBox ID="txtScholarshipAmount" runat="server"></asp:TextBox>
    
            <br />
    
    <asp:Label ID="Label5" runat="server" Text="ScholarshipYear"></asp:Label>
            <asp:TextBox ID="txtScholarshipYear" runat="server"></asp:TextBox>
    
            <br />
    
            <br />
   
     
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/> 








</asp:Content>
