<%--Dana Elzoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddJob.aspx.cs" Inherits="Lab2.AddJob" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="reqSchName" ControlToValidate="txtTitle" Text="(Required)" runat="server" ForeColor="HotPink" />
      <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Location"></asp:Label>
            <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtLocation" Text="(Required)" runat="server" ForeColor="HotPink" />
            <br />
    
   
    <asp:ListBox ID="lstJobs" runat="server"></asp:ListBox>
            <br />

    <asp:Button ID="btnAddJob" runat="server" Text="Add Job" OnClick="btnAddJob_Click"/> 
    <%--<asp:Button ID="btnSave" runat="server" Text="Save" />--%> 
    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" CausesValidation="false"/>
    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click"/>
   <%-- <asp:Button ID="btnCommit" runat="server" Text="Commit" OnClick="btnCommit_Click" />--%>
  <asp:SqlDataSource 
        ID="sqlsrcJobTable"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT Title,JobID FROM JobOpportunity"> 

    </asp:SqlDataSource>

</asp:Content>
