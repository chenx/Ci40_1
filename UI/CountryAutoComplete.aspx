<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CountryAutoComplete.aspx.cs" Inherits="Countries" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<p>Demonstrate AutoComplete Extender.</p>

<asp:Label ID="lblMenu" runat="server"></asp:Label>

<hr />
<p>Search State in Country:</p>
<asp:DropDownList ID="lblCountryList" ClientIDMode="Static" runat="server"></asp:DropDownList>

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods = "true"></asp:ScriptManager>  
<asp:TextBox id="txtSearch" placeholder="Search State" name="txtSearch" ClientIDMode="Static" runat="server" 
             style="vertical-align: middle; width:400px;" onkeyup="SetContextKey()" />
<cc1:AutoCompleteExtender ID="AutoCompleteExtender1" ClientIDMode="Static" runat="server" 
             ServiceMethod="GetList" UseContextKey="true"
             MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="false" CompletionSetCount="1"
             TargetControlID="txtSearch" FirstRowSelected="false"></cc1:AutoCompleteExtender>

<br /><br />
<hr />

<p>Search Chinese Character by Pinyin (单拼输入):</p>
<asp:TextBox id="txtSearchCharCN" placeholder="Search Chinese By Pinyin" name="txtSearchCharCN" ClientIDMode="Static" runat="server" 
             style="vertical-align: middle; width:400px;" onkeyup="detectCN()" />
<cc1:AutoCompleteExtender ID="AutoCompleteExtender2" ClientIDMode="Static" runat="server" 
             ServiceMethod="GetListCharCN" UseContextKey="true" 
             MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="True" CompletionSetCount="1"
             DelimiterCharacters=":" ShowOnlyCurrentWordInCompletionListItem="true"
             TargetControlID="txtSearchCharCN" FirstRowSelected="true"></cc1:AutoCompleteExtender>
<br />
<asp:Label ID="lblContent" ClientIDMode="Static" runat="server"></asp:Label><br/><br />

<p>Note: </p>
<ul>
<li>Here it searches in about 10k chinese characters. The speed is good when computer load is fine.</li>
<li>The default behavior of AutoCompleteExtender is to replace the entire textbox content instead of append to it,
so it cannot continuously append new Chinese letters here.</li>
<li>Well, there is a way to do this: set DelimiterCharacters (i.e., to space or color ':'), and ShowOnlyCurrentWordInCompletionListItem to true, 
then you can enter more than 1 Chinese character by typing a delimiter after each. But this is still not so clean, since an 
artificial delimiter is used.</li>
<li>Right now this uses a workaround, since you most of the time press the enter key when adding a new Chinese character.
When the enter key is pressed, remove delimiters, then append a delimiter at the end for entering next Chinese
letter. However if you backspace and remove that delimiter, new input will overwrite all previous input.</li>
<li>Alternatively, an improved AutoCompleteExtender to address the above problem is available <a href="http://www.codeproject.com/Articles/15960/Custom-AutoCompleteExtender-with-multiple-word-sug">here</a>.</li>
</ul>

<br /><br />


<script type = "text/javascript">
    function SetContextKey() {
        $find('<%=AutoCompleteExtender1.ClientID%>').set_contextKey($get("<%=lblCountryList.ClientID %>").value);
    }
        
    function detectCN() {
        var v = $('#txtSearchCharCN').val();
        var o = document.getElementById('lblContent');
        o.innerHTML = '';
        var strToDetect = '';
        for (var i = v.length - 1; i >= 0; --i) {
            var is_cn = isCN(v[i]);
            o.innerHTML = v[i] + ':' + is_cn + ', ' + o.innerHTML;
            if (!is_cn) strToDetect = v[i] + strToDetect;
        }
        while (strToDetect.length > 0 && (strToDetect[0] === ':' || strToDetect[0] == ' ')) {
            strToDetect = strToDetect.substr(1);
        }
        o.innerHTML += '. strToDetect = ' + strToDetect;

        $find('<%=AutoCompleteExtender2.ClientID%>').set_contextKey(strToDetect);
        //document.getElementById('lblContent').innerHTML = ':' + isCN($('#txtSearchCharCN').val());
    }

    function isCN(sel) { 
        return sel.toString().match(/[\u3400-\u9FBF]/) ? true : false;
    }

    function postProcessInput() {
        $('#txtSearchCharCN').val($('#txtSearchCharCN').val().replace(':', ''));
        $('#txtSearchCharCN').val($('#txtSearchCharCN').val() + ':');
    }

    $(document).ready(function () {
        // Need this. Otherwise after lblCountryList selection is changed, the first time search for something,
        // it still uses the old value of the dropdown list.
        $('#lblCountryList').change(function () {
            SetContextKey();
        });

        $('#txtSearchCharCN').on('input', function () {
            detectCN();
        });

        $('#txtSearchCharCN').keyup(function (e) {
            if (e.which == 13 || e.keyCode == 13) {
                postProcessInput();
            }
        });

        $('#txtSearchCharCN').mouseup(function (e) {
            postProcessInput();
        });
    });
</script>

</asp:Content>

