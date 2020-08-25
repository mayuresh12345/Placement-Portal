    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" StylesheetTheme="Skin1" Inherits="WebApplication12.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            height: 34px;
            border-style: solid;
            border-width: 1px;
            margin-top: 51px;
        }
        .auto-style3 {
            width: 98px;
            height: 65px;
        }
        .auto-style4 {
            width: 427px;
            height: 65px;
        }
        .auto-style7 {
            width: 98px;
            height: 56px;
        }
        .auto-style8 {
            width: 427px;
            height: 56px;
        }
        .auto-style9 {
            width: 98px;
            height: 51px;
        }
        .auto-style10 {
            width: 427px;
            height: 51px;
        }
        .auto-style11 {
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table cellpadding="5" class="auto-style1">
            <tr>
                <td class="auto-style3">Username:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Password:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="TextBox2" Type="password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
                </td>
                <td class="auto-style8">
                    <asp:Button ID="signup" runat="server" Text="Sign Up" OnClick="signup_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style11" colspan="2">
                    <asp:Label ID="error" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
       
    </form>
 
        </p>
    
</body>
</html>
