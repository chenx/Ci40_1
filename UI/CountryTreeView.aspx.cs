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
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            try
            {
                conn.Open();
                getCountries(conn);
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.Message);
            }
        }
    }

    private void getCountries(SqlConnection conn)
    {
        string country0 = "", country, id, state;
        TreeNode countryNode = null;

        string cmdText = "select Country, ID, State FROM V_CountryStates";
        using (SqlCommand cmd = new SqlCommand(cmdText, conn)) { 
            using (SqlDataReader sdr = cmd.ExecuteReader()) {
                int ct = 0;
                while (sdr.Read()) {
                    country = ClsUtil.ObjToStr(sdr[0]);
                    id = ClsUtil.ObjToStr(sdr[1]);
                    state = ClsUtil.ObjToStr(sdr[2]);

                    if (country != country0)
                    {
                        countryNode = new TreeNode(country, country);
                        countryNode.ToolTip = country;
                        countryNode.SelectAction = TreeNodeSelectAction.Expand;
                        tvContent.Nodes.Add(countryNode);
                        country0 = country;
                        ct = 0;
                    }

                    TreeNode stateNode = new TreeNode("[" + (++ct) + "] " + state, state);
                    //stateNode.NavigateUrl = "?";
                    stateNode.ToolTip = state;
                    countryNode.ChildNodes.Add(stateNode);
                }
            } 
        }
    }
}