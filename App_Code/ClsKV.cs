using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsKV
/// </summary>
public class ClsKV
{
	public ClsKV(string key, string value)
	{
        this.Key = key;
        this.Value = value;
	}

    public string Key
    {
        get;
        set;
    }

    public string Value
    {
        get;
        set;
    }

    public string ToString() {
        return Key + ":" + Value;
    }

    public static bool ContainsKey(List<ClsKV> list, string key) {
        foreach (ClsKV o in list) 
        {
            if (o.Key == key) return true;
        }
        return false;
    }

    public static bool ContainsValue(List<ClsKV> list, string value)
    {
        foreach (ClsKV o in list)
        {
            if (o.Value == value) return true;
        }
        return false;
    }

    public static void RemoveKey(List<ClsKV> list, string key)
    {
        foreach (ClsKV o in list)
        {
            if (o.Key == key) {
                list.Remove(o);
                break;
            }
        }
    }
}