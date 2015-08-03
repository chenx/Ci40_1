using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Database functions that are application oriented.
/// </summary>
public class ClsDBUtil
{
    private string connStr;

    public ClsDBUtil()
	{
        connStr = ClsConfig.connStr();
	}


    public List<ClsLinkItem> getLinkItemList(SqlConnection conn, string cmdText)
    {
        List<ClsLinkItem> links = new List<ClsLinkItem>();

        SqlCommand cmd = new SqlCommand(cmdText, conn);
        using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            while (sdr.Read())
            {
                string ID = ClsUtil.ObjToStr(sdr[0]);
                string Name = ClsUtil.ObjToStr(sdr[1]);

                links.Add(new ClsLinkItem(ID, Name));
            }
        }
        return links;
    }

    public List<ClsLinkItem> getLinkItemList(string cmdText)
    {
        List<ClsLinkItem> links = new List<ClsLinkItem>();

        using (SqlConnection conn = new SqlConnection(connStr)) {
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        string ID = ClsUtil.ObjToStr(sdr[0]);
                        string Name = ClsUtil.ObjToStr(sdr[1]);

                        links.Add(new ClsLinkItem(ID, Name));
                    }
                }
            }
        }

        return links;
    }



    public DataTable getQueryAsDataTable(string cmdText)
    {
        DataTable dt = new DataTable();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }
                conn.Close();
            }
        }

        return dt;
    }

    public string ExecuteScalar(string cmd)
    {
        return ClsDB.ExecuteScalar(connStr, cmd);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cmdText">First column is for Text, 2nd column is for Value of SELECTION list.</param>
    /// <returns></returns>
    public string getDropDownListFromDB(string cmdText, string attr, string value)
    {
        DataTable dt = getQueryAsDataTable(cmdText);
        if (dt.Columns.Count < 2)
        {
            return "(query should contain 2 columsn for Text and Value)";
        }

        string s = "<option value=\"\">-- Select One--</option>";

        for (int i = 0, n = dt.Rows.Count; i < n; ++i)
        {
            string text = ClsUtil.ObjToStr(dt.Rows[i][0]);
            string val = ClsUtil.ObjToStr(dt.Rows[i][1]);
            string selected = (value == val) ? " selected" : "";
            s += string.Format("<option value=\"{0}\"{2}>{1}</option>", val, text, selected);
        }

        s = "<select" + attr + ">" + s + "</select>";

        return s;
    }
}