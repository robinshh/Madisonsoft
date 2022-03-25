<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AwardScholarship.aspx.cs" Inherits="Lab2.AwardScholarship" %>
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
        ID="ddlScholarshipList"
        runat="server"
        DataSourceID="dtasrcScholarshipList"
        DataTextField="ScholarshipName"
        DataValueField="ScholarshipID"
        AutoPostBack="true">
    </asp:DropDownList>

    <asp:SqlDataSource
        ID="dtasrcScholarshipList"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT ScholarshipName, ScholarshipID FROM Scholarships"
        UpdateCommand="UPDATE Scholarships SET ScholarshipName=@ScholarshipName, ScholarshipAmount=@ScholarshipAmount, ScholarshipYear=@ScholarshipYear WHERE ScholarshipID=@ScholarshipID">
        <UpdateParameters>
    <asp:Parameter Type="String" Name="ScholarshipID" />
    <asp:Parameter Type="String" Name="ScholarshipName" />
    <asp:Parameter Type="String" Name="ScholarshipAmount" />
    <asp:Parameter Type="String" Name="ScholarshipYear" />
   

</UpdateParameters>
    </asp:SqlDataSource>

     <asp:Button ID="btnAssign" runat="server" Text="Reward Scholarship" OnClick="btnAssign_Click" />
    <br />

    <br />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    
    <br />

</asp:Content>
