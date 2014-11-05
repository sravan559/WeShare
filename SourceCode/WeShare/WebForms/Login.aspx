<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WeShare.WebForms.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/weshare.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.11.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.validate.js" type="text/javascript"></script>
    <script src="../Scripts/additional-methods.js" type="text/javascript"></script>
    <link href="../Styles/bootstrap.min.css" rel="Stylesheet" type="text/css" />
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
</head>
<body bgcolor="#ffffff">
  <form id="signUpForm" runat="server" >
    <div id="userLogin" class="login form-signin">
        <h2 style="text-align: center;">
            WeShare Login</h2> 
        <table align="center">
            <tr>
                <td>
                    <asp:TextBox ID="txtLoginEmail" runat="server" placeholder="Email address" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="color: Red">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="Session Expired. Please login to access the application."
                        Visible="false"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
                    <input id="btnShowSignUp" type="button" value="Sign Up" class="btn" />
                </td>
            </tr>
        </table>
    </div>
    <div id="userSignUp" style="display: none; border: 2px solid black; width: 70% !important;
        max-width: 500px;" class="login form-signin">
        <table style="width: 100%;">
            <tr>
                <th>
                    First Name:
                </th>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Last Name:
                </th>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Email Id:
                </th>
                <td>
                    <asp:TextBox ID="txtEmailId" runat="server" TextMode="Email"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Contact No.:
                </th>
                <td>
                    <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Password:
                </th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Confirm Password:
                </th>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnSignUpUser" runat="server" Text="Start Sharing" CssClass="btn"
                        OnClick="btnSignUpUser_Click" />
                    <input id="btnShowLogin" type="button" value="Back to Login" class="btn" />
                </td>
            </tr>
        </table>
    </div>


    </form>
</body>
<script type="text/javascript">

$(document).ready(function () 
{
  CreateSignUpValidationRules();
});

function CreateSignUpValidationRules() {
$("#signUpForm").validate(
        {
            rules:
             {  
                <%=txtFirstName.ClientID%>:
                {
                    required: true
                },
                <%=txtLastName.ClientID%>:
                {
                    required: true
                },   
                <%=txtEmailId.ClientID%>:
                {
                    required: true,
                    email:true
                },
                <%=txtPassword.ClientID%>:
                {
                    required: true,
                    minlength: 6,
                    maxlength: 10
                },
                <%=txtConfirmPassword.ClientID%>:
                {
                    equalTo: '#<%=txtPassword.ClientID%>'
                }
             },
            messages: 
            {     
                <%=txtFirstName.ClientID%>:
                {
                    required: "Please enter your First Name"
                },
                <%=txtLastName.ClientID%>:
                {
                    required: "Please enter your Last Name"
                },   
                <%=txtEmailId.ClientID%>:
                {
                    required: "Please enter an e-mail address",
                    email:"Please enter a valid e-mail address"
                },
                <%=txtPassword.ClientID%>: 
                {
                    required: "Please enter a password",
                    minlength: "Password must contain at least 6 characters.",
                    maxlength: "Password cannot exceed 10 characters."
                },      
                <%=txtConfirmPassword.ClientID%>: 
                {
                   equalTo: "Passwords do not match."
                }
            }
        });
}

  $('#<%=btnSignUpUser.ClientID%>').click(function() 
    {
        if (!$('#signUpForm').valid()) 
        {
            alert('Please make sure all the data is valid before submitting.');
        }     
    });

      $('#btnLogin').click(function(){
        if($('#<%=txtLoginEmail.ClientID %>').val()=='' || $('#<%=txtLoginPassword.ClientID %>').val()=='')
        {
            alert('Please enter your login credentials to login.')
            return false;
        }
        return true;
    });

    $('#btnShowSignUp').click(function(){
        $('#userSignUp').show();
        $('#userLogin').hide();
    });
    $('#btnShowLogin').click(function(){
        $('#userSignUp').hide();
        $('#userLogin').show();
    });
    
</script>

</html>
