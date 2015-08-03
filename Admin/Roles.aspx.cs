using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Web.Security;
using System.Drawing;

/// <summary>
/// To use Roles you have to enable roleManager in web.config:
/// <roleManager enabled="true"></roleManager>
/// </summary>
public partial class Admin_Roles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        init();
        if (!IsPostBack) getRoleList();
    }

    private void init() {
        lblMsg.Text = "";
        lblInfo.Text = "";
    }

    private void getRoleList()
    {
        dlRoles.Items.Clear();

        bool roleExists = (Roles.GetAllRoles().Length > 0);

        dlRoles.Visible = roleExists;
        btnDeleteRole.Visible = roleExists;
        btnManageUsers.Visible = roleExists;

        if (! roleExists) {
            lblInfo.Text = "(none)";
            return;
        }

        for (int i = 0, n = Roles.GetAllRoles().Length; i < n; ++i)
        {
            dlRoles.Items.Add(Roles.GetAllRoles()[i]);
        }
    }

    protected void btnCreateRole_OnClick(object sender, EventArgs e) {
        string newRole = txtNewRole.Text.Trim();
        
        if (string.IsNullOrEmpty(newRole)) {
            showMsg("Role name cannot be empty.", lblMsg, Color.Red);
        }
        else if (Roles.RoleExists(newRole))
        {
            showMsg("Role already exists: " + newRole, lblMsg, Color.Red);
        }
        else {
            try
            {
                Roles.CreateRole(newRole);
                txtNewRole.Text = "";
                getRoleList();
                showMsg("Role is successfully created: " + newRole, lblMsg, Color.Green);
            }
            catch (Exception ex) {
                showMsg("Error: " + ex.Message, lblMsg, Color.Red);
            }
        }
    }
    
    private void showMsg(string msg, Label lbl, Color color) {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }

    protected void btnDeleteRole_OnClick(object sender, EventArgs e) {
        string roleToDelete = dlRoles.SelectedValue;
        try
        {
            Roles.DeleteRole(roleToDelete);
            getRoleList();
            showMsg("Role is successfully deleted: " + roleToDelete, lblInfo, Color.Green); ;
        }
        catch (Exception ex) {
            showMsg("Error: " + ex.Message, lblInfo, Color.Red);
        }
    }

    protected void btnManageUsers_OnClick(object sender, EventArgs e) {
        string role = dlRoles.Text.Trim();
        if (!string.IsNullOrEmpty(role)) {
            Response.Redirect("RoleUsers.aspx?role=" + role);
        }
    }        
}