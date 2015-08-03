using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            //Response.Redirect("Logon.aspx");
            FormsAuthentication.RedirectToLoginPage();
        }
        lblMsg.Text = ("Hi, " + User.Identity.Name + ", You are authenticated. Authentication Type: " + User.Identity.AuthenticationType);
    }

    protected void btnLogout_OnClick(object sender, EventArgs args)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }
}