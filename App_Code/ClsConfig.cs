using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for ClsConfig
/// </summary>
public class ClsConfig
{
	public ClsConfig()
	{
	}

    public static string connStr() {
        return ConfigurationManager.ConnectionStrings["connCI40"].ConnectionString;
    }

    public static string connStr2() {
        return ConfigurationManager.ConnectionStrings["connFarm"].ConnectionString;
    }

    public static bool allowRegister()
    {
        return Convert.ToBoolean(ConfigurationManager.AppSettings["AllowRegister"]);
    }

    public static bool requireLogin()
    {
        return Convert.ToBoolean(ConfigurationManager.AppSettings["RequireLogin"]);
    }

    public static bool Debug()
    {
        return Convert.ToBoolean(ConfigurationManager.AppSettings["Debug"]);
    }

}