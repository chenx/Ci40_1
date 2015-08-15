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
        new ClsMenu().getMenu(NavigationMenu);       
    }
}
