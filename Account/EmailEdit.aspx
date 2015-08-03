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
<h1><a href="Profile.aspx">My Profile</a> &gt; Edit Email</h1>

<p><b>Current Email:</b> <% =Membership.GetUser(User.Identity.Name).Email %></p>

<asp:TextBox ID="txtNewEmail" ClientIDMode="Static" runat="server" PlaceHolder="New Email"></asp:TextBox>
<asp:Button ID="btnSubmit" ClientIDMode="Static" runat="server" Text="Update Email" OnClick="btnSubmit_OnClick" />

<p><asp:Label ID="lblInfo" runat="server"></asp:Label></p>

</asp:Content>

