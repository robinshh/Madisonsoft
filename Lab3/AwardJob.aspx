<%--Dana Elzoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AwardJob.aspx.cs" Inherits="Lab2.AwardJob" %>
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
    <%-- fix ambiguous parameter--%>

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
        ID="ddlJobList"
        runat="server"
        DataSourceID="dtasrcJobList"
        DataTextField="Title"
        DataValueField="JobID"
        AutoPostBack="true">
    </asp:DropDownList>

    <asp:SqlDataSource
        ID="dtasrcJobList"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT Title, JobID FROM JobOpportunity"
        UpdateCommand="UPDATE JobOpportunity SET Title=@Title, Location=@Location WHERE JobID=@JobID">
        <UpdateParameters>
    <asp:Parameter Type="String" Name="JobID" />
    <asp:Parameter Type="String" Name="Title" />
    <asp:Parameter Type="String" Name="Location" />
    

</UpdateParameters>
    </asp:SqlDataSource>
     <asp:Button ID="btnAssign" runat="server" Text="Reward Job" OnClick="btnAssign_Click" />
    <br />

    <br />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

    <br />




</asp:Content>
