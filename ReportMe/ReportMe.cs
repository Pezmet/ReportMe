using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Principal;
using System.DirectoryServices;
using ReportMe.Backend;



namespace ReportMe
{
    public partial class MainContainer : Form
    {
        AllTheShinies masterObject; 
        List<Jiras> jirainfo = new List<Jiras>();
        //saves the link so it that issues can be queried from favourite filters
        List<string> links = new List<string>();
        //saves the testplans id so we can query them
        List<string> _testrailId = new List<string>();
        //saves the jira values so the report is sorted
        List<string> _runsId = new List<string>();

        List<string> _tests = new List<string>();

        Dictionary<string, string> issues = new Dictionary<string, string>();

        string jiraLogin, testrailLogin;

        public MainContainer()
        { 
            masterObject = new AllTheShinies();
            masterObject.LoginPreparations();
            string name = masterObject.givenName;

            InitializeComponent();
            TestrailPanel.Hide();
            JiraPanel.Hide();
            LoginPanel.Show();
            GenRep.Show();
            GenRepPlan.Hide();
            GenRepJira.Enabled = false;
            TestplanList.Hide();
            ReadtheJira.Enabled = false;
            userBox.Text = "Welcome " + name;
            
        }
        private void ResetForm(string s)
        {
            //write code here to setup your dropdowns, put empty strings into textboxes, etc.
            //UserName.Clear();
            Password.Clear();
            Login.ForeColor = Color.Red;
            Login.Text = s;
            //TUserN.Clear();
            ReadtheJira.Enabled = false;

            //UserDiff.Checked = false;

            //pretty much the reverse of the process by which you copy the values into your user object.
        }
        private void Login_Click(object sender, EventArgs e)
        {

            //perform calls to verify user credentials
            masterObject.pass = Password.Text;
            var res = masterObject.JRvalid(masterObject.jiraLogin);
            var rest = masterObject.TRvalid(masterObject.testrailLogin);
            //jira 19 validation
            if (res.IsSuccessStatusCode == false)
            {
                ResetForm("Jira cred, Retry!");
            }
            string credet = CredentialCache.DefaultCredentials.ToString();
            //testrail validation, if credentials are good, rest is not null
            if (rest == null)
                ResetForm("Testrail cred Retry");
            if (res.IsSuccessStatusCode && rest !=null)
            {
                LoginPanel.Hide();
                TestrailPanel.Show();
                JiraPanel.Show();
                GetPlansB.Hide();
            }
            masterObject.pass = Password.Text;
        }
        private void GetPlansB_Click(object sender, EventArgs e)
        {
            string selectedProject,plansPerProject,  auth;string[] plansId;
            _testrailId.Clear();
            //create the testplan list
            TestplanList.Show();
            //calculate the authentication for testrail
            auth = masterObject.Gen_Authen(testrailLogin, Password.Text);
            //work the selected project to obtain it's id
            selectedProject = TProj.SelectedItem.ToString().Substring(0, 3).TrimEnd(' ');
            //get the plans for said id
            plansPerProject = masterObject.GetPlans(selectedProject, masterObject.testrailLogin, masterObject.pass);
            //forming an array of the plans
            plansId = plansPerProject.Split('\n').ToArray();
            //add all the results 
            List<string> items = new List<string>();
            for (int i = 0; i < masterObject._testrailId.Count; i++)
                items.Add(plansId[i]);
            //associate the list data to the buttons datasource
            TestplanList.DataSource = items;
        }
        private async void GenRepPlan_Click(object sender, EventArgs e)
        {
            checkOptions();
            //affects UI behavior
            jirainfo.Clear();
            Progress.Value = 0;
            PTLabel.Text = "Preparing process...";
            PTLabel.Refresh();
            Progress.Increment(20);
            //pass the name of the testplan to argument name
            string name = TestplanList.SelectedItem.ToString();
            //pass the index of the testplan 
            int index = TestplanList.SelectedIndex;
            //make sure the button is disabled
            GenRepPlan.Enabled = false;
            //pass the index for sorting
            int sort_index = testrail_sorting.SelectedIndex;
            //AllTheShinies runReport = new AllTheShinies();
            //start a thread in which all the calls and processing is performed
            await Task.Run(() => masterObject.PlanReport(name, index, sort_index, JiraValueTestrail.Text));

            //UI - behavior
            for (int i = 0; i < 4; i++)
                Progress.Increment(20);
            GenRepPlan.Enabled = true;

            PTLabel.Text = "Done ";
            PTLabel.Refresh();

        }

        private async void GenRep_Click(object sender, EventArgs e)
        {
            //UI
            jirainfo.Clear();
            Progress.Value = 0;
            PTLabel.Text = "Preparing process...";
            PTLabel.Refresh();
            GenRep.Enabled = false;
            checkOptions();
            Progress.Increment(20);
            //pass the name of the run, to be used in the email thread
            string name = RunsList.SelectedItem.ToString();
            //index of the run
            int runs_index = RunsList.SelectedIndex;
            //pass the sorting index
            int sort_index = testrail_sorting.SelectedIndex;
            //start the task of creating the report
            //AllTheShinies runReport = new AllTheShinies();

            await Task.Run(() => masterObject.RunReport(name, runs_index, sort_index, JiraValueTestrail.Text));
            //UI
            for (int i = 0; i < 4; i++)
                Progress.Increment(20);

            PTLabel.Text = "Done ";
            PTLabel.Refresh();

            GenRep.Enabled = true;
        }


        private void JiraInst_TextChanged(object sender, EventArgs e)
        {

        }
 

        private void Jiras_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        //describes behavior for checked
       

        private void TProj_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //Behavior after clicking t
        private void GetRun_Click(object sender, EventArgs e)
        {
            //clean the list for the runs id
            _runsId.Clear(); string[] d;

            //testrail name
            string testrailProj = TProj.SelectedItem.ToString().Substring(0, 3).TrimEnd(' ');
            //string of runs returned
            string testrailId = AllTheShinies.GetRuns(testrailProj, masterObject.testrailLogin, masterObject.pass);
            //making sure there is no space
            testrailId = testrailId.Trim(' ');

            //splitting the string to an array
            d = testrailId.Split('\n').Distinct().ToArray();        
            List<string> items = new List<string>();
            //
            for (int i = 0; i < d.Length - 1; i++)
            {
                items.Add(d[i]);

            }
            RunsList.DataSource = items;
        }

        //format the email
        private void mailto_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook._MailItem oMailItem = (Microsoft.Office.Interop.Outlook._MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            DateTime dt = DateTime.Now;
            oMailItem.To = "victor-cristian.popa@ubisoft.com";
            oMailItem.CC = "alina-diana.milasan@ubisoft.com";
            oMailItem.Subject = "[Report Me] " + String.Format("{0:d-mm-yyy}", dt);
            oMailItem.Display(false);
        }



        private void TestPlan_CheckedChanged(object sender, EventArgs e)
        {
            if (TestPlan.Checked)
            {
                GetPlansB.Show();
                TestplanList.Show();
                GetRun.Hide();
                RunsList.Hide();
                GenRep.Hide();
                GenRepPlan.Show();

            }
            else
            {
                GetPlansB.Hide();
                TestplanList.Hide();
                GetRun.Show();
                RunsList.Show();
                GenRepPlan.Hide();
                GenRep.Show();
                GenRep.Enabled = true;
            }
        }

        //Testrail panel options
        private void Testrail_CheckedChanged(object sender, EventArgs e)
        {
            string[] d; string auth, b;
            if (Testrail.Checked)
            {
                //unchecks jira filter panel
                JiraFilter.Checked = false;
                //sets the background color
                TestrailPanel.BackColor = Color.MintCream;

                    b = AllTheShinies.GetProjects(masterObject.testrailLogin, masterObject.pass);
                // gets the projects from testrail to populate the drop down list
                //work the response to display correctly
                d = b.Split('\n').Distinct().ToArray();      
                List<string> items = new List<string>();
                for (int i = 0; i < d.Length - 1; i++)
                {

                    items.Add(d[i]);

                    // set data source
                }
                TProj.DataSource = items;
                GetRun.Enabled = true;
                GetPlansB.Enabled = true;
            }
            else
            {
                TProj.DataSource = null;
                GetPlansB.Enabled = false;
                GetRun.Enabled = false;
                List<string> sorting_options = new List<string>();
            }
        }


     

        private void JiraFilter_CheckedChanged(object sender, EventArgs e)
        {
            //based on user selection, sets the switch between 2 panels
            if (JiraFilter.Checked)
            {
                Testrail.Checked = false;
                TestrailPanel.BackColor = Color.Transparent;
                JiraPanel.BackColor = Color.MintCream;
            }
            else
            {
                TestrailPanel.BackColor = Color.MintCream;
                Testrail.Checked = true;
                JiraPanel.BackColor = Color.Transparent;
            }
        }

        private async void GenRepJira_Click(object sender, EventArgs e)
        {
            //the name in the subject
            string name = JiraFiltersList.SelectedItem.ToString();

            checkOptions();

                //the selected filter
            ProgressJira.Value = 0;
            var a = JiraFiltersList.SelectedIndex;
            //the entered jira 
            var j = JiraValueFilter.Text;
            PJLabel.Text = "Preparing ";
            //pass the sort index
            int sort_index = Jira_sorting.SelectedIndex;
            if (sort_index == -1)
                sort_index = 0;

            ProgressJira.Increment(20);
            //start the report creation
            await Task.Run(() => masterObject.JiraReport(name, a, j, sort_index));
            //UI
            for (int i = 0; i < 4; i++)
                ProgressJira.Increment(20);

            PJLabel.Text = "Done ";
            PJLabel.Refresh();
        }
       
      
        //get them button behavior based on value in Jira text input box
        private void JiraValueFilter_TextChanged(object sender, EventArgs e)
        {
            if (JiraValueFilter.Text == "")
            {
                ReadtheJira.ForeColor = Color.Red; 
                ReadtheJira.Text = "No Jira";
                ReadtheJira.Enabled = false;
                GenRepJira.Enabled = false;
            }
            else
            {
                ReadtheJira.Enabled = true;
                ReadtheJira.ForeColor = Color.Black;
                ReadtheJira.Text = "Get Them";
                GenRepJira.Enabled = true;
            }
        }


        //gets the favourite filters
        private void ReadtheJira_Click(object sender, EventArgs e)
        {
            //if (JiraValueFilter.Text != "")
            //{
                //generating the authentication
                string auth = masterObject.Gen_Authen(masterObject.jiraLogin, masterObject.pass);
                //passing the filter name to jira variable
                string jira = JiraValueFilter.Text;
                //initializing a new get object
                var j = new Get();
                //passing the response data of the request to jsonResponse
                string jsonResponse = j.Jrequest(jira, "filter/","favourite",auth);
                //parse response to JTOKEN which allows to extract ids until a certain level
                var help = JToken.Parse(jsonResponse);
                //number of entries
                int count = help.Count();
                //initializing a new list to store information
                var myList = new List<string>();
                //foreach entry from the help(jtoken), save the name and the searchUrl
                for (int i = 0; i < count; i++)
                    {
                        //name is stored in mylist to show user
                        myList.Add(help[i]["name"].ToString());
                        //link is stored in links to get issues for filter
                        masterObject.links.Add(help[i]["searchUrl"].ToString());

                    }
                    //populates the list with filters
                    JiraFiltersList.DataSource = myList;
                
            //}
        }


       
        private void JiraValueTestrail_TextChanged(object sender, EventArgs e)
        {
            if (JiraValueTestrail.Text == "")
            {
                GenRepPlan.Enabled = false;
                GenRep.Enabled = false;
            }
            else
            {
                GenRep.Enabled = true;
                GenRepPlan.Enabled = true;
            }                    
        }
       
        public void checkOptions()
        {
            if (Testrail.Checked ^ JiraFilter.Checked)
            {
                if (testrail_issueType.Checked ^ jira_issueType.Checked )
                    masterObject.issueType = true;
                if (testrail_priority.Checked ^ jira_priority.Checked)
                    masterObject.priority = true;
                if (testrail_status.Checked ^ jira_status.Checked)
                    masterObject.status = true;
                if (testrail_ubiPriority.Checked ^ jira_ubiPriority.Checked)
                    masterObject.ubiPriority = true;
            }
            else 
            {
                    masterObject.issueType = false;
                    masterObject.priority = false;
                    masterObject.status = false;
                    masterObject.ubiPriority = false;

            }
        }

    }
    }