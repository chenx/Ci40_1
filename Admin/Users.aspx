<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    function ajax_update(cmd, user, val, succeed_action, fail_action) {
        $.ajax({
            url: 'Handler.ashx',
            data: { cmd: cmd, user: user, val: val },
            dataType: 'html',
            success: function (data, textStatus, jqXHR) {
                if (data == 'ok') {
                   if (succeed_action != null) { eval(succeed_action); }
                }
                else {
                    alert('Error: ' + data);
                    if (fail_action != null) { eval(fail_action); }
                }
            },
            cache: false
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Manage Users</h1>

<p><a href="CreateNewUser.aspx">Create New User</a></p>

<asp:Label ID="lblContent" ClientIDMode="Static" runat="server"></asp:Label>

<script type="text/javascript">
    function do_lockout(user) {
        /*var o = document.getElementById('lockout_' + user);
        var IsLockedOut = (! o.checked);
        var msg = IsLockedOut ? 'Are you sure to unlock user ' : 'Are you sure to lock out user ';
        if (!confirm(msg + '\"' + user + '\"?')) {
            //alert(document.getElementById('lockout_' + User));
            o.checked = ! o.checked;
            return;
        }
        */

        var succeed_action = "document.getElementById('lockout_" + user + "').disabled = true;";
        var fail_action = "document.getElementById('lockout_" + user + "').checked = true;";
        ajax_update('lockout', user, 0, succeed_action, fail_action);
    }

    function do_approval(user) {
        var o = document.getElementById('approval_' + user);
        var IsApproved = (!o.checked);

        var succeed_action = null; 
        var fail_action = "document.getElementById('approval_" + user + "').checked = " + (IsApproved) + ";";
        ajax_update('approve', user, IsApproved ? 0 : 1, succeed_action, fail_action);
    }

    function do_role(user, role) {
        var id = 'role_' + user + '_' + role;
        var o = document.getElementById(id);
        var IsChecked = (!o.checked);

        var succeed_action = null;
        var fail_action = "document.getElementById('" + id + "').checked = " + (IsChecked) + ";";
        ajax_update('role', user + "_" + role, IsChecked ? 0 : 1, succeed_action, fail_action);
    }
</script>

</asp:Content>

