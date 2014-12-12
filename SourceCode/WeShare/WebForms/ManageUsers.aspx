<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs" Inherits="WeShare.WebForms.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label for="ddlGroups" class="col-sm-2 control-label">
                Select Group</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlGroups" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged" Width="50%" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="txtUserId" class="col-sm-2 control-label">
                User ID</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtUserId" runat="server" placeholder="abc@xyz.com" Width="50%"
                    class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtWeeklyPoints" class="col-sm-2 control-label">
                Weekly Points</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtWeeklyPoints" runat="server" Width="50%" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtRecurrenceStartDate" class="col-sm-2 control-label">
                Recurrence Start Date</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtRecurrenceStartDate" runat="server" Width="50%" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10" align="left">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-info"
                    BorderColor="Black" />
            </div>
        </div>
    </div>
    <div class="gridcontainer">
        <asp:GridView ID="gvUsersInGroup" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUsersInGroup_RowCommand"
            OnRowDeleting="gvUsersInGroup_RowDeleting"
            DataKeyNames="UserId,WeeklyPoints,RecurrenceDate" class="table table-hover">
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="User ID" />
                <asp:BoundField DataField="Name" HeaderText="User Name" />
                <asp:BoundField DataField="WeeklyPoints" HeaderText="Weekly Points" />
                <asp:BoundField DataField="RecurrenceDate" HeaderText="Recurrence Date" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EditUser" AlternateText="Edit"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif"
                            CssClass="imagebutton" />
                        <asp:ImageButton ID="imgDeleteUser" runat="server" align="center" CommandName="Delete"
                            ToolTip="Delete user from group?" OnClientClick="return confirm('Are you sure?')"
                            AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" CssClass="imagebutton" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="table emptytable">
                    <tr>
                        <th>
                            User ID
                        </th>
                    </tr>
                    <tr>
                        <td>
                            There are no users in this group!
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <HeaderStyle CssClass="gridheader" />
        </asp:GridView>
    </div>
    <script type="text/javascript">

        $("#<%=txtRecurrenceStartDate.ClientID %>").datepicker({ minDate: 0 });
    </script>
</asp:Content>
