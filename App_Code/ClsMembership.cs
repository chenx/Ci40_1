using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ClsMembership
/// </summary>
public class ClsMembership
{
    public ClsMembership()
    {

    }

    public static void DeleteUser(string username) {
        if (username == "admin") return; // do not delete this default admin account.
        Membership.DeleteUser(username, true); 
    }

    public static void ResetPassword(string username, string new_password) {
        MembershipUser u = Membership.GetUser(username);
        string pwd = u.ResetPassword();
        //Response.Write(pwd);
        u.ChangePassword(pwd, new_password);
    }

    public static void UnlockUser(string username) {
        MembershipUser u = Membership.GetUser(username);
        u.UnlockUser();
        Membership.UpdateUser(u);    
    }

    public static void DisapproveUser(string username)
    {
        MembershipUser u = Membership.GetUser(username);
        u.IsApproved = false;
        Membership.UpdateUser(u);
    }

    public static void ApproveUser(string username)
    {
        MembershipUser u = Membership.GetUser(username);
        u.IsApproved = true;
        Membership.UpdateUser(u);
    }

    public static string getMemberRoles(string username)
    {
        string[] roles = Roles.GetRolesForUser(username);
        string s;
        if (roles.Length == 0)
        {
            s = "<b>Role:</b> (none)";
        }
        else if (roles.Length == 1)
        {
            s = "<b>Role:</b> " + roles[0];
        }
        else
        {
            s = "<b>Roles:</b> " + ClsConvert.ArrayToStringList(roles, ", ");
        }

        return s;
    }

    public static List<string> ValidatePassword(string pwd, string pwd2) {
        List<string> error_msgs = new List<string>();
        if (pwd != pwd2)
        {
            error_msgs.Add("The Password and Confirmation Password must match.");
        }

        int n = Membership.MinRequiredPasswordLength;
        if (pwd.Length < n)
        {
            error_msgs.Add("The Password should be at least " + n + " in length.");
        }

        n = Membership.MinRequiredNonAlphanumericCharacters;
        if (n > 0)
        {
            if (ClsUtil.CountNonAlphanumericCharacters(pwd) < n)
            {
                error_msgs.Add("The Password should contain at least " + n + " non-alphanumeric characters.");
            }
        }

        return error_msgs;
    }
}