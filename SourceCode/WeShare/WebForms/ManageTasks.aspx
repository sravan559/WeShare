﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageTasks.aspx.cs" Inherits="WeShare.WebForms.ManageTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="inputcontainer">
        <asp:Panel ID="Panel1" BackColor="#CCCCCC" runat="server" BorderColor="Black" BorderStyle="Solid">
            <table style="min-width: 400px;">
                <tr>
                    <th>
                        Task Name:
                    </th>
                    <td>
                        <asp:TextBox ID="txtTaskName" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        Points Alloted:
                    </th>
                    <td>
                        <asp:TextBox ID="txtTaskPoints" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        Task Description:
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="txtTaskDesc" runat="server" TextMode="MultiLine" Rows="5" Columns="30"
                            Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        TaskType:
                    </th>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rbTaskType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                            <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <th>
                        Is this task recursive?
                    </th>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rbTaskRecursive" runat="server" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:HiddenField ID="hdnTaskId" runat="server" />
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <h3>
        List of tasks...</h3>
    <div class="grid">
        <asp:GridView ID="gvtasks" runat="server" AutoGenerateColumns="false" OnRowCommand="gvtasks_RowCommand"
            DataKeyNames="TaskId,TaskTitle,TaskDescription,PointsAllocated" OnRowDeleting="gvtasks_RowDeleting"
            Width="100%">
            <Columns>
                <asp:BoundField DataField="TaskTitle" HeaderText="Task Name" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Description" />
                <asp:BoundField DataField="PointsAllocated" HeaderText="Points" />
               
                
               <asp:TemplateField HeaderText ="Type">
               <ItemTemplate>
               <asp:Label ID="lblTaskType" runat="server" Text='<%# Eval("TaskType") %>'></asp:Label>
               </ItemTemplate>
               <EditItemTemplate>
               <asp:RadioButtonList ID="rbTaskType" runat="server" >
               <asp:ListItem>Weekly</asp:ListItem>
               <asp:ListItem>Monthly</asp:ListItem>
               </asp:RadioButtonList>
               </EditItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText ="Type">
               <ItemTemplate>
               <asp:Label ID="lblTaskRecursive" runat="server" Text='<%# Eval("TaskRecursive") %>'></asp:Label>
               </ItemTemplate>
               <EditItemTemplate>
               <asp:RadioButtonList ID="rbTaskRecursive" runat="server" >
               <asp:ListItem>Yes</asp:ListItem>
               <asp:ListItem>No</asp:ListItem>
               </asp:RadioButtonList>
               </EditItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EditTask" AlternateText="Edit"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                            AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" />
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
                            Description
                        </th>
                        <th>
                            Points
                        </th>
                    </tr>
                    <tr>
                        <td colspan="5">
                            No data available.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <HeaderStyle BackColor="LightBlue" />
        </asp:GridView>
    </div>
</asp:Content>
