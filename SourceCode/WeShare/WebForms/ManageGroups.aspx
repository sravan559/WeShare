<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageGroups.aspx.cs" Inherits="WeShare.WebForms.ManageGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label for="ddlGroups" class="col-sm-2 control-label">
                Group Name</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtGroupName" runat="server" Width="50%"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10" align="left">
                <asp:HiddenField ID="hdnCurrentGroupName" runat="server" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-info"
                    BorderColor="Black" />
            </div>
        </div>
    </div>
    <div class="gridcontainer">
        <asp:GridView ID="gvUserGroups" runat="server" DataKeyNames="GroupName" AutoGenerateColumns="false"
            OnRowCommand="gvUserGroups_RowCommand" class="table table-hover">
            <Columns>
                <asp:TemplateField HeaderText="S.No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GroupName" HeaderText="Group Name" />
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
                <table class="table">
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
