<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs" Inherits="WeShare.WebForms.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="text-align: center;">
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
                        <td>
                            <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <br />
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUsers_RowCommand"
                    DataKeyNames="EmailId,FirstName" OnRowDeleting="gvUsers_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EditUser" AlternateText="Edit"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif" />
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                                    AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="LightBlue" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
