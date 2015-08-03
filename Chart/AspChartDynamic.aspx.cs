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
        this.Title = "Dynamic ASP Chart";
        ClsData data = new ClsData();

        DataTable dt = data.getDataTable();
        string[] seriesName = new string[] { "Series 1", "Series 2", "Series 3" };
        
        ClsAspChart chart = new ClsAspChart();
        chart.drawChart(chart1, dt, "Line Chart", seriesName, "Year", "Amount", SeriesChartType.Line);

        //panel1.Width = 500;

        for (int i = 0; i < 2; ++i)
        {
            chart.appendDynamicChart(panel1, 500, 300, dt, "Line Chart", seriesName, "Year", "Amount", SeriesChartType.Line);
            chart.appendDynamicChart(panel1, 500, 300, dt, "Column Chart", seriesName, "Year", "Amount", SeriesChartType.Column);
            chart.appendDynamicChart(panel1, 500, 300, dt, "Bar Chart", seriesName, "Year", "Amount", SeriesChartType.Bar);
            chart.appendDynamicChart(panel1, 500, 300, dt, "Area Chart", seriesName, "Year", "Amount", SeriesChartType.Area);
            chart.appendDynamicChart(panel1, 500, 300, dt, "Pie Chart", seriesName, "Year", "Amount", SeriesChartType.Pie);
            chart.appendDynamicChart(panel1, 500, 300, dt, "Stock Chart", seriesName, "Year", "Amount", SeriesChartType.Stock);
        }
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