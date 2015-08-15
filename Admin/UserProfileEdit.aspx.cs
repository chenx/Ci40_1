using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_UserProfileEdit : System.Web.UI.Page
{
    private string UserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = ClsUtil.ObjToStr(Request["u"]);
        if (Membership.GetUser(UserName) == null) {
            lblContent.Text = "<p>Unknown user: " + UserName + "</p>";
            return;
        }

        if (!IsPostBack)
        {
            init();
        }
        else
        {
            if (Request["btnSubmit"] != null)
            {
                string errMsg = new ClsProfile().saveProfile(UserName, Request);
                init();
                if (errMsg != "")
                {
                    errMsg = "<div class=\"error\">" + errMsg.Replace("\n", "<br/>") + "</div>";
                    lblContent.Text += errMsg;
                }
                else
                {
                    lblContent.Text +=
                        "<div class=\"info\">Profile of user '" + UserName + "' is updated.</div><script>$('.info').hide('fade', {}, 5000);</script>";
                }
            }
        }
    }

    private void init()
    {
        ProfileCommon user = (ProfileCommon)ProfileCommon.Create(UserName, false);
        ClsProfile p = new ClsProfile();
        lblMembership.Text = p.getMembershipInfo(UserName, true, false);
        lblContent.Text = p.getProfileEdit(user, "USA");
    }
}