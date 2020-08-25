<%@ Page Title="" Language="C#" MasterPageFile="~/recruiter.Master" AutoEventWireup="true" CodeBehind="registered_stu.aspx.cs" Inherits="WebApplication12.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" OnRowCommand="Update_company">
        <Columns>
            <asp:ButtonField CommandName ="Update" Text ="Select" ButtonType="Button" />
            <asp:ButtonField CommandName ="Delete" Text ="Reject" ButtonType="Button"/>
            <asp:ButtonField CommandName ="View"    Text ="View" ButtonType ="Button" />
        </Columns>
    </asp:GridView>
</asp:Content>
