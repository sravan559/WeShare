<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="AssignTasks.aspx.cs" Inherits="WeShare.WebForms.AssignTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="inputcontainer">
        <asp:Panel ID="Panel1" BackColor="#CCCCCC" runat="server" BorderColor="Black" BorderStyle="Solid">
            <table style="min-width: 400px;">
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
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnAssignTask" runat="server" Text="Assign Task" OnClick="btnAssignTask_Click"
                            CssClass="btn" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div class="gridcontainer">
        <h1>
            Assigned Tasks List</h1>
        <asp:GridView ID="gvAssignedTasks" runat="server" AutoGenerateColumns="false" OnRowCommand="gvAssignedTasks_RowCommand"
            DataKeyNames="TaskId,TaskTitle,TaskDescription,PointsAllocated" OnRowDeleting="gvAssignedTasks_RowDeleting"
            Width="80%">
            <Columns>
                <asp:BoundField DataField="TaskTitle" HeaderText="Task Name" />
                <asp:BoundField DataField="UserName" HeaderText="Assigned To" />
                <asp:BoundField DataField="EmailId" HeaderText="Email ID" />
                <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:TemplateField HeaderText="Action" Visible="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" CommandName="EditTask" AlternateText="Edit"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif" />
                        <asp:ImageButton ID="imgDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                            AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" ToolTip="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="emptytable">
                    <tr>
                        <th>
                            Task Name
                        </th>
                        <th>
                            Assigned To
                        </th>
                        <th>
                            Email ID
                        </th>
                        <th>
                            Due Date
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            No data available.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <HeaderStyle BackColor="LightBlue" />
        </asp:GridView>
    </div>
    <script type="text/javascript">
        $("#<%=txtDueDate.ClientID %>").datepicker({ minDate: 0 });
    </script>
</asp:Content>
