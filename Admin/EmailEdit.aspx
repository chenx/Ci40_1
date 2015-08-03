<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmailEdit.aspx.cs" Inherits="Account_EmailEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    $(function () {
        $('#btnSubmit').click(function () {
            var o = $('#txtNewEmail');
            if (o.val() == '') {
                o.focus();
                return false;
            }
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:Label ID="lblHeader" runat="server"></asp:Label>

<div id="divContent" runat="server">
<asp:TextBox ID="txtNewEmail" ClientIDMode="Static" runat="server" PlaceHolder="New Email"></asp:TextBox>
<asp:Button ID="btnSubmit" ClientIDMode="Static" runat="server" Text="Update Email" OnClick="btnSubmit_OnClick" />
<p><asp:Label ID="lblInfo" runat="server"></asp:Label></p>
</div>

</asp:Content>

