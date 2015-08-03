<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <title>Login</title>
    <style type="text/css">
    .logon 
    {
        width: 150px;    
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div style="width:280px; margin:0 auto; text-align:left;">       
        <div style="text-align:center;"><h1>Login</h1></div>
        <div>
            <table cellpadding="1" cellspacing="1" style="background-color: #E0E0E0; border: 1px solid #727272; width:100%; padding:10px;">
            
                <tr>
                    <td><asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label></td>
                    <td><asp:TextBox ID="txtLoginID" cssclass="logon" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><asp:Label ID="lblpwd" runat="server" Text="Password:"></asp:Label></td>
                    <td><asp:TextBox ID="txtPassword" cssclass="logon" TextMode="Password" runat="server"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td>Domain:</td>
                    <td><asp:DropDownList ID="dlDomain" cssclass="logon" runat="server"></asp:DropDownList></td>
                </tr>
                                
                <tr>
                    <td><br /></td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnCancel_Click" />
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

</asp:Content>

