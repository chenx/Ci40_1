using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ClsDB
/// </summary>
public class ClsDB
{
	public ClsDB()
	{
	}

    public static void ExecuteNonQuery(string connStr, string cmdText, int timeout = 30)
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = connStr;

            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = cmdText;
                com.Connection = con;
                com.CommandTimeout = timeout;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
        }
    }

    public static string ExecuteScalar(string connStr, string cmdText, int timeout = 30)
    {
        string result = "";
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = connStr;

            using (SqlCommand com = new SqlCommand())
            {
                com.CommandText = cmdText;
                com.Connection = con;
                com.CommandTimeout = timeout;
                con.Open();
                result = ClsUtil.ObjToStr(com.ExecuteScalar());
                con.Close();
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="conn">An open connection.</param>
    /// <param name="cmdText"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static string ExecuteScalar2(SqlConnection conn, string cmdText, int timeout = 30)
    {
        string result = "";
        using (SqlCommand com = new SqlCommand())
        {
            com.CommandText = cmdText;
            com.Connection = conn;
            com.CommandTimeout = timeout;
            result = ClsUtil.ObjToStr(com.ExecuteScalar());
        }

        return result;
    }
    

    /// <summary>
    /// Encode a variable string to be used in a query.
    /// </summary>
    /// <param name="s">A parameter string.</param>
    /// <returns>Encoded parameter string, which is safe to be used in a database query.</returns>
    public static string sqlEncode(string s)
    {
        if (s == null || s == "") return "''";

        s = s.Replace("'", "''");
        s = "'" + s + "'";
        return s;
    }

    /// <summary>
    /// In sql search: LIKE '%' + s + '%'
    /// If s contains special wildcard characters %, _ or [, they can be escaped by quoted in "[]".
    /// See: https://msdn.microsoft.com/en-us/library/ms179859.aspx
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string sqlSearchEncode(string s)
    {
        return s.Replace("[", "[[]");
    }

}