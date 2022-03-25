<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AssignMentor.aspx.cs" Inherits="Lab2.AssignMentor" %>
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

     <asp:DropDownList 
            ID="ddlMemberList"
            runat="server"
            DataSourceID="dtasrcMemberList"
            DataTextField="MemberName"
            DataValueField="MemberID"
            AutopostBack="true" ></asp:DropDownList>

     <asp:SqlDataSource 
        ID="dtasrcMemberList"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT FirstName + ' ' + LastName AS MemberName, MemberID FROM MEMBERS"
        UpdateCommand="UPDATE Members SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, JobTitle=@JobTitle WHERE MemberID=@MemberID"> 
<UpdateParameters> 
    <asp:Parameter Type="String" Name="MemberID" />
    <asp:Parameter Type="String" Name="FirstName" />
    <asp:Parameter Type="String" Name="LastName" />
    <asp:Parameter Type="String" Name="Email" />
    <asp:Parameter Type="String" Name="Phone" />
    <asp:Parameter Type="String" Name="GradYear" />
    <asp:Parameter Type="String" Name="JobTitle" />
   
</UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" />
    <asp:Label ID="lblSave" runat="server" Text="Click to update student who already has a mentor"></asp:Label>
    <br />
    <br />

    <asp:Button ID="btnAssign" runat="server" Text="Assign Mentor" OnClick="btnAssign_Click" />
    <asp:Label ID="lblAssign" runat="server" Text="ONLY for students who have no mentor"></asp:Label>
    <br />
    
    <br />

    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

    <br />
    <asp:GridView ID="grd1" 
        DataSourceID="srcMentors" 
        runat="server"
       
        ></asp:GridView>

    <asp:SqlDataSource ID="srcMentors" ConnectionString="<%$ ConnectionStrings: Lab3 %>" SelectCommand="Select (Students.FirstName + ' ' + Students.LastName) as StudentName, (Members.FirstName + ' ' + Members.LastName) as MentorName From Students Left Join Mentorship ON Students.StudentID=Mentorship.StudentID Left Join Members ON Mentorship.MemberID=Members.MemberID" runat="server"
        ></asp:SqlDataSource>





</asp:Content>
