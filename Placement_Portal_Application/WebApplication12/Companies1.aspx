<%@ Page Title="" Language="C#" MasterPageFile="~/student.Master" AutoEventWireup="true" CodeBehind="companies1.aspx.cs" Inherits="WebApplication12.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="Update_company">
        <Columns>
            <asp:ButtonField CommandName ="Update" Text ="Register" ButtonType="Button" />
        </Columns>
    </asp:GridView>
</asp:Content>
