using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for ClsFormSetting
/// </summary>
public class ClsFormSetting
{
	public ClsFormSetting()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Return form fields in order of SeqNo.
    /// </summary>
    /// <param name="FormName"></param>
    /// <returns></returns>
    public ClsProfileEntry[] getFormSetting(string FormName) {
        string cmdText = "SELECT * FROM T_FormSetting WHERE FormName = " + ClsDB.sqlEncode(FormName) + " ORDER BY SeqNo ASC";
        DataTable dt = new ClsDBUtil().getQueryAsDataTable(cmdText);

        List<ClsProfileEntry> setting = new List<ClsProfileEntry>();
        for (int i = 0; i < dt.Rows.Count; ++i) {
            DataRow dr = dt.Rows[i];
            setting.Add(
                new ClsProfileEntry(
                    ClsUtil.ObjToStr(dr["FieldName"]), 
                    ClsUtil.ObjToStr(dr["FieldLabel"]), 
                    ClsUtil.ObjToBool(dr["ShowInUI"]), 
                    ClsUtil.ObjToBool(dr["IsRequired"]), 
                    ClsUtil.ObjToBool(dr["IsDisabled"]), 
                    ClsUtil.ObjToStr(dr["FieldValue"]))
                );
        }

        return setting.ToArray();
    }
}