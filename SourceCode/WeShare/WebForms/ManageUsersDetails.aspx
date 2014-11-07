<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageUsersDetails.aspx.cs" Inherits="WeShare.WebForms.ManageUsersDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="inputcontainer">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="txtFirstName" class="col-sm-2 control-label">
                                First Name</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtFirstName" placeholder="Enter First Name" input="text" class="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtLastName" class="col-sm-2 control-label">
                                Last Name</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtLastName" placeholder="Enter Last Name" input="text" class="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtEmailAddress" class="col-sm-2 control-label">
                                Email Address</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtEmailAddress" placeholder="email@example.com" input="text" class="form-control"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtContactNumber" class="col-sm-2 control-label">
                                Contact</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtContactNumber" placeholder="Enter Contact number" input="text"
                                    class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-info"
                                    BorderColor="Black" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" class="btn btn-info"
                                    BorderColor="Black" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="gridcontainer1">
                <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUsers_RowCommand"
                    DataKeyNames="UserId,FirstName,LastName,ContactNumber" OnRowDeleting="gvUsers_RowDeleting"
                    Width="90%" class="table table-hover" AllowPaging="true">
                    <Columns>
                        <asp:BoundField DataField="UserId" HeaderText="Email ID" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" HeaderStyle-Width="20%" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" HeaderStyle-Width="20%" />
                        <asp:TemplateField HeaderText="Edit | Delete" HeaderStyle-Width="10%">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEditUser" runat="server" CommandName="EditUser" AlternateText="Edit"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif"
                                    CssClass="imagebutton" ToolTip="Edit User Details" />
                                <asp:ImageButton ID="igDeleteUser" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                                    AlternateText="Delete User" ToolTip="Delete User" ImageUrl="~/Images/img_delete.gif"
                                    CssClass="imagebutton" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="table emptytable">
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
                    <HeaderStyle CssClass="gridheader" />
                </asp:GridView>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
