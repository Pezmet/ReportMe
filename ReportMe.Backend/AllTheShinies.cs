using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Gurock.TestRail;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Principal;
using System.DirectoryServices;
using Gurock.TestRail;

namespace ReportMe.Backend
{
    public class AllTheShinies
    {
        public string pass { get; set; }
        List<Jiras> jirainfo = new List<Jiras>();
        //saves the link so it that issues can be queried from favourite filters
        public List<string> links = new List<string>();
        //saves the testplans id so we can query them
        public List<string> _testrailId = new List<string>();
        //saves the jira values so the report is sorted
        static List<string> _runsId = new List<string>();

        static List<string> _tests = new List<string>();

        Dictionary<string, string> issues = new Dictionary<string, string>();

        public string jiraLogin, testrailLogin, givenName;
        public bool issueType, ubiPriority, priority, status;

        public void LoginPreparations()
        {
            string account;
            //retrieving the windows user
            string identity = WindowsIdentity.GetCurrent().Name;
            //remove the Ubisoft-org\\ domain
            account = testrailLogin = identity.Substring(12);
            //pass the value to a diferent global variable
            //create AD session and query to retieve user information
            DirectoryEntry entry = new DirectoryEntry("LDAP://UBISOFT.ORG");
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(&(objectClass=user)(anr=" + account + "))";

            // specify which property values to return in the search
            search.PropertiesToLoad.Add("givenName");   // first name
            search.PropertiesToLoad.Add("sn");          // last name
            search.PropertiesToLoad.Add("mail");        // smtp mail address

            // perform the search
            SearchResult result = search.FindOne();
            jiraLogin = result.Properties["mail"][0].ToString();
            givenName = result.Properties["givenName"][0].ToString();

        }
        public string Gen_Authen(string u, string p)
        {
            //Generate the authentication hash so it is not dependant on one user
            string auth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(u + ":" + p));
            return auth;

        }
        public HttpResponseMessage JRvalid(string jiraLogin)
        {
            //creating a new handler
            HttpClientHandler handler = new HttpClientHandler();
            //creating a new client 
            var client = new HttpClient(handler);
            //creating the authentication string
            string auth = Gen_Authen(jiraLogin, pass);
            //
            var byteArray = Encoding.ASCII.GetBytes(auth);
            //passing the Basic authentication to the request header
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", auth);
            //passing the API to the client's address
            client.BaseAddress = new Uri("https://mdc-tomcat-jira19.ubisoft.org/jira/rest/api/2/");
            //adding accepted content type to request header
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            //retrieving the result from a Get                                                                                                                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "filter/favourite");
            var result = client.GetAsync("filter/favourite").Result;
            //returning the result for comparisson
            return result;
        }
        public object TRvalid(string testrailLogin)
        {
            //initializing a new Get object
            var t = new Get();
            //pasing the response data from the testrail api get request to res
            JToken res = t.Trequest("get_project/", "44", testrailLogin, pass);
            //returning the response data
            return res;
        }
        public string GetResults(string IDS, string user, string pass)
        {
            //need to work the variable
            string solution = "";
            var t = new Get();
            var help = t.Trequest("get_results/", IDS, user, pass);

            //parsing the answer
            //var help = JToken.Parse(jsResponse);
            for (int i = 0; i < help.Count(); i++)
            {
                if (help[0]["defects"].ToString() != "")
                {
                    solution += help[0]["defects"].ToString() + ",";
                    //jirainfo.Add(new Jiras.jirainfo)
                }
            }

            //}
            return solution;
        }
        public string GetUbiPrioId(string jira, string auth)
        {
            string rezult = "";
            //initialize a Get object
            var j = new Get();
            //passing the response data 
            string jsonResponse = j.Jrequest(jira, "", "field", auth);
            if (jsonResponse != "")
            {
                //creating a JToken from the response for better nodes access
                var help = JToken.Parse(jsonResponse);
                //adding the id of the field to rezult
                for (int i = 1; i < help.Count(); i++)
                {
                    if (help[i]["name"].ToString() == "Ubi Priority")
                        rezult = help[i]["id"].ToString();
                }
                if (rezult == "")
                    rezult = "N/A";
            }
            //return the id
            return rezult;
        }

        public async Task JiraReport(string name, int a, string j, int sort_index)
        {
            //the object list is cleared
            jirainfo.Clear();
            //generate the authentication string
            string auth = Gen_Authen(jiraLogin, pass);

            //Building the email report header
            string resort = "Your Text Goes Here\n<table border=1><tr><th bgcolor=#3A5DAD><font color=#FFFFFF>Jira Id</font></th><th width=\"250\" bgcolor=#3A5DAD><font color=#FFFFFF>Summary</font></th>";
            //checked fields are added to the header
            if (issueType)
                resort += "<th width =\"70\" bgcolor=#3A5DAD><font color=#FFFFFF>Issue Type</font></th>";
            if (ubiPriority)
                resort += "<th bgcolor =#3A5DAD><font color=#FFFFFF>UbiPrio</font></th>";
            if (priority)
                resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Priority</font></th>";
            if (status)
                resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Status</font></th>";

            resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Regression</font></th><th bgcolor=#3A5DAD><font color=#FFFFFF>Comments</font></th></tr>";

            //jiras except 19have a different field id
            string UField = GetUbiPrioId(j, auth);

            //a jira filter will only show the first 50 issues so a bypass using MaxRes argument
            // verification for total number of issues in filter to know if MaxRes bypass is needed
            var help = JToken.Parse(MaxRes(links[a], auth));

            int total = Int32.Parse(help["total"].ToString());
            int max = Int32.Parse(help["maxResults"].ToString());

            var call = new Get();

            //if nr of issues in filter >50, we need to have a modified get
            if (total > max)
            {
                var helps = JToken.Parse(call.Jrequest(j, links[a], "&maxResults=" + total.ToString(), auth));

                //get Jira information for each of the defects
                for (int i = 0; i < total; i++)

                    JiraInfo(j, helps["issues"][i]["key"].ToString(), auth, UField);


            }
            else
            {
                //get jira information for each of the defects
                for (int i = 0; i < total; i++)
                    JiraInfo(j, help["issues"][i]["key"].ToString(), auth, UField);

            }


            //jira issues loaded in jirainfo are sorted based on the index of the users list selection
            switch (sort_index)
            {
                case 0:
                    jirainfo.Sort((x, y) => x.UbiPrio.CompareTo(y.UbiPrio));
                    break;
                //to enable the scenario uncomment
                //case 1:
                //    jirainfo.Sort((x, y) => y.UbiPrio.CompareTo(x.UbiPrio));
                //    break;
                case 2:
                    jirainfo.Sort((x, y) => y.Jiraid.CompareTo(x.Jiraid));
                    break;
                case 3:
                    jirainfo.Sort((x, y) => x.Jiraid.CompareTo(y.Jiraid));
                    break;
                default:
                    break;
            }
            //adding the defects to the report in html format
            foreach (Jiras jira_variab in jirainfo)
            {
                resort += "<tr><td>" + jira_variab.id_link + "</td><td>" + jira_variab.Jirasummary + "</td>";

                if (issueType)
                    resort += "<td>" + jira_variab.IssueType + "</td>";
                if (ubiPriority)
                    resort += FormattingActions.FormatUp(jira_variab.UbiPrio) + "</td>";
                if (priority)
                    resort += "<td>" + FormattingActions.Prio(jira_variab.Priority) + " </td>";
                if (status)
                    resort += "<td>" + jira_variab.Status + "</td>";

                resort += "<td>" + jira_variab.Regression + "</td><td>" + jira_variab.Comment + "</td></tr>";
            }



            resort = resort + "</table>";
            //starting the mail thread
            Thread mth = new Thread(() => JiraFilterThread(name, j, resort));
            mth.Start();
        }
        public /*string*/ void JiraInfo(string jira, string va, string auth, string UField)
        {

            var j = new Get();
            //parse response to JTOKEN which allows to extract ids until a certain level
            var jsonResponse = j.Jrequest(jira, "issue/", va, auth);
            if (jsonResponse.Contains("errorMessages") == false)
            {
                //var help = JToken.Parse(jsonResponse);
                var objectparsejson = JObject.Parse(jsonResponse);


                if ((jirainfo.Exists(x => x.Jiraid == va) == false))
                {//adding defect information to jirainfo object list
                    jirainfo.Add(new Jiras()
                    {
                        Jiraid = va,
                        Jirasummary = objectparsejson["fields"]["summary"].ToString(),
                        UbiPrio = FormattingActions.UbiPrioP(jsonResponse, UField),
                        //Priority = Prio(jsonResponse),
                        Priority = objectparsejson["fields"]["priority"]["name"].ToString(),
                        IssueType = objectparsejson["fields"]["issuetype"]["name"].ToString(),
                        Status = objectparsejson["fields"]["status"]["name"].ToString(),
                        id_link = "<a href=\"https://mdc-tomcat-jira" + jira + ".ubisoft.org/jira/browse/" + objectparsejson["key"] + "\">" + objectparsejson["key"] + "</a>",
                        Regression = FormattingActions.RegressionP(jsonResponse)
                    });
                }

            }
        }
        public string MaxRes(string link, string auth)
        {
            //define the URL
            string WEBSERVICE_URL = (link);
            //define the jsonResponse
            string jsonResponse = "Bad request";
            //create the request
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            //define method, content type and headers
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.Timeout = 12000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", "Basic " + auth);
                //reading the response
                using (Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        //passing the information to jsonResponse
                        jsonResponse = sr.ReadToEnd();
                    }
                }
            }

            return jsonResponse;
        }
        public void JiraFilterThread(string name, string j, string resort)
        {

            //Use Office Interop to create email and pass the information into it
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            oMailItem.HTMLBody = resort;
            DateTime dt = DateTime.Now;

            oMailItem.Subject = name + " " + String.Format("{0:d-MM-yyy}", dt);
            oMailItem.Display(false);

        }
        public void RunReport(string name, int runs_index, int sort_index,string jiravalue)
        {
            //initialization
            string defects = ""; string[] defect_id;
            // pass the jira instance

            //Building the email report header
            string resort = "Your Text Goes Here\n<table border=1><tr><th bgcolor=#3A5DAD><font color=#FFFFFF>Jira Id</font></th><th width=\"250\" bgcolor=#3A5DAD><font color=#FFFFFF>Summary</font></th>";
            //based on the which field is checked, info is added to the header
            if (issueType)
                resort += "<th width =\"70\" bgcolor=#3A5DAD><font color=#FFFFFF>Issue Type</font></th>";
            if (ubiPriority)
                resort += "<th bgcolor =#3A5DAD><font color=#FFFFFF>UbiPrio</font></th>";
            if (priority)
                resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Priority</font></th>";
            if (status)
                resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Status</font></th>";

            resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Regression</font></th><th bgcolor=#3A5DAD><font color=#FFFFFF>Comments</font></th></tr>";

            //generate the authentication string
            string Jauth = Gen_Authen(jiraLogin, pass);

            // Test id's for said run
            string ds = GetTestId(_runsId[runs_index], testrailLogin, pass);

            //splitting the test id's
            string[] tr = ds.Split(',');
            string UField = GetUbiPrioId(jiravalue, Jauth);
            //Getting the defects from test ids
            for (int i = 0; i < tr.Length - 1; i++)
            {
                if (tr[i] != null)
                    defects = GetResults(tr[i], testrailLogin, pass) + defects + ",";
                //jirainfo.Add(jirainfo)
            }
            //distinct defects moved to string array

            defect_id = defects.Split(',').Distinct().ToArray();
            //parsing the defects, triming if necessary, adding them to JiraInfo list
            for (int i = 0; i < defect_id.Length; i++)
                if (defect_id[i] != null && defect_id[i] != "")
                {
                    var parsedissue = defect_id[i].TrimStart(' ');
                    JiraInfo(jiravalue, parsedissue, Jauth, UField);
                }

            //creating the sorting
            switch (sort_index)
            {
                case 0:
                    jirainfo.Sort((x, y) => x.UbiPrio.CompareTo(y.UbiPrio));
                    break;
                //to enable uncomment
                //case 1:
                //    jirainfo.Sort((x, y) => y.UbiPrio.CompareTo(x.UbiPrio));
                //    break;
                case 2:
                    jirainfo.Sort((x, y) => y.Jiraid.CompareTo(x.Jiraid));
                    break;
                case 3:
                    jirainfo.Sort((x, y) => x.Jiraid.CompareTo(y.Jiraid));
                    break;
                default:
                    break;
            }

            //adding the information to the resort string
            foreach (Jiras jira_variab in jirainfo)
            {
                resort += "<tr><td>" + jira_variab.id_link + "</td><td>" + jira_variab.Jirasummary + "</td>";

                if (issueType)
                    resort += "<td>" + jira_variab.IssueType + "</td>";
                if (ubiPriority)
                    resort += FormattingActions.FormatUp(jira_variab.UbiPrio) + "</td>";
                if (priority)
                    resort += "<td>" + FormattingActions.Prio(jira_variab.Priority) + "</td>";
                if (status)
                    resort += "<td>" + jira_variab.Status + "</td>";

                resort += "<td>" + jira_variab.Regression + "</td><td>" + jira_variab.Comment + "</td></tr>";
            }


            //complete the string to define table
            resort = resort + "</table>";

            //Thread mth = new Thread(() => RunsThread(uj, ut, Password.Text, _runsId[b], j, name));
            //mth.Start();
            Thread mth = new Thread(() => RunsThread(resort, name));
            mth.Start();
        }



        //public void RunsThread(string User, string us, string pass, string Tids, string j, string name)
        public void RunsThread(string resort, string name)
        {

            //Use Office Interop to create email and pass the information into it
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            oMailItem.HTMLBody = resort;
            DateTime dt = DateTime.Now;

            oMailItem.Subject = name + " " + String.Format("{0:d-MM-yyy}", dt);
            oMailItem.Display(false);

        }
        public void PlanReport(string name, int index, int sort_index, string jiraValue)
        {

            //button for plan generations
            string Jauth; string[] runs_id, defect_id; int a;
            //gets the selected testplan

            //calculate key for jira authentication
            Jauth = Gen_Authen(jiraLogin, pass);
            //get the jira entered by the user

            //gets the runs for the selected test plan
            string runId = GetPlan(_testrailId[index], testrailLogin,pass);

            //ze runs are split 
            runs_id = runId.Split('\n').ToArray();

            //var myList = new List<string>();
            //for (int i = 0; i < d.Length - 1; i++)
            //    myList.Add(d[i]);
            ////this contains all the runs extracted from testplan
            //df = myList.ToArray();


            //retrieve the id for Ubi Priority fiels. differs between jira instances
            string UField = GetUbiPrioId(jiraValue, Jauth);

            //        getting runs from each plan
            //List<string> items = new List<string>();
            //Thread mth = new Thread(() => PlanThreads(uj, ut, Password.Text, j, name, df));
            //mth.Start();

            string defects = "";

            //Building the email report header
            string resort = "Your Text Goes Here\n<table border=1><tr><th bgcolor=#3A5DAD><font color=#FFFFFF>Jira Id</font></th><th width=\"250\" bgcolor=#3A5DAD><font color=#FFFFFF>Summary</font></th>";
            //if fields are checked they are added
            if (issueType)
                resort += "<th width =\"50\" bgcolor=#3A5DAD><font color=#FFFFFF>Issue Type</font></th>";
            if (ubiPriority)
                resort += "<th bgcolor =#3A5DAD><font color=#FFFFFF>UbiPrio</font></th>";
            if (priority)
                resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Priority</font></th>";
            if (status)
                resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Status</font></th>";

            resort += "<th bgcolor=#3A5DAD><font color=#FFFFFF>Regression</font></th><th bgcolor=#3A5DAD><font color=#FFFFFF>Comments</font></th></tr>";

            for (int o = 0; o < runs_id.Length; o++)
            {

                // get testid for each of the runs in plan
                if (runs_id[o] != "")
                {
                    string testId = GetTestId(runs_id[o], testrailLogin, pass);
                    string[] tr = testId.Split(',');
                    //int n = tr.Length;

                    //Getting the defects from test ids
                    for (int i = 0; i < tr.Length - 1; i++)
                    {
                        if (tr[i] != null)
                            defects = GetResults(tr[i], testrailLogin, pass) + defects + ",";
                    }
                    //distinct defects moved to string array
                    defect_id = defects.Split(',').Distinct().ToArray();

                    //get Jira information for each of the defects
                    for (int i = 0; i < defect_id.Length; i++)
                        if (defect_id[i] != null && defect_id[i] != "")
                        {
                            //d[i].TrimStart(' ');
                            var parsedIssue = defect_id[i].TrimStart(' ');
                            //add information into the table string
                            JiraInfo(jiraValue , parsedIssue, Jauth, UField);
                        }
                }
            }

            //creating the sorting
            switch (sort_index)
            {
                case 0:
                    jirainfo.Sort((x, y) => x.UbiPrio.CompareTo(y.UbiPrio));
                    break;
                //to enable uncomment
                //case 1:
                //    jirainfo.Sort((x, y) => y.UbiPrio.CompareTo(x.UbiPrio));
                //    break;
                case 2:
                    jirainfo.Sort((x, y) => y.Jiraid.CompareTo(x.Jiraid));
                    break;
                case 3:
                    jirainfo.Sort((x, y) => x.Jiraid.CompareTo(y.Jiraid));
                    break;
                default:
                    break;
            }

            //adding the issues into the table in html code
            foreach (Jiras jira_variab in jirainfo)
            {
                resort += "<tr><td>" + jira_variab.id_link + "</td><td>" + jira_variab.Jirasummary + "</td>";

                if (issueType)
                    resort += "<td>" + jira_variab.IssueType + "</td>";
                if (ubiPriority)
                    resort += FormattingActions.FormatUp(jira_variab.UbiPrio) + "</td>";
                if (priority)
                    resort += "<td>" + FormattingActions.Prio(jira_variab.Priority) + " </td>";
                if (status)
                    resort += "<td>" + jira_variab.Status + " </td>";

                resort += "<td>" + jira_variab.Regression + "</td><td>" + jira_variab.Comment + "</td></tr>";
            }
            //starts the email preparation
            Thread mth = new Thread(() => PlanThreads(name, resort));
            mth.Start();
        }
        public void PlanThreads(string name, string resort)
        //public void PlanThreads(string User, string us, string pass, string j, string name, string[] runs)
        {

            //Use Office Interop to create email and pass the information into it
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            //table is passed to the body of the email
            oMailItem.HTMLBody = resort;
            //date is set
            DateTime dt = DateTime.Now;
            //subject of the email
            oMailItem.Subject = name + " " + String.Format("{0:d-MM-yyy}", dt);
            //
            oMailItem.Display(false);

            //DataTable table = new DataTable;
            //table.Initialized

        }
        public static string GetProjects(string user, string pass)
        {
            //need to work the variable
            string rezul;
            rezul = "";

            var t = new Get();
            var help = t.Trequest("get_projects", "/", user, pass);

            //parsing the answer
            //var help = JArray.Parse(jsonResponse);
            int i; int count = help.Count();
            for (i = 0; i < count; i++)
                rezul = rezul + help[i]["id"].ToString() + " " + help[i]["name"].ToString() + "\n";
            //}
            //return the solution
            return rezul;
        }
        public static string GetRuns(string PID, string user, string pass)
        {
            //work the variable because of try-catch
            string help;
            help = "" + " ";
            //create the request
            var t = new Get();
            JToken js = t.Trequest("get_runs/", PID, user, pass);

            //JToken js = JToken.Parse(jsonResponse);
            //parse the response and get the value for id
            for (int i = 0; i < js.Count(); i++)
            {
                help = help + js[i]["name"].ToString() + "\n";
                AllTheShinies._runsId.Add(js[i]["id"].ToString());
            }
            //return the value
            return help;
        }
        public string GetTestId(string RID, string user, string pass)
        {
            //need to work the variable because of try-catch
            string results = "";
            //create the request
            var t = new Get();
            var help = t.Trequest("get_tests/", RID, user, pass);

            //parsing the json
            //var help = JArray.Parse(jsonResponse);
            //adding the ids a string
            for (int i = 0; i < help.Count(); i++)
            {
                results = results + help[i]["id"].ToObject<string>() + ",";
                _tests.Add(help[i]["id"].ToString());
            }

            //return the results string
            return results;
        }

        public string GetPlans(string PID, string user, string pass)
        {
            //need to work the variable because of try-catch
            string results = "";/*_testrailId = "";*/
            //create the request
            var t = new Get();
            var help = t.Trequest("get_plans/", PID, user, pass);
            //parsing the json
            //var help = JToken.Parse(jsonResponse);
            //adding the ids a string
            for (int i = 0; i < help.Count(); i++)
            {
                results = results + help[i]["name"] + "\n";
                _testrailId.Add(help[i]["id"].ToString());
            }

            //return the results string
            return results;
        }

        public string GetPlan(string PID, string user, string pass)
        {
            //need to work the variable because of try-catch
            string results = "";
            var t = new Get();
            //create the request - Testrail API is bad and does not accept httpclient - yet
            var help = t.Trequest("get_plan/", PID, user, pass);

            
            for (int i = 0; i < help["entries"].Count(); i++)
                results = results + help["entries"][i]["runs"][0]["id"] + "\n";
            //return the results string
            return results;
        }

    }
}
