<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>LDAP Login Demonstration</h1>
    </div>

    <p>Login authentication using LDAP (Active Directory) for ASP.NET applications. LDAP setting is stored in web.config.</p>
    <ul>
    <li>Code here is modified from: http://www.dotnetgallery.com/kb/resource6-Login-authentication-using-LDAP-Active-Directory-for-ASPNET-applications.aspx</li>
    <li>Another reference: https://msdn.microsoft.com/en-us/library/ms180890%28v=vs.80%29.aspx</li>
    </ul>
    
    <div>
    <!--Login View Control:-->
    <asp:LoginView ID="LoginView" runat="server" EnableViewState="false">
        <AnonymousTemplate>
            You are not logged in yet.
        </AnonymousTemplate>
        <LoggedInTemplate>
            You are logged in. <a href="Member.aspx">Member Page</a>. 
        </LoggedInTemplate>
    </asp:LoginView>
  
    <!--Login Status Control: --><asp:LoginStatus ID="LoginStatus1" runat="server" />
    </div>
               
    </form>
</body>
</html>
