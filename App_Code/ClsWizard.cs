using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ClsWizard
/// </summary>
public class ClsWizard
{
    private SqlConnection conn = null;

	public ClsWizard()
	{
        conn = new SqlConnection(ClsConfig.connStr());
	}

    public SqlConnection connection() {
        return conn;
    }

    /// <summary>
    /// Assumption: cmdText has 2 fields: key/value.
    /// </summary>
    /// <param name="dl"></param>
    /// <param name="cmdText"></param>
    /// <param name="selectHeader">Default first item with empty value, e.g., "-- Select One --". If null, don't provide.</param>
    /// <param name="excludeList"></param>
    public void populateDropdownList(DropDownList dl, string cmdText, string selectHeader, List<ClsKV> excludeList) {
        dl.Items.Clear();
        if (selectHeader != null)
        {
            dl.Items.Add(new ListItem(selectHeader, string.Empty));
        }

        using (SqlCommand cmd = new SqlCommand(cmdText, conn)) {
            using (SqlDataReader sdr = cmd.ExecuteReader()) {
                while (sdr.Read()) {
                    if (excludeList != null)
                    {
                        if (ClsKV.ContainsKey(excludeList, ClsUtil.ObjToStr(sdr[0]))) continue;
                    }
                    string text = ClsUtil.ObjToStr(sdr[1]);
                    string value = ClsUtil.ObjToStr(sdr[0]);
                    dl.Items.Add(new ListItem(text, value));
                }
            }
        }
    }

    public void populateDropdownList(DropDownList dl, List<ClsKV> List)
    {
        dl.Items.Clear();
        for (int i = 0, n = List.Count; i < n; ++i) {
            dl.Items.Add(new ListItem(List[i].Value, List[i].Key));
        }
    }

}