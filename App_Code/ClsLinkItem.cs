using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClassGeoSite
/// </summary>
public class ClsLinkItem
{
    public ClsLinkItem(string Id, string Name)
    {
        this.ID = Id;
        this.Name = Name;
        this.ToolTip = "";
    }

    public ClsLinkItem(string Id, string Name, string ToolTip)
	{
        this.ID = Id;
        this.Name = Name;
	}

    public string ID
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public string ToolTip
    {
        get;
        set;
    }
}