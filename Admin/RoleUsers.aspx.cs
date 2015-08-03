using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Linq;
using System.Drawing;

public partial class Admin_RoleUsers : System.Web.UI.Page
{
    private string role; 

    protected void Page_Load(object sender, EventArgs e)
    {
        init();

        role = ClsUtil.ObjToStr(Request["role"]).Trim();
        if (string.IsNullOrEmpty(role) || !Roles.RoleExists(role)) {
            ClsUtil.UIShowMsg("Error: Unknown role - " + role, lblInfo, Color.Red);
            divContent.Visible = false;
            return;
        }

        divRole.InnerHtml = role;

        if (! IsPostBack) updateUserLists();
    }

    private void init() {
        lblMsgAdd.Text = "";
        lblMsgRemove.Text = "";
        lblInfo.Text = "";

        string msg = Request["msg"];
        if (!string.IsNullOrEmpty(msg)) {
            lblInfo.Text = msg;
            msg += "<script>$('#lblInfo').hide('fade', {}, 5000);</script>";
            ClsUtil.UIShowMsg(msg, lblInfo, Color.Green);
        }
    }

    private void updateUserLists() {
        getRoleUsers();
        getNonRoleUsers();    
    }

    private void getRoleUsers() {
        dlRoleUsers.Items.Clear();

        bool roleHasUser = (Roles.GetUsersInRole(role).Length > 0);

        dlRoleUsers.Visible = roleHasUser;
        btnRemoveRoleUser.Visible = roleHasUser;

        if (!roleHasUser) lblMsgRemove.Text = "(none)";

        for (int i = 0, n = Roles.GetUsersInRole(role).Length; i < n; ++i)
        {
            dlRoleUsers.Items.Add(Roles.GetUsersInRole(role)[i]);
        }
    }

    private void getNonRoleUsers()
    {
        dlNonRoleUsers.Items.Clear();
                
        List<MembershipUser> usersNotInRole = getUsersNotInRole(role);

        bool roleHasNonUser = (usersNotInRole.Count > 0);

        dlNonRoleUsers.Visible = roleHasNonUser;
        btnAddRoleUser.Visible = roleHasNonUser;
        if (!roleHasNonUser) lblMsgAdd.Text = "(none)";

        //foreach (MembershipUser u in Membership.GetAllUsers()) {
        //    dlNonRoleUsers.Items.Add(u.UserName);
        //}

        for (int i = 0, n = usersNotInRole.Count; i < n; ++ i)
        {
            dlNonRoleUsers.Items.Add(usersNotInRole[i].UserName);
        }
    }


    /// <summary>
    /// Return list of users not in a role.
    /// Linq grammar is used below.
    /// See: http://stackoverflow.com/questions/5325414/how-to-get-users-not-in-role
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    private List<MembershipUser> getUsersNotInRole(string role, string orderBy = "asc")
    {
        string[] usersInRole = Roles.GetUsersInRole(role);
        var usersNotInRole = Membership.GetAllUsers()
            .Cast<MembershipUser>()
            .Where(u =>
                !usersInRole.Contains(u.UserName)
            ); //.ToList(); 
        //.OrderBy(u => u.UserName);
        //.OrderByDescending(u => u.UserName);

        if (orderBy == "asc")
        {
            usersNotInRole.OrderBy(u => u.UserName);
        }
        else if (orderBy == "desc")
        {
            usersNotInRole = usersNotInRole.OrderByDescending(u => u.UserName);            
        }

        return usersNotInRole.ToList();
    }

    
    protected void btnAddRoleUser_OnClick(object sender, EventArgs e) {
        string user = dlNonRoleUsers.SelectedValue;
        //Response.Write("add: " + user);
        if (!string.IsNullOrEmpty(user)) {
            try
            {
                Roles.AddUserToRole(user, role);
                updateUserLists();
                Response.Redirect(ClsUtil.getPageName(Request) + "?role=" + role + "&msg=User '" + user + "' is added to current role.");
            }
            catch (Exception ex) {
                lblMsgAdd.Text = "Error: " + ex.Message;
            }
        }
    }
   
    protected void btnRemoveRoleUser_OnClick(object sender, EventArgs e)
    {
        string user = this.dlRoleUsers.SelectedValue;
        //Response.Write("remove: " + user);
        if (!string.IsNullOrEmpty(user))
        {
            try
            {
                Roles.RemoveUserFromRole(user, role);
                updateUserLists();
                Response.Redirect(ClsUtil.getPageName(Request) + "?role=" + role + "&msg=User '" + user + "' is removed from current role.");
            }
            catch (Exception ex)
            {
                lblMsgRemove.Text = "Error: " + ex.Message;
            }
        }
    }
}