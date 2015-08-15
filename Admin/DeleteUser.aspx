<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DeleteUser.aspx.cs" Inherits="Admin_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1><a href="Users.aspx">Users</a> &gt; <a href="UserProfile.aspx?u=<% =ClsUtil.ObjToStr(Request["u"]) %>">User Profile</a> &gt; Delete User</h1>

<p>
<a href="?u=<% =ClsUtil.ObjToStr(Request["u"]) %>&action=delete" 
onclick="return confirm('Are you sure to permanently delete this user?');" style="color:Red; font-weight:bold;">
Permanently Delete This User</a>
</p>

<asp:Label ID="lblMembership" runat="server"></asp:Label>

<asp:Label ID="lblContent" runat="server"></asp:Label>

</asp:Content>

