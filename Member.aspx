<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div>
    <h1>Authenticated Page</h1>
    <p><a href="Default.aspx">Home Page</a></p>
    
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    
    <p><!--Login Status Control: --><asp:LoginStatus ID="LoginStatus1" runat="server" /></p>
    <!--
    <p>Manual Logout: <asp:LinkButton ID="btnLogout" Text="Logout" runat="server" OnClick="btnLogout_OnClick"></asp:LinkButton></p>
    -->
    
    </div>
   

</asp:Content>

