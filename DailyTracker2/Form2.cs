using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Windows.Forms;

namespace DailyTracker2
{
    public partial class Form2 : Form
    {
        #region properties

        string receivedSenderName;

        #endregion

        #region constructors

        public Form2(object sender)
        {
            receivedSenderName = sender.ToString();

            InitializeComponent();
        }

        #endregion

        #region functions

        private void UpdateFormSize()
        {
            int largestHeight = 42; // This works for some reason. Don't fuck with it.

            foreach (Control item in Controls)
            {
                if (item.Location.Y + item.Height + 42 > largestHeight)
                {
                    largestHeight = item.Location.Y + item.Height + 42;
                }
            }

            Size newSize = new Size(Size.Width, largestHeight);
            Size = newSize;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StreamReader sr;
            List<CheckBox> checkboxes = new List<CheckBox>();

            switch (receivedSenderName)
            {
                case "Configure Dailies":
                    sr = new StreamReader("dailies.txt");

                    using (sr)
                    {
                        checkboxes = new List<CheckBox>(GenerateCheckboxes(sr));
                    }
                    break;

                case "Configure Weeklies":
                    sr = new StreamReader("weeklies.txt");

                    using (sr)
                    {
                        checkboxes = new List<CheckBox>(GenerateCheckboxes(sr));
                    }
                    break;

                case "Configure Monthlies":
                    sr = new StreamReader("monthlies.txt");

                    using (sr)
                    {
                        checkboxes = new List<CheckBox>(GenerateCheckboxes(sr));
                    }
                    break;

                default:
                    Close();
                    break;
            }

            foreach (CheckBox checkbox in checkboxes)
            {
                Controls.Add(checkbox);
            }

            UpdateFormSize();
        }

        private List<CheckBox> GenerateCheckboxes(StreamReader sr)
        {
            List<CheckBox> resultsList = new List<CheckBox>();
            int count = 0;

            while (sr.Peek() >= 0)
            {
                CheckBox checkBox1 = new CheckBox
                {
                    AutoSize = true,
                    Location = new Point(13, 42 + (24 * count)),
                    Name = "checkBox" + (count + 1),
                    Size = new Size(80, 17),
                    TabIndex = 2,
                    Text = sr.ReadLine(),
                    UseVisualStyleBackColor = true
                };

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
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
