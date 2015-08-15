using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_UserProfile : System.Web.UI.Page
{
    private string UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = ClsUtil.ObjToStr(Request["u"]);
        if (UserName == "" || Membership.GetUser(UserName) == null)
        {
            lblContent.Text = "<p>Unknown user: " + UserName + "</p>";
            return;
        }

        string action = ClsUtil.ObjToStr(Request["action"]);
        if (action == "delete") {
            ClsMembership.DeleteUser(UserName);
            Response.Redirect("Users.aspx");
            Response.End();
            return;
        }

        if (!IsPostBack) {
            init();
        }
    }

    private void init() {
        ProfileCommon user = (ProfileCommon)ProfileCommon.Create(UserName, false);
        ClsProfile p = new ClsProfile();
        lblMembership.Text = p.getMembershipInfo(UserName, true, false);
        lblContent.Text = p.getProfileView(user);
    }
}