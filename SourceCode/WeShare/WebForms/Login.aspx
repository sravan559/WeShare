<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WeShare.WebForms.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccff99">
    <form id="form1" runat="server">
    <div>
    <h1 align="center" 
            style="font-family: 'Lucida Handwriting'; font-style: normal; color: #800000; background-color: #CCFFCC;">WeShare....</h1>
    <table align ="center">
    <tr>
    <td>User ID</td>
    <td><asp:TextBox ID="txtUserID" runat="server" Width="200px"></asp:TextBox></td>
   
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Enter User ID" ControlToValidate="txtUserID" ForeColor="#3366FF"></asp:RequiredFieldValidator></td>
    
    </tr>
    <tr>
    <td>Password</td>
    <td>
        <asp:TextBox ID="txtPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox></td>
        
        <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="Enter your password" ControlToValidate="txtPwd" 
                ForeColor="#3366FF"></asp:RequiredFieldValidator></td>
        
            </tr>
    <tr><td></td></tr>
    <tr>
    <td>
    </td>
    <td>
       
        <asp:Button ID="Button1" runat="server" Text="Login" Width="100px" 
            onclick="Button1_Click" /></td>
    </tr>
    </table>
    </div>

    </form>
</body>
</html>
