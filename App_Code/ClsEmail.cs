using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Modified from:
/// https://msdn.microsoft.com/en-us/library/01escwtf%28v=vs.110%29.aspx
/// Note the time parameter is available in .NET 4.5 and above.
/// </summary>
public class ClsEmail
{
    private bool invalid = false;

	public ClsEmail()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public void UpdateEmail(string newEmail, string UserName, Label lblInfo) {
        if (newEmail == "")
        {
            lblInfo.ForeColor = System.Drawing.Color.Red;
            lblInfo.Text = "Email cannot be empty.";
            return;
        }
        else if (! IsValidEmail(newEmail))
        {
            lblInfo.ForeColor = System.Drawing.Color.Red;
            lblInfo.Text = "Email is invalid.";
            return;
        }

        MembershipUser u = Membership.GetUser(UserName);
        u.Email = newEmail;
        Membership.UpdateUser(u);

        lblInfo.ForeColor = System.Drawing.Color.Green;
        lblInfo.Text = "Email has been updated.";
    }


    public bool IsValidEmail(string strIn)
    {
        invalid = false;
        if (String.IsNullOrEmpty(strIn))
            return false;

        // Use IdnMapping class to convert Unicode domain names. 
        try
        {
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                  RegexOptions.None); //, TimeSpan.FromMilliseconds(200));
        }
        catch (Exception)
        {
            return false;
        }

        if (invalid)
            return false;

        // Return true if strIn is in valid e-mail format. 
        try
        {
            return Regex.IsMatch(strIn,
                  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                  RegexOptions.IgnoreCase); //, TimeSpan.FromMilliseconds(250));
        }
        catch (Exception)
        {
            return false;
        }
    }


    private string DomainMapper(Match match)
    {
        // IdnMapping class with default property values.
        IdnMapping idn = new IdnMapping();

        string domainName = match.Groups[2].Value;
        try
        {
            domainName = idn.GetAscii(domainName);
        }
        catch (ArgumentException)
        {
            invalid = true;
        }
        return match.Groups[1].Value + domainName;
    }
}