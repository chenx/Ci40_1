<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AjaxChart.aspx.cs" Inherits="AjaxChart" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<p>Demonstrate AjaxControlToolkit Chart. Some obvious disadvantages as compared to ASP:Chart (thus the latter is more favorable):
<br /> - if all values are less than a threshold (~ 0.39), then data will be shown as zero. A workaround is to use a scale factor like 10 or 100.
<br /> - poor control on min/max X/Y values and X/Y titles.
<br /> - chart will take the entire row, like div in "block" style; in comparison, ASP:Chart is like span in "inline" mode.
<br /> - value labels may overlap.
<br /> - the artificial delay in drawing line chart may be annoying.
</p>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<cc1:LineChart id="chart1" Height="300" Width="500" Visible="false" runat="server"></cc1:LineChart>
<cc1:LineChart id="chart2" Height="300" Width="500" Visible="false" runat="server"></cc1:LineChart>
<cc1:LineChart id="chart3" Height="300" Width="500" Visible="false" runat="server"></cc1:LineChart>
<cc1:LineChart id="chart4" Height="300" Width="500" Visible="false" runat="server"></cc1:LineChart>
<cc1:LineChart id="chart5" Height="300" Width="500" Visible="false" runat="server"></cc1:LineChart>
<cc1:LineChart id="chart6" Height="300" Width="500" Visible="false" runat="server"></cc1:LineChart>

<div style="background-color:#eeeeee; width: 524px; display: block; padding: 2px;">
<cc1:LineChart ID="LineChart1" Visible="false" ChartWidth="520" ChartHeight="300" BorderStyle="None" runat="server"></cc1:LineChart><br/>
<cc1:BarChart ID="BarChart1" Visible="false" ChartWidth="520" ChartHeight="300" BorderStyle="None" runat="server"></cc1:BarChart>
</div>

</asp:Content>

