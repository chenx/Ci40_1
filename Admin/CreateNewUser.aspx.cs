using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

/// <summary>
/// How to add a Login, Roles and Profile system to an ASP.NET 2.0 app in only 24 lines of code:
/// http://weblogs.asp.net/scottgu/427754
/// 
/// Use these two to control where to go after creating an account, and whether to login as that user immediately:
/// - ContinueDestinationPageUrl="~/Admin/CreateNewUser.aspx" 
/// - LoginCreatedUser="false"
/// Here I want to continue to create another account, hence the setting above.
/// </summary>
public partial class Admin_CreateNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Create New User";
    }

    // CreatedUser event is called when a new user is successfully created
    public void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        // Create an empty Profile for the newly created user
        /*ProfileCommon p = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);

        // Populate some Profile properties off of the create user wizard
        p.Country = ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Country")).SelectedValue;
        p.Gender = ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Gender")).SelectedValue;
        p.Age = Int32.Parse(((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Age")).Text);

        // Save the profile - must be done since we explicitly created this profile instance
        p.Save();
         * */
    }

    // Activate event fires when the user hits "next" in the CreateUserWizard
    public void AssignUserToRoles_Activate(object sender, EventArgs e)
    {

        // Databind list of roles in the role manager system to a listbox in the wizard
        AvailableRoles.DataSource = Roles.GetAllRoles(); ;
        AvailableRoles.DataBind();
    }

    // Deactivate event fires when user hits "next" in the CreateUserWizard 
    public void AssignUserToRoles_Deactivate(object sender, EventArgs e)
    {

        // Add user to all selected roles from the roles listbox
        for (int i = 0; i < AvailableRoles.Items.Count; i++)
        {
            if (AvailableRoles.Items[i].Selected == true)
                Roles.AddUserToRole(CreateUserWizard1.UserName, AvailableRoles.Items[i].Value);
        }
    }

    /// <summary>
    /// This will jump over the last "Complete Confirmation" page, which repeats the "Complete"
    /// button of the last wizard page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CompleteWizardStep1_Activate (object sender, EventArgs e) {
        Response.Redirect("CreateNewUser.aspx");
    }
}