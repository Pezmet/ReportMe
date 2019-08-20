using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ReportMe.Backend
{
    class FormattingActions
    {
        public static string FormatUp(string _justUp)
        {
            //setting the background color and the font color specific for UbiPriority field in the report
            switch (_justUp)
            {
                case "01":
                    _justUp = "<td bgcolor =#C11111><font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "02":
                    _justUp = "<td bgcolor =#EEA115><font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "03":
                    _justUp = "<td bgcolor =#EEA115><font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "04":
                    _justUp = "<td bgcolor =#EEA115><font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "05":
                    _justUp = "<td bgcolor =#E9E608><font color=#000000>" + _justUp + "</font>";
                    break;
                case "06":
                    _justUp = "<td bgcolor =#E9E608><font color=#000000>" + _justUp + "</font>";
                    break;
                case "07":
                    _justUp = "<td bgcolor =#E9E608><font color=#000000>" + _justUp + "</font>";
                    break;
                case "08":
                    _justUp = "<td bgcolor =#539E48><font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "09":
                    _justUp = "<td bgcolor =#539E48><font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "10":
                    _justUp = "<td bgcolor =#539E48<font color=#FFFFFF>" + _justUp + "</font>";
                    break;
                case "11":
                    _justUp = "<td bgcolor =#794489><font color=#FFFFFF>" + _justUp + "</font>";
                    break;

            }
            return _justUp;
        }
        public static string UbiPrioP(string input, string id)
        {
            string response = null;
            //parsing the web request response into Jobject - this allows us to get values from this type of field
            JObject help = JObject.Parse(input);
            //getting the values for the field
            string s = help["fields"].ToString();
            //getting the priority depending on the bellow conditions
            if (s.Contains(id))
            {
                if (id != "")
                    s = help["fields"][id].ToString();
                if (s.Contains("1") || s.Contains("0"))
                {
                    string[] d = s.Split(':', ',');
                    string t = d[4].Substring(8, 2);
                    response = response + t;

                }
                else response = "<td>Unset</td>";
                //return the report
            }
            else response = "<td>None</td>";
            return response;
        }
        public static string Prio(string t)
        {
            //formats the field based on its cases
            var response = "";
            if ((t != null) && (t != ""))
            {
                switch (t)
                {
                    case "P0":
                        response = "<font color=#c60115>" + t + "</font>";
                        break;
                    case "P1":
                        response = "<font color=#d17b0c>" + t + "</font>";
                        break;
                    case "P2":
                        response = "<font color=#BF9F17>" + t + "</font>";
                        break;
                    case "P3":
                        response = "<font color=#539E48>" + t + "</font>";
                        break;
                    case "Unset":
                        response = t;
                        break;
                    case "Major":
                        response = t;
                        break;
                    case "Minor":
                        response = t;
                        break;
                    case "Blocker":
                        response = t;
                        break;

                }
            }
            else response = "N/A";
            return response;
        }
        public static string RegressionP(string input)
        {
            //initiate the string
            string response = null;
            //parsing the web request response into Jobject - this allows us to get values from this type of field
            JToken help = JToken.Parse(input);
            //verify existance of value for regression field
            if (help["fields"]["customfield_10111"].HasValues == true)
                response = help["fields"]["customfield_10111"]["value"].ToString();
            else response = " ";
            return response;
        }
    }
}
