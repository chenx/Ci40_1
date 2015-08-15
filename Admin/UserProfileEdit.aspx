<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserProfileEdit.aspx.cs" Inherits="Admin_UserProfileEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1><a href="Users.aspx">Users</a> &gt; <a href="UserProfile.aspx?u=<% =Request["u"] %>">User Profile</a> &gt; Update Profile</h1>

<asp:Label ID="lblMembership" runat="server"></asp:Label>
<asp:Label ID="lblContent" runat="server"></asp:Label>

</asp:Content>

