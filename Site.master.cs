using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

/// <summary>
/// Note:
/// - Below shows how to add sub menu.
/// - to change menu style, change items in section "TAB MENU" in ~/Styles/Site.css.
/// </summary>
public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MenuItem itemMember = new MenuItem("Member");
            itemMember.NavigateUrl = "Member.aspx";
            NavigationMenu.Items.AddAt(1, itemMember);

            MenuItem itemProfile = new MenuItem("My Profile");
            itemProfile.NavigateUrl = "~/Account/Profile.aspx";
            itemMember.ChildItems.Add(itemProfile);

            MenuItem itemPwd = new MenuItem("Change Password");
            itemPwd.NavigateUrl = "~/Account/ChangePassword.aspx";
            itemMember.ChildItems.Add(itemPwd);
        }

        if (!ClsConfig.requireLogin() || HttpContext.Current.User.Identity.IsAuthenticated)
        {
            // User Interface.

            MenuItem itemUI = new MenuItem("UI");
            itemUI.Selectable = false;
            NavigationMenu.Items.AddAt(1, itemUI);

            // AutoComplete Extender

            MenuItem itemCountryAutoComplete = new MenuItem("AutoComplete Extender");
            itemCountryAutoComplete.NavigateUrl = ResolveUrl("~/UI/CountryAutoComplete.aspx");
            itemUI.ChildItems.Add(itemCountryAutoComplete);

            // Charts.

            MenuItem itemChart = new MenuItem("Chart ...");
            itemChart.Selectable = false;
            //itemChart.PopOutImageUrl = "~/images/help.png"; // this does not work.
            itemUI.ChildItems.AddAt(1, itemChart);

            MenuItem itemAjaxChart = new MenuItem("Ajax Chart");
            itemAjaxChart.NavigateUrl = ResolveUrl("~/Chart/AjaxChart.aspx");
            itemChart.ChildItems.Add(itemAjaxChart);

            MenuItem itemAspChart = new MenuItem("Asp Chart");
            itemAspChart.NavigateUrl = ResolveUrl("~/Chart/AspChart.aspx");
            itemChart.ChildItems.Add(itemAspChart);

            MenuItem itemAspChartDynamic = new MenuItem("Dynamic Asp Chart");
            itemAspChartDynamic.NavigateUrl = ResolveUrl("~/Chart/AspChartDynamic.aspx");
            itemChart.ChildItems.Add(itemAspChartDynamic);

            // List.

            MenuItem itemCountryList = new MenuItem("Country List");
            itemCountryList.NavigateUrl = ResolveUrl("~/UI/CountryList.aspx");
            itemUI.ChildItems.Add(itemCountryList);

            MenuItem itemCountryTable = new MenuItem("Country Table");
            itemCountryTable.NavigateUrl = ResolveUrl("~/UI/CountryTable.aspx");
            itemUI.ChildItems.Add(itemCountryTable);

            // TreeView.

            MenuItem itemCountryTreeView = new MenuItem("Country TreeView");
            itemCountryTreeView.NavigateUrl = ResolveUrl("~/UI/CountryTreeView.aspx");
            itemUI.ChildItems.Add(itemCountryTreeView);
            
            // Map.

            MenuItem itemMap = new MenuItem("Embed Map");
            itemMap.NavigateUrl = ResolveUrl("~/UI/Map.aspx");
            itemUI.ChildItems.Add(itemMap);

            // Multi-level Menu

            MenuItem itemSubMenu = new MenuItem("SubMenu Test ...");
            itemUI.ChildItems.Add(itemSubMenu);

            MenuItem itemTest = new MenuItem("SubSubMenu 1");
            itemSubMenu.ChildItems.Add(itemTest);
            
            MenuItem itemTest2 = new MenuItem("SubSubMenu 2 ...");
            itemSubMenu.ChildItems.Add(itemTest2);

            MenuItem itemTest21 = new MenuItem("SubSubSubMenu 1");
            itemTest2.ChildItems.Add(itemTest21);
            
            MenuItem itemTest22 = new MenuItem("SubSubSubMenu 2");
            //itemTest222.Text = "<hr size='1'/>";
            //itemTest222.Selectable = false;
            itemTest22.SeparatorImageUrl = ResolveClientUrl("~/images/MenuSeparator.jpg"); // Menu Separator.
            itemTest2.ChildItems.Add(itemTest22);

            MenuItem itemTest23 = new MenuItem("SubSubSubMenu 3 (Under separator)");
            itemTest2.ChildItems.Add(itemTest23);

            // This no longer works. So at most 4 levels of menu including top level.
            MenuItem itemTest3 = new MenuItem("Test3");
            itemTest23.ChildItems.Add(itemTest3);
            
            // Wizard
            
            MenuItem itemWizard = new MenuItem("Wizard");
            itemWizard.NavigateUrl = ResolveUrl("~/UI/Wizard.aspx");
            itemUI.ChildItems.Add(itemWizard);


            // Data

            MenuItem itemData = new MenuItem("Data");
            itemData.Selectable = false;
            NavigationMenu.Items.AddAt(1, itemData);

            MenuItem itemSPComp = new MenuItem("Computation Progress Bar");
            itemSPComp.NavigateUrl = ResolveUrl("~/Data/SPCompute/");
            itemData.ChildItems.Add(itemSPComp);
                                    
            // Management

            if (HttpContext.Current.User.Identity.IsAuthenticated && 
                Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Administrator"))
            {
                MenuItem itemAdmin = new MenuItem("Admin");
                itemAdmin.Selectable = false;
                NavigationMenu.Items.AddAt(1, itemAdmin);

                MenuItem itemRoles = new MenuItem("Manage Roles");
                itemRoles.NavigateUrl = "Admin/Roles.aspx";
                itemAdmin.ChildItems.Add(itemRoles);

                MenuItem itemUsers = new MenuItem("Manage Users");
                itemUsers.NavigateUrl = "Admin/Users.aspx";
                itemAdmin.ChildItems.Add(itemUsers);

                MenuItem itemNewUser = new MenuItem("Create New User");
                itemNewUser.NavigateUrl = "Admin/CreateNewUser.aspx";
                itemAdmin.ChildItems.Add(itemNewUser);
            }
        }
    }
}
