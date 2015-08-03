<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
    .logon 
    {
        width: 150px;    
    }
    </style>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
    <div style="width:250px; margin:0 auto; text-align:left;">
       
        <div style="text-align:center;"><h1>Login</h1></div>
        <div>
            <table cellpadding="1" cellspacing="1" style="background-color: #E0E0E0; border: 1px solid #727272; width:100%; padding:10px;">
            
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLoginID" cssclass="logon" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblpwd" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" cssclass="logon" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        Domain
                    </td>
                    <td>
                        <asp:DropDownList ID="dlDomain" cssclass="logon" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align:center;"><p><a href="Default.aspx">Home Page</a></p></div>
    </div>
    </form>
</body>
</html>
