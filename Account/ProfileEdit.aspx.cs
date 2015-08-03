using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ProfileEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            init();
        }
        else
        {
            if (Request["btnSubmit"] != null)
            {
                string errMsg = new ClsProfile().saveProfile(User.Identity.Name, Request);
                init();
                if (errMsg != "")
                {
                    errMsg = "<div class=\"error\">" + errMsg.Replace("\n", "<br/>") + "</div>";
                    lblContent.Text += errMsg;
                }
                else {
                    lblContent.Text +=
                        "<div class=\"info\">Your profile is updated.</div><script>$('.info').hide('fade', {}, 5000);</script>";
                }
            }
        }
    }

    private void init() {
        lblContent.Text = new ClsProfile().getProfileEdit(Profile, "USA");
    }
}