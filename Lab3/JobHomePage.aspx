<%--Dana El-Zoobi and Madeleine Duley and Kit Harmon
2/27/2022--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="JobHomePage.aspx.cs" Inherits="Lab2.JobHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    Dana Elzoobi and Madeleine Duley and Kit Harmon
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

      <br />
    
    <br />
    <%--<asp:Button ID="btnAddJob" runat="server" Text="Add Job" OnClick="btnAddJob_Click1" />--%>
    <asp:Button ID="btnjob" runat="server" Text="Add Job" OnClick="btnjob_Click" />
    <asp:Button ID="btnAward" runat="server" Text="Award Job" OnClick="btnAward_Click" />
   
    <br />

    <fieldset> 
<legend> Select Internship to View Details</legend>
        <asp:DropDownList 
            ID="ddlJobList"
            runat="server"
            DataSourceID="dtasrcJobList"
            DataTextField="Title"
            DataValueField="JobID"
            AutopostBack="true" ></asp:DropDownList>
        <asp:Button ID="btnLoadJobData" runat="server" Text="Show Job" OnClick="btnLoadJobData_Click"/>
        <asp:Button ID="btnShowAll" runat="server" Text="Show All Jobs" OnClick="btnShowAll_Click"/>

    </fieldset>
    <br />
    <fieldset>
<legend> Information for Selected Job</legend>
        <asp:GridView 
            runat="server"
           ID="grdJobResults"
            AlternatingRowStyle-BackColor="#eaaaff"
            EmptyDataText="No Job Selected!"
             
           
            ></asp:GridView>

    </fieldset>
    <asp:SqlDataSource 
        ID="dtasrcJobList"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
        SelectCommand ="SELECT Title, JobID FROM JobOpportunity"
        UpdateCommand="UPDATE JobOpportunity SET Title=@Title, Location=@Location WHERE JobID=@JobID"> 
         <UpdateParameters>
    <asp:Parameter Type="String" Name="JobID" />
    <asp:Parameter Type="String" Name="Title" />
    <asp:Parameter Type="String" Name="Location" />
    

</UpdateParameters>
    </asp:SqlDataSource>

  

    <asp:DetailsView 
        ID="dtlJob" DataSourceID ="srcJob" DataKeyNames="JobID" AllowPaging="true" AutoGenerateRows="false" runat="server">
<Fields>
    <asp:BoundField DataField="JobID" HeaderText="JobID:" ReadOnly="true" InsertVisible="false" Visible="false" />
    <asp:BoundField DataField="Title" HeaderText="Title:" />
    <asp:BoundField DataField="Location" HeaderText="Location:" />
   
    

</Fields>
    </asp:DetailsView>
    <asp:SqlDataSource 
        ID="srcJob"
        runat="server"
        ConnectionString ="<%$ ConnectionStrings:Lab3 %>"
       SelectCommand ="SELECT * FROM JobOpportunity"
        UpdateCommand= "UPDATE JobOpportunity SET Title=@Title, Location=@Location WHERE JobID=@JobID">
         <UpdateParameters>
    <asp:Parameter Type="String" Name="JobID" />
    <asp:Parameter Type="String" Name="Title" />
    <asp:Parameter Type="String" Name="Location" />
    

</UpdateParameters>
    </asp:SqlDataSource>

     <br />
     
            <br />
     <asp:Label ID="Lab" runat="server" Text="Select Job to Edit"></asp:Label>
    <br />
    <asp:ListBox ID="lstJobs" runat="server" OnSelectedIndexChanged="lstJobs_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Title"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Location"></asp:Label>
            <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
            <br />
    
   
   
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/> 



   





</asp:Content>
