<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="AssignTasks.aspx.cs" Inherits="WeShare.WebForms.AssignTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="width:60%">
        <asp:Panel ID="Panel1" BackColor="#CCCCCC" runat="server" BorderColor="Black" BorderStyle="Solid">
            <table>
                <tr>
                    <th>
                        Select Task:
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlTasks" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="Select Task" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Select User:
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlUsers" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="Select User" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Due Date:
                    </th>
                    <td>
                        <asp:TextBox ID="txtDueDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAssignTask" runat="server" Text="Assign Task" OnClick="btnAssignTask_Click" CssClass="btn"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <script type="text/javascript">
        $("#<%=txtDueDate.ClientID %>").datepicker({ minDate: 0 });
    </script>
</asp:Content>
