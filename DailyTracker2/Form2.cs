using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DailyTracker2
{
    public partial class Form2 : Form
    {
        #region properties

        ConfigHandler Handler;
        RSTaskList currentList;
        string receivedSenderName;

        #endregion

        #region constructors

        public Form2(object sender, ConfigHandler Handler)
        {
            receivedSenderName = sender.ToString();
            this.Handler = Handler;

            InitializeComponent();
        }

        #endregion

        #region functions

        private void Form2_Load(object sender, EventArgs e)
        {
            Text = "Config";
            List<CheckBox> checkboxes = new List<CheckBox>();

            switch (receivedSenderName)
            {
                case "Configure Dailies":
                    currentList = Handler.Dailies; //checkboxes = new List<CheckBox>(GenerateCheckboxes(Handler.Dailies));
                    break;

                case "Configure Weeklies":
                    currentList = Handler.Weeklies; //checkboxes = new List<CheckBox>(GenerateCheckboxes(Handler.Weeklies));
                    break;

                case "Configure Monthlies":
                    currentList = Handler.Monthlies; //checkboxes = new List<CheckBox>(GenerateCheckboxes(Handler.Monthlies));
                    break;

                default:
                    Close();
                    break;
            }

            checkboxes = new List<CheckBox>(GenerateCheckboxes(currentList));
            foreach (CheckBox checkbox in checkboxes)
            {
                Controls.Add(checkbox);
            }
        }

        private List<CheckBox> GenerateCheckboxes(RSTaskList List)
        {
            List<CheckBox> Ret = new List<CheckBox>();
            for(int i = 0; i < List.Count; i++)
            {
                Ret.Add(new CheckBox
                {
                    AutoSize = true,
                    Location = new Point(13, 42 + (24 * i)),
                    Name = "checkBox" + (i + 1),
                    Size = new Size(80, 17),
                    TabIndex = 2,
                    Text = List[i].Name,
                    UseVisualStyleBackColor = true,
                    Checked = List[i].isEnabled
                });
            }
            return Ret;
        }

        private List<CheckBox> GenerateCheckboxes_StreamReader(StreamReader sr)
        {
            List<CheckBox> resultsList = new List<CheckBox>();
            int count = 0;

            while (sr.Peek() >= 0)
            {
                CheckBox checkBox1 = new CheckBox();
                checkBox1.AutoSize = true;
                checkBox1.Location = new Point(13, 42 + (24 * count));
                checkBox1.Name = "checkBox" + (count + 1);
                checkBox1.Size = new Size(80, 17);
                checkBox1.TabIndex = 2;
                checkBox1.Text = sr.ReadLine();
                checkBox1.UseVisualStyleBackColor = true;

                checkBox1.Checked = ReadConfig(checkBox1.Text);

                resultsList.Add(checkBox1);
                count++;
            }

            return resultsList;
        }
        private bool ReadConfig(string name)
        {
            StreamReader sr = new StreamReader("config.txt");
            bool found = false;

            using (sr)
            {
                while (sr.Peek() >= 0)
                {
                    if (name == sr.ReadLine())
                    {
                        found = true;
                    }
                }
            }

            return found;
        }

        private void WriteConfig()
        {
            CheckBox[] checkBoxes = Controls.OfType<CheckBox>().ToArray();
            for(int i = 0; i < checkBoxes.Length; i++)
            {
                currentList[i].isEnabled = checkBoxes[i].Checked;
            }
        }

        [Obsolete("This method is obsolete, please use WriteConfig.")]
        private void WriteConfig_Old()
        {
            List<string> checkedItems = new List<string>();
            List<string> uncheckedItems = new List<string>();

            foreach (object control in Controls)
            {
                CheckBox thisControl;

                if (control is CheckBox)
                {
                    thisControl = (CheckBox)control;

                    if (thisControl.Checked)
                    {
                        checkedItems.Add(thisControl.Text);
                    }
                    else
                    {
                        uncheckedItems.Add(thisControl.Text);
                    }
                }
            }

            StreamReader sr = new StreamReader("config.txt");
            List<string> streamResults = new List<string>();

            using (sr)
            {
                while (sr.Peek() >= 0)
                {
                    streamResults.Add(sr.ReadLine());
                }
            }

            foreach (string name in checkedItems)
            {
                if (!streamResults.Contains(name))
                {
                    streamResults.Add(name);
                }
            }

            foreach (string name in uncheckedItems)
            {
                if (streamResults.Contains(name))
                {
                    streamResults.Remove(name);
                }
            }

            StreamWriter sw = new StreamWriter("config.txt");

            using (sw)
            {
                foreach (string line in streamResults)
                {
                    sw.WriteLine(line);
                }
            }

        }

        #endregion

        #region event handlers

        private void saveButton_Click(object sender, EventArgs e)
        {
            WriteConfig();
            Handler.SaveMemory("Config.xml");
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
