<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Account_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
</style>
<link href="../Styles/Site.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>My Profile</h1>

<asp:Label ID="lblMembership" runat="server"></asp:Label>

<p>[ <a href="ProfileEdit.aspx">Update Profile</a> ]</p>

<asp:Label ID="lblContent" runat="server"></asp:Label>

</asp:Content>

