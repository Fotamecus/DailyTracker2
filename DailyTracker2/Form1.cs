using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DailyTracker2
{
    public partial class Form1 : Form
    {

        #region constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region functions

        private void Form1_Load(object sender, EventArgs e)
        {
            dailyPanel.Visible = false;
            weeklyPanel.Visible = false;
            monthlyPanel.Visible = false;
            UpdateFormSize();
            UpdateLists();
            SetupTimer();
        }

        private void SetupTimer()
        {
            Timer minuteTimer = new Timer();
            minuteTimer.Interval = 60000; // 60 seconds
            minuteTimer.Tick += CheckResetTime;
            minuteTimer.Start();
        }

        private void CheckResetTime(object sender, EventArgs e)
        {
            DateTime lastUpdated = FetchConfigTimestamp();
            DateTime now = DateTime.UtcNow;

            if (now.DayOfYear > lastUpdated.DayOfYear || now.Year > lastUpdated.Year)
            {
                foreach (string line in completeDailiesList.Items)
                {
                    MoveItemToSection(line, "incomplete");
                }

                DateTime nextWeeklyReset = lastUpdated;

                switch (lastUpdated.DayOfWeek)
                {
                    case DayOfWeek.Thursday:
                        nextWeeklyReset.AddDays(6);
                        break;
                    case DayOfWeek.Friday:
                        nextWeeklyReset.AddDays(5);
                        break;
                    case DayOfWeek.Saturday:
                        nextWeeklyReset.AddDays(4);
                        break;
                    case DayOfWeek.Sunday:
                        nextWeeklyReset.AddDays(3);
                        break;
                    case DayOfWeek.Monday:
                        nextWeeklyReset.AddDays(2);
                        break;
                    case DayOfWeek.Tuesday:
                        nextWeeklyReset.AddDays(1);
                        break;
                }

                if (now.DayOfYear > nextWeeklyReset.DayOfYear || now.Year > nextWeeklyReset.Year)
                {
                    foreach (string line in completeWeekliesList.Items)
                    {
                        MoveItemToSection(line, "incomplete");
                    }
                }

                if (now.Month > lastUpdated.Month || now.Year > lastUpdated.Year)
                {
                    foreach (string line in completeMonthliesList.Items)
                    {
                        MoveItemToSection(line, "incomplete");
                    }
                }

                TimeSpan ts = now - new DateTime(1970, 1, 1, 0, 0, 0);
                WriteConfigTimestamp((long)ts.TotalSeconds);

                UpdateLists();
            }
        }

        private void WriteConfigTimestamp(long timestamp)
        {
            List<string> configFile = new List<string>(GetConfigFile());
            configFile[0] = "UNIXSTAMP=" + timestamp;
            PushToConfigFile(configFile);
        }

        private DateTime FetchConfigTimestamp()
        {
            long unixstamp = new long();
            string identifier = "UNIXSTAMP=";
            List<string> configFile = new List<string>(GetConfigFile());

            foreach (string line in configFile)
            {
                if (line.StartsWith(identifier))
                {
                    unixstamp = long.Parse(line.Substring(identifier.Length));
                }
            }

            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dt = dt.AddSeconds(unixstamp).ToLocalTime();

            return dt;
        }

        private void UpdateFormSize()
        {
            int runningTotalHeight = 42; // This works for some reason. Don't fuck with it.

            runningTotalHeight += dailyButton.Size.Height;
            if (dailyPanel.Visible)
            {
                runningTotalHeight += dailyPanel.Size.Height;
            }
            runningTotalHeight += weeklyButton.Size.Height;
            if (weeklyPanel.Visible)
            {
                runningTotalHeight += weeklyPanel.Size.Height;
            }
            runningTotalHeight += monthlyButton.Size.Height;
            if (monthlyPanel.Visible)
            {
                runningTotalHeight += monthlyPanel.Size.Height;
            }

            Size newSize = new Size(Size.Width, runningTotalHeight);
            Size = newSize;
        }

        private void UpdateLists()
        {
            incompleteDailiesList.Items.Clear();
            incompleteWeekliesList.Items.Clear();
            incompleteMonthliesList.Items.Clear();
            completeDailiesList.Items.Clear();
            completeWeekliesList.Items.Clear();
            completeMonthliesList.Items.Clear();

            List<string> incompleteDailies = PopulateListBox("dailies", false);
            List<string> incompleteWeeklies = PopulateListBox("weeklies", false);
            List<string> incompleteMonthlies = PopulateListBox("monthlies", false);
            List<string> completeDailies = PopulateListBox("dailies", true);
            List<string> completeWeeklies = PopulateListBox("weeklies", true);
            List<string> completeMonthlies = PopulateListBox("monthlies", true);

            incompleteDailies.Sort();
            incompleteWeeklies.Sort();
            incompleteMonthlies.Sort();
            completeDailies.Sort();
            completeWeeklies.Sort();
            completeMonthlies.Sort();

            FillBoxFromList(incompleteDailies, incompleteDailiesList);
            FillBoxFromList(incompleteWeeklies, incompleteWeekliesList);
            FillBoxFromList(incompleteMonthlies, incompleteMonthliesList);
            FillBoxFromList(completeDailies, completeDailiesList);
            FillBoxFromList(completeWeeklies, completeWeekliesList);
            FillBoxFromList(completeMonthlies, completeMonthliesList);
        }

        private void PushToConfigFile(List<string> newConfigFile)
        {
            string fullText = "";

            foreach (string line in newConfigFile)
            {
                if (line != "")
                {
                    fullText += line + Environment.NewLine;
                }
            }

            writeTextFile("config.txt", fullText);
        }

        private void writeTextFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }

        private void MoveItemToSection(string item, string section)
        {
            List<string> configFile = GetConfigFile();

            configFile.Remove(item);

            switch (section)
            {
                case "complete":
                    configFile.Insert(configFile.IndexOf("SECTION=INCOMPLETE"), item);
                    break;
                case "incomplete":
                    configFile.Add(item);
                    break;
                default:
                    Close();
                    break;
            }

            PushToConfigFile(configFile);
        }

        private void FillBoxFromList(List<string> text, ListBox control)
        {
            foreach (string line in text)
            {
                control.Items.Add(line);
            }
        }

        private List<string> GetConfigFile()
        {
            return GetWholeFile("config.txt");
        }

        private List<string> GetWholeFile(string filename)
        {
            List<string> results = new List<string>();
            StreamReader sr = new StreamReader(filename);

            using (sr)
            {
                while (sr.Peek() >= 0)
                {
                    results.Add(sr.ReadLine());
                }
            }

            return results;
        }

        private List<string> PopulateListBox(string type, bool complete)
        {
            List<string> results = new List<string>();
            List<string> fullList = new List<string>();
            List<string> configFile = GetConfigFile();

            switch (type)
            {
                case "dailies":
                    fullList = GetWholeFile("dailies.txt");
                    break;
                case "weeklies":
                    fullList = GetWholeFile("weeklies.txt");
                    break;
                case "monthlies":
                    fullList = GetWholeFile("monthlies.txt");
                    break;
                default:
                    Close();
                    break;
            }

            foreach (string item in fullList)
            {
                if (configFile.Contains(item))
                {
                    int dividerLine = 0;
                    int keywordLine = 0;

                    for (int i = 0; i < configFile.Count; i++)
                    {
                        if (configFile[i] == "SECTION=INCOMPLETE")
                        {
                            dividerLine = i;
                        }

                        if (configFile[i] == item)
                        {
                            keywordLine = i;
                        }
                    }

                    if (complete)
                    {
                        if (keywordLine < dividerLine)
                        {
                            results.Add(item);
                        }
                    }
                    else
                    {
                        if (keywordLine > dividerLine)
                        {
                            results.Add(item);
                        }
                    }
                }
            }

            return results;
        }

        #endregion

        #region event handlers

        private void incompleteDailiesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (incompleteDailiesList.SelectedItem != null)
            {
                MoveItemToSection((string)incompleteDailiesList.SelectedItem, "complete");
            }

            UpdateLists();
        }

        private void incompleteWeekliesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (incompleteWeekliesList.SelectedItem != null)
            {
                MoveItemToSection((string)incompleteWeekliesList.SelectedItem, "complete");
            }

            UpdateLists();
        }

        private void incompleteMonthliesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (incompleteMonthliesList.SelectedItem != null)
            {
                MoveItemToSection((string)incompleteMonthliesList.SelectedItem, "complete");
            }

            UpdateLists();
        }

        private void completeDailiesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (completeDailiesList.SelectedItem != null)
            {
                MoveItemToSection((string)completeDailiesList.SelectedItem, "incomplete");
            }

            UpdateLists();
        }

        private void completeWeekliesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (completeWeekliesList.SelectedItem != null)
            {
                MoveItemToSection((string)completeWeekliesList.SelectedItem, "incomplete");
            }

            UpdateLists();
        }

        private void completeMonthliesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (completeMonthliesList.SelectedItem != null)
            {
                MoveItemToSection((string)completeMonthliesList.SelectedItem, "incomplete");
            }

            UpdateLists();
        }

        private void incompleteDailiesButton_Click(object sender, EventArgs e)
        {
            foreach (string line in completeDailiesList.Items)
            {
                MoveItemToSection(line, "incomplete");
            }

            UpdateLists();
        }

        private void incompleteWeekliesButton_Click(object sender, EventArgs e)
        {
            foreach (string line in completeWeekliesList.Items)
            {
                MoveItemToSection(line, "incomplete");
            }

            UpdateLists();
        }

        private void incompleteMonthliesButton_Click(object sender, EventArgs e)
        {
            foreach (string line in completeMonthliesList.Items)
            {
                MoveItemToSection(line, "incomplete");
            }

            UpdateLists();
        }

        private void completeDailiesButton_Click(object sender, EventArgs e)
        {
            foreach (string line in incompleteDailiesList.Items)
            {
                MoveItemToSection(line, "complete");
            }

            UpdateLists();
        }

        private void completeWeekliesButton_Click(object sender, EventArgs e)
        {
            foreach (string line in incompleteWeekliesList.Items)
            {
                MoveItemToSection(line, "complete");
            }

            UpdateLists();
        }

        private void completeMonthliesButton_Click(object sender, EventArgs e)
        {
            foreach (string line in incompleteMonthliesList.Items)
            {
                MoveItemToSection(line, "complete");
            }

            UpdateLists();
        }

        private void configureDailiesMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(sender);
            form2.ShowDialog();
            UpdateLists();
        }

        private void configureWeekliesMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(sender);
            form2.ShowDialog();
            UpdateLists();
        }

        private void configureMonthliesMenuitem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(sender);
            form2.ShowDialog();
            UpdateLists();
        }
        
        private void dailyButton_Click(object sender, EventArgs e)
        {
            bool visibility = dailyPanel.Visible;

            if (visibility)
            {
                dailyPanel.Visible = false;
                dailyButton.Text = "DAILIES +";
            }
            else
            {
                dailyPanel.Visible = true;
                dailyButton.Text = "DAILIES -";
            }

            UpdateFormSize();
        }

        private void weeklyButton_Click(object sender, EventArgs e)
        {
            bool visibility = weeklyPanel.Visible;

            if (visibility)
            {
                weeklyPanel.Visible = false;
                weeklyButton.Text = "WEEKLIES +";
            }
            else
            {
                weeklyPanel.Visible = true;
                weeklyButton.Text = "WEEKLIES -";
            }

            UpdateFormSize();
        }

        private void monthlyButton_Click(object sender, EventArgs e)
        {
            bool visibility = monthlyPanel.Visible;

            if (visibility)
            {
                monthlyPanel.Visible = false;
                monthlyButton.Text = "MONTHLIES +";
            }
            else
            {
                monthlyPanel.Visible = true;
                monthlyButton.Text = "MONTHLIES -";
            }

            UpdateFormSize();
        }

        #endregion
    }
}
