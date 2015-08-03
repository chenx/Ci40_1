<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Admin_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $('#btnDeleteRole').click(function () {
            var role = $('#dlRoles').val();
            if (role == null || role === '') {
                alert('Please select a role to delete');
                return false;
            }
            if (!confirm('Are you sure to irrevisibly delete role "' + role + '"?')) {
                return false;
            }
        });

        $('#btnManageUsers').click(function () {
            var role = $('#dlRoles').val();
            if (role == null || role === '') {
                alert('Please select a role to manage');
                return false;
            }        
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Manage Roles</h1>
<br />

<asp:Button ID="btnCreateRole" Text="Create New Role" runat="server" OnClick="btnCreateRole_OnClick" />
<asp:TextBox ID="txtNewRole" runat="server" placeholder="Role Name"></asp:TextBox>
<asp:Label ID="lblMsg" runat="server"></asp:Label>

<br /><br />
Existing Roles:  <br />
<asp:DropDownList ID="dlRoles" runat="server" ClientIDMode="Static" size="5" style="vertical-align: top; width:200px;"></asp:DropDownList>
<asp:Button ID="btnDeleteRole" ClientIDMode="Static" Text = "Delete Role" runat="server" OnClick="btnDeleteRole_OnClick" />
<asp:Button ID="btnManageUsers" ClientIDMode="Static" Text = "Manage Role Users" runat="server" OnClick="btnManageUsers_OnClick" />
<asp:Label ID="lblInfo" runat="server"></asp:Label>

</asp:Content>

