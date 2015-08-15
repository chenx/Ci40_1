using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_ResetPwd : System.Web.UI.Page
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
<h1><a href=""Users.aspx"">Users</a> &gt; <a href=""UserProfile.aspx?u={0}"">User Profile</a> &gt; Reset Password</h1>
<p>
<b>User Name:</b> {0} <br/>
<b>Email:</b> {1} <br/>
{2}
</p>
", UserName, CurrentEmail, ClsMembership.getMemberRoles(UserName));

        lblHeader.Text = s;
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e) {
        string pwd = Password.Text;
        string pwd2 = ConfirmPassword.Text;

        List<string> errors = ClsMembership.ValidatePassword(pwd, pwd2);

        int n;
        if ((n = errors.Count) > 0)
        {
            string msg = "";
            for (int i = 0; i < n; ++i) {
                msg += string.Format("<li>{0}</li>", errors[i]);
            }
            msg = "<ul>" + msg + "</ul>";
            ErrorMessage.Text = msg;
            lblInfo.Text = "";
        }
        else
        {
            ErrorMessage.Text = "";
            ClsMembership.ResetPassword(UserName, pwd);
            lblInfo.ForeColor = System.Drawing.Color.Green;
            lblInfo.Text = "The user's password has been successfully reset.";
        }
    }
}