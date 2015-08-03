<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">
    ///
    /// For 1) Demonstrate single click and double click on DropdownList.
    ///
    $(document).ready(function () {
        $("#dlStates").click(function () {
            var txt = $("#dlStates :selected").text() + ": " + $("#dlStates :selected").val(); // text() for text. val() for val.
            $('#lblMsg').html('Single click on: ' + txt);
        });
        $("#dlStates").dblclick(function () {
            var txt = $("#dlStates :selected").text() + ": " + $("#dlStates :selected").val(); // text() for text. val() for val.
            $('#lblMsg').html('Double click on: ' + txt);
        });
    });


    ///
    /// For 2) Demonstrate CheckBoxList and check/uncheck all.
    ///
    $(document).ready(function () {
        $("#cbAll").click(function () {
            toggleCheckboxes(document.getElementById("cbAll").checked, 'divClStates');
            $('#lblMsg2').html('You selected: ' + getCheckedValues('divClStates'));
        });
        $("#clStates").click(function () {
            $('#lblMsg2').html('You selected: ' + getCheckedValues('divClStates'));
        });
    });

    function getCheckedValues(div) {
        var val = '';
        $("#" + div).find("input:checked").each(function (i, ob) {
            if ($(ob).val() == 'all') {
                val = 'all';
                return false; // break out of loop.
            }
            if (val != '') val += ',';
            val += $(ob).val();
        });

        return val;
    }

    function toggleCheckboxes(val, id) {
        $('#' + id + ' input[type=checkbox]').each(function () {
            $(this).prop('checked', val);
        });
    }


    ///
    /// For 3) Demonstrate Multiple Selection DropDownList.
    /// This widget is from: 
    /// http://www.erichynds.com/examples/jquery-ui-multiselect-widget/demos/
    /// https://github.com/ehynds/jquery-ui-multiselect-widget
    ///
    $(document).ready(function () {
        $("#txtStates").attr('multiple', 'multiple');
        //$("#txtStates").multiselect({header: false}); // Turn off "Check All, Uncheck All" header.
        $("#txtStates").multiselect();
        $("#txtStates").val([""]);
        $("#txtStates").multiselect("refresh");
        $("#txtStates").on('change', function () {
            $('#lblMsg3').html('You selected: ' + getTxtStates());
        });
    });
    
    // if selectedValue is '', then clear all selections.
    function selectDropDownListMultiple(id, selectedValue) {
        // These do not work or do not work well.
        //$("#txtBlockWgtName").prop('selectedIndex', 0);
        //$("#txtBlockWgtName option:selected").removeAttr("selected");
        //$("#txtBlockWgtName option[value='']").attr("selected", "selected");

        var values = selectedValue.split(',');
        $('#' + id).val(values);
        $('#' + id).multiselect("refresh");
    }

    function selectDropDownListSingle(id, selectedValue) {
        $('#' + id + ' option').filter(function () {
            return ($(this).val() === selectedValue);
        }).prop('selected', true);
    }

    function getTxtStates() {
        var msg = '';
        $("#txtStates").children('option:selected').each(function () {
            if (msg !== '') msg += ',';
            msg +=  this.text + '(' + this.value + ')';
        });
        return msg;
    }

    function setTxtStates(val) {
        selectDropDownListMultiple('txtStates', val); 
        $('#lblMsg3').html('You selected: ' + getTxtStates());
        return false;
    }
    
</script>

<!-- These are all for: 3) Demonstrate Multiple Selection DropDownList. -->
<!-- For asp.net 4.0 default style, smoothness is good, or used customized my_jquery-ui in local cupertino. -->
<!-- Other ok style: trontastic,smoothness,redmond,pepper-grinder,eggplant,cupertino,blitzer -->
<!-- For jqueryui styles, see: -->
<!-- [1] http://blog.jqueryui.com/2013/05/jquery-ui-1-10-3/ -->
<!-- [2] http://stackoverflow.com/questions/820412/downloading-jquery-ui-css-from-googles-cdn-->
<!--link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/ui-lightness/jquery-ui.css" /-->
<link rel="stylesheet" type="text/css" href="../Scripts/multiselect/themes/cupertino/my_jquery-ui.css" />
<!--link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1/themes/smoothness/jquery-ui.css" /-->
<link rel="stylesheet" type="text/css" href="../Scripts/multiselect/jquery.multiselect.css" />
<script type="text/javascript" src="../Scripts/multiselect/jquery.multiselect.min.js"></script>

<!-- Below are not required for 3). -->
<!--link rel="stylesheet" type="text/css" href="./Scripts/multiselect/style.css" /-->
<!--link rel="stylesheet" type="text/css" href="./Scripts/multiselect/prettify.css" /-->
<!--script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script-->
<!--script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script-->
<!--script type="text/javascript" src="./Scripts/multiselect/prettify.js"></script-->


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<p>See html source for more information.</p>

<p>1) Demonstrate single click and double click on DropdownList.</p>

<p><asp:Label ID="lblCountry" runat="server"></asp:Label></p>
<asp:DropDownList id="dlStates" ClientIDMode="Static" runat="server" size="10" style="width: 300px;"></asp:DropDownList>
<p>
<asp:Label ID="lblMsg" ClientIDMode="Static" runat="server"></asp:Label>
</p>


<hr />
<p>2) Demonstrate CheckBoxList and check/uncheck all.</p>

<div style="width: 300px; padding-left:3px;"><input type="checkbox" id="cbAll" value='all' class="cb"/>Check All</div>
<div id="divClStates" style="BORDER: 0px solid; OVERFLOW: auto; WIDTH: 300px; HEIGHT: 200px; background-color: #eeeeee;">
<asp:CheckBoxList ID="clStates" ClientIDMode="Static" runat="server" Visible="true" ></asp:CheckBoxList>
</div>
<p>
<asp:Label ID="lblMsg2" ClientIDMode="Static" runat="server"></asp:Label>
</p>

<hr />
<p>3) Demonstrate Multiple Selection DropDownList.</p>

<p>
<button onclick="return setTxtStates('');">Clear Selection</button>
<button onclick="return setTxtStates('AL,AK');">Select Top 2 States</button>
</p>
<asp:DropDownList ID="txtStates" ClientIDMode="Static" runat="server" style="width: 300px;"></asp:DropDownList>
<p>
<asp:Label ID="lblMsg3" ClientIDMode="Static" runat="server"></asp:Label>
</p>

<br /><br />

<br /><br />
<br /><br />
<br /><br />
<br /><br />
<br /><br />

</asp:Content>

