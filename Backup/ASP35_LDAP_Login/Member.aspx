<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member.aspx.cs" Inherits="Member" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Authenticated Page</h1>
    <p><a href="Default.aspx">Home Page</a></p>
    
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    
    <p><!--Login Status Control: --><asp:LoginStatus runat="server" /></p>
    <!--
    <p>Manual Logout: <asp:LinkButton ID="btnLogout" Text="Logout" runat="server" OnClick="btnLogout_OnClick"></asp:LinkButton></p>
    -->
    
    </div>
    </form>
</body>
</html>
