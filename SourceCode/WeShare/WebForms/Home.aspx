<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="WeShare.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <div class="gridcontainer">
        <h1>
            My Tasks
        </h1>
        <div class="grid">
            <asp:GridView ID="gvMyTasks" runat="server" AutoGenerateColumns="false" Width="80%">
                <Columns>
                    <asp:BoundField DataField="TaskTitle" HeaderText="Task Title" />
                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
                <HeaderStyle BackColor="LightBlue" />
                <EmptyDataTemplate>
                    <table class="emptytable">
                        <tr>
                            <th>
                                Task Title
                            </th>
                            <th>
                                Due Date
                            </th>
                            <th>
                                Status
                            </th>
                        </tr>
                        <tr>
                            <td colspan="3">
                                No data available.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
</asp:Content>
