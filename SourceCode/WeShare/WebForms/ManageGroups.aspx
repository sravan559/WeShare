<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageGroups.aspx.cs" Inherits="WeShare.WebForms.ManageGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="inputcontainer">
        <table style="min-width: 400px;">
            <tr>
                <th>
                    Group Name:
                </th>
                <td>
                    <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn" />
                   
                </td>
            </tr>
        </table>
    </div>
    <div class="gridcontainer">
        <asp:GridView ID="gvUserGroups" runat="server" DataKeyNames="GroupId" AutoGenerateColumns="false"
            OnRowCommand="gvUserGroups_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GroupName" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEditGroup" runat="server" CommandName="EditGroup" AlternateText="Edit"
                            ImageUrl="~/Images/img_edit.gif" />
                        <asp:ImageButton ID="imgDeleteGroup" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure, you want to delete?')"
                            AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="emptytable">
                    <tr>
                        <th>
                            Group Name
                        </th>
                    </tr>
                    <tr>
                        <td>
                            No groups found. Create a new group.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
