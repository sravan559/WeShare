<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageTasks.aspx.cs" Inherits="WeShare.WebForms.ManageTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div style="width:60%">
    <asp:Panel ID="Panel1" BackColor="#CCCCCC" runat="server" BorderColor="Black" 
            BorderStyle="Solid">
        <table>
            <tr>
                <th>
                    Task Name:
                </th>
                <td>
                    <asp:TextBox ID="txtTaskName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Description:
                </th>
                <td>
                    <asp:TextBox ID="txtTaskDesc" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
                </td>
                <th>
                    Points Alloted:
                </th>
                <td>
                    <asp:TextBox ID="txtTaskPoints" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <asp:HiddenField ID="hdnTaskId" runat="server" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn"/>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn"/>
                </td>
            </tr>
        </table>
        </asp:Panel>
    </div>
    <div>
        <br />
        <asp:GridView ID="gvtasks" runat="server" AutoGenerateColumns="false" OnRowCommand="gvtasks_RowCommand"
            DataKeyNames="TaskId,TaskTitle,TaskDescription,PointsAllocated" OnRowDeleting="gvtasks_RowDeleting">
            <Columns>
                <asp:BoundField DataField="TaskTitle" HeaderText="Task Name" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Description" />
                <asp:BoundField DataField="PointsAllocated" HeaderText="Points" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EditTask" AlternateText="Edit"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                            AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="LightBlue" />
        </asp:GridView>
    </div>
</asp:Content>
