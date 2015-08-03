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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) init();
    }

    private void init() {
        connStr = ClsConfig.connStr(); 

        lblCountryList.Items.Add("China");
        lblCountryList.Items.Add("United States");
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetList(string prefixText, int count, string contextKey)
    {
        List<string> countryNames = new List<string>();
                
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = connStr;

            using (SqlCommand cmd = new SqlCommand())
            {
                string cmdText = @"select State from V_CountryStates where State like @Search + '%'";
                cmd.Parameters.AddWithValue("@Search", prefixText);

                if (string.IsNullOrEmpty(contextKey)) { contextKey = "China"; }
                cmdText += " AND country = @Country";
                cmd.Parameters.AddWithValue("@Country", contextKey);

                cmdText += " ORDER BY State";
                cmd.CommandText = cmdText;
                
                /* //This works too.
                string cmdText = @"select State from V_CountryStates where State like " + ClsDB.sqlEncode(prefixText) + " + '%'";
                if (!string.IsNullOrEmpty(contextKey))
                {
                    cmdText += " AND country = " + ClsDB.sqlEncode(contextKey);
                }
                else {
                    cmdText += " AND country = " + ClsDB.sqlEncode("China"); // default when page is loaded.
                }
                cmdText += " ORDER BY State";
                cmd.CommandText = cmdText;
                */

                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        countryNames.Add( ClsUtil.ObjToStr(sdr[0]) );
                    }
                }
            }
        }

        return countryNames;
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetListCharCN(string prefixText, int count, string contextKey)
    {
        List<string> words = new List<string>();

        contextKey = contextKey.Trim();
        //if (contextKey.StartsWith(":")) contextKey = contextKey.Substring(1).Trim();
        if (contextKey == "") return words;

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = connStr;

            using (SqlCommand cmd = new SqlCommand())
            {
                string cmdText = @"select Character from Character_CN where Pinyin like @Search + '%'"; 
                    // ORDER BY FrequencyRaw DESC"; // already ordered by ID.
                //cmd.Parameters.AddWithValue("@Search", prefixText);
                cmd.Parameters.AddWithValue("@Search", contextKey.Trim());
                cmd.CommandText = cmdText;

                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        words.Add(ClsUtil.ObjToStr(sdr[0]));
                    }
                }
            }
        }

        return words;
    }

}