<%@ Page Title="" Language="C#" MasterPageFile="WeShare.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="WeShare.WebForms.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <h1>
        My Tasks
    </h1>
    <div>
        <asp:GridView ID="gvMyTasks" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TaskTitle" HeaderText="Task Title" />
                <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
