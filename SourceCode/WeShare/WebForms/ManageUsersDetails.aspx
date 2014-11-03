<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageUsersDetails.aspx.cs" Inherits="WeShare.WebForms.ManageUsersDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="inputcontainer">
                <asp:Panel runat="server" BackColor="#CCCCCC" BorderColor="Black" BorderStyle="Solid">
                    <table>
                        <tr>
                            <th>
                                First Name:
                            </th>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                            </td>
                            <th>
                                Last Name:
                            </th>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Email Address:
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                            </td>
                            <th>
                                Contact Number:
                            </th>
                            <td id="panel1">
                                <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center;">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="gridcontainer">
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUsers_RowCommand"
                    DataKeyNames="UserId,FirstName,LastName,ContactNumber" OnRowDeleting="gvUsers_RowDeleting"
                    Width="90%">
                    <Columns>
                        <asp:BoundField DataField="UserId" HeaderText="Email ID" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" HeaderStyle-Width="10%" />
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEditUser" runat="server" CommandName="EditUser" AlternateText="Edit"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif"
                                    CssClass="imagebutton" ToolTip="Edit User Details"/>
                                <asp:ImageButton ID="igDeleteUser" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                                    AlternateText="Delete User" ToolTip="Delete User" ImageUrl="~/Images/img_delete.gif" CssClass="imagebutton" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="emptytable">
                            <tr>
                                <th>
                                    Email ID
                                </th>
                                <th>
                                    First Name
                                </th>
                                <th>
                                    Last Name
                                </th>
                                <th>
                                    Contact Number
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
