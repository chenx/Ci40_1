using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsData
/// </summary>
public class ClsData
{
	public ClsData()
	{
	}


    public DataTable getDataTable()
    {
        DataTable dt = new DataTable();
        dt.TableName = "Statistics";

        dt.Columns.Add("2011");
        dt.Columns.Add("2012");
        dt.Columns.Add("2013");
        dt.Columns.Add("2014");
        dt.Columns.Add("2015");

        dt.Rows.Add(new string[] { "1", "2", "4.3", "5", "6" });
        dt.Rows.Add(new string[] { "2", "3.2", "1.3", "0.5", "3" });
        dt.Rows.Add(new string[] { "1.4", "2.1", "3.1", "4.5", "6.1" });

        return dt;
    }


    public DataTable getDataTable2()
    {
        DataTable dt = new DataTable();
        dt.TableName = "Statistics";

        dt.Columns.Add("Value");
        dt.Columns.Add("2011");
        dt.Columns.Add("2012");
        dt.Columns.Add("2013");
        dt.Columns.Add("2014");
        dt.Columns.Add("2015");

        dt.Rows.Add(new string[] { "Series A", "1", "2", "4.3", "5", "6" });
        dt.Rows.Add(new string[] { "Series B", "2", "3.2", "1.3", "0.5", "3" });
        dt.Rows.Add(new string[] { "Series C", "1.4", "2.1", "3.1", "4.5", "6.1" });

        return dt;
    }
}