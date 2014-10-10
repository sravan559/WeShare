<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WeShare.WebForms.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/weshare.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#ccff99">
    <form id="form1" runat="server">
    <div class="login form-signin">
        <h2 style="text-align: center;">
            Login</h2>
        <table align="center">
            <tr>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server" Width="200px" placeholder="Email address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter User ID"
                        ControlToValidate="txtUserID" ForeColor="#3366FF"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" Width="200px" TextMode="Password" placeholder="Password"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter your password"
                        ControlToValidate="txtPwd" ForeColor="#3366FF"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <label class="checkbox">
                        <input type="checkbox" value="remember-me" />
                        Remember me
                    </label>
                </td>
            </tr>--%>
            <tr align="center">
                <td>    
                    <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
