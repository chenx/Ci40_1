using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// To center the login form, do:
/// - add '<div style="text-align:center;"></div>' to wrap the entire content.
/// - add 'style="margin:auto;"' to <div class="accountInfo">.
/// </summary>
public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // http://stackoverflow.com/questions/4834387/how-to-redirect-users-to-an-asp-net-page-when-not-authorized
        if (User.Identity.IsAuthenticated)
        {
            // if they came to the page directly, ReturnUrl will be null.
            if (String.IsNullOrEmpty(Request["ReturnUrl"]))
            {
                /* in that case, instead of redirecting, I hide the login 
                   controls and instead display a message saying that are 
                   already logged in. */
                Response.Redirect("~/");
            }
            else
            {
                // This happens when a signed in user tries to access a location the user has no access,
                // e.g., a member tries to access ~/Admin files.
                //Response.Redirect("~/AccessDenied.aspx");
                Response.Redirect("~/");
            }
        }
        
        if (!ClsConfig.allowRegister())
        {
            this.txtRegister.Visible = false;
        }
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void OnLoggedIn(object sender, EventArgs e)
    {
        Response.Redirect("../");
    }
}
