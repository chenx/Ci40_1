<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Wizard.aspx.cs" Inherits="Wizard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
.BtnPrev, .BtnNext 
{
    width: 100px;    
    /*background-color: Green;
    height: 30px;*/
}
.NavBar
{
    /*border: 1px solid gray;
    width: 180px;
    height: 30px;*/
}
.SideBar
{
    border: 2px solid gray;
    width: 160px;
    height: 30px;
    padding-left: 35px;
    text-align:center;
    vertical-align: top;
    line-height: 25px;
}
.StepContent
{
    padding: 10px;
}
.tbl_wizard
{
    width: 800px;
    height: 400px;
    vertical-align: top;
}
.tbl_wizard td
{
    vertical-align: top;
}

.dropdownList
{
    width: 200px;
}

#divFooterTop
{
    display: block;
    height: 50px;
}
#divFooter
{
    display: block;
    height: 80px;
    color: White;
    background-color: #ffffff;
}
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $('#btnSelectState').click(function () {
            var v = $('#dlState').val();
            if (v == null || v == '') {
                alert('Please select a State to add');
                return false;
            }
        });

        $('#btnDeSelectState').click(function () {
            var v = $('#dlStateSelected').val();
            if (v == null || v == '') {
                alert('Please select a State to remove');
                return false;
            }
        });
    });

    /*function getSelectedState() {
        //alert($('#spanState').html());
        //var StateList = getCheckedValues('divState', 'cbState');
        //$('#spanState').html(StateList);
        var StateList = '';
        $('#dlStateSelected option').each(function () {
            StateList += $(this).val();
        });
        if (StateList != '') alert(StateList);

        disableStartNextButton(StateList == '');
    }

    function disableStartNextButton(disabled) {
        document.getElementById('StartNextButton').disabled = disabled;
    }*/
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<h1>Wizard</h1>
<br />

<asp:Wizard ID="wizard1" ClientIDMode="Static" runat="server" BorderWidth="1"  
    StartNextButtonStyle-CssClass="BtnNext" OnSideBarButtonClick="Wizard1_OnOnSideBarButtonClick"
    StepPreviousButtonStyle-CssClass="BtnPrev" StepNextButtonStyle-CssClass="BtnNext" style="vertical-align:top;">
    <HeaderStyle HorizontalAlign="Center" Font-Bold="True" />
    
    <NavigationStyle CssClass="NavBar" />
    <SideBarStyle CssClass="SideBar" />
    <StepStyle CssClass="StepContent" />

    <HeaderTemplate>
    </HeaderTemplate>
    

    <WizardSteps>

        <asp:WizardStep ID="WizardStep1" OnActivate="do_activate_step1" OnDeactivate="do_deactivate_step1" Title="Country and State">
    
            <h2>Choose Country and State</h2>
            <table class="tbl_wizard">
            <tr>
            <td>
            
            <table>
            <tr>
                <td>
                Choose Country: <br />
                <asp:DropDownList ID="dlGeo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dlGeo_OnSelectedIndexChanged" size="1" CssClass="dropdownList"></asp:DropDownList>    
                <br />
                Choose State: <br />
                <asp:DropDownList ID="dlState" ClientIDMode="Static" runat="server" size="5"  CssClass="dropdownList"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnSelectState" Text="Add State" runat="server" OnClick="btnSelectState_OnClick" style="width: 120px;" /><br />
                <asp:Button ID="btnDeSelectState" Text="Remove State" runat="server" OnClick="btnDeSelectState_OnClick" style="width: 120px;" />
                <br />
                <br />
                Selected State:<br />
                <asp:DropDownList ID="dlStateSelected" ClientIDMode="Static" runat="server" size="5"  CssClass="dropdownList"></asp:DropDownList>
                </td>
            </tr>
            </table>
            
            <asp:Label ID="lblMsg" runat="server"></asp:Label>

            </td>
            </tr>
            </table>

        </asp:WizardStep>

        <asp:WizardStep ID="WizardStep2" OnActivate="do_activate_step2" OnDeactivate="do_deactivate_step2" AllowReturn="true" Title="Options">
    
            <h2>Choose Options</h2>
            <table class="tbl_wizard">
            <tr>
            <td>
                <asp:Label ID="lblInfo" runat="server"></asp:Label>
            </td>
            </tr>
            </table>

        </asp:WizardStep>
 
        <asp:WizardStep ID="WizardStep3" OnActivate="do_activate_step3" OnDeactivate="do_deactivate_step3" AllowReturn="true" Title="Payment">
    
            <h2>Payment Information</h2>
            <table class="tbl_wizard">
            <tr>
            <td>3</td>
            </tr>
            </table>

        </asp:WizardStep>

        <asp:WizardStep ID="WizardStep4" OnActivate="do_activate_step4" OnDeactivate="do_deactivate_step4" AllowReturn="true" Title="Confirm">
    
            <h2>Confirm and Commit</h2>
            <table class="tbl_wizard">
            <tr>
            <td>4</td>
            </tr>
            </table>

        </asp:WizardStep>

        <asp:WizardStep ID="WizardStep5" Title="Complete" OnActivate="do_activate_step1" OnDeactivate="do_deactivate_step5">
    
            <h2>Acknowledgement</h2>
            <table class="tbl_wizard">
            <tr>
            <td>5</td>
            </tr>
            </table>

        </asp:WizardStep>

    </WizardSteps>


    <StartNavigationTemplate>
        <div style="height: 5px; padding-top: 10px; padding-right: 10px; padding-bottom: 10px;">
        <asp:Button ID="StartNextButton" runat="server" CssClass="BtnNext" CommandName="MoveNext" Text="Next" />
        </div>
        <br />    
    </StartNavigationTemplate>
    
    <StepNavigationTemplate>
        <div style="height: 5px; padding-top: 10px; padding-right: 10px; padding-bottom: 10px;">
        <asp:Button ID="StepPreviousButton" runat="server" CssClass="BtnNext" CausesValidation="False" CommandName="MovePrevious" Text="Previous" />
        <asp:Button ID="StepNextButton" runat="server" CssClass="BtnNext" CommandName="MoveNext" Text="Next" />
        </div>
        <br />
    </StepNavigationTemplate>

    <FinishNavigationTemplate>
        <div style="height: 5px; padding-top: 10px; padding-right: 10px; padding-bottom: 10px;">
        <asp:Button ID="btnFinish" ClientIDMode="Static" CssClass="BtnNext" Text="Finish" runat="server" OnClick="btnFinish_OnClick"/>
        </div>
        <br />
    </FinishNavigationTemplate>
    
</asp:Wizard>

<div id="divFooterTop"></div>
<div id="divFooter"></div>

</asp:Content>

