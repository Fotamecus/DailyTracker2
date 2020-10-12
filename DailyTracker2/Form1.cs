using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DailyTracker2
{
    public partial class Form1 : Form
    {
        public ConfigHandler Handler;

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
            Handler = (ConfigHandler)GSMemoryLoader.LoadMemory("Config.xml", typeof(ConfigHandler));
            Handler.Init(this);
            Handler.ListsUpdated += (s, e1) => UpdateLists();
            ToolTip a = new ToolTip();
            a.SetToolTip(completeDailiesList, "Rawr!");
            UpdateFormSize();
            UpdateLists();
        }
        private void UpdateFormSize()
        {
            int runningTotalHeight = Height - ClientSize.Height; //Accounts for form border size

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
            basePanel.Controls.OfType<Panel>().SelectMany(x => x.Controls.OfType<ListBox>().ToList()).ToList().ForEach(x => x.Items.Clear());

            FillBoxFromList(Handler.Dailies.Where(x => !x.isCompleted && x.isEnabled).Select(x => x.Name).ToList(), incompleteDailiesList);
            FillBoxFromList(Handler.Dailies.Where(x => x.isCompleted && x.isEnabled).Select(x => x.Name).ToList(), completeDailiesList);
            FillBoxFromList(Handler.Weeklies.Where(x => !x.isCompleted && x.isEnabled).Select(x => x.Name).ToList(), incompleteWeekliesList);
            FillBoxFromList(Handler.Weeklies.Where(x => x.isCompleted && x.isEnabled).Select(x => x.Name).ToList(), completeWeekliesList);
            FillBoxFromList(Handler.Monthlies.Where(x => !x.isCompleted && x.isEnabled).Select(x => x.Name).ToList(), incompleteMonthliesList);
            FillBoxFromList(Handler.Monthlies.Where(x => x.isCompleted && x.isEnabled).Select(x => x.Name).ToList(), completeMonthliesList);

            Handler.SaveMemory("Config.xml");
        }
        [Obsolete("Method is deprecated, please use UpdateLists instead.")]
        private void UpdateLists_depricated()
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
        [Obsolete("This method is obsolete, please use ConfigHandler for this instead.")]
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
        private void List_DoubleClick(object sender, MouseEventArgs e)
        {
            RSTask task = Handler.GetTaskByName((sender as ListBox).SelectedItem.ToString());
            task.Complete(!task.isCompleted);
            UpdateLists();
        }


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
            Handler.Dailies.ForEach(x => x.Complete(false));
            UpdateLists();
        }

        private void incompleteWeekliesButton_Click(object sender, EventArgs e)
        {
            Handler.Weeklies.ForEach(x => x.Complete(false));
            UpdateLists();
        }

        private void incompleteMonthliesButton_Click(object sender, EventArgs e)
        {
            Handler.Monthlies.ForEach(x => x.Complete(false));
            UpdateLists();
        }

        private void completeDailiesButton_Click(object sender, EventArgs e)
        {
            Handler.Dailies.ForEach(x => x.Complete(true));
            UpdateLists();
        }

        private void completeWeekliesButton_Click(object sender, EventArgs e)
        {
            Handler.Weeklies.ForEach(x => x.Complete(true));
            UpdateLists();
        }

        private void completeMonthliesButton_Click(object sender, EventArgs e)
        {
            Handler.Monthlies.ForEach(x => x.Complete(true));
            UpdateLists();
        }

        private void ConfigMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(sender, Handler);
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
