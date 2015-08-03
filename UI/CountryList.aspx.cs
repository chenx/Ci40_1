using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CountryList : System.Web.UI.Page
{
    private ClsDBUtil dbUtil;

    protected void Page_Load(object sender, EventArgs e)
    {
        init();
    }

    private void init() {
        lblCountry.Text = "United States";
        dbUtil = new ClsDBUtil();

        string cmdText = "SELECT Abbreviation, State FROM C_US";
        List<ClsLinkItem> states = dbUtil.getLinkItemList(cmdText);

        dlStates.Items.Clear();
        for (int i = 0; i < states.Count; ++i) {
            dlStates.Items.Add(new ListItem(states[i].Name, states[i].ID.Trim()));
        }

        clStates.Items.Clear();
        for (int i = 0; i < states.Count; ++i)
        {
            clStates.Items.Add(new ListItem(states[i].Name, states[i].ID.Trim()));
        }


        txtStates.Items.Clear();
        for (int i = 0; i < states.Count; ++i)
        {
            txtStates.Items.Add(new ListItem(states[i].Name, states[i].ID.Trim()));
        }
    }
}