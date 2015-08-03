using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// To put side bar on top horizontally:
/// http://techbrij.com/stylish-asp-net-wizard-control-horizontal-sidebar-on-top
/// http://forums.asp.net/t/1045345.aspx?Wizard+control+adapter+with+sidebar+on+top
/// http://forums.asp.net/t/961937.aspx?How+to+enable+disable+a+Wizard+Control+s+Next+Button
/// </summary>
public partial class Wizard : System.Web.UI.Page
{
    ClsWizard wizard;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initSelectedStateList();
            initStep1();
        }
    }


    /// <summary>
    /// Save Country and State.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void do_activate_step1(object sender, EventArgs e)
    {

    }
    protected void do_deactivate_step1(object sender, EventArgs e)
    {
        if (dlGeo.SelectedItem == null || dlStateSelected.Items.Count == 0) { 
            
        }

        Session["SelectedGeo"] = new ClsKV(dlGeo.SelectedItem.Value.ToString(), dlGeo.SelectedItem.Text);
    }

    private void initSelectedStateList() {
        Session["SelectedStateList"] = new List<ClsKV>();
        dlStateSelected.Items.Clear();
    }

    protected void initStep1() {
        ClsWizard wizard = new ClsWizard();
        string sql = "SELECT Country, Country FROM T_CountryList WHERE Abbreviation in ('CN', 'US')";
        wizard.connection().Open();
        wizard.populateDropdownList(dlGeo, sql, "-- Select One --", null);
        sql = "SELECT ID, State FROM V_CountryStates WHERE ID = -1";
        wizard.populateDropdownList(dlState, sql, null, null);
        wizard.connection().Close();
        dlGeo.SelectedIndex = -1;
        dlGeo.SelectedIndex = -1;
        //Response.Write(dlGeo.SelectedIndex);

        Button b = wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("StartNextButton") as Button;
        if (b != null) b.Enabled = false;
    }

    protected void dlGeo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        string id = dlGeo.SelectedValue.ToString();
        //string sql = "SELECT ID, StateName FROM V_Geo_State WHERE GeoID = " + ClsDB.sqlEncode(id);
        string sql = "SELECT State, State FROM V_CountryStates WHERE Country = " + ClsDB.sqlEncode(id);
        ClsWizard wizard = new ClsWizard();
        wizard.connection().Open();
        wizard.populateDropdownList(dlState, sql, null, null);
        wizard.connection().Close();
        initSelectedStateList();
    }

    protected void btnSelectState_OnClick(object sender, EventArgs e) {
        ClsKV kv = new ClsKV(dlState.SelectedValue.ToString(), dlState.SelectedItem.ToString());
        //lblMsg.Text = kv.ToString();
        UpdateMsg("You added: " + kv.Value);
                
        List<ClsKV> StateList = Session["SelectedStateList"] as List<ClsKV>;
        if (! ClsKV.ContainsKey(StateList, kv.Key)) {
            StateList.Add(kv);
        }
        Session["SelectedStateList"] = new List<ClsKV>(StateList);

        updateStateDrowdownLists(StateList);
    }

    protected void btnDeSelectState_OnClick(object sender, EventArgs e)
    {
        ClsKV kv = new ClsKV(dlStateSelected.SelectedValue.ToString(), dlStateSelected.SelectedItem.ToString());
        //lblMsg.Text = kv.ToString();
        UpdateMsg("You removed: " + kv.Value);

        List<ClsKV> StateList = Session["SelectedStateList"] as List<ClsKV>;
        
        if (ClsKV.ContainsKey(StateList, kv.Key))
        {
            ClsKV.RemoveKey(StateList, kv.Key);
        }
        Session["SelectedStateList"] = new List<ClsKV>(StateList);

        updateStateDrowdownLists(StateList);
    }

    private void UpdateMsg(string msg) {
        lblMsg.Text = msg;
        lblMsg.ForeColor = System.Drawing.Color.Green;
    }

    private void updateStateDrowdownLists(List<ClsKV> StateList)
    {
        ClsWizard wizard = new ClsWizard();
        string id = dlGeo.SelectedValue.ToString();
        //string sql = "SELECT ID, StateName FROM V_Geo_State WHERE GeoID = " + ClsDB.sqlEncode(id);
        string sql = "SELECT ID, State FROM V_CountryStates WHERE Country = " + ClsDB.sqlEncode(id);
        wizard.connection().Open();
        wizard.populateDropdownList(dlState, sql, null, StateList);
        wizard.populateDropdownList(dlStateSelected, StateList);
        wizard.connection().Close();

        Button b = wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("StartNextButton") as Button;
        if (b != null) b.Enabled = (StateList.Count > 0);
    }

    /// <summary>
    /// Save options.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void do_activate_step2(object sender, EventArgs e)
    {
        lblInfo.Text = getInfo_Geo() + "<br/>" + getInfo_State();
    }
    protected void do_deactivate_step2(object sender, EventArgs e)
    {

    }

    private string getInfo_Geo() {
        if (Session["SelectedGeo"] == null || Session["SelectedGeo"] == "")
        {
            return "";
        }
        else {
            ClsKV kv = Session["SelectedGeo"] as ClsKV;
            //return "Country: " + kv.Key + ":" + kv.Value;
            return "Country: " + kv.Value;
        }
    }
    private string getInfo_State() {
        string s = "";
        List<ClsKV> StateList = Session["SelectedStateList"] as List<ClsKV>;

        for (int i = 0, n = StateList.Count; i < n; ++i) {
            if (s != "") s += ", ";
            s += StateList[i].Value;
        }
        s = "State: " + s;

        return s;
    }


    /// <summary>
    /// Save payment options.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void do_activate_step3(object sender, EventArgs e)
    {

    }
    protected void do_deactivate_step3(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// Confirm and commit.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void do_activate_step4(object sender, EventArgs e)
    {

    }
    protected void do_deactivate_step4(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// Finish
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void do_activate_step5(object sender, EventArgs e)
    {

    }
    protected void do_deactivate_step5(object sender, EventArgs e)
    {

    }


    protected void btnFinish_OnClick(object sender, EventArgs e) {
        Response.Redirect(ClsUtil.getPageName(Request));
    }


    protected void Wizard1_OnOnSideBarButtonClick(object sender, WizardNavigationEventArgs e) {
        e.Cancel = true;
    }
}