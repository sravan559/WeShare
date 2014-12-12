<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="WeShare.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div>
        <h3>
            My Tasks
        </h3>
        <table style="width: 98%;">
            <tr>
                <td style="width: 70%;">
                    <div class="gridcontainer">
                        <asp:GridView ID="gvMyTasks" runat="server" AutoGenerateColumns="False" DataKeyNames="TaskId,Status,PointsAllocated,DueDate"
                            OnRowCommand="gvMyTasks_RowCommand" Width="98%" OnRowDataBound="gvMyTasks_RowDataBound"
                            class="table table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Task" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTaskTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskTitle") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTaskDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskDescription") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Task Points" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTaskPoints" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PointsAllocated") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:MM/dd/yyyy}"
                                    HeaderStyle-Width="10%" />
                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTaskStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mark Task as Complete?" HeaderStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgMarkComplete" runat="server" CommandName="TaskComplete" AlternateText="Mark task as complete"
                                            ImageUrl="~/Images/img_complete.jpg" CssClass="imagebutton" ImageAlign="Middle"
                                            ToolTip="Mark Task as complete" OnClientClick="return confirm('Are you sure, you want to mark the task as complete?')"
                                            Height="20px" Width="20px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table class="table emptytable">
                                    <tr>
                                        <th>
                                            Task
                                        </th>
                                        <th>
                                            Description
                                        </th>
                                        <th>
                                            Task Points
                                        </th>
                                        <th>
                                            Due Date
                                        </th>
                                        <th>
                                            Status
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="5">
                                            No pending tasks available.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <HeaderStyle CssClass="gridheader" />
                        </asp:GridView>
                    </div>
                </td>
                <td valign="top">
                    <div style="background: #C0C0C0; height: 30px; padding: 2px;">
                        <b>Current Goal:</b>
                    </div>
                    <div style="">
                        <b>Points to be accomplished</b>
                        <asp:Literal ID="ltlWeeklyPoints" runat="server"></asp:Literal>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <div style="width: 100%;">
            <h3>
                Roommates Tasks
            </h3>
            <div class="gridcontainer">
                <asp:GridView ID="gvAllTasks" runat="server" AutoGenerateColumns="False" DataKeyNames="TaskId,Status"
                    Width="80%" class="table table-hover" OnRowCommand="gvAllTasks_RowCommand" OnRowDataBound="gvAllTasks_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Task" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lblTaskTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskTitle", "") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="lblTaskDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskDescription", "") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assigned To" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbltaskassign" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName", "") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:MM/dd/yyyy}"
                            HeaderStyle-Width="10%" />
                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="lbltaskstatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status", "") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Button ID="btnAssignToSelf" runat="server" Text="AssignToSelf" CommandName="AssignToSelf" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="table emptytable">
                            <tr>
                                <th>
                                    Task
                                </th>
                                <th>
                                    Description
                                </th>
                                <th>
                                    Assigned To
                                </th>
                                <th>
                                    Due Date
                                </th>
                                <th>
                                    Status
                                </th>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    No pending tasks available.
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <HeaderStyle CssClass="gridheader" />
                </asp:GridView>
            </div>
            <b>Note:</b> Task highlighted in <span style="color: Red; font-weight: bold;">Red</span>
            indicates overdue tasks
        </div>
    </div>
</asp:Content>
