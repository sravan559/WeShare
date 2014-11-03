<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs" Inherits="WeShare.WebForms.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="inputcontainer">
        <table style="min-width: 400px;">
            <tr>
                <th>
                    Select Group:
                </th>
                <td>
                    <asp:DropDownList ID="ddlGroups" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    User ID:
                </th>
                <td>
                    <asp:TextBox ID="txtUserId" runat="server" placeholder="abc@xyz.com"></asp:TextBox>
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
        <asp:GridView ID="gvUsersInGroup" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvUsersInGroup_RowDeleting"
            DataKeyNames="UserId">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="User ID" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDeleteUser" runat="server" CommandName="Delete" ToolTip="Delete user from group?"
                            OnClientClick="return confirm('Are you sure?')" AlternateText="Delete" ImageUrl="~/Images/img_delete.gif"
                            CssClass="imagebutton" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
