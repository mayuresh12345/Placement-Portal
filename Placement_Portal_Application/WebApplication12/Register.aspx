<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication12.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
      Reg Id:  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="Enter registration ID" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <br />
       Name : <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        &nbsp;
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Enter Name" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
        <br />
       Contact No : <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:customvalidator ID="cv1" runat="server" ErrorMessage="Enter proper contact number" ControlToValidate="TextBox3" OnServerValidate="Validate_number"></asp:customvalidator>
        <br />
       Email ID : <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="Enter valid email ID" ControlToValidate="TextBox4" 
            ValidationExpression=".+@.+"></asp:RegularExpressionValidator>
        <br />
        Branch :<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="Enter Branch" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
        <br />
      Password :  <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ErrorMessage="Enter Password" ControlToValidate="TextBox8"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Register" Width="91px" OnClick="Button1_Click" />
        &ensp;&ensp;&nbsp;&nbsp;&nbsp;&nbsp; &ensp;
        <asp:Button ID="Button2" runat="server" Text="Back" Width="89px" OnClick="Button2_Click" CausesValidation="false" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>

