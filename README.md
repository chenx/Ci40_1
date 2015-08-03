# Ci40_1
An ASP.NET 4.0 website framework that can be used for Rapid Application Development.



<h1>About</h1>

<p>
This is an ASP.NET 4.0 website framework that can be used for RAD (Rapid Application Development). 
</p>

<p>
This framework includes a functional Membership/Role/Profile management system, 
so you can start a website without re-creating the wheel. 
It also demonstrates various functions and capabilities of a typical web application.
</p>

<p>
Many of the functions here can be easily adapted for other platforms, e.g., LAMP and JavaEE.
Either The coding logic is the same, or the function is based on pure html/javascript/css.
</p>


<h1>License</h1>

<p>Apache/BSD/MIT/GPL v2.0</p>



<h1>System Requirement</h1>

<p>Minimum system requirement (tested):</p>

<ul>
<li>ASP.NET 4.0</li>
<li>Visual Studio.NET 2010</li>
<li>MSSQL 2008</li>
</ul>


<h1>Installation Guide</h1>

<h2>A. Database deployment</h2>

<ol>
<li>Create an empty database with the name "CI40" or another name you want.</li>
<li>Run ~/App_Data/CI40.sql to populate the database.</li>
<li>Use the aspnet_regsql.exe utility to create the ASP.NET membership/Role/Profile database.
<br />(Aspnet_regsql.exe is usually found in C:\Windows\Microsoft.NET\Framework\v***\.)
<br />Alternatively, You can run ~/App_Data/aspnetdb.sql on CI40 (or another separate database).
</li>
<li>In ~/web.config, change values of connection strings ApplicationServices and connCI40 accordingly.</li>
</ol>

<h2>B. File deployment</h2>

<ol>
<li>Copy this project folder to desired location on web server.</li>
<li>Open IIS Manager, convert this folder to an application with ASP.NET v4.0 application pool.</li>
</ol>




<h1>
    Functions demonstrated
</h1>

<ul>
    <li>Admin Functions (~/Admin)
        <ul>
        <li>Manage Roles (use asp.net Roles, ~/Admin/Roles.aspx)</li>
        <li>Manage Users (use asp.net Membership, ~/Admin/Users.aspx)</li>
        <li>Control access to ~/Admin using ~/Admin/web.config</li>
        <li>If non-admin user visits ~/Admin after signed in, redirect to ~/Account/Login.aspx, which in turn redirect to ~/. (see ~/Account/Login.aspx)</li>
        <li>Create New User using wizard (~/Admin/CreateNewUser.aspx)</li>
        <li>Manage Profile (use asp.net Profile)
            <ul>
            <li>Initialize setting is in web.config</li>
            <li>Use ClsProfile.cs to automate creation of view/edit pages.</li>
            <li>Also see ~/Account/Profile.aspx, ~/Account/ProfileEdit.aspx, ~/App_Code/ClsFormSetting.</li>
            <li>In database table T_FormSetting, field SeqNo determines the order of fields on UI display.</li>
            </ul>
        </li>
        <li>Change Email (~/Account/EmailEdit.aspx, ~/Admin/EmailEdit.aspx)</li>
        <li>See: 
        <br /><a href="http://www.shiningstar.net/ASPNet_Articles/SqlMembershipProvider.aspx">SQL Membership Provider and aspnet_regsql.exe Utility</a>
        <br /><a href="http://weblogs.asp.net/scottgu/427754">How to add a Login, Roles and Profile system to an ASP.NET 2.0 app in only 24 lines of code</a>        
        </li>
        </ul>
    </li>
    <li>AutoComplete Extender
        <ul>
        <li>~/CountryAutoComplete.aspx</li>
        <li>Pass additional parameter by SetContextKey</li>
        <li>A potential Chinese input utility (but so far only overwrite instead of append, unless you use a delimiter)</li>
        </ul>
    </li>
    <li>Chart: AjaxControlTookit chart 
        <ul>
        <li>~/AjaxChart.aspx</li>
        </ul>
    </li>
    <li>Chart: ASP:Chart 
        <ul>
        <li>~/AspChart.aspx</li>
        <li>~/AspChartDynamic.aspx, this demonstrates charts created programmingly.</li>
        </ul>
    </li>
    <li>Display data: List, Table and TreeView
        <ul>
        <li>UI - Country List/Table/TreeView</li>
        <li>as List: DropdownList, CheckboxList, Multiselection DropdownList</li>
        <li>as Table</li>
        <li>As TreeView</li>
        </ul>    
    </li>
    <li>IFrame
        <ul>
        <li>~/About/Default.aspx</li>
        <li>Full page, iframe height adjusted to content page height.</li>
        </ul>
    </li>
    <li>jQuery fall back when cdn not available
        <ul>
        <li>See example at ~/Data/SPCompute.aspx</li>
        <li>Basically use something like this: &lt;script&gt; window.jQuery || document.write('&lt;script src="../Scripts/jquery-1.10.2.js"&gt;&lt;\/script&gt;'); &lt;/script&gt; </li>
        </ul>
    </li>
    <li>Login using aspnet Membership
        <ul>
        <li>~/Account/Login.aspx</li>
        <li><a href="https://msdn.microsoft.com/en-us/library/x28wfk74%28v=vs.140%29.aspx">Instruction to setup the membership database</a></li>
        <li>Basically, run the command: C:\WINDOWS\Microsoft.NET\Framework\[versionNumber]\aspnet_regsql.exe</li>
        <li><a href="http://www.asp.net/web-forms/overview/older-versions-security/membership/creating-the-membership-schema-in-sql-server-vb">Another tutorial</a></li>
        </ul>
    </li>
    <li>Login using LDAP (as Domain User) 
        <ul>
        <li>~/Login.aspx</li>
        <li>To choose between aspnet Membership and LDAP login, change web.config "authentication" section loginUrl.
        <br />For now, both login links are shown in top right corner just for convenience.
        <br />Also for LDAP login, the "profile" page to change (local user) password should not be shown.
        </li>
        <li><a href="http://www.dotnetgallery.com/kb/resource6-Login-authentication-using-LDAP-Active-Directory-for-ASPNET-applications.aspx">Login authentication using LDAP (Active Directory) for ASP.NET applications</a></li>
        <li><a href="https://msdn.microsoft.com/en-us/library/ms180890%28v=vs.80%29.aspx">MSDN: Active Directory Authentication from ASP .NET</a></li>
        </ul>
    </li>
    <li>Map: Embed Map
        <ul>
        <li>~/Map.aspx</li>
        </ul>
    </li>
    <li>Master page 
        <ul>
        <li>~/Site.master</li>
        <li>Dynamically generated menu</li>
        <li>Solve issue on relative path in subfolder: ResolveUrl and ResolveClientUrl
        <br /><u>ResolveUrl</u> creates the URL relative to the root. <u>ResolveClientUrl</u> creates the URL relative to the current page.
        <br />See <a href="http://stackoverflow.com/questions/1874636/what-is-the-difference-between-resolveurl-and-resolveclienturl">http://stackoverflow.com/questions/1874636/what-is-the-difference-between-resolveurl-and-resolveclienturl</a>
        <br /><u>System.Web.VirtualPathUtility.ToAbsolute</u> is similar to ResolveUrl but is used in code under App_Code. 
        <br />See <a href="https://msdn.microsoft.com/en-us/library/system.web.virtualpathutility%28v=vs.110%29.aspx">https://msdn.microsoft.com/en-us/library/system.web.virtualpathutility%28v=vs.110%29.aspx</a>
        </li>
        </ul>
    </li>
    <li>Menu
        <ul>
        <li>Submenu (e.g., Chart)</li>
        <li>Menu style: change style in ~/Styles/Site.css, "TAB MENU" section</li>
        <li>Multiple levels (UI/SubMenu Test). Seems 4 levels are available</li>
        <li>Menu separator (UI/SubMenu Test)</li>
        </ul>
    </li>
    <li>Progress bar in jquery/css
        <ul>
        <li>Data/S.P. Computation</li>
        <li>~/SPCompute.aspx</li>
        <li>Modified from: <a href="https://css-tricks.com/css3-progress-bars/">https://css-tricks.com/css3-progress-bars/</a></li>
        </ul>
    </li>
</ul>


<h1>To-do list</h1>



<h1>Change Log</h1>



<h1>Author</h1>

X. Chen<br />
Copyright © 2011-2015 
