<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
  // From: http://stackoverflow.com/questions/9162933/make-iframe-height-dynamic-based-on-content-inside-jquery-javascript
  function iframeLoaded() {
      var iFrameID = document.getElementById('iframeReadme');
      if(iFrameID) {
            //iFrameID.height = "";
            iFrameID.height = (iFrameID.contentWindow.document.body.scrollHeight + 50) + "px";
      }   
  }
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<iframe id="iframeReadme" src="README.html" style="width:100%; border: 0px;" onload="iframeLoaded();"></iframe>
    
</asp:Content>
