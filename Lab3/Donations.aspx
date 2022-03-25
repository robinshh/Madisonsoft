<%@ Page Title="" Language="C#" MasterPageFile="~/HomeOverview.Master" AutoEventWireup="true" CodeBehind="Donations.aspx.cs" Inherits="Lab3.Donations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    As you know, we are a non-profit organization dedicated to aiding African American students to successfully continue their education at James Madison University (JMU).  We gladly accept and appreciate any and all donations. 
Thanks to the following people for their recent donations:

    <br />
    Coach Challace and Mary Lou McMillan, Tamara Ziggy-Adams, Clayton and Denise Taylor, Melvin Petty and ERP Enterprises, Adrena May, Candace Taylor, Marvin Smith, Michael and Rhonda Thurman, Allison Parker, Tommy Parker, Michael Arrington, Michael Fornadel, Derek Steele, Bud and Angela Russell, Warren Marshall and family, Reggie and Serena Hayes
    <br />
    Donations may be made via: credit card, through secured Paypal website (click below), check, money order or mail to: 
    <br />
    JMU Ole School Group
    <br />
    P.O. Box 2701
    <br />
    Chesterfield, Va. 23832
    <br />
    <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl="https://www.paypal.com/webapps/shoppingcart?mfid=1648176045806_f54786328ab46&flowlogging_id=f54786328ab46#/checkout/shoppingCart" runat="server">Donate Now</asp:HyperLink>
</asp:Content>
