<%--
Date: 2/27/2022
    Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
File Purpose: This file is the webform for the student home page--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="Lab2.StudentHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dana El-Zoobi & Madeleine Duley
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    
    <br />
    <br />
    
    <asp:Button ID="btnAddUser" runat="server" Text="Add New User" OnClick="btnAddUser_Click" />
    <asp:Button ID="btnAssignMentor" runat="server" Text="Manage Mentorship" OnClick="btnAssignMentor_Click" />
    
   
    <br />

    <fieldset> 
<legend> Select Student to View Details</legend>
        <asp:DropDownList 
            ID="ddlStudentList"
            runat="server"
            DataSourceID="dtasrcStudentList"
            DataTextField="StudentName"
            DataValueField="StudentID"
            AutopostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnLoadStudentData" runat="server" Text="Show Student" OnClick="btnLoadStudentData_Click" />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Students" OnClick="btnShowAll_Click" />

    </fieldset>
    <br />
    <fieldset>
<legend> Information for Selected Student</legend>
        <asp:GridView 
            runat="server"
           ID="grdStudentResults"
            AlternatingRowStyle-BackColor="#eaaaff"
            EmptyDataText="No Student Selected!"
             
           
            ></asp:GridView>

    </fieldset>
    <asp:SqlDataSource 
        ID="dtasrcStudentList"
        runat="server"
       ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT FirstName + ' ' + LastName AS StudentName, StudentID FROM STUDENTS"
        UpdateCommand="UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, Major=@Major, InternshipStatus=@InternshipStatus, EmploymentStatus=@EmploymentStatus WHERE StudentID=@StudentID"> 
        <UpdateParameters>
    <asp:Parameter Type="String" Name="StudentID" />
    <asp:Parameter Type="String" Name="FirstName" />
    <asp:Parameter Type="String" Name="LastName" />
    <asp:Parameter Type="String" Name="Email" />
    <asp:Parameter Type="String" Name="Phone" />
    <asp:Parameter Type="String" Name="GradYear" />
    <asp:Parameter Type="String" Name="Major" />
    <asp:Parameter Type="String" Name="InternshipStatus" />
    <asp:Parameter Type="String" Name="EmploymentStatus" />

</UpdateParameters>
    </asp:SqlDataSource>

  

    <asp:DetailsView 
        ID="dtlStudents" DataSourceID ="srcStudents" DataKeyNames="StudentID" AllowPaging="true" AutoGenerateRows="false" runat="server">
<Fields>
    <asp:BoundField DataField="StudentID" HeaderText="StudentID:" ReadOnly="true" InsertVisible="false" Visible="false"/>
    <asp:BoundField DataField="FirstName" HeaderText="First Name:" />
    <asp:BoundField DataField="LastName" HeaderText="LastName:" />
    <asp:BoundField DataField="Email" HeaderText="Email:" />
    <asp:BoundField DataField="Phone" HeaderText="Phone:" />
    <asp:BoundField DataField="GradYear" HeaderText="GradYear:" />
    <asp:BoundField DataField="Major" HeaderText="Major:" />
    <asp:BoundField DataField="InternshipStatus" HeaderText="InternshipStatus:" />
    <asp:BoundField DataField="EmploymentStatus" HeaderText="EmploymentStatus:" />

</Fields>
    </asp:DetailsView>
    <asp:SqlDataSource 
        ID="srcStudents"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
       SelectCommand ="SELECT * FROM STUDENTS"
        UpdateCommand="UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, Major=@Major, InternshipStatus=@InternshipStatus, EmploymentStatus=@EmploymentStatus WHERE StudentID=@StudentID"> 
        <UpdateParameters>
    <asp:Parameter Type="String" Name="StudentID" />
    <asp:Parameter Type="String" Name="FirstName" />
    <asp:Parameter Type="String" Name="LastName" />
    <asp:Parameter Type="String" Name="Email" />
    <asp:Parameter Type="String" Name="Phone" />
    <asp:Parameter Type="String" Name="GradYear" />
    <asp:Parameter Type="String" Name="Major" />
    <asp:Parameter Type="String" Name="InternshipStatus" />
    <asp:Parameter Type="String" Name="EmploymentStatus" />

</UpdateParameters>
    </asp:SqlDataSource>

    <br />
         <br />
     <asp:Label ID="Label4" runat="server" Text="Select Student to Edit"></asp:Label>
    <br />
    <asp:ListBox ID="lstEdit" runat="server" OnSelectedIndexChanged="lstEdit_SelectedIndexChanged" AutoPostBack="true">

    </asp:ListBox>
    <br />
     
             <br />
     
            <asp:Label ID="Label2" runat="server" Text="FirstName"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
   
            <br />
            <asp:Label ID="Label3" runat="server" Text="LastName"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    
            <br />
    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    
            <br />
    <asp:Label ID="Label5" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    
            <br />
    <asp:Label ID="Label6" runat="server" Text="GradYear"></asp:Label>
            <asp:TextBox ID="txtGradYear" runat="server"></asp:TextBox>
    
            <br />
    <asp:Label ID="Label7" runat="server" Text="Major"></asp:Label>
            <asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
            <br />
    <asp:Label ID="Label8" runat="server" Text="InternshipStatus"></asp:Label>
            <asp:TextBox ID="txtInternshipStatus" runat="server"></asp:TextBox>
   
            <br />
    <asp:Label ID="Label9" runat="server" Text="EmploymentStatus"></asp:Label>
            <asp:TextBox ID="txtEmploymentStatus" runat="server"></asp:TextBox>
  
            <br />
    
            
     <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    



</asp:Content>
