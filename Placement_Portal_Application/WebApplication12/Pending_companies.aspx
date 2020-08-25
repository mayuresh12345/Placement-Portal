<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Pending_companies.aspx.cs" Inherits="WebApplication12.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="Update_company">
        <Columns>
            <asp:ButtonField CommandName ="Update" Text ="Approve" ButtonType="Button" />
            <asp:ButtonField CommandName ="Delete" Text ="Reject" ButtonType="Button"/>
        </Columns>
    </asp:GridView>
</asp:Content>
