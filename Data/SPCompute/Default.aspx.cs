using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class SPCompute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        init();
    }

    private void init() {
        string taskName = "", startTime = "", endTime = "", errorMsg = "";
        int total_ct = 0, current_ct = 0;
        string connStr = ClsConfig.connStr();

        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = connStr;

            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = "SELECT * FROM T_Compute WHERE Name = " + ClsDB.sqlEncode(dlItemName.SelectedValue);
                //Response.Write(com.CommandText);
                com.Connection = con;
                con.Open();

                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        taskName = ClsUtil.ObjToStr(sdr["Name"]).Trim();
                        startTime = ClsUtil.ObjToStr(sdr["TimeStart"]).Trim();
                        endTime = ClsUtil.ObjToStr(sdr["TimeEnd"]).Trim();
                        errorMsg = ClsUtil.ObjToStr(sdr["Message"]).Trim();
                        total_ct = ClsUtil.ObjToInt(sdr["TotalCount"]);
                        current_ct = ClsUtil.ObjToInt(sdr["CurrentCount"]);
                    }
                }
                con.Close();
            }
        }

        if (errorMsg == "") errorMsg = "(none)";
        else errorMsg = "<br/><font color=\"red\">" + errorMsg.Replace("\r", "<br/>") + "</font>";

        lblTaskName.InnerHtml = "Task Name: " + taskName + "<br/>";
        lblTimeStart.InnerHtml = "Start Time: " + startTime + "<br/>";
        lblTimeEnd.InnerHtml = "End Time: " + endTime + "<br/>";
        lblTotalCt.InnerHtml = "Total Count: " + total_ct.ToString() + "<br/>";
        lblCurrentCt.InnerHtml = "Current Count: " + current_ct.ToString() + "<br/>";
        lblProgress.InnerHtml = "<script type=\"text/javascript\">getProgress(" + total_ct + ", " + current_ct + ");</script>"; 
        lblErrorMsg.InnerHtml = "Error Message: " + errorMsg + "<br/>";
        
        if (startTime != "" && endTime == "")
        {
            this.divTask.Visible = false;
            //this.btnComp.Visible = false;
            this.lblMsg.InnerHtml = "<div><font color=\"green\">Computation is going on ... </font><img src=\"../../images/waiting.gif\" height=\"50\" style=\"vertical-align:middle;\"></div>";
            this.lblMsg.InnerHtml += "<script type=\"text/javascript\">show_progress('" + dlItemName.SelectedValue + "');</script>";
        }
        else
        {
            this.divTask.Visible = true;
            //this.btnComp.Visible = true;
            this.lblMeter.Visible = false;
        }
    }    
}