<%--
Date: 2/27/2022
    Name: Madeleine Duley and Dana El-Zoobi and Kit Harmon
File Purpose: This file is the webform for the members home page--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MembersHomePage.aspx.cs" Inherits="Lab2.MembersHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dana El-Zoobi & Madeleine Duley & Kit Harmon
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <br />
    
    <br />
    <asp:Button ID="btnAddMember" runat="server" Text="Add Member" OnClick="btnAddMember_Click" />
    
    <br />

    <fieldset> 
<legend> Select Member to View Details</legend>
        <asp:DropDownList 
            ID="ddlMemberList"
            runat="server"
            DataSourceID="dtasrcMemberList"
            DataTextField="MemberName"
            DataValueField="MemberID"
            AutopostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnLoadMemberData" runat="server" Text="Show Member" OnClick="btnLoadMemberData_Click" />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Members" OnClick="btnShowAll_Click" />

    </fieldset>
    <br />
    <fieldset>
<legend> Information for Selected Member</legend>
        <asp:GridView 
            runat="server"
           ID="grdMemberResults"
            AlternatingRowStyle-BackColor="#eaaaff"
            EmptyDataText="No Member Selected!"
             
           
            ></asp:GridView>

    </fieldset>
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

  

    <asp:DetailsView 
        ID="dtlMembers" DataSourceID ="srcMembers" DataKeyNames="MemberID" AllowPaging="true" AutoGenerateRows="false" runat="server">
<Fields>
    <asp:BoundField DataField="MemberID" HeaderText="MemberID:" ReadOnly="true" InsertVisible="false" Visible="false" />
    <asp:BoundField DataField="FirstName" HeaderText="First Name:" />
    <asp:BoundField DataField="LastName" HeaderText="LastName:" />
    <asp:BoundField DataField="Email" HeaderText="Email:" />
    <asp:BoundField DataField="Phone" HeaderText="Phone:" />
    <asp:BoundField DataField="GradYear" HeaderText="GradYear:" />
    <asp:BoundField DataField="JobTitle" HeaderText="JobTitle:" />
    

</Fields>
    </asp:DetailsView>
    <asp:SqlDataSource 
        ID="srcMembers"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
       SelectCommand ="SELECT * FROM Members"
        UpdateCommand="UPDATE Members SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, GradYear=@GradYear, JobTitle=@JobTitle  WHERE MemberID=@MemberID"> 
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
   
    <asp:Button ID="btnEdit" runat="server" Text="Edit Individual Records" OnClick="btnEdit_Click" />

 














</asp:Content>
