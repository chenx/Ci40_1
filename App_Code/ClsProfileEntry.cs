using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsProfileEntry
/// </summary>
public class ClsProfileEntry
{
	public ClsProfileEntry()
	{
	}

    public ClsProfileEntry(string Name, string Label, bool ShowInUI = true, bool IsRequired = true, bool IsDisabled = false, string value = "")
    {
        this.Name = Name;
        this.Label = Label;
        this.ShowInUI = ShowInUI;
        this.IsRequired = IsRequired;
        this.IsDisabled = IsDisabled;
        this.Value = value;
    }

    public string Name
    {
        get;
        set;
    }

    public string Label
    {
        get;
        set;
    }

    public string Value
    {
        get;
        set;
    }

    public bool ShowInUI
    {
        get;
        set;
    }

    /// <summary>
    /// Whether this field is required when save.
    /// </summary>
    public bool IsRequired
    {
        get;
        set;
    }

    public bool IsDisabled
    {
        get;
        set;
    }
}