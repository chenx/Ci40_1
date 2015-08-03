<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<p>The map is generated from: <a href="http://www.map-embed.com/">http://www.map-embed.com/</a></p>
<p>Also refer to: <a href="https://developers.google.com/maps/documentation/embed/">Google Maps Embed API</a>. A API key is needed to access more functions.</p>

<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
<div style="overflow:hidden;height:300px;width:600px;">
<div id="gmap_canvas" style="height:300px;width:600px;"></div>
<style>#gmap_canvas img{max-width:none!important;background:none!important}</style>
<a class="google-map-code" href="http://premium-wordpress-themes.org" id="get-map-data">premium-wordpress-themes.org</a>
</div>
<script type="text/javascript">function init_map() { var myOptions = { zoom: 14, center: new google.maps.LatLng(37.6239079, -122.38159239999999), mapTypeId: google.maps.MapTypeId.ROADMAP }; map = new google.maps.Map(document.getElementById("gmap_canvas"), myOptions); marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(37.6239079, -122.38159239999999) }); infowindow = new google.maps.InfoWindow({ content: "<b>San Francisco International Airport (SFO)</b><br/><br/>94128 San Francisco" }); google.maps.event.addListener(marker, "click", function () { infowindow.open(map, marker); }); infowindow.open(map, marker); } google.maps.event.addDomListener(window, 'load', init_map);</script>

<br />

</asp:Content>

