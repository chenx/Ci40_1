using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Collections;

public partial class Account_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) init();        
    }

    private void init() {
        ClsProfile p = new ClsProfile();
        lblMembership.Text = p.getMembershipInfo(User.Identity.Name, true);
        lblContent.Text = p.getProfileView(Profile);
    }
}