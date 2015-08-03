using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Format collection for output.
/// </summary>
public class ClsConvert
{
	public ClsConvert()
	{
	}

    public static string ArrayToHTML<T>(T[] arr) {
        string s = "";
        s += "length = " + arr.Length + "<br/>";
        for (int i = 0; i < arr.Length; ++i) {
            s += (i + 1) + ". " + ClsUtil.ObjToStr(arr[i]) +"<br/>";
        }
        return s;
    }

    public static string ArrayToStringList<T>(T[] arr, string delimiter) {
        string s = "";
        int n = arr.Length;
        if (n > 0)
        {
            s = ClsUtil.ObjToStr(arr[0]);
            for (int i = 1; i < n; ++i)
            {
                s += delimiter + ClsUtil.ObjToStr(arr[i]);
            }
        }
        return s;    
    }

    // Output Links.

    public static string writeLinksAsTable(List<ClsLinkItem> links, int cols, string url, string tbl_class = "")
    {
        string s = "";
        string row = "";
        int i = 0;

        for (; i < links.Count; ++i)
        {
            ClsLinkItem link = links[i];
            string toolTip = link.ToolTip == "" ? "" : " Title=\"" + link.ToolTip + "\"";
            row += "<td><a href=\"" + url + link.ID + "\"" + toolTip + ">" + link.Name + "</a></td>";
            if (i % cols == cols - 1)
            {
                s += "<tr>" + row + "</tr>";
                row = "";
            }
        }

        if (row != "")
        {            
            for (i %= cols; i < cols; ++i)
            {
                row += "<td><br/></td>";
            }
            s += "<tr>" + row + "</tr>";
        }

        if (s != "")
        {
            if (tbl_class != "") tbl_class = " class=\"" + tbl_class + "\"";
            s = "<table" + tbl_class + ">" + s + "</table>";
            s += "<br/>";
        }

        return s;
    }

    public static string writeLinksAsList(List<ClsLinkItem> links, string url)
    {
        string s = "";
        for (int j = 0; j < links.Count; ++j)
        {
            ClsLinkItem link = links[j];
            if (s != "") s += "<br/>";
            s += "<a href=\"" + url + link.ID + "\">" + link.Name + "</a>";
        }
        return s;
    }

    
    // To Html.

    public static string DataTableToHTML(DataTable dt, string tblClass = "")
    {
        string s = "";
        if (dt.Rows.Count == 0) return s;

        for (int j = 0; j < dt.Columns.Count; ++j)
        {
            s += "<td>" + dt.Columns[j].ColumnName + "</td>";
        }
        s = "<tr>" + s + "</tr>";
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            string row = "";
            for (int j = 0; j < dt.Columns.Count; ++j)
            {
                row += "<td>" + dt.Rows[i][j] + "</td>";
            }
            s += "<tr>" + row + "</tr>";
        }

        if (tblClass != "") {
            tblClass = " class=\"" + tblClass + "\"";
        }
        s = "<table" + tblClass + ">" + s + "</table>";

        return "<p><h2>" + dt.TableName + "</h2></p>" + s;
    }

    public static string DataSetToHTML(DataSet ds, string tblClass = "")
    {
        string s = "";
        for (int i = 0; i < ds.Tables.Count; ++i)
        {
            s += DataTableToHTML(ds.Tables[i], tblClass);
        }
        return s;
    }


    // To CSV.
    
    public static string DataSetToCSV(DataSet ds, string tblClass = "")
    {
        string s = "";
        for (int i = 0; i < ds.Tables.Count; ++i)
        {
            if (s != "") s += "\n\n";
            s += DataTableToCSV(ds.Tables[i], tblClass);
        }
        return s;
    }
    
    public static string DataTableToCSV(DataTable dt, string tblClass = "")
    {
        string s = "";
        string header = "";
        string tbl_name = "TableName: " + dt.TableName;

        // Get header.
        for (int j = 0; j < dt.Columns.Count; ++j)
        {
            if (header != "")
            {
                header += ",";
                tbl_name += ",";
            }
            header += escapeCsvField(dt.Columns[j].ColumnName);
        }
        s = tbl_name + "\n" + header;

        // Get body.
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            string row = "";
            for (int j = 0; j < dt.Columns.Count; ++j)
            {
                if (row != "") row += ",";
                row += escapeCsvField(dt.Rows[i][j].ToString());
            }
            s += "\n" + row;
        }

        //return "<p><h2>" + dt.TableName + "</h2></p>" + s;
        return s;
    }

    /// <summary>
    /// The CSV format uses commas to separate values, values which contain carriage returns, linefeeds, commas, 
    /// or double quotes are surrounded by double-quotes. Values that contain double quotes are quoted and each 
    /// literal quote is escaped by an immediately preceding quote: For example, the 3 values:
    /// 
    /// test
    /// list, of, items
    /// "go" he said
    /// 
    /// would be encoded as:
    /// 
    /// test
    /// "list, of, items"
    /// """go"" he said"
    /// 
    /// See: http://stackoverflow.com/questions/769621/dealing-with-commas-in-a-csv-file
    /// </summary>
    /// <param name="s">input string</param>
    /// <returns>escaped string</returns>
    private static string escapeCsvField(string s) {
        if (s.Contains('\"')) {
            s = s.Replace("\"", "\"\"");
        }
        if (s.Contains(',') || s.Contains('\n') || s.Contains('\r')) { 
            s = "\"" + s + "\"";
        }
        return s;
    }
    
}