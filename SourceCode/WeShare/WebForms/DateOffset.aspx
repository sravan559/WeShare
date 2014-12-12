<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/WeShare.Master" AutoEventWireup="true"
    CodeBehind="DateOffset.aspx.cs" Inherits="WeShare.WebForms.DateOffset" %>

<%@ Register TagPrefix="uc" TagName="DateOffset" Src="~/WebForms/DateOffSetManager.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphBody" runat="server">
    <uc:DateOffset id="ucDateOffset" runat="server">
    </uc:DateOffset>
</asp:Content>
