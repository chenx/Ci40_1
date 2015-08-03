using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.DirectoryServices;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated) {
            Response.Redirect("Member.aspx");
            Response.End();
        }

        //string DomainName = HttpContext.Current.Request.Url.Host;
        //Response.Write("Your domain: " + DomainName);
        if (!IsPostBack)
        {
            dlDomain.Items.Add(new ListItem("(local)", ""));
            string dominName = ConfigurationManager.AppSettings["DirectoryName"].ToString();
            dlDomain.Items.Add(new ListItem(dominName, dominName));
            dlDomain.SelectedIndex = 1;
        }
        lblName.Focus();
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string dominName = string.Empty;
        string adPath = string.Empty;
        string userName = txtLoginID.Text.Trim().ToUpper();
        string strError = string.Empty;

        try
        {
            dominName = ConfigurationManager.AppSettings["DirectoryName"].ToString();
            adPath = ConfigurationManager.AppSettings["DirectoryPath"].ToString(); 

            if (!string.IsNullOrEmpty(dominName) && !string.IsNullOrEmpty(adPath))
            {
                //Response.Write(dominName + "\\" + userName + ":" + txtPassword.Text);
                if (true == AuthenticateUser(dominName, userName, txtPassword.Text, adPath, out strError))
                {
                    FormsAuthentication.SetAuthCookie(userName, true);
                    Response.Redirect("Member.aspx");// Authenticated user redirects to default.aspx
                }
                dominName = string.Empty;
                adPath = string.Empty;
            }

            if (!string.IsNullOrEmpty(strError))
            {
                lblError.Text = "Invalid user name or Password!";
            }
        }
        catch (Exception ex)
        {
            //lblError.Text = "Error: " + ex.Message;
            lblError.Text = "Error happens. Please contact System Administrator.";
        }
    }


    public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
    {
        Errmsg = "";
        string domainAndUsername = domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);

        try
        {
            // Bind to the native AdsObject to force authentication.
            object obj = entry.NativeObject;           
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();

            if (null == result)
            {
                return false;
            }

            // Update the new path to the user in the directory
            LdapPath = result.Path;
            string _filterAttribute = (String)result.Properties["cn"][0];
        }
        catch (Exception ex)
        {
            Errmsg = ex.Message;
            return false;
            throw new Exception("Error authenticating user." + ex.Message);
        }

        return true;
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtLoginID.Text = string.Empty;
        txtPassword.Text = string.Empty;
        Response.Redirect("Default.aspx");
    }
}
