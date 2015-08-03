using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_EmailEdit : System.Web.UI.Page
{
    private string UserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = ClsUtil.ObjToStr(Request["u"]);
        if (UserName == "" || Membership.GetUser(UserName) == null)
        {
            lblHeader.Text = "<p>Unknown user: " + UserName + "</p>";
            divContent.Visible = false;
            return;
        }

        if (! IsPostBack) init();
    }

    private void init() {
        MembershipUser u = Membership.GetUser(UserName);
        string CurrentEmail = u == null ? "" : u.Email;
        string s = string.Format(@"
<h1><a href=""Users.aspx"">Users</a> &gt; <a href=""UserProfile.aspx?u={0}"">User Profile</a> &gt; Edit Email</h1>
<p>
<b>User:</b> {0} <br/>
<b>Current Email:</b> {1} 
</p>
", UserName, CurrentEmail);

        lblHeader.Text = s;
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e) {
        new ClsEmail().UpdateEmail(txtNewEmail.Text.Trim(), UserName, lblInfo);
        init();
    }
}