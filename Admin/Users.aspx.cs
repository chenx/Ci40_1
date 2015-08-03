using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (! IsPostBack) init();

        //resetUserPassword("user1");
    }

    private void resetUserPassword(string user) {
        Membership.GetUser(user).UnlockUser();
        string newPwd = Membership.GetUser(user).ResetPassword();
        Response.Write(newPwd);
    }

    private void init() {
        string s = "";
        int currentPage = ClsUtil.ObjToInt(Request["p"]); // starts at 0
        int pageSize = 10;

        int ct = currentPage * pageSize + 0;
        int total;
        foreach (MembershipUser u in Membership.GetAllUsers(currentPage, pageSize, out total)) {
            string row = "";
            row += "<td class='center'>" + (++ct) + "</td>";
            row += "<td class='center'>" + getLockOut(u.UserName, u.IsLockedOut) + "</td>";
            row += "<td><a href=\"UserProfile.aspx?u=" + u.UserName + "\">" + u.UserName + "</a></td>";
            row += "<td>" + getUserRealName(u.UserName) + "</td>";
            row += "<td>" + u.Email + "</td>";
            row += "<td class='center'>" + getApproval(u.UserName, u.IsApproved) + "</td>";
            row += "<td>" + u.IsOnline + "</td>";
            row += "<td>" + u.CreationDate.ToShortDateString() + "</td>";
            row += "<td>" + u.LastLoginDate + "</td>";
            row += "<td>" + getRoles(u.UserName) + "</td>";        
                
            s += "<tr>" + row + "</tr>";
        }

        // Avoid page overflow/underflow.
        int totalPages = (int) Math.Ceiling(Membership.GetAllUsers().Count * 1.0 / pageSize);
        //Response.Write(currentPage + ", total = " + (total));
        if (currentPage >= total) { Response.Redirect("Users.aspx?p=" + (total - 1)); }
        else if (currentPage < 0) { Response.Redirect("Users.aspx?p=0"); }
        
        if (s != "") {
            string header =
@"<tr>
<td>No.</td>
<td>Locked</td>
<td>Username</td>
<td>Real name</td>
<td>Email</td>
<td>Approved</td>
<td>Online</td>
<td>Creation Date</td>
<td>Last Login</td>
<td>Roles</td>
</tr>";
            s = header + s;
            s = "<table class=\"tbl_users\">" + s + "</table>";
        }

        // write page links.
        s = getPageLinks(currentPage, pageSize, totalPages) + s;

        lblContent.Text = s;
    }

    private string getUserRealName(string username) {
        string s = "";
        ProfileCommon p = (ProfileCommon)ProfileCommon.Create(username, false);

        string firstName = (p["FirstName"] == null) ? "" : (string) p["FirstName"];
        string lastName = (p["LastName"] == null) ? "" : (string) p["LastName"];

        s = (lastName + ", " + firstName).Trim();
        if (s == ",") s = "";

        return s;
    }

    private string getPageLinks(int currentPage, int pageSize, int totalPages) {
        string s = "";

        if (totalPages == 1) return s;

        for (int i = 0; i < totalPages; ++i) {
            if (i == currentPage) s += (i + 1) + " ";
            else s += "<a href=\"Users.aspx?p=" + i + "\">" + (i+1) + "</a> ";
        }

        if (s != "") s = "<p>Page " + s + "</p>";

        return s;
    }


    private string getRoles(string UserName) {
        string s = "";

        string[] allRoles = Roles.GetAllRoles();

        for (int i = 0; i < allRoles.Length; ++i) {
            bool userInRole = Roles.IsUserInRole(UserName, allRoles[i]);

            string id = "role_" + UserName + "_" + allRoles[i];
            string onclick = " onclick=\"do_role('" + UserName + "', '" + allRoles[i] + "');\"";
            s += "<input type=\"checkbox\" id=\"" + id + "\" " + (userInRole ? " checked" : "") + onclick + ">" + allRoles[i] + " &nbsp;";
        }

        return s;
    }

    private string getApproval(string UserName, bool IsApproved)
    {
        string s = "";
        s += "<input type=\"checkbox\" id=\"approval_" + UserName + "\" " + (IsApproved ? " checked" : "") +
            " onclick=\"do_approval('" + UserName + "');\">";
        return s;
    }

    private string getLockOut(string UserName, bool IsLockedOut) {
        string s = "";
        string disabled = IsLockedOut ? " Title=\"Unlock this user\"" : " disabled";
        s += "<input type=\"checkbox\" id=\"lockout_" + UserName + "\" " + (IsLockedOut ? " checked" : "") +
            " onclick=\"do_lockout('" + UserName + "');\"" + disabled + ">";
        return s;
    }
}