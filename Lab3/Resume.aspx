<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.Master" AutoEventWireup="true" CodeBehind="Resume.aspx.cs" Inherits="Lab3.Resume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td>Select Resume
                </td>
                <td>
                    <asp:FileUpload
                        ID="ResumeUpload"
                        runat="server"
                        ToolTip="Please only select a PDF file" />
                </td>
                <td>
                    <asp:Button ID="ButtonUpload" runat="server" Text="Upload Resume" OnClick="ButtonUpload_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonViewResume" runat="server" Text="View Resume" OnClick="ButtonViewResume_Click" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <p>
                        <asp:Label ID="LabelResumeRequest" runat="server" Text=""></asp:Label>
                    </p>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridViewResume" runat="server" Caption="Resume Files " onselectedindexchanged="GridViewResume_SelectedIndexChanged"> 
            <Columns>
                <asp:CommandField ShowSelectButton="true" SelectText="Download" />
            </Columns>
        </asp:Gridview>
    </div>
</asp:Content>

