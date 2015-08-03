<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="Admin_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1><a href="Users.aspx">Users</a> &gt; User Profile</h1>

<asp:Label ID="lblMembership" runat="server"></asp:Label>

<p>[ <a href="UserProfileEdit.aspx?u=<% =Request["u"] %>">Update Profile</a> ]</p>
<asp:Label ID="lblContent" runat="server"></asp:Label>

</asp:Content>

