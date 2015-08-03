<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SPCompute" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    window.jQuery || document.write('<script src="../../Scripts/jquery-1.10.2.js"><\/script> <script src="../../Scripts/jquery-ui-1.11.4.js"><\/script>');
    //alert(typeof jQuery); // this needs to be moved to body to function.
</script>

<script type="text/javascript" src="../../Scripts/SPCompute.js"></script>
<link href="../../Styles/meter.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Stored Procedure Computation and Progress Bar</h1>

<p>
After start computation, you can leave this page and come back. The computation goes on and will not be interrupted.
This is achieved by using ajax call to a Handler in the background. The progress is stored in database and 
retrieved by ajax to display on user interface.
</p>

<p>This page can be improved such that multiple tasks are displayed simultaneously. New task can be just added to 
database and then displayed here.</p>

<br />

<div runat="server" clientidmode="Static" id="divTask">
<button id="btnComp">Compute</button>

Task Name: 
<asp:DropDownList ID="dlItemName" runat="server" AutoPostBack="true" ClientIDMode="Static">
<asp:ListItem Text="item1"></asp:ListItem>
</asp:DropDownList>
Task Size:
<asp:DropDownList ID="dlItemCount" runat="server" ClientIDMode="Static">
<asp:ListItem Text="5"></asp:ListItem>
<asp:ListItem Text="10"></asp:ListItem>
<asp:ListItem Text="20"></asp:ListItem>
<asp:ListItem Text="100"></asp:ListItem>
<asp:ListItem Text="200"></asp:ListItem>
</asp:DropDownList>
</div>

<div id="lblMsg" runat="server" clientidmode="Static">&nbsp;</div>

<div id="lblTaskName" runat="server" clientidmode="Static"></div>
<div id="lblTimeStart" runat="server" clientidmode="Static"></div>
<div id="lblTimeEnd" runat="server" clientidmode="Static"></div>
<div id="lblTotalCt" runat="server" clientidmode="Static"></div>
<div id="lblCurrentCt" runat="server" clientidmode="Static"></div>
<span id="lblProgress" runat="server" clientidmode="Static"></span>
<div id="lblMeter" runat="server" clientidmode="Static" class="meter"><span id="meter1"></span></div>
<div id="lblErrorMsg" runat="server" clientidmode="Static"></div>

</asp:Content>

