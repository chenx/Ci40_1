using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Draw AjaxControlToolkit chart.
/// 
/// Note when y max value is below 0.39, it won't draw correctly.
/// Therefore a yExpandFactor is used to artifitially fix the problem:
/// Use a factor of 100 when calling function here, so it hides the bug.
/// 
/// References:
/// - http://www.aspsnippets.com/Articles/ASPNet-AJAX-Line-Chart-Control-Populate-from-Database-example.aspx
/// - http://www.aspsnippets.com/Articles/ASPNet-AJAX-Line-Chart-Control-Multiple-Series-Populate-from-Database-example.aspx
/// </summary>
public class ClsAjaxChart
{
    public ClsAjaxChart()
	{	
	}
    
    /// <summary>
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="LineChart"></param>
    public void drawLineChart(AjaxControlToolkit.LineChart Chart, DataTable dt, int yScaleFactor = 1)
    {
        if (Chart == null) return;

        string[] x = new string[dt.Columns.Count - 1];

        for (int i = 1; i < dt.Columns.Count; ++i)
        {
            x[i - 1] = dt.Columns[i].ColumnName;
            Chart.CategoriesAxis = string.Join(",", x);
            //Response.Write(ClsConvert.ArrayToHTML(x));
        }
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            decimal[] y = new decimal[dt.Columns.Count - 1];
            for (int j = 1; j < dt.Columns.Count; ++j)
            {
                y[j - 1] = Convert.ToDecimal(ClsUtil.ObjToDouble(dt.Rows[i][j])) * yScaleFactor;
            }
            //Response.Write(ClsConvert.ArrayToHTML(y));
            Chart.Series.Add(new AjaxControlToolkit.LineChartSeries { Name = dt.Rows[i][0].ToString(), Data = y });
        }
        Chart.ChartTitle = dt.TableName;

        Chart.Visible = true;
    }


    public void drawBarChart(AjaxControlToolkit.BarChart Chart, DataTable dt, int yScaleFactor = 1)
    {
        if (Chart == null) return;

        string[] x = new string[dt.Columns.Count - 1];

        for (int i = 1; i < dt.Columns.Count; ++i)
        {
            x[i - 1] = dt.Columns[i].ColumnName;
            Chart.CategoriesAxis = string.Join(",", x);
            //Response.Write(ClsConvert.ArrayToHTML(x));
        }
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            decimal[] y = new decimal[dt.Columns.Count - 1];
            for (int j = 1; j < dt.Columns.Count; ++j)
            {
                y[j - 1] = Convert.ToDecimal(ClsUtil.ObjToDouble(dt.Rows[i][j])) * yScaleFactor;
            }
            //Response.Write(ClsConvert.ArrayToHTML(y));
            Chart.Series.Add(new AjaxControlToolkit.BarChartSeries { Name = dt.Rows[i][0].ToString(), Data = y });
        }
        Chart.ChartTitle = dt.TableName;

        Chart.Visible = true;
    }
    
}