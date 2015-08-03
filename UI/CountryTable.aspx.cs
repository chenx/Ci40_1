using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Countries : System.Web.UI.Page
{
    private static string connStr = "";
    private SqlConnection conn = null;
    private ClsDBUtil dbUtil;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) init();
    }

    private void init() {
        connStr = ClsConfig.connStr();  
        dbUtil = new ClsDBUtil();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            try
            {
                conn.Open();
                lblContent.Text = getCountriesAsList(conn);
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.Message);
            }
        }
    }

    private string getCountriesAsList(SqlConnection conn)
    {
        string cmdText = "select Country, Abbreviation FROM T_CountryList";
        List<ClsLinkItem> links = dbUtil.getLinkItemList(conn, cmdText);

        string output = "";
        for (int i = 0, n = links.Count; i < n; ++i)
        {
            output += "<h2>" + ClsUtil.UCaseFirst( links[i].ID ) + "</h2>";
            cmdText = "SELECT ID, State FROM V_CountryStates WHERE Country = " + ClsDB.sqlEncode(links[i].ID);
            //Response.Write(cmdText);
            output += GetCountryStatesAsList(conn, cmdText, links[i].Name);
            output += "<br/>";
        }

        return output;
    }

    private string GetCountryStatesAsList(SqlConnection conn, string cmdText, string countryAbbreviation)
    {
        string output = "";
        List<ClsLinkItem> links = dbUtil.getLinkItemList(conn, cmdText);

        string url = "?c=" + countryAbbreviation + "&id=";
        output = "<hr class=\"hr_subjects\"/>" + ClsConvert.writeLinksAsTable(links, 2, url, "subjects");
        return output;
    }    
}