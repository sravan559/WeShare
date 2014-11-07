<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="ManageTasks.aspx.cs" Inherits="WeShare.WebForms.ManageTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label for="ddlGroups" class="col-sm-2 control-label">
                Select Group</label>
            <div class="col-sm-10">
                <asp:DropDownList ID="ddlGroups" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                    Width="100%" OnSelectedIndexChanged="ddlGroups_SelectedIndexChanged" class="form-control">
                    <asp:ListItem Text="Select Group" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <label for="txtTaskName" class="col-sm-2 control-label">
                Task Name</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTaskName" input="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtTaskPoints" class="col-sm-2 control-label">
                Points</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTaskPoints" input="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtTaskDesc" class="col-sm-2 control-label">
                Task Description</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtTaskDesc" input="text" class="form-control" runat="server" TextMode="MultiLine"
                    Rows="5" Columns="30"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="rbtnTaskRecursive" class="col-sm-2 control-label">
                Is the Task Recursive</label>
            <div class="col-sm-10">
                <asp:RadioButtonList ID="rbtnTaskRecursive" runat="server" RepeatDirection="Horizontal"
                    class="form-control">
                    <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group" id="trRecursionType" style="display: none;">
            <label for="rbTaskType" class="col-sm-2 control-label">
                Recursive Type</label>
            <div class="col-sm-10">
                <asp:RadioButtonList ID="rbtnTaskType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10" align="center">
                <asp:HiddenField ID="hdnTaskId" runat="server" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-info"
                    BorderColor="Black" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" class="btn btn-info"
                    BorderColor="Black" />
            </div>
        </div>
    </div>
    <h3>
        List of Tasks</h3>
    <div class="grid">
        <asp:GridView ID="gvtasks" runat="server" AutoGenerateColumns="false" OnRowCommand="gvtasks_RowCommand"
            DataKeyNames="TaskId,TaskTitle,TaskDescription,PointsAllocated,GroupName,TaskType,IsTaskRecursive" OnRowDeleting="gvtasks_RowDeleting"
            Width="100%" class="table table-hover" AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="TaskTitle" HeaderText="Task Name" />
                <asp:BoundField DataField="TaskDescription" HeaderText="Description" />
                <asp:BoundField DataField="PointsAllocated" HeaderText="Points" />
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label ID="lblTaskType" runat="server" Text='<%# Eval("TaskType") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="rbTaskType" runat="server">
                            <asp:ListItem>Weekly</asp:ListItem>
                            <asp:ListItem>Monthly</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Is Recursive?">
                    <ItemTemplate>
                        <asp:Label ID="lblTaskRecursive" runat="server" Text='<%# Eval("IsTaskRecursive") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="rbTaskRecursive" runat="server">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="EditTask" AlternateText="Edit"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Images/img_edit.gif"
                            CssClass="imagebutton" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?')"
                            AlternateText="Delete" ImageUrl="~/Images/img_delete.gif" CssClass="imagebutton" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table class="table table-hover">
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
            
        </asp:GridView>
    </div>
    <script type="text/javascript">
        $("#<%=rbtnTaskRecursive.ClientID%> input[type='radio']").click(function () {
            var isRecursive = $(this).val();
            if (isRecursive == "Yes") {
                $('#trRecursionType').css("display", "");
            }
            else {
                $('#trRecursionType').css("display", "none");
            }
        });
    </script>
</asp:Content>
