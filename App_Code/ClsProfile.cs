using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Security;

/// <summary>
/// To update profile attributes, either
/// 1) change property ProfilePropertyCollection below, or
/// 2) read property collection from database table T_FormSetting in ClsFormSetting.
/// Note order is important on display.
/// 
/// References:
/// ~/Account/ProfileEdit.aspx.cs
/// web.config
/// 
/// References:
/// http://blog.typps.com/2008/02/customizing-changepassword-control-and.html
/// </summary>
public class ClsProfile
{
    private bool DEBUG = false;
    private static ClsProfileEntry[] _ProfileCollection = null;
    private string fieldNamePrefix = "txt";
    private string IsRequiredLabel = "<span class=\"IsRequired\">*</span>";
    
    public ClsProfile(bool DEBUG = false)
	{
        this.DEBUG = DEBUG;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="IsSelfProfile">If true, this function is called from self Profile page.</param>
    /// <returns></returns>
    public string getMembershipInfo(string username, bool IsSelfProfile, bool ShowEmailEditLink) {
        string s = "";

        // Admin cannot reset user password without providing user's current password.
        // So it seems pointless to add this:
        // <b>Password:</b> [ <a href=""ChangePassword.aspx{2}"">Update</a> ]<br/>

        string emailEditParam = IsSelfProfile ? "" : ("?u=" + username);
        string emailEditLink = ShowEmailEditLink ? string.Format(" [ <a href=\"EmailEdit.aspx{0}\">Update</a> ]", emailEditParam) : "";
        string resetPwdLink = IsSelfProfile ? "" : ResetPwdLink(username);
        string deleteLink = IsSelfProfile ? "" : DeleteMemberLink(username);
        s = string.Format(@"
<p>
<b>User Name:</b> {0} <br/>
<b>Email: </b> {1} &nbsp; {2} <br/>
{3}
{4}
{5}
</p>
", username, Membership.GetUser(username).Email, emailEditLink, ClsMembership.getMemberRoles(username), resetPwdLink, deleteLink);

        return s;
    }

    private string DeleteMemberLink(string username) {
        //string s = "<br/>[ <a href=\"?u=" + username + "&action=delete\" onclick=\"return confirm('Are you sure to permanently delete this user?');\">Delete User</a> ]";
        string s = "<br/><a href=\"DeleteUser.aspx?u=" + username + "\" onclick=\"\">Delete User</a>";
        return s;
    }

    private string ResetPwdLink(string username) {
        string s = "<br/><a href=\"ResetPwd.aspx?u=" + username + "\" onclick=\"\">Reset Password</a>";
        return s;    
    }

    public static ClsProfileEntry[] ProfilePropertyCollection {
        get {
            if (_ProfileCollection == null) { 
                /*
                _ProfileCollection = new ClsProfileEntry[] {
                    new ClsProfileEntry("FirstName", "First Name", true, true),
                    new ClsProfileEntry("LastName", "Last Name", true, true),
                    new ClsProfileEntry("Gender", "Gender", true, false),
                    new ClsProfileEntry("AddressLine1", "Address Line 1", true, true),
                    new ClsProfileEntry("AddressLine2", "Address Line 2", true, false),
                    new ClsProfileEntry("City", "City", true, true),
                    new ClsProfileEntry("State", "State", true, true),
                    new ClsProfileEntry("Zip", "Zip", true, true),
                    new ClsProfileEntry("Country", "Country", true, false, true),
                    new ClsProfileEntry("FullAddress", "Full Address", false, false)
                };
                */

                _ProfileCollection = new ClsFormSetting().getFormSetting("Profile");
            }

            return _ProfileCollection;
        }
    }
    
    /// <summary>
    /// Get View table.
    /// </summary>
    /// <param name="Profile"></param>
    /// <returns></returns>
    public string getProfileView(ProfileCommon Profile)
    {
        string s = "";

        /*// This is not in order.
         * foreach (SettingsProperty p in  ProfileCommon.Properties) 
        {
            s += p.Name + ",";
        }*/

        for (int i = 0, n = ProfilePropertyCollection.Length; i < n; ++i)
        {
            ClsProfileEntry property = ProfilePropertyCollection[i];
            if (! property.ShowInUI) continue;

            string row = string.Format("<tr><td>{0}:</td><td>{1}</td></tr>",
                property.Label, Profile[property.Name]);
            s += row;
        }

        s = "<table class=\"tbl_profile\">" + s + "</table>";
        return s;
    }


    /// <summary>
    /// Get Edit table.
    /// </summary>
    /// <param name="Profile"></param>
    /// <returns></returns>
    public string getProfileEdit(ProfileCommon Profile, string Country = "")
    {
        string s = "";
        string script = ""; // for client side validation.

        string row;
        for (int i = 0, n = ProfilePropertyCollection.Length; i < n; ++i)
        {
            ClsProfileEntry property = ProfilePropertyCollection[i];
            if (! property.ShowInUI) continue;

            string propertyName = property.Name;
            string label = (string) property.Label;
            string value = (string) Profile[property.Name];
            string spanIsRequired = property.IsRequired ? IsRequiredLabel : "";
            string disabled = property.IsDisabled ? " disabled" : "";

            if (property.IsRequired) {
                script = string.Format(@"
  if ($.trim(document.getElementById('{0}{1}').value) == '') {{
    eo = $('#{0}{1}');
    $('#{0}{1}').addClass('perror');
    document.getElementById('e_{1}').innerHTML = 'cannot be empty';
  }}
  else {{
    $('#{0}{1}').removeClass('perror');
    document.getElementById('e_{1}').innerHTML = '';
  }}
", fieldNamePrefix, propertyName) + script;
            }

            if (propertyName == "Gender")
            {
                value = getDropDownList_Gender(value, string.Format(" id=\"txtGender\" name=\"txtGender\"{0}", disabled));
            }
            else if (propertyName == "State" && Country != "" && ClsStateList.getStateList(Country) != null) {
                value = ClsStateList.getStateListAsDropDownList(
                    ClsStateList.getStateList(Country),
                    string.Format(" id=\"{0}State\" name=\"{0}State\"{1}", fieldNamePrefix, disabled),
                    value);
            }
            else if (propertyName == "Country") {
                //value = new ClsDBUtil().getDropDownListFromDB("Select Country, Country FROM T_CountryList", " id=\"txtCountry\" name=\"txtCountry\"", value);
                value = ClsStateList.getCountryListAsDropDownList(" id=\"txtCountry\" name=\"txtCountry\"", value);
            }
            else
            {
                value = string.Format("<input type=\"Text\" id=\"{0}{1}\" name=\"{0}{1}\" value=\"{2}\"{3}>", fieldNamePrefix, propertyName, value, disabled);
            }

            string spanErrMsg = string.Format("<span id=\"e_{0}\" class=\"error\"></span>", propertyName);
            
            row = string.Format("<tr><td>{0}:</td><td>{1}{2} {3}</td></tr>\n", label, value, spanIsRequired, spanErrMsg);
            
            s += row;
        }

        s += "<tr><td colspan=\"2\" align='right'><input type='submit' value='Update' name='btnSubmit' onclick='return validation();' /></td></tr>";

        s = "<table class=\"tbl_profile\">" + s + "</table>";

        if (script != "") {
            script = string.Format(@"
<script type=""text/javascript"">
function validation() {{
  var eo = null; // object with empty value.
{0}

  if (eo != null) {{
    eo.focus();
    return false; // cancel submit.
  }}
  return true;
}}
</script>
", script);
            //script = script.Replace("\n", "<br/>");
            s += script;
        }

        return s;
    }
    

    /// <summary>
    /// Save when there is no error.
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="Request"></param>
    /// <returns></returns>
    public string saveProfile(string UserName, HttpRequest Request) {
        string errMsg = "";
        ProfileCommon p = (ProfileCommon)ProfileCommon.Create(UserName, true);

        for (int i = 0, n = ProfilePropertyCollection.Length; i < n; ++i)
        {
            ClsProfileEntry property = ProfilePropertyCollection[i];
            if (!property.ShowInUI || property.IsDisabled) continue;

            string value = ClsUtil.ObjToStr(Request[fieldNamePrefix + property.Name]).Trim();
            p[property.Name] = value;
            
            if (DEBUG) errMsg += property.Name + ":" + value + "; ";
            if (property.IsRequired && value == "") {
                errMsg += property.Name + " cannot be empty\n";
            }
        }

        if (errMsg == "") p.Save();

        return errMsg;
    }


    private string getDropDownList_Gender(string value, string attr) {
        string s = "";

        string[] GenderList = new string[]{
            "-- Select One --", "",
            "M", "M",
            "F", "F"
        };

        for (int i = 0, n = GenderList.Length; i < n; i += 2) {
            string selected = (value == GenderList[i + 1]) ? " selected" : "";
            s += string.Format("<option value=\"{0}\"{1}>{2}</option>", GenderList[i + 1], selected, GenderList[i]);
        }

        s = "<select" + attr + ">" + s + "</select>";

        return s;
    }
}