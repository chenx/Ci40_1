using System;
using System.Web.UI.WebControls;
using System.Drawing;

/// <summary>
/// Summary description for ClsUtil
/// </summary>
public class ClsUtil
{
	public ClsUtil()
	{        
	}

    public static string ObjToStr(object o) {
        return o == null ? "" : o.ToString();
    }
    
    public static int ObjToInt(object o) {
        string v = ObjToStr(o).ToString().Trim();
        int val = 0;

        try
        {
            val = (v == "" ? 0 : Convert.ToInt32(v));
        }
        catch {
            val = -1;
        }

        return val;
    }
    
    public static bool ObjToBool(object o) {
        bool val;
        try
        {
            val = Convert.ToBoolean(o);
        }
        catch {
            val = false;
        }

        return val;
    }

    public static double ObjToDouble(object o) {
        string s = ObjToStr(o);
        double val;
        try
        {
            val = s == "" ? 0 : Convert.ToDouble(s);
        }
        catch
        {
            val = 0;
        }
        return val;
    }

    public static string UCaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        s = s.ToLower();
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }


    /// <summary>
    /// From: http://stackoverflow.com/questions/9809340/how-to-check-if-isnumeric
    /// </summary>
    /// <param name="Expression"></param>
    /// <returns></returns>
    public static Boolean IsNumeric (object Expression)
    {
        if(Expression == null || Expression is DateTime)
            return false;

        if(Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal 
            || Expression is Single || Expression is Double || Expression is Boolean)
            return true;

        try 
        {
            if(Expression is string) Double.Parse(Expression as string);
            else Double.Parse(Expression.ToString());

            return true;
        } catch {
            // just dismiss errors but return false
            return false;
        }
    }

    
    public static void UIShowMsg(string msg, Label lbl, Color color)
    {
        lbl.ForeColor = color;
        lbl.Text = msg;
    }


    public static string getPageName(System.Web.HttpRequest Request)
    {
        return System.IO.Path.GetFileName(Request.PhysicalPath);
    }


    public static bool IsAlphanumeric(char c) { 
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
    }


    /// <summary>
    /// Return the number of alphanumeric characters in a given string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int CountAlphanumericCharacters(string s) {
        int count = 0;
        for (int i = 0, n = s.Length; i < n; ++i) {
            count += IsAlphanumeric(s[i]) ? 1 : 0;
        }
        return count;
    }


    /// <summary>
    /// Return the number of non-alphanumeric characters in a given string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int CountNonAlphanumericCharacters(string s)
    {
        return s.Length - CountAlphanumericCharacters(s);
    }
}