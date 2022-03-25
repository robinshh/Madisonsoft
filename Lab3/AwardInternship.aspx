<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AwardInternship.aspx.cs" Inherits="Lab2.AwardInternship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
        <asp:DropDownList 
            ID="ddlStudentList"
            runat="server"
            DataSourceID="dtasrcStudentList"
            DataTextField="StudentName"
            DataValueField="StudentID"
            AutopostBack="true" ></asp:DropDownList>
    <%--        SelectCommand ="select (Students.FirstName + ' ' + Students.LastName) as StudentName from Students left join JobApplications ON Students.StudentID=JobApplications.StudentID"--%>


     <asp:SqlDataSource 
        ID="dtasrcStudentList"
        runat="server"
       ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
         SelectCommand ="select FirstName + ' ' + LastName as StudentName,StudentID from Students"
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


     <asp:DropDownList
        ID="ddlInternshipList"
        runat="server"
        DataSourceID="dtasrcInternshipList"
        DataTextField="InternshipName"
        DataValueField="InternshipID"
        AutoPostBack="true">
    </asp:DropDownList>

    <asp:SqlDataSource
        ID="dtasrcInternshipList"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT InternshipName, InternshipID FROM Internships"
        UpdateCommand="UPDATE Internships SET InternshipName=@InternshipName, InternshipYear=@InternshipYear, DateStart=@DateStart, DateEnd=@DateEnd WHERE InternshipID=@InternshipID">
        <UpdateParameters>
    <asp:Parameter Type="String" Name="InternshipID" />
    <asp:Parameter Type="String" Name="InternshipName" />
    <asp:Parameter Type="String" Name="InternshipYear" />
    <asp:Parameter Type="String" Name="DateStart" />
    <asp:Parameter Type="String" Name="DateEnd" />
    

</UpdateParameters>
    </asp:SqlDataSource>
     <asp:Button ID="btnAssign" runat="server" Text="Reward Internship" OnClick="btnAssign_Click" />
    <br />

    <br />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

    <br />


    
</asp:Content>
