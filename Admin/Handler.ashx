<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Web.Security;

/// <summary>
/// Handle administration stuff.
/// Created on: 7/29/2015
/// Last modified: 7/29/2015
/// </summary>
public class Handler : IHttpHandler {
    private bool DEBUG = true;
    
    public void ProcessRequest (HttpContext context) {
        DEBUG = ClsConfig.Debug();
        
        string status = "ok";

        try
        {
            string cmd = context.Request["cmd"].ToString().ToLower();

            if (cmd == "lockout")
            {
                string user = ClsUtil.ObjToStr(context.Request["user"]);
                string val = ClsUtil.ObjToStr(context.Request["val"]);
                HandleLockout(user, val);
            }
            else if (cmd == "approve")
            {
                string user = ClsUtil.ObjToStr(context.Request["user"]);
                string val = ClsUtil.ObjToStr(context.Request["val"]);
                HandleApproval(user, val);
            }
            else if (cmd == "role") {
                string[] user_role = ClsUtil.ObjToStr(context.Request["user"]).Split(new char[]{'_'});
                if (user_role.Length != 2) {
                    throw new Exception("Invalid input");
                }
                string user = user_role[0];
                string role = user_role[1];
                string val = ClsUtil.ObjToStr(context.Request["val"]);
                HandleRole(user, role, val);
            }
        }
        catch (Exception ex) {
            status = "Handler exception";
            if (DEBUG) status += ": " + ex.Message;
        }

        context.Response.ContentType = "text/plain";
        context.Response.Write(status);       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    
    
    private void HandleLockout (string user, string val) {
        //throw new Exception("testing HandleLockout");
        
        if (val == "0")
        {
            MembershipUser u = Membership.GetUser(user);
            u.UnlockUser();
            Membership.UpdateUser(u);
        }
        else if (val == "1")
        {
            // There is no "lock" functions. Can use approve/dis-approve for lockout purpose.
            // Although it is possible to update table aspnet_Membership.
        }
        else
        {
            // do nothing
        }
    }


    private void HandleApproval(string user, string val)
    {
        if (val == "0")
        {
            MembershipUser u = Membership.GetUser(user);
            u.IsApproved = false;
            Membership.UpdateUser(u);
        }
        else if (val == "1")
        {
            MembershipUser u = Membership.GetUser(user);
            u.IsApproved = true;
            Membership.UpdateUser(u);
        }
        else
        {
            // do nothing
        }
    }
    

    private void HandleRole(string user, string role, string val) {
        //throw new Exception("testing HandleRole");
        
        if (val == "0")
        {
            Roles.RemoveUserFromRole(user, role);
        }
        else if (val == "1")
        {
            Roles.AddUserToRole(user, role);
        }
        else
        {
            // do nothing
        }
    }
}