<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ResetPwd.aspx.cs" Inherits="Admin_ResetPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    $(function () {
        $('#btnSubmit').click(function () {
            var o = $('#txtNewPwd');
            if (o.val() == '') {
                o.focus();
                return false;
            }
        });

        $('#txtNewPwd').focus();
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<asp:Label ID="lblHeader" runat="server"></asp:Label>

<div id="divContent" runat="server">
    <p>
        Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
    </p>
    <span class="failureNotification">
        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="ResetPasswordValidationSummary" runat="server" CssClass="failureNotification" 
         ValidationGroup="ResetPasswordValidationGroup"/>

    <asp:TextBox ID="Password" TextMode="Password" ClientIDMode="Static" runat="server" PlaceHolder="New Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ToolTip="Password is required." ErrorMessage="Password is required." 
        ValidationGroup="ResetPasswordValidationGroup" ControlToValidate="Password" CssClass="error">*</asp:RequiredFieldValidator>
    <br />
    
    <asp:TextBox ID="ConfirmPassword" TextMode="Password" ClientIDMode="Static" runat="server" PlaceHolder="Confirm New Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ToolTip="Confirm password is required." ErrorMessage="Confirm password is required." 
        ValidationGroup="ResetPasswordValidationGroup" ControlToValidate="ConfirmPassword" CssClass="error">*</asp:RequiredFieldValidator>
    <br />

    <asp:CompareValidator ID="CompareValidator" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
        CssClass="failureNotification" Display="None" ErrorMessage="The Password and Confirmation Password must match."
        ValidationGroup="ResetPasswordValidationGroup">*</asp:CompareValidator>
    <br />

    <asp:Button ID="btnSubmit" ClientIDMode="Static" runat="server" 
        ValidationGroup="ResetPasswordValidationGroup" Text="Reset Password" OnClick="btnSubmit_OnClick" />
    <p><asp:Label ID="lblInfo" runat="server"></asp:Label></p>
</div>

</asp:Content>

