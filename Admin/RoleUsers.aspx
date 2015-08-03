<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RoleUsers.aspx.cs" Inherits="Admin_RoleUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $('#btnAddRoleUser').click(function () {
            //var user = $('#dlNonRoleUsers option:selected').text();
            var user = $('#dlNonRoleUsers').val();
            if (user == null || user === '') {
                alert('Please select a user to add to role');
                return false;
            }
        });

        $('#btnRemoveRoleUser').click(function () {
            //var user = $('#dlRoleUsers option:selected').text();
            var user = $('#dlRoleUsers').val();
            if (user == null || user === '') {
                alert('Please select a user to remove from role');
                return false;
            }
        });
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1><a href="Roles.aspx">Roles</a> &gt; Role Users</h1>

<p>This page can be improved by allowing multiple selection.</p>

<h2>Role: <span runat="server" id="divRole" ></span></h2>
<br />

<div id="divContent" runat="server">

<div id="divUsersInRole">
Users in role:  <br />
<asp:DropDownList ID="dlRoleUsers" runat="server" ClientIDMode="Static" size="5" style="vertical-align: top; width:200px;"></asp:DropDownList>
<asp:Button ID="btnRemoveRoleUser" ClientIDMode="Static" Text = "Remove User From Role" runat="server" OnClick="btnRemoveRoleUser_OnClick" />
<asp:Label ID="lblMsgRemove" runat="server"></asp:Label>
</div>
<br />

<div id="divUsersNotInRole">
Users not in role: <br />
<asp:DropDownList ID="dlNonRoleUsers" runat="server" ClientIDMode="Static" size="5" style="vertical-align:top; width:200px;"></asp:DropDownList>
<asp:Button ID="btnAddRoleUser" ClientIDMode="Static" Text="Add User To Role" runat="server" OnClick="btnAddRoleUser_OnClick" />
<asp:Label ID="lblMsgAdd" runat="server"></asp:Label>
</div>
<br />

</div>

<p><asp:Label ID="lblInfo" ClientIDMode="Static" runat="server"></asp:Label></p>

</asp:Content>

