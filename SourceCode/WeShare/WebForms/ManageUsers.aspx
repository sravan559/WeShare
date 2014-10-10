<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs" Inherits="WeShare.WebForms.ManageUsers" %>

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
            <div class="grid" >
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUsers_RowCommand"
                    DataKeyNames="EmailId,FirstName,LastName,ContactNumber" OnRowDeleting="gvUsers_RowDeleting"
                    Width="80%">
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
                            <th>Contact Number</th>
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
