<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="Lab2.StudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <br />
    <asp:DetailsView
        ID="dtlStudents" DataSourceID="srcStudents" DataKeyNames="StudentID" AllowPaging="false" AutoGenerateEditButton="false" AutoGenerateRows="false" runat="server">
        <Fields>
            <asp:BoundField DataField="StudentID" HeaderText="StudentID:" ReadOnly="true" InsertVisible="false" Visible="false" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name:" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name:" />
            <asp:BoundField DataField="Email" HeaderText="Email:" />
            <asp:BoundField DataField="Phone" HeaderText="Phone:" />
            <asp:BoundField DataField="GradYear" HeaderText="Graduation Year:" />
            <asp:BoundField DataField="Major" HeaderText="Major:" />
            <asp:BoundField DataField="InternshipStatus" HeaderText="Internship Status:" />
            <asp:BoundField DataField="EmploymentStatus" HeaderText="Employment Status:" />
        </Fields>
    </asp:DetailsView>

    <asp:SqlDataSource
        ID="srcStudents"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand="SELECT * FROM Students WHERE ([Username] = @Username)"
        UpdateCommand="UPDATE Students SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, Major=@Major, InternshipStatus=@InternshipStatus, EmploymentStatus=@EmploymentStatus WHERE StudentID=@StudentID">
<SelectParameters>
            <asp:SessionParameter
                Name="Username"
                SessionField="Username"
                DefaultValue="2" />
        </SelectParameters>
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
    <asp:Button ID="ButtonResume" runat="server" Text="Resume" OnClick ="ButtonResume_Click" />


     <br />
         <br />
     <asp:Label ID="Label4" runat="server" Text="Select Student to Edit"></asp:Label>
    <br />
    <asp:ListBox ID="lstEdit" runat="server" OnSelectedIndexChanged="lstEdit_SelectedIndexChanged" AutoPostBack="true" ></asp:ListBox>
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

   <asp:Label ID="Label10" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>  
            
     <br />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    


    </asp:Content>