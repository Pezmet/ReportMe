namespace ReportMe
{
    partial class MainContainer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainContainer));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.passwordInfoBox = new System.Windows.Forms.TextBox();
            this.userBox = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.TestrailPanel = new System.Windows.Forms.Panel();
            this.testrail_sorting = new System.Windows.Forms.ComboBox();
            this.testrail_ubiPriority = new System.Windows.Forms.CheckBox();
            this.testrail_status = new System.Windows.Forms.CheckBox();
            this.testrail_priority = new System.Windows.Forms.CheckBox();
            this.testrail_issueType = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PTLabel = new System.Windows.Forms.Label();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.JiraTestrailDescr = new System.Windows.Forms.TextBox();
            this.JiraValueTestrail = new System.Windows.Forms.TextBox();
            this.GenRepPlan = new System.Windows.Forms.Button();
            this.Testrail = new System.Windows.Forms.CheckBox();
            this.GetPlansB = new System.Windows.Forms.Button();
            this.Milestone = new System.Windows.Forms.CheckBox();
            this.TestPlan = new System.Windows.Forms.CheckBox();
            this.TestplanList = new System.Windows.Forms.ComboBox();
            this.RunsList = new System.Windows.Forms.ComboBox();
            this.GenRep = new System.Windows.Forms.Button();
            this.GetRun = new System.Windows.Forms.Button();
            this.TProj = new System.Windows.Forms.ComboBox();
            this.PTip = new System.Windows.Forms.ToolTip(this.components);
            this.UTip = new System.Windows.Forms.ToolTip(this.components);
            this.GenerateTip = new System.Windows.Forms.ToolTip(this.components);
            this.mailto = new System.Windows.Forms.Button();
            this.JiraPanel = new System.Windows.Forms.Panel();
            this.Jira_sorting = new System.Windows.Forms.ComboBox();
            this.jira_ubiPriority = new System.Windows.Forms.CheckBox();
            this.jira_status = new System.Windows.Forms.CheckBox();
            this.jira_priority = new System.Windows.Forms.CheckBox();
            this.jira_issueType = new System.Windows.Forms.CheckBox();
            this.PJLabel = new System.Windows.Forms.Label();
            this.ProgressJira = new System.Windows.Forms.ProgressBar();
            this.ReadtheJira = new System.Windows.Forms.Button();
            this.JiraFilterDesc = new System.Windows.Forms.TextBox();
            this.JiraValueFilter = new System.Windows.Forms.TextBox();
            this.GenRepJira = new System.Windows.Forms.Button();
            this.JiraFiltersList = new System.Windows.Forms.ComboBox();
            this.JiraFilter = new System.Windows.Forms.CheckBox();
            this.LoginPanel.SuspendLayout();
            this.TestrailPanel.SuspendLayout();
            this.JiraPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.MintCream;
            this.LoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LoginPanel.Controls.Add(this.passwordInfoBox);
            this.LoginPanel.Controls.Add(this.userBox);
            this.LoginPanel.Controls.Add(this.Login);
            this.LoginPanel.Controls.Add(this.Password);
            this.LoginPanel.Location = new System.Drawing.Point(196, 186);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(432, 178);
            this.LoginPanel.TabIndex = 0;
            // 
            // passwordInfoBox
            // 
            this.passwordInfoBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.passwordInfoBox.Location = new System.Drawing.Point(106, 75);
            this.passwordInfoBox.Name = "passwordInfoBox";
            this.passwordInfoBox.Size = new System.Drawing.Size(200, 20);
            this.passwordInfoBox.TabIndex = 9;
            this.passwordInfoBox.Text = "Please enter your password bellow";
            // 
            // userBox
            // 
            this.userBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.userBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBox.HideSelection = false;
            this.userBox.Location = new System.Drawing.Point(88, 32);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(235, 20);
            this.userBox.TabIndex = 8;
            this.userBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(120, 130);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(142, 23);
            this.Login.TabIndex = 4;
            this.Login.Text = "Log me!";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Password
            // 
            this.Password.AccessibleDescription = "Password";
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Password.Location = new System.Drawing.Point(106, 104);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(200, 20);
            this.Password.TabIndex = 3;
            // 
            // TestrailPanel
            // 
            this.TestrailPanel.BackColor = System.Drawing.Color.Transparent;
            this.TestrailPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TestrailPanel.Controls.Add(this.testrail_sorting);
            this.TestrailPanel.Controls.Add(this.testrail_ubiPriority);
            this.TestrailPanel.Controls.Add(this.testrail_status);
            this.TestrailPanel.Controls.Add(this.testrail_priority);
            this.TestrailPanel.Controls.Add(this.testrail_issueType);
            this.TestrailPanel.Controls.Add(this.label1);
            this.TestrailPanel.Controls.Add(this.PTLabel);
            this.TestrailPanel.Controls.Add(this.Progress);
            this.TestrailPanel.Controls.Add(this.JiraTestrailDescr);
            this.TestrailPanel.Controls.Add(this.JiraValueTestrail);
            this.TestrailPanel.Controls.Add(this.GenRepPlan);
            this.TestrailPanel.Controls.Add(this.Testrail);
            this.TestrailPanel.Controls.Add(this.GetPlansB);
            this.TestrailPanel.Controls.Add(this.Milestone);
            this.TestrailPanel.Controls.Add(this.TestPlan);
            this.TestrailPanel.Controls.Add(this.TestplanList);
            this.TestrailPanel.Controls.Add(this.RunsList);
            this.TestrailPanel.Controls.Add(this.GenRep);
            this.TestrailPanel.Controls.Add(this.GetRun);
            this.TestrailPanel.Controls.Add(this.TProj);
            this.TestrailPanel.Location = new System.Drawing.Point(335, 25);
            this.TestrailPanel.Name = "TestrailPanel";
            this.TestrailPanel.Size = new System.Drawing.Size(452, 422);
            this.TestrailPanel.TabIndex = 1;
            this.TestrailPanel.Visible = false;
            // 
            // testrail_sorting
            // 
            this.testrail_sorting.FormattingEnabled = true;
            this.testrail_sorting.Items.AddRange(new object[] {
            "Descending By Ubi Priority",
            "Descending By Jira Key",
            "Ascending By Jira Key"});
            this.testrail_sorting.Location = new System.Drawing.Point(16, 143);
            this.testrail_sorting.Name = "testrail_sorting";
            this.testrail_sorting.Size = new System.Drawing.Size(202, 21);
            this.testrail_sorting.TabIndex = 35;
            this.testrail_sorting.Text = "Sorting by";
            // 
            // testrail_ubiPriority
            // 
            this.testrail_ubiPriority.AutoSize = true;
            this.testrail_ubiPriority.Location = new System.Drawing.Point(16, 226);
            this.testrail_ubiPriority.Name = "testrail_ubiPriority";
            this.testrail_ubiPriority.Size = new System.Drawing.Size(76, 17);
            this.testrail_ubiPriority.TabIndex = 34;
            this.testrail_ubiPriority.Text = "Ubi Priority";
            this.testrail_ubiPriority.UseVisualStyleBackColor = true;
            // 
            // testrail_status
            // 
            this.testrail_status.AutoSize = true;
            this.testrail_status.Location = new System.Drawing.Point(107, 226);
            this.testrail_status.Name = "testrail_status";
            this.testrail_status.Size = new System.Drawing.Size(56, 17);
            this.testrail_status.TabIndex = 33;
            this.testrail_status.Text = "Status";
            this.testrail_status.UseVisualStyleBackColor = true;
            // 
            // testrail_priority
            // 
            this.testrail_priority.AutoSize = true;
            this.testrail_priority.Location = new System.Drawing.Point(107, 205);
            this.testrail_priority.Name = "testrail_priority";
            this.testrail_priority.Size = new System.Drawing.Size(57, 17);
            this.testrail_priority.TabIndex = 31;
            this.testrail_priority.Text = "Priority";
            this.testrail_priority.UseVisualStyleBackColor = true;
            // 
            // testrail_issueType
            // 
            this.testrail_issueType.AutoSize = true;
            this.testrail_issueType.Location = new System.Drawing.Point(16, 203);
            this.testrail_issueType.Name = "testrail_issueType";
            this.testrail_issueType.Size = new System.Drawing.Size(78, 17);
            this.testrail_issueType.TabIndex = 30;
            this.testrail_issueType.Text = "Issue Type";
            this.testrail_issueType.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 28;
            // 
            // PTLabel
            // 
            this.PTLabel.AutoSize = true;
            this.PTLabel.Location = new System.Drawing.Point(160, 270);
            this.PTLabel.Name = "PTLabel";
            this.PTLabel.Size = new System.Drawing.Size(0, 13);
            this.PTLabel.TabIndex = 22;
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(161, 291);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 23);
            this.Progress.TabIndex = 19;
            // 
            // JiraTestrailDescr
            // 
            this.JiraTestrailDescr.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.JiraTestrailDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JiraTestrailDescr.Location = new System.Drawing.Point(16, 102);
            this.JiraTestrailDescr.Name = "JiraTestrailDescr";
            this.JiraTestrailDescr.ReadOnly = true;
            this.JiraTestrailDescr.Size = new System.Drawing.Size(198, 20);
            this.JiraTestrailDescr.TabIndex = 18;
            this.JiraTestrailDescr.Text = "Type your Jira instance id (Eg 19)";
            // 
            // JiraValueTestrail
            // 
            this.JiraValueTestrail.HideSelection = false;
            this.JiraValueTestrail.Location = new System.Drawing.Point(239, 102);
            this.JiraValueTestrail.Name = "JiraValueTestrail";
            this.JiraValueTestrail.Size = new System.Drawing.Size(47, 20);
            this.JiraValueTestrail.TabIndex = 17;
            this.JiraValueTestrail.TextChanged += new System.EventHandler(this.JiraValueTestrail_TextChanged);
            // 
            // GenRepPlan
            // 
            this.GenRepPlan.BackColor = System.Drawing.SystemColors.Control;
            this.GenRepPlan.Enabled = false;
            this.GenRepPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenRepPlan.ForeColor = System.Drawing.Color.OliveDrab;
            this.GenRepPlan.Location = new System.Drawing.Point(150, 330);
            this.GenRepPlan.Name = "GenRepPlan";
            this.GenRepPlan.Size = new System.Drawing.Size(149, 36);
            this.GenRepPlan.TabIndex = 11;
            this.GenRepPlan.Text = "Generate Report";
            this.GenRepPlan.UseVisualStyleBackColor = true;
            this.GenRepPlan.Click += new System.EventHandler(this.GenRepPlan_Click);
            // 
            // Testrail
            // 
            this.Testrail.AutoSize = true;
            this.Testrail.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Testrail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Testrail.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Testrail.Location = new System.Drawing.Point(16, 3);
            this.Testrail.Name = "Testrail";
            this.Testrail.Size = new System.Drawing.Size(60, 17);
            this.Testrail.TabIndex = 5;
            this.Testrail.Text = "Testrail";
            this.Testrail.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Testrail.UseVisualStyleBackColor = false;
            this.Testrail.CheckedChanged += new System.EventHandler(this.Testrail_CheckedChanged);
            // 
            // GetPlansB
            // 
            this.GetPlansB.AutoSize = true;
            this.GetPlansB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GetPlansB.Location = new System.Drawing.Point(329, 56);
            this.GetPlansB.Name = "GetPlansB";
            this.GetPlansB.Size = new System.Drawing.Size(120, 23);
            this.GetPlansB.TabIndex = 9;
            this.GetPlansB.Text = "        Get  Plans          ";
            this.GetPlansB.UseVisualStyleBackColor = true;
            this.GetPlansB.Click += new System.EventHandler(this.GetPlansB_Click);
            // 
            // Milestone
            // 
            this.Milestone.AutoSize = true;
            this.Milestone.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Milestone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Milestone.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Milestone.Location = new System.Drawing.Point(338, 91);
            this.Milestone.Name = "Milestone";
            this.Milestone.Size = new System.Drawing.Size(106, 17);
            this.Milestone.TabIndex = 16;
            this.Milestone.TabStop = false;
            this.Milestone.Text = "Need Milestone?";
            this.Milestone.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Milestone.UseVisualStyleBackColor = false;
            this.Milestone.Visible = false;
            // 
            // TestPlan
            // 
            this.TestPlan.AutoSize = true;
            this.TestPlan.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TestPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestPlan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TestPlan.Location = new System.Drawing.Point(336, 36);
            this.TestPlan.Name = "TestPlan";
            this.TestPlan.Size = new System.Drawing.Size(111, 17);
            this.TestPlan.TabIndex = 7;
            this.TestPlan.Text = "Need Testplan?   ";
            this.TestPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.TestPlan.UseVisualStyleBackColor = false;
            this.TestPlan.CheckedChanged += new System.EventHandler(this.TestPlan_CheckedChanged);
            // 
            // TestplanList
            // 
            this.TestplanList.FormattingEnabled = true;
            this.TestplanList.Location = new System.Drawing.Point(16, 75);
            this.TestplanList.Name = "TestplanList";
            this.TestplanList.Size = new System.Drawing.Size(278, 21);
            this.TestplanList.TabIndex = 8;
            this.TestplanList.Text = "Click Get Plans to populate";
            // 
            // RunsList
            // 
            this.RunsList.FormattingEnabled = true;
            this.RunsList.Location = new System.Drawing.Point(16, 75);
            this.RunsList.Name = "RunsList";
            this.RunsList.Size = new System.Drawing.Size(278, 21);
            this.RunsList.TabIndex = 8;
            this.RunsList.Text = "Click Get Runs to populate";
            // 
            // GenRep
            // 
            this.GenRep.BackColor = System.Drawing.SystemColors.Control;
            this.GenRep.Enabled = false;
            this.GenRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenRep.ForeColor = System.Drawing.Color.OliveDrab;
            this.GenRep.Location = new System.Drawing.Point(150, 343);
            this.GenRep.Name = "GenRep";
            this.GenRep.Size = new System.Drawing.Size(149, 36);
            this.GenRep.TabIndex = 11;
            this.GenRep.Text = "Generate Report";
            this.GenRep.UseVisualStyleBackColor = true;
            this.GenRep.Click += new System.EventHandler(this.GenRep_Click);
            // 
            // GetRun
            // 
            this.GetRun.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.GetRun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GetRun.Location = new System.Drawing.Point(329, 56);
            this.GetRun.Name = "GetRun";
            this.GetRun.Size = new System.Drawing.Size(120, 23);
            this.GetRun.TabIndex = 9;
            this.GetRun.Text = "Get Runs ";
            this.GetRun.UseVisualStyleBackColor = false;
            this.GetRun.Click += new System.EventHandler(this.GetRun_Click);
            // 
            // TProj
            // 
            this.TProj.FormattingEnabled = true;
            this.TProj.Location = new System.Drawing.Point(16, 36);
            this.TProj.Name = "TProj";
            this.TProj.Size = new System.Drawing.Size(278, 21);
            this.TProj.TabIndex = 6;
            this.TProj.SelectedIndexChanged += new System.EventHandler(this.TProj_SelectedIndexChanged);
            // 
            // PTip
            // 
            this.PTip.ToolTipTitle = "Password";
            // 
            // UTip
            // 
            this.UTip.ToolTipTitle = "Username here";
            // 
            // GenerateTip
            // 
            this.GenerateTip.ToolTipTitle = "Click to create report";
            // 
            // mailto
            // 
            this.mailto.BackColor = System.Drawing.Color.Transparent;
            this.mailto.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
            this.mailto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.mailto.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.mailto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mailto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mailto.ForeColor = System.Drawing.Color.Salmon;
            this.mailto.Location = new System.Drawing.Point(300, 457);
            this.mailto.Name = "mailto";
            this.mailto.Size = new System.Drawing.Size(197, 23);
            this.mailto.TabIndex = 2;
            this.mailto.Text = "Need help? ";
            this.mailto.UseVisualStyleBackColor = false;
            this.mailto.Click += new System.EventHandler(this.mailto_Click);
            // 
            // JiraPanel
            // 
            this.JiraPanel.BackColor = System.Drawing.Color.Transparent;
            this.JiraPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.JiraPanel.Controls.Add(this.Jira_sorting);
            this.JiraPanel.Controls.Add(this.jira_ubiPriority);
            this.JiraPanel.Controls.Add(this.jira_status);
            this.JiraPanel.Controls.Add(this.jira_priority);
            this.JiraPanel.Controls.Add(this.jira_issueType);
            this.JiraPanel.Controls.Add(this.PJLabel);
            this.JiraPanel.Controls.Add(this.ProgressJira);
            this.JiraPanel.Controls.Add(this.ReadtheJira);
            this.JiraPanel.Controls.Add(this.JiraFilterDesc);
            this.JiraPanel.Controls.Add(this.JiraValueFilter);
            this.JiraPanel.Controls.Add(this.GenRepJira);
            this.JiraPanel.Controls.Add(this.JiraFiltersList);
            this.JiraPanel.Controls.Add(this.JiraFilter);
            this.JiraPanel.Location = new System.Drawing.Point(33, 25);
            this.JiraPanel.Name = "JiraPanel";
            this.JiraPanel.Size = new System.Drawing.Size(205, 422);
            this.JiraPanel.TabIndex = 3;
            this.JiraPanel.Visible = false;
            // 
            // Jira_sorting
            // 
            this.Jira_sorting.AllowDrop = true;
            this.Jira_sorting.FormattingEnabled = true;
            this.Jira_sorting.Items.AddRange(new object[] {
            "Descending By Ubi Priority",
            "Descending By Jira Key",
            "Ascending By Jira Key"});
            this.Jira_sorting.Location = new System.Drawing.Point(0, 143);
            this.Jira_sorting.Name = "Jira_sorting";
            this.Jira_sorting.Size = new System.Drawing.Size(202, 21);
            this.Jira_sorting.TabIndex = 28;
            this.Jira_sorting.Text = "Sorting by";
            // 
            // jira_ubiPriority
            // 
            this.jira_ubiPriority.AutoSize = true;
            this.jira_ubiPriority.Location = new System.Drawing.Point(3, 226);
            this.jira_ubiPriority.Name = "jira_ubiPriority";
            this.jira_ubiPriority.Size = new System.Drawing.Size(76, 17);
            this.jira_ubiPriority.TabIndex = 27;
            this.jira_ubiPriority.Text = "Ubi Priority";
            this.jira_ubiPriority.UseVisualStyleBackColor = true;
            // 
            // jira_status
            // 
            this.jira_status.AutoSize = true;
            this.jira_status.Location = new System.Drawing.Point(94, 226);
            this.jira_status.Name = "jira_status";
            this.jira_status.Size = new System.Drawing.Size(56, 17);
            this.jira_status.TabIndex = 26;
            this.jira_status.Text = "Status";
            this.jira_status.UseVisualStyleBackColor = true;
            // 
            // jira_priority
            // 
            this.jira_priority.AutoSize = true;
            this.jira_priority.Location = new System.Drawing.Point(94, 203);
            this.jira_priority.Name = "jira_priority";
            this.jira_priority.Size = new System.Drawing.Size(57, 17);
            this.jira_priority.TabIndex = 24;
            this.jira_priority.Text = "Priority";
            this.jira_priority.UseVisualStyleBackColor = true;
            // 
            // jira_issueType
            // 
            this.jira_issueType.AutoSize = true;
            this.jira_issueType.Location = new System.Drawing.Point(3, 203);
            this.jira_issueType.Name = "jira_issueType";
            this.jira_issueType.Size = new System.Drawing.Size(78, 17);
            this.jira_issueType.TabIndex = 23;
            this.jira_issueType.Text = "Issue Type";
            this.jira_issueType.UseVisualStyleBackColor = true;
            // 
            // PJLabel
            // 
            this.PJLabel.AutoSize = true;
            this.PJLabel.Location = new System.Drawing.Point(55, 265);
            this.PJLabel.Name = "PJLabel";
            this.PJLabel.Size = new System.Drawing.Size(0, 13);
            this.PJLabel.TabIndex = 21;
            // 
            // ProgressJira
            // 
            this.ProgressJira.Location = new System.Drawing.Point(47, 291);
            this.ProgressJira.Name = "ProgressJira";
            this.ProgressJira.Size = new System.Drawing.Size(100, 23);
            this.ProgressJira.TabIndex = 20;
            // 
            // ReadtheJira
            // 
            this.ReadtheJira.ForeColor = System.Drawing.Color.Black;
            this.ReadtheJira.Location = new System.Drawing.Point(94, 77);
            this.ReadtheJira.Name = "ReadtheJira";
            this.ReadtheJira.Size = new System.Drawing.Size(75, 23);
            this.ReadtheJira.TabIndex = 7;
            this.ReadtheJira.Text = "Get Them";
            this.ReadtheJira.UseVisualStyleBackColor = true;
            this.ReadtheJira.Click += new System.EventHandler(this.ReadtheJira_Click);
            // 
            // JiraFilterDesc
            // 
            this.JiraFilterDesc.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.JiraFilterDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JiraFilterDesc.Location = new System.Drawing.Point(0, 50);
            this.JiraFilterDesc.Name = "JiraFilterDesc";
            this.JiraFilterDesc.ReadOnly = true;
            this.JiraFilterDesc.Size = new System.Drawing.Size(198, 20);
            this.JiraFilterDesc.TabIndex = 6;
            this.JiraFilterDesc.Text = "Type your Jira bellow (Eg 19)";
            // 
            // JiraValueFilter
            // 
            this.JiraValueFilter.HideSelection = false;
            this.JiraValueFilter.Location = new System.Drawing.Point(27, 76);
            this.JiraValueFilter.Name = "JiraValueFilter";
            this.JiraValueFilter.Size = new System.Drawing.Size(47, 20);
            this.JiraValueFilter.TabIndex = 5;
            this.JiraValueFilter.TextChanged += new System.EventHandler(this.JiraValueFilter_TextChanged);
            // 
            // GenRepJira
            // 
            this.GenRepJira.BackColor = System.Drawing.SystemColors.Control;
            this.GenRepJira.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenRepJira.ForeColor = System.Drawing.Color.OliveDrab;
            this.GenRepJira.Location = new System.Drawing.Point(20, 330);
            this.GenRepJira.Name = "GenRepJira";
            this.GenRepJira.Size = new System.Drawing.Size(149, 36);
            this.GenRepJira.TabIndex = 4;
            this.GenRepJira.Text = "Generate Report";
            this.GenRepJira.UseVisualStyleBackColor = true;
            this.GenRepJira.Click += new System.EventHandler(this.GenRepJira_Click);
            // 
            // JiraFiltersList
            // 
            this.JiraFiltersList.FormattingEnabled = true;
            this.JiraFiltersList.Location = new System.Drawing.Point(0, 106);
            this.JiraFiltersList.Name = "JiraFiltersList";
            this.JiraFiltersList.Size = new System.Drawing.Size(202, 21);
            this.JiraFiltersList.TabIndex = 3;
            this.JiraFiltersList.Text = "Favourite filters";
            // 
            // JiraFilter
            // 
            this.JiraFilter.AutoSize = true;
            this.JiraFilter.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.JiraFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JiraFilter.ForeColor = System.Drawing.SystemColors.Desktop;
            this.JiraFilter.Location = new System.Drawing.Point(16, 3);
            this.JiraFilter.Name = "JiraFilter";
            this.JiraFilter.Size = new System.Drawing.Size(64, 17);
            this.JiraFilter.TabIndex = 1;
            this.JiraFilter.Text = "Jira filter";
            this.JiraFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.JiraFilter.UseVisualStyleBackColor = false;
            this.JiraFilter.CheckedChanged += new System.EventHandler(this.JiraFilter_CheckedChanged);
            // 
            // MainContainer
            // 
            this.AcceptButton = this.Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ReportMe.Properties.Resources.maxresdefault;
            this.ClientSize = new System.Drawing.Size(825, 551);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.TestrailPanel);
            this.Controls.Add(this.mailto);
            this.Controls.Add(this.JiraPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainContainer";
            this.Text = "ReportMe";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.TestrailPanel.ResumeLayout(false);
            this.TestrailPanel.PerformLayout();
            this.JiraPanel.ResumeLayout(false);
            this.JiraPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Panel TestrailPanel;
        private System.Windows.Forms.Button GenRep;
        private System.Windows.Forms.ToolTip PTip;
        private System.Windows.Forms.ToolTip UTip;
        private System.Windows.Forms.ToolTip GenerateTip;
        private System.Windows.Forms.ComboBox TProj;
        private System.Windows.Forms.ComboBox RunsList;
        private System.Windows.Forms.Button GetRun;
        private System.Windows.Forms.Button mailto;
        private System.Windows.Forms.CheckBox Milestone;
        private System.Windows.Forms.CheckBox TestPlan;
        private System.Windows.Forms.ComboBox TestplanList;
        private System.Windows.Forms.Button GetPlansB;
        public System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.CheckBox Testrail;
        private System.Windows.Forms.Button GenRepPlan;
        private System.Windows.Forms.Panel JiraPanel;
        private System.Windows.Forms.CheckBox JiraFilter;
        private System.Windows.Forms.ComboBox JiraFiltersList;
        private System.Windows.Forms.Button GenRepJira;
        private System.Windows.Forms.TextBox JiraValueFilter;
        private System.Windows.Forms.TextBox JiraFilterDesc;
        private System.Windows.Forms.Button ReadtheJira;
        private System.Windows.Forms.TextBox JiraValueTestrail;
        private System.Windows.Forms.TextBox JiraTestrailDescr;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.Label PTLabel;
        private System.Windows.Forms.Label PJLabel;
        private System.Windows.Forms.ProgressBar ProgressJira;
        private System.Windows.Forms.CheckBox jira_ubiPriority;
        private System.Windows.Forms.CheckBox jira_status;
        private System.Windows.Forms.CheckBox jira_priority;
        private System.Windows.Forms.CheckBox jira_issueType;
        private System.Windows.Forms.CheckBox testrail_ubiPriority;
        private System.Windows.Forms.CheckBox testrail_status;
        private System.Windows.Forms.CheckBox testrail_priority;
        private System.Windows.Forms.CheckBox testrail_issueType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox testrail_sorting;
        private System.Windows.Forms.ComboBox Jira_sorting;
        private System.Windows.Forms.TextBox passwordInfoBox;
        private System.Windows.Forms.TextBox userBox;
    }
}

