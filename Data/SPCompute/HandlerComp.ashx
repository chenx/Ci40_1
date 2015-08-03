<%@ WebHandler Language="C#" Class="HandlerComp" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class HandlerComp : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string cmd = context.Request["cmd"].ToString().ToLower();
        string cmdText = "";
        string output;

        try
        {
            if (cmd == "comp")
            {
                string itemName = context.Request["item"].ToString().ToLower();
                string itemCount = context.Request["count"].ToString().ToLower();
                
                cmdText = "SP_Compute";
                string connStr = ClsConfig.connStr(); 
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    using (SqlCommand com = new SqlCommand(cmdText, conn)) {
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.Add("@itemName", SqlDbType.VarChar).Value = itemName;
                        com.Parameters.Add("@itemCount", SqlDbType.Int).Value = itemCount;

                        com.CommandTimeout = 60 * 30; // 30 minutes.
                        conn.Open();
                        com.ExecuteNonQuery();
                    }
                }
                output = "ok";
            }
            else if (cmd == "progress") {
                string connStr = ClsConfig.connStr(); 
                string itemName = ClsUtil.ObjToStr(context.Request["item"]).ToString().ToLower();
                cmdText = "SELECT convert(varchar, CurrentCount) + '/' + convert(varchar, TotalCount) AS progress FROM T_Compute WHERE Name = " + ClsDB.sqlEncode(itemName);
                output = ClsDB.ExecuteScalar(connStr, cmdText);
            }
            else
            {
                output = "unknown command: " + cmd;
            }
        }
        catch (Exception ex) {
            output = "ProcessRequest Error: " + ex.Message;
            output += cmdText;
        }

        context.Response.ContentType = "text/plain";
        context.Response.Write(output);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}