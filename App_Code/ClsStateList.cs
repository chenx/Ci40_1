using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClsUsaStateList
/// </summary>
public class ClsStateList
{
	public ClsStateList()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static string[] getStateList(string Country) {
        Country = Country.ToLower();
        string[] stateList = null;
        if (Country == "usa") stateList = ClsStateList.StateList_USA;
        else if (Country == "china") stateList = ClsStateList.StateList_China;

        return stateList;
    }


    public static string[] StateList_China {
        get { 
            return new string[] {
                "北京", "Beijing",
                "天津", "Tianjin",
                "河北", "Shijiazhuang",
                "山西", "Taiyuan",
                "內蒙", "Hohhot",
                "辽宁", "Shenyang",
                "吉林", "Changchun",
                "黑龙", "Harbin",
                "上海", "Shanghai",
                "江苏", "Nanjing",
                "浙江", "Hangzhou",
                "安徽", "Hefei",
                "福建", "Fuzhou",
                "江西", "Nanchang",
                "山东", "Jinan",
                "河南", "Zhengzhou",
                "湖北", "Wuhan",
                "湖南", "Changsha",
                "广东", "Guangzhou",
                "广西", "Nanning",
                "海南", "Haikou",
                "重庆", "Chongqing",
                "四川", "Chengdu",
                "贵州", "Guiyang",
                "云南", "Kunming",
                "西藏", "Lhasa",
                "陕西", "Xi'an",
                "甘肃", "Lanzhou",
                "青海", "Xining",
                "宁夏", "Yinchuan",
                "新疆", "Ürümqi",
                "香港", "Hong Kong",
                "澳门", "Macau",
                "台湾", "Taipei"
            };
        }
    }


    public static string[] StateList_USA {
        get
        {
            return new string[] {
                "Alabama", "AL",
                "Alaska", "AK",
                "Arizona", "AZ",
                "Arkansas", "AR",
                "California", "CA",
                "Colorado", "CO",
                "Connecticut", "CT",
                "Delaware", "DE",
                "District of Columbia", "DC",
                "Florida", "FL",
                "Georgia", "GA",
                "Hawaii", "HI",
                "Idaho", "ID",
                "Illinois", "IL",
                "Indiana", "IN",
                "Iowa", "IA",
                "Kansas", "KS",
                "Kentucky", "KY",
                "Louisiana", "LA",
                "Maine", "ME",
                "Maryland", "MD",
                "Massachusetts", "MA",
                "Michigan", "MI",
                "Minnesota", "MN",
                "Mississippi", "MS",
                "Missouri", "MO",
                "Montana", "MT",
                "Nebraska", "NE",
                "Nevada", "NV",
                "New Hampshire", "NH",
                "New Jersey", "NJ",
                "New Mexico", "NM",
                "New York", "NY",
                "North Carolina", "NC",
                "North Dakota", "ND",
                "Ohio", "OH",
                "Oklahoma", "OK",
                "Oregon", "OR",
                "Pennsylvania", "PA",
                "Rhode Island", "RI",
                "South Carolina", "SC",
                "South Dakota", "SD",
                "Tennessee", "TN",
                "Texas", "TX",
                "Utah", "UT",
                "Vermont", "VT",
                "Virginia", "VA",
                "Washington", "WA",
                "West Virginia", "WV",
                "Wisconsin", "WI",
                "Wyoming", "WY"
            };
        }
    }


    public static string[] CountryList {
        get {
            return new string[] {
                "Albania", "AL",
                "Algeria", "DZ",
                "Angola", "AO",
                "Argentina", "AR",
                "Armenia", "AM",
                "Australia", "AU",
                "Austria", "AT",
                "Azerbaijan", "AZ",
                "Bahrain", "BH",
                "Bangladesh", "BD",
                "Belarus", "BY",
                "Belgium", "BE",
                "Bolivia", "BO",
                "Bosnia And Herzegovina", "BA",
                "Brazil", "BR",
                "Brunei Darussalam", "BN",
                "Bulgaria", "BG",
                "Cameroon", "CM",
                "Canada", "CA",
                "Chile", "CL",
                "China", "CN",
                "Colombia", "CO",
                "Costa Rica", "CR",
                "Côd'Ivoire", "CI",
                "Croatia", "HR",
                "Cyprus", "CY",
                "Czech Republic", "CZ",
                "Denmark", "DK",
                "Dominican Republic", "DO",
                "Ecuador", "EC",
                "Egypt", "EG",
                "El Salvador", "SV",
                "Estonia", "EE",
                "Finland", "FI",
                "France", "FR",
                "Georgia", "GE",
                "Germany", "DE",
                "Greece", "GR",
                "Guatemala", "GT",
                "Honduras", "HN",
                "Hong Kong", "HK",
                "Hungary", "HU",
                "Iceland", "IS",
                "India", "IN",
                "Indonesia", "ID",
                "Ireland", "IE",
                "Israel", "IL",
                "Italy", "IT",
                "Jamaica", "JM",
                "Japan", "JP",
                "Jordan", "JO",
                "Kazakhstan", "KZ",
                "Kenya", "KE",
                "Korea, Republic Of", "KR",
                "Kuwait", "KW",
                "Lao People's Democratic Republic", "LA",
                "Latvia", "LV",
                "Lebanon", "LB",
                "Libya", "LY",
                "Lithuania", "LT",
                "Luxembourg", "LU",
                "Macao", "MO",
                "Macedonia, Republic Of", "MK",
                "Malaysia", "MY",
                "Malta", "MT",
                "Mauritius", "MU",
                "Mexico", "MX",
                "Mongolia", "MN",
                "Montenegro", "ME",
                "Morocco", "MA",
                "Namibia", "NA",
                "Netherlands", "NL",
                "New Zealand", "NZ",
                "Nigeria", "NG",
                "Norway", "NO",
                "Oman", "OM",
                "Pakistan", "PK",
                "Panama", "PA",
                "Paraguay", "PY",
                "Peru", "PE",
                "Philippines", "PH",
                "Poland", "PL",
                "Portugal", "PT",
                "Puerto Rico", "PR",
                "Qatar", "QA",
                "Réion", "RE",
                "Romania", "RO",
                "Russian Federation", "RU",
                "Saudi Arabia", "SA",
                "Senegal", "SN",
                "Serbia", "RS",
                "Singapore", "SG",
                "Slovak Republic", "SK",
                "Slovenia", "SI",
                "South Africa", "ZA",
                "Spain", "ES",
                "Sri Lanka", "LK",
                "Sweden", "SE",
                "Switzerland", "CH",
                "Taiwan", "TW",
                "Tajikistan", "TJ",
                "Thailand", "TH",
                "Trinidad And Tobago", "TT",
                "Tunisia", "TN",
                "Turkey", "TR",
                "Turkmenistan", "TM",
                "Ukraine", "UA",
                "United Arab Emirates", "AE",
                "United Kingdom", "GB",
                "United States", "US",
                "Uruguay", "UY",
                "Venezuela", "VE",
                "Vietnam", "VN"
            };
        }
    }


    public static string getStateListAsDropDownList(string[] StateList, string attr, string value, bool UseFullnameAsValue = false)
    {
        string s = "<option value=\"\">-- Select One--</option>";

        for (int i = 0; i < StateList.Length; i += 2) {
            if (UseFullnameAsValue)
            {
                string selected = (value == StateList[i]) ? " selected" : "";
                s += string.Format("<option value=\"{0}\"{2}>{1}</option>", StateList[i], StateList[i], selected);
            }
            else
            {
                string selected = (value == StateList[i + 1]) ? " selected" : "";
                s += string.Format("<option value=\"{0}\"{2}>{1}</option>", StateList[i + 1], StateList[i], selected);
            }
        }

        s = "<select" + attr  + ">" + s + "</select>";

        return s;
    }


    public static string getCountryListAsDropDownList(string attr, string value, bool UseFullnameAsValue = false)
    {
        string s = "<option value=\"\">-- Select One--</option>";

        for (int i = 0; i < CountryList.Length; i += 2)
        {
            if (UseFullnameAsValue)
            {
                string selected = (value == CountryList[i]) ? " selected" : "";
                s += string.Format("<option value=\"{0}\"{2}>{1}</option>", CountryList[i], CountryList[i], selected);
            }
            else
            {
                string selected = (value == CountryList[i + 1]) ? " selected" : "";
                s += string.Format("<option value=\"{0}\"{2}>{1}</option>", CountryList[i + 1], CountryList[i], selected);
            }
        }

        s = "<select" + attr + ">" + s + "</select>";

        return s;
    }


}