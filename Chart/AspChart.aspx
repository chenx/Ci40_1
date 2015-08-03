<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AspChart.aspx.cs" Inherits="AspChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
#circle {
    width: 100px;
    height: 100px;
    background: red;
    -moz-border-radius: 50px;
    -webkit-border-radius: 50px;
    border-radius: 50px;
}
</style>
<script type="text/javascript">
    function chart1_event(a) {
        //alert(a);
    }

    /*
    $(document).ready(function () {
        $("area").hover(
          function () {
              //($(this).css('background-color', 'black')); return;
              //$(this).css('border', '1px solid black');
              // area has no border so this won't work.
              //$(this).css({ "border-color": "#000000",
              //    "border-width": "1px",
              //    "border-style": "solid"
              //});
              //alert($(this).attr('coords')); // e.g., for circle: 346,205,5
              //var pos0x = $('#MainContent_chart1ImageMap').css('top');
              //var pos0y = $('#MainContent_chart1ImageMap').css('left');
              //alert(pos0x);

              $('#circle').detach().appendTo('#MainContent_chart1ImageMap');
              var pos = $(this).attr('coords').split(',');
              //alert(pos[0] + ',' + pos[1]);
              $("#circle").parent().css({ position: 'relative' });
              $("#circle").css({ top: pos[0] + 'px', left: pos[1] + 'px', position: 'absolute' });
              $("#circle").show();
          },
          function () {
              $("#circle").hide();
          }
        );
    });
    */
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<p>Demonstrate ASP:Chart.</p>

<div id="circle" style="display:none;"></div>
<asp:Chart id="chart1" Height="300" Width="500" Visible="false" runat="server" OnPrePaint="chart1_Load">
</asp:Chart>

<asp:Chart id="chart2" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>
<asp:Chart id="chart3" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>
<asp:Chart id="chart4" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>
<asp:Chart id="chart5" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>
<asp:Chart id="chart6" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>

<asp:Chart id="chartB1" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>
<asp:Chart id="chartB2" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>
<asp:Chart id="chartB3" Height="300" Width="500" Visible="false" runat="server"></asp:Chart>

</asp:Content>

