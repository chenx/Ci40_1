<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateNewUser.aspx.cs" Inherits="Admin_CreateNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1><a href="Users.aspx">Manage Users</a> &gt; Create New User</h1>
<br />

    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
                              ContinueDestinationPageUrl="~/Admin/CreateNewUser.aspx" 
                              LoginCreatedUser="false"
                              DisableCreatedUser="false" 
                              Font-Names="Verdana" 
                              BackColor="white"
                              Font-Size="10pt" 
                              BorderWidth="1px" 
                              BorderColor="#CCCC99" 
                              BorderStyle="Solid"
                              CellPadding="20"
                              CompleteSuccessText="The account has been successfully created." 
                              UnknownErrorMessage="The account was not created. Please try again."
                              OnCreatedUser="CreateUserWizard1_CreatedUser" style="margin:auto;"> 
            
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="Step 1">
                    <ContentTemplate>

                        <table style="font-size: 10pt; font-family: Verdana" border="0" width="400">
                            <tr>
                                <td style="font-weight: bold; color: white; background-color: #6b696b" align="center" colspan="2">
                                    Create Your UserID
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">UserID:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ToolTip="User Name is required."
                                        ErrorMessage="User Name is required." ValidationGroup="CreateUserWizard1" ControlToValidate="UserName">
                                        *</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ToolTip="Password is required."
                                        ErrorMessage="Password is required." ValidationGroup="CreateUserWizard1" ControlToValidate="Password">
                                        *</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Re-Type Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ToolTip="Confirm Password is required."
                                        ErrorMessage="Confirm Password is required." ValidationGroup="CreateUserWizard1"
                                        ControlToValidate="ConfirmPassword">
                                        *</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">Email:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ToolTip="Email is required."
                                        ErrorMessage="Email is required." ValidationGroup="CreateUserWizard1" ControlToValidate="Email">
                                        *</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                            
                    </ContentTemplate>
            </asp:CreateUserWizardStep>

            <asp:WizardStep ID="CreateUserWizardStep2" runat="server" Title="Step 2"
                OnActivate="AssignUserToRoles_Activate" OnDeactivate="AssignUserToRoles_Deactivate">
                    
                    <table width="400">
                        <tr>
                            <td>
                                Select one or more roles for the user:</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="AvailableRoles" runat="server" SelectionMode="Multiple" Height="104px" Width="264px"></asp:ListBox>
                            </td>
                        </tr>
                    </table>

            </asp:WizardStep>

            <asp:WizardStep ID="CreateUserWizardStep3" runat="server" Title="Step 3" AllowReturn="true">
                    
                    <table width="400">
                        <tr>
                            <td>
                                You are welcome!
                            </td>
                        </tr>
                    </table>

            </asp:WizardStep>


            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" OnActivate="CompleteWizardStep1_Activate">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

