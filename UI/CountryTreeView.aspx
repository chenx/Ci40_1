<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CountryTreeView.aspx.cs" Inherits="Countries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script type="text/javascript">
// Wrap default javvascript action.
function TreeView_OnLoad() {
    var links = document.getElementById("tvContent").getElementsByTagName("a");
    for (var i = 0; i < links.length; i++) {
        //if (i == 0) alert(links[0]);
        links[i].setAttribute("href", "javascript:NodeClick(\"" + links[i].id + "\", \"" + links[i].getAttribute("href") + "\")");
    }
}

function NodeClick(id, attribute) {
    var nodeLink = document.getElementById(id);
    //alert(nodeLink.innerHTML + " clicked. ");
    var htmlVal = nodeLink.innerHTML;

    if (htmlVal.indexOf("<img") === 0) { // toggle node (+/-).
        showSelected('');
        eval(attribute);
    }
    else if (htmlVal.indexOf("[") === 0) { // field node.
        //alert("is subfield." + ', parentNode: ' + getParentText(nodeLink));
        // Do any custom javascript handling here.
        showSelected(htmlVal); // (nodeLink);
        //eval(attribute);
    }
    else { // parent node.
        showSelected(htmlVal);
        eval(attribute);
    }
}

function showSelected(val) {
    if (val == '') {
        document.getElementById('lblContent').innerHTML = '';
    }
    else {
        document.getElementById('lblContent').innerHTML = 'Selected: ' + val;
    }
}

// Get a node's parent's text.
function getParentText(node) {
    var p = node.parentNode.parentNode.parentNode.parentNode.parentNode.previousSibling
    var txt = p.innerText ? p.innerText : p.textContent;
    return $.trim(txt);
}

$(document).ready(function () {
    TreeView_OnLoad(); // Override default behavior of TreeView nodes.
});

</script>
<style type="text/css">
#divTreeView
{
    border: solid 1px #666;
    height: 600px;
    width: 300px; /*auto;*/
    overflow:auto;
    overflow-y: scroll;    
    overflow-x: scroll;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<p>Demonstrate listing items in hierarchy.</p>

<asp:Label ID="lblMenu" runat="server"></asp:Label>
<asp:Label ID="lblContent" ClientIDMode="Static" runat="server"></asp:Label><br/><br />

<div id="divTreeView">
<asp:TreeView ID="tvContent" ClientIDMode="Static" runat="server" ExpandDepth="0"></asp:TreeView>
</div>

<br /><br />

</asp:Content>

