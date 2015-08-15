using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class Account_Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ClsConfig.allowRegister())
        {
            Response.Redirect("../");
        }
        RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        string username = RegisterUser.UserName;
        AssignDefaultRoles(username);

        // If a user needs admin approval, or need email confirmation before gaining system access,
        // do this.
        //ClsMembership.DisapproveUser(username); 
        //Response.Redirect("RegisterConfirmation.aspx");

        // Code below will automatically sign the user in.
        FormsAuthentication.SetAuthCookie(username, false /* createPersistentCookie */);

        string continueUrl = RegisterUser.ContinueDestinationPageUrl;
        if (String.IsNullOrEmpty(continueUrl))
        {
            continueUrl = ResolveUrl("~/");
        }
        Response.Redirect(continueUrl);
    }

    private void AssignDefaultRoles(string username)
    {
        //Roles.AddUserToRole(username, ClsConfig.Role_Member);
    }
}
