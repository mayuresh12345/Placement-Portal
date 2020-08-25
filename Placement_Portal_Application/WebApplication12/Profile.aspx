<%@ Page Title="" Language="C#" MasterPageFile="~/student.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication12.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 35%;
            height: 240px;
        }
        .auto-style3 {
            width: 151px;
        }
        .auto-style4 {
            width: 168px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style2" border="1">
        <tr>
            <td class="auto-style3">Registration number:</td>
            <td class="auto-style4">
                <asp:Label ID="reg_no" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Name:</td>
            <td class="auto-style4">
                <asp:Label ID="name" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Branch:</td>
            <td class="auto-style4">
                <asp:Label ID="branch" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Email:</td>
            <td class="auto-style4">
                <asp:Label ID="email" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Phone number:</td>
            <td class="auto-style4">
                <asp:Label ID="ph_number" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
