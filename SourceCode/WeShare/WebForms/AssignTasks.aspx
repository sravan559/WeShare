<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="AssignTasks.aspx.cs" Inherits="WeShare.WebForms.AssignTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="inputcontainer">
        <asp:Panel ID="Panel1" runat="server">
                    <div class="form-horizontal">
                <div class="form-group">
                    <label for="txtTaskName" class="col-sm-2 control-label">
                        Select Task</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlTasks" runat="server" AppendDataBoundItems="true" Width="50%">
                            <asp:ListItem Text="Select Task" Value=""></asp:ListItem>
                        </asp:DropDownList>
                       
                    </div>
                </div>
                 <div class="form-group">
                    <label for="ddlUsers" class="col-sm-2 control-label">
                        Select User</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlUsers" runat="server" AppendDataBoundItems="true" Width="50%">
                            <asp:ListItem Text="Select User" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                 <div class="form-group">
                    <label for="txtDueDate" class="col-sm-2 control-label">
                       Due Date</label>
                    <div class="col-sm-10">
                          <asp:TextBox ID="txtDueDate" runat="server" Width="50%"></asp:TextBox>
                       
                    </div>
                </div>
                 <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10" align="left">
                                <asp:Button ID="btnAssignTask" runat="server" Text="Assign Task" OnClick="btnAssignTask_Click" class="btn btn-info"
                                        BorderColor="Black" />
                    
                                </div>
                            </div>


                </div>

        </asp:Panel>
    </div>
    <div class="gridcontainer">
        <h2>
            Assigned Tasks List</h2>
        <asp:GridView ID="gvAssignedTasks" runat="server" AutoGenerateColumns="false" OnRowCommand="gvAssignedTasks_RowCommand"
            DataKeyNames="TaskId,TaskTitle,TaskDescription,PointsAllocated" OnRowDeleting="gvAssignedTasks_RowDeleting"
            Width="80%" class="table table-hover" AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="TaskTitle" HeaderText="Task Name" />
                <asp:BoundField DataField="UserName" HeaderText="Assigned To" />
                <asp:BoundField DataField="UserId" HeaderText="User ID" />
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
                <table class="table table-hover">
                    <tr>
                        <th>
                            Task Name
                        </th>
                        <th>
                            Assigned To
                        </th>
                        <th>
                            User ID
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
