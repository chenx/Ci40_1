using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    private string UserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = ClsUtil.ObjToStr(Request["u"]);
        if (UserName == "" || Membership.GetUser(UserName) == null)
        {
            lblContent.Text = "<p>Unknown user: " + UserName + "</p>";
            divContent.Visible = false;
            return;
        }

        ChangeUserPassword.CancelDestinationPageUrl = "UserProfile.aspx?u=" + UserName;
        ChangeUserPassword.UserName = UserName;        
    }
}
