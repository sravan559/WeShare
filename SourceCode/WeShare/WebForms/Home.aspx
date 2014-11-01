﻿<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="WeShare.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="grid container">
        <h1>
            Tasks Assigned to me..
        </h1>
        <div class="grid1">
            <asp:GridView ID="gvMyTasks" runat="server" AutoGenerateColumns="False" DataKeyNames="Task_Id"
                Width="80%">
                <Columns>
                    <asp:TemplateField HeaderText="Task id">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskId", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Task">
                        <ItemTemplate>
                            <asp:Label ID="lbltasktitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskTitle", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskdesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TaskDescription", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finish by">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskduedate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DueDate", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskstatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnstatus" runat="server" CommandName="StatusChange" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Mark as Complete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="LightBlue" />
                <EmptyDataTemplate>
                    <table class="emptytable">
                        <tr>
                            <th>
                                Task ID
                            </th>
                            <th>
                                Task
                            </th>
                            <th>
                                Description
                            </th>
                            <th>
                                Finish by
                            </th>
                            <th>
                                Status
                            </th>
                        </tr>
                        <tr>
                            <td colspan="5">
                                No data available.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <h1>
            List of all tasks..
        </h1>
        <div class="grid2">
            <asp:GridView ID="gvAllTasks" runat="server" AutoGenerateColumns="False" DataKeyNames="Task_Id"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Task id">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Task_Id", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Task">
                        <ItemTemplate>
                            <asp:Label ID="lbltasktitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Task_Title", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskdesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Task_Description", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assigned to">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskassign" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "First_Name", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finish by">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskduedate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Due_Date", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lbltaskstatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status", "") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="LightBlue" />
                <EmptyDataTemplate>
                    <table class="emptytable">
                        <tr>
                            <th>
                                Task ID
                            </th>
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
                                Finish by
                            </th>
                            <th>
                                Status
                            </th>
                        </tr>
                        <tr>
                            <td colspan="6">
                                No data available.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
