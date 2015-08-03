using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class AspChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) init();
    }
    
    private void init() {
        ClsData data = new ClsData();

        DataTable dt = data.getDataTable();
        string[] seriesName = new string[] { "Series 1", "Series 2", "Series 3" };
        
        ClsAspChart chart = new ClsAspChart();
        chart.drawChart(chart1, dt, "Line Chart", seriesName, "Year", "Amount", SeriesChartType.Line);
        chart.drawChart(chart2, dt, "Column Chart", seriesName, "Year", "Amount", SeriesChartType.Column);
        chart.drawChart(chart3, dt, "Bar Chart", seriesName, "Year", "Amount", SeriesChartType.Bar);
        chart.drawChart(chart4, dt, "Area Chart", seriesName, "Year", "Amount", SeriesChartType.Area);
        chart.drawChart(chart5, dt, "Pie Chart", seriesName, "Year", "Amount", SeriesChartType.Pie);
        chart.drawChart(chart6, dt, "Stock Chart", seriesName, "Year", "Amount", SeriesChartType.Stock);

        DataTable dt2 = data.getDataTable2();

        dt2.TableName = "Line Chart 2";
        chart.drawChart2(chartB1, dt2, "Year", "Amount", SeriesChartType.Line);
        dt2.TableName = "Column Chart 2";
        chart.drawChart2(chartB2, dt2, "Year", "Amount", SeriesChartType.Column);
        dt2.TableName = "Bar Chart 2";
        chart.drawChart2(chartB3, dt2, "Year", "Amount", SeriesChartType.Bar);
    }


    /// <summary>
    /// For customized event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chart1_Load(object sender, ChartPaintEventArgs e)
    {
        if (e.ChartElement is Series)
        {
            Series series = (Series)e.ChartElement; 
            series.MapAreaAttributes = "onmouseover=\"javascript: chart1_event('" + series.Name + ": #VALY-#VALX');\"";
        }
    }
}