using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

/// <summary>
/// To use asp:Chart, do these:
/// 
/// - Add reference System.Web.UI.DataVisualization.dll to project.
/// - Put this to head of aspx page:
///   <%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
/// - Add the chart control to aspx page:
///   <asp:Chart id="chart1" Height="300" Width="500"  runat="server"></asp:Chart>
/// - in web.config, add these:
///   <configuration>
///     <appSettings>
///       <add key="ChartImageHandler" value="storage=memory;timeout=30;" />
///     </appSettings>
///     <system.webServer>
///       <handlers>
///          <add name="ChartImg" verb="*" path="ChartImg.axd" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
///       </handlers>
///     </system.webServer>
///   </configuration>
/// - In aspx.cs file, add code:
///   (new ClsAspChart).drawLineChart(chart1, dataTable);
/// 
/// References:
/// - http://forums.asp.net/t/1979115.aspx?MS+Chart+not+working+Unknown+server+tag+asp+Chart+
/// - http://www.aspsnippets.com/Articles/Create-ASPNet-Chart-Control-from-Database-using-C-and-VBNet-Example.aspx
/// - http://stackoverflow.com/questions/7633819/c-sharp-automatic-colorcycle-for-legends-in-ms-chart
/// - http://demos.telerik.com/aspnet-ajax/htmlchart/examples/appearance/configuringappearance/defaultcs.aspx
/// </summary>
public class ClsAspChart
{
	public ClsAspChart()
	{
	}


    /// <summary>
    /// Append a programmingly created chart to a Panel.
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="dt"></param>
    /// <param name="ChartName"></param>
    /// <param name="seriesName"></param>
    /// <param name="TitleX"></param>
    /// <param name="TitleY"></param>
    /// <param name="ChartType"></param>
    public void appendDynamicChart(Panel panel, int width, int height,
        DataTable dt, string ChartName, string[] seriesName, string TitleX, string TitleY, SeriesChartType ChartType = SeriesChartType.Line)
    {
        Chart c = new Chart();
        c.Width = width;
        c.Height = height;
        this.drawChart(c, dt, ChartName, seriesName, TitleX, TitleY, ChartType);
        panel.Controls.Add(c);
    }

    /// <summary>
    /// Same as appendDynamicChart(), but call drawChart2() instead of drawChart().
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="dt"></param>
    /// <param name="ChartName"></param>
    /// <param name="seriesName"></param>
    /// <param name="TitleX"></param>
    /// <param name="TitleY"></param>
    /// <param name="ChartType"></param>
    public void appendDynamicChart2(Panel panel, int width, int height,
    DataTable dt, string ChartName, string[] seriesName, string TitleX, string TitleY, SeriesChartType ChartType = SeriesChartType.Line)
    {
        Chart c = new Chart();
        c.Width = width;
        c.Height = height;
        this.drawChart2(c, dt, TitleX, TitleY, ChartType);
        panel.Controls.Add(c);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="chart"></param>
    /// <param name="dt"></param>
    /// <param name="ChartName"></param>
    /// <param name="seriesName"></param>
    /// <param name="TitleX"></param>
    /// <param name="TitleY"></param>
    /// <param name="ChartType"></param>
    public void drawChart(Chart chart, DataTable dt, string ChartName, string[] seriesName, string TitleX, string TitleY, SeriesChartType ChartType = SeriesChartType.Line)
    {
        if (ChartType == SeriesChartType.Pie) {
            drawPieChart(chart, dt, ChartName, seriesName, TitleX, TitleY, ChartType);
            return;
        }

        chart.Titles.Add(new Title(ChartName, Docking.Top, new Font("Helvetica", 12f), Color.Brown));

        chart.Palette = ChartColorPalette.BrightPastel;
        //chart.Palette = ChartColorPalette.Excel;

        decimal maxY = 0;
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            if (i >= seriesName.Length) chart.Series.Add("Series " + (i + 1));
            else chart.Series.Add(seriesName[i]);

            string[] x = new string[dt.Columns.Count];
            decimal[] y = new decimal[dt.Columns.Count];

            for (int j = 0; j < dt.Columns.Count; ++j)
            {
                x[j] = dt.Columns[j].ColumnName;
                y[j] = Convert.ToDecimal(ClsUtil.ObjToDouble(dt.Rows[i][j]));
                maxY = Math.Max(maxY, y[j]);
            }
            chart.Series[i].Points.DataBindXY(x, y);

            SetSerieType(chart.Series[i], ChartType);
        }

        chart.ChartAreas.Add(dt.TableName);
        FormatChartArea(chart.ChartAreas[0], maxY, TitleX, TitleY);

        chart.Legends.Add(dt.TableName);
        FormatLegend(chart.Legends[0]);

        chart.Visible = true;
    }


    /// <summary>
    /// Pie chart, compared to other chart types, can only have one series.
    /// </summary>
    /// <param name="chart"></param>
    /// <param name="dt"></param>
    /// <param name="ChartName"></param>
    /// <param name="seriesName"></param>
    /// <param name="TitleX"></param>
    /// <param name="TitleY"></param>
    /// <param name="ChartType"></param>
    private void drawPieChart(Chart chart, DataTable dt, string ChartName, string[] seriesName, string TitleX, string TitleY, SeriesChartType ChartType = SeriesChartType.Line)
    {
        chart.Titles.Add(new Title(ChartName, Docking.Top, new Font("Helvetica", 12f), Color.Brown));

        chart.Palette = ChartColorPalette.BrightPastel;
        //chart.Palette = ChartColorPalette.Excel;

        decimal maxY = 0;
        int i = 0;
        //for (int i = 0; i < dt.Rows.Count; ++i)
        //{
            if (i >= seriesName.Length) chart.Series.Add("Series " + (i + 1));
            else chart.Series.Add(seriesName[i]);

            string[] x = new string[dt.Columns.Count];
            decimal[] y = new decimal[dt.Columns.Count];

            for (int j = 0; j < dt.Columns.Count; ++j)
            {
                x[j] = dt.Columns[j].ColumnName;
                y[j] = Convert.ToDecimal(ClsUtil.ObjToDouble(dt.Rows[i][j]));
                maxY = Math.Max(maxY, y[j]);
            }
            chart.Series[i].Points.DataBindXY(x, y);

            SetSerieType(chart.Series[i], ChartType);
        //    break;
        //}

        chart.ChartAreas.Add(dt.TableName);
        //FormatChartArea(chart.ChartAreas[0], maxY, TitleX, TitleY);

        chart.Legends.Add(dt.TableName);
        FormatLegend(chart.Legends[0]);

        chart.Visible = true;
    }

    /// <summary>
    /// Series names are in first column of dt.
    /// </summary>
    /// <param name="chart"></param>
    /// <param name="dt"></param>
    /// <param name="TitleX"></param>
    /// <param name="TitleY"></param>
    /// <param name="ChartType"></param>
    public void drawChart2(Chart chart, DataTable dt, string TitleX, string TitleY, SeriesChartType ChartType = SeriesChartType.Line)
    {
        chart.Titles.Add(new Title(dt.TableName, Docking.Top, new Font("Helvetica", 12f), Color.Brown));

        chart.Palette = ChartColorPalette.BrightPastel;
        //chart.Palette = ChartColorPalette.Excel;

        decimal maxY = 0;
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            chart.Series.Add(dt.Rows[i][0].ToString());

            string[] x = new string[dt.Columns.Count - 1];
            decimal[] y = new decimal[dt.Columns.Count - 1];

            for (int j = 1; j < dt.Columns.Count; ++j)
            {
                x[j - 1] = dt.Columns[j].ColumnName;
                y[j - 1] = Convert.ToDecimal(ClsUtil.ObjToDouble(dt.Rows[i][j]));
                maxY = Math.Max(maxY, y[j - 1]);
            }
            chart.Series[i].Points.DataBindXY(x, y);

            SetSerieType(chart.Series[i], ChartType);
        }

        chart.ChartAreas.Add(dt.TableName);
        FormatChartArea(chart.ChartAreas[0], maxY, TitleX, TitleY);

        chart.Legends.Add(dt.TableName);
        FormatLegend(chart.Legends[0]);

        chart.Visible = true;
    }

    private void FormatLegend(Legend legend) {
        legend.Enabled = true;

        //chart.Legends["Legend1"].Position.Auto = false;
        //chart.Legends[0].Position = new ElementPosition(30, 5, 100, 20);
        legend.Docking = Docking.Bottom;
        legend.Alignment = StringAlignment.Center;
    }

    private void FormatChartArea(ChartArea ChartArea, decimal maxY, string TitleX, string TitleY)
    {
        ChartArea.AxisY.Maximum = Math.Ceiling(Convert.ToDouble(maxY * (decimal)1.11) * 10) / 10; // 1.0;
        ChartArea.AxisY.Interval = ChartArea.AxisY.Maximum / 10; // 0.05;
        //ChartArea.Area3DStyle.Enable3D = true;
        ChartArea.BorderColor = Color.Gray;
        ChartArea.AxisY.LabelStyle.Font = new Font("Verdana", 8f);
        ChartArea.AxisX.LabelStyle.Font = new Font("Verdana", 8f);

        //chart.BorderlineColor = Color.Silver;
        ChartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
        ChartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
        ChartArea.AxisX.LineColor = Color.DarkGray;
        ChartArea.AxisY.LineColor = Color.DarkGray;
        //ChartArea.AxisY.LineWidth = 2;

        //ChartArea.AxisX.MajorGrid.Interval = 1;
        //ChartArea.AxisX.MajorGrid.IntervalOffset = 0.5;
        //ChartArea.AxisX.Crossing = 0.5;
        //ChartArea.AxisX.Minimum = 0.5;
        /*
        //ChartArea.AxisX.Interval = 0.5;
        ChartArea.AxisX.MinorGrid.Interval = 0.5;
        ChartArea.AxisX.MinorGrid.Enabled = true;
        ChartArea.AxisX.MinorGrid.LineColor = Color.LightGray;
        ChartArea.AxisX.MajorGrid.LineColor = Color.White;
        */

        //ChartArea.AxisX.LabelStyle = new LabelStyle();
        ChartArea.AxisX.Title = TitleX;
        ChartArea.AxisY.Title = TitleY;
    }

    private void SetSerieType(Series serie, SeriesChartType ChartType)
    {
        serie.ChartType = ChartType;

        if (ChartType == SeriesChartType.Line)
        {
            serie.MarkerStyle = MarkerStyle.Circle;
            serie.MarkerSize = 10;
        }

        // Add tooltip to data points. See:
        // - http://blogs.msdn.com/b/alexgor/archive/2008/11/11/microsoft-chart-control-how-to-using-keywords.aspx
        // - https://msdn.microsoft.com/en-us/library/vstudio/dd456772%28v=vs.100%29.aspx
        // - http://stommepoes.nl/Homeselling/aziekaart.html
        //
        // To add customized onmouseover event, see AspChart.aspx OnPrePaint() event:
        // there Tooltip can also be specified, and will overwrite the value specificed here.
        // The advantage there is to specify onmouseover javascript event etc.
        serie.ToolTip = serie.Name + ": (#VALX, #VALY)"; // serie.Points.Count.ToString();
                
        serie.IsValueShownAsLabel = true;
        serie.MarkerBorderWidth = 2;
        serie.BorderWidth = 2;
    }

}