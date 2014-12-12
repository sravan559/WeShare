<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateOffSetManager.ascx.cs"
    Inherits="WeShare.WebForms.DateOffSetManager" %>
<div class="form-horizontal">
    <div class="form-group">
        <label for="ddlGroups" class="col-sm-2 control-label">
            Enter Date Offset value</label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtDateOffset" runat="server"> </asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10" align="left">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" class="btn btn-info"
                BorderColor="Black" />
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
    </div>
</div>
