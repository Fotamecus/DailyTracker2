namespace DailyTracker2
{
    partial class Form1
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
            this.basePanel = new System.Windows.Forms.Panel();
            this.monthlyPanel = new System.Windows.Forms.Panel();
            this.completeMonthliesList = new System.Windows.Forms.ListBox();
            this.incompleteMonthliesList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.completeMonthliesButton = new System.Windows.Forms.Button();
            this.incompleteMonthliesButton = new System.Windows.Forms.Button();
            this.monthlyButton = new System.Windows.Forms.Button();
            this.monthliesContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configureMonthliesMenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyPanel = new System.Windows.Forms.Panel();
            this.completeWeekliesList = new System.Windows.Forms.ListBox();
            this.incompleteWeekliesList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.completeWeekliesButton = new System.Windows.Forms.Button();
            this.incompleteWeekliesButton = new System.Windows.Forms.Button();
            this.weeklyButton = new System.Windows.Forms.Button();
            this.weekliesContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configureWeekliesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyPanel = new System.Windows.Forms.Panel();
            this.completeDailiesList = new System.Windows.Forms.ListBox();
            this.incompleteDailiesList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.completeDailiesButton = new System.Windows.Forms.Button();
            this.incompleteDailiesButton = new System.Windows.Forms.Button();
            this.dailyButton = new System.Windows.Forms.Button();
            this.dailiesContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.configureDailiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basePanel.SuspendLayout();
            this.monthlyPanel.SuspendLayout();
            this.monthliesContextStrip.SuspendLayout();
            this.weeklyPanel.SuspendLayout();
            this.weekliesContextStrip.SuspendLayout();
            this.dailyPanel.SuspendLayout();
            this.dailiesContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.AutoSize = true;
            this.basePanel.Controls.Add(this.monthlyPanel);
            this.basePanel.Controls.Add(this.monthlyButton);
            this.basePanel.Controls.Add(this.weeklyPanel);
            this.basePanel.Controls.Add(this.weeklyButton);
            this.basePanel.Controls.Add(this.dailyPanel);
            this.basePanel.Controls.Add(this.dailyButton);
            this.basePanel.Location = new System.Drawing.Point(0, 0);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(567, 667);
            this.basePanel.TabIndex = 7;
            // 
            // monthlyPanel
            // 
            this.monthlyPanel.Controls.Add(this.completeMonthliesList);
            this.monthlyPanel.Controls.Add(this.incompleteMonthliesList);
            this.monthlyPanel.Controls.Add(this.label8);
            this.monthlyPanel.Controls.Add(this.completeMonthliesButton);
            this.monthlyPanel.Controls.Add(this.incompleteMonthliesButton);
            this.monthlyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthlyPanel.Location = new System.Drawing.Point(0, 490);
            this.monthlyPanel.Name = "monthlyPanel";
            this.monthlyPanel.Size = new System.Drawing.Size(567, 177);
            this.monthlyPanel.TabIndex = 3;
            // 
            // completeMonthliesList
            // 
            this.completeMonthliesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.completeMonthliesList.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeMonthliesList.ForeColor = System.Drawing.Color.Green;
            this.completeMonthliesList.FormattingEnabled = true;
            this.completeMonthliesList.ItemHeight = 18;
            this.completeMonthliesList.Location = new System.Drawing.Point(297, 35);
            this.completeMonthliesList.Name = "completeMonthliesList";
            this.completeMonthliesList.Size = new System.Drawing.Size(267, 130);
            this.completeMonthliesList.TabIndex = 16;
            this.completeMonthliesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.completeMonthliesList_MouseDoubleClick);
            // 
            // incompleteMonthliesList
            // 
            this.incompleteMonthliesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incompleteMonthliesList.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incompleteMonthliesList.ForeColor = System.Drawing.Color.Crimson;
            this.incompleteMonthliesList.FormattingEnabled = true;
            this.incompleteMonthliesList.ItemHeight = 18;
            this.incompleteMonthliesList.Location = new System.Drawing.Point(3, 35);
            this.incompleteMonthliesList.Name = "incompleteMonthliesList";
            this.incompleteMonthliesList.Size = new System.Drawing.Size(280, 130);
            this.incompleteMonthliesList.TabIndex = 15;
            this.incompleteMonthliesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.incompleteMonthliesList_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(289, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(2, 177);
            this.label8.TabIndex = 12;
            // 
            // completeMonthliesButton
            // 
            this.completeMonthliesButton.Location = new System.Drawing.Point(289, 0);
            this.completeMonthliesButton.Name = "completeMonthliesButton";
            this.completeMonthliesButton.Size = new System.Drawing.Size(278, 29);
            this.completeMonthliesButton.TabIndex = 14;
            this.completeMonthliesButton.Text = "MARK ALL COMPLETE";
            this.completeMonthliesButton.UseVisualStyleBackColor = true;
            this.completeMonthliesButton.Click += new System.EventHandler(this.completeMonthliesButton_Click);
            // 
            // incompleteMonthliesButton
            // 
            this.incompleteMonthliesButton.Location = new System.Drawing.Point(0, 0);
            this.incompleteMonthliesButton.Name = "incompleteMonthliesButton";
            this.incompleteMonthliesButton.Size = new System.Drawing.Size(291, 29);
            this.incompleteMonthliesButton.TabIndex = 14;
            this.incompleteMonthliesButton.Text = "MARK ALL INCOMPLETE";
            this.incompleteMonthliesButton.UseVisualStyleBackColor = true;
            this.incompleteMonthliesButton.Click += new System.EventHandler(this.incompleteMonthliesButton_Click);
            // 
            // monthlyButton
            // 
            this.monthlyButton.ContextMenuStrip = this.monthliesContextStrip;
            this.monthlyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.monthlyButton.Font = new System.Drawing.Font("Narkisim", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlyButton.Location = new System.Drawing.Point(0, 448);
            this.monthlyButton.Name = "monthlyButton";
            this.monthlyButton.Size = new System.Drawing.Size(567, 42);
            this.monthlyButton.TabIndex = 4;
            this.monthlyButton.Text = "MONTHLIES +";
            this.monthlyButton.UseVisualStyleBackColor = true;
            this.monthlyButton.Click += new System.EventHandler(this.monthlyButton_Click);
            // 
            // monthliesContextStrip
            // 
            this.monthliesContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureMonthliesMenuitem});
            this.monthliesContextStrip.Name = "dailiesContextStrip";
            this.monthliesContextStrip.Size = new System.Drawing.Size(184, 26);
            // 
            // configureMonthliesMenuitem
            // 
            this.configureMonthliesMenuitem.Name = "configureMonthliesMenuitem";
            this.configureMonthliesMenuitem.Size = new System.Drawing.Size(183, 22);
            this.configureMonthliesMenuitem.Text = "Configure Monthlies";
            this.configureMonthliesMenuitem.Click += new System.EventHandler(this.configureMonthliesMenuitem_Click);
            // 
            // weeklyPanel
            // 
            this.weeklyPanel.Controls.Add(this.completeWeekliesList);
            this.weeklyPanel.Controls.Add(this.incompleteWeekliesList);
            this.weeklyPanel.Controls.Add(this.label7);
            this.weeklyPanel.Controls.Add(this.completeWeekliesButton);
            this.weeklyPanel.Controls.Add(this.incompleteWeekliesButton);
            this.weeklyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.weeklyPanel.Location = new System.Drawing.Point(0, 256);
            this.weeklyPanel.Name = "weeklyPanel";
            this.weeklyPanel.Size = new System.Drawing.Size(567, 192);
            this.weeklyPanel.TabIndex = 2;
            // 
            // completeWeekliesList
            // 
            this.completeWeekliesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.completeWeekliesList.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeWeekliesList.ForeColor = System.Drawing.Color.Green;
            this.completeWeekliesList.FormattingEnabled = true;
            this.completeWeekliesList.ItemHeight = 18;
            this.completeWeekliesList.Location = new System.Drawing.Point(297, 31);
            this.completeWeekliesList.Name = "completeWeekliesList";
            this.completeWeekliesList.Size = new System.Drawing.Size(267, 148);
            this.completeWeekliesList.TabIndex = 16;
            this.completeWeekliesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.completeWeekliesList_MouseDoubleClick);
            // 
            // incompleteWeekliesList
            // 
            this.incompleteWeekliesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incompleteWeekliesList.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incompleteWeekliesList.ForeColor = System.Drawing.Color.Crimson;
            this.incompleteWeekliesList.FormattingEnabled = true;
            this.incompleteWeekliesList.ItemHeight = 18;
            this.incompleteWeekliesList.Location = new System.Drawing.Point(3, 31);
            this.incompleteWeekliesList.Name = "incompleteWeekliesList";
            this.incompleteWeekliesList.Size = new System.Drawing.Size(280, 148);
            this.incompleteWeekliesList.TabIndex = 15;
            this.incompleteWeekliesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.incompleteWeekliesList_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(289, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(2, 192);
            this.label7.TabIndex = 11;
            // 
            // completeWeekliesButton
            // 
            this.completeWeekliesButton.Location = new System.Drawing.Point(289, 0);
            this.completeWeekliesButton.Name = "completeWeekliesButton";
            this.completeWeekliesButton.Size = new System.Drawing.Size(278, 29);
            this.completeWeekliesButton.TabIndex = 13;
            this.completeWeekliesButton.Text = "MARK ALL COMPLETE";
            this.completeWeekliesButton.UseVisualStyleBackColor = true;
            this.completeWeekliesButton.Click += new System.EventHandler(this.completeWeekliesButton_Click);
            // 
            // incompleteWeekliesButton
            // 
            this.incompleteWeekliesButton.Location = new System.Drawing.Point(0, 0);
            this.incompleteWeekliesButton.Name = "incompleteWeekliesButton";
            this.incompleteWeekliesButton.Size = new System.Drawing.Size(291, 29);
            this.incompleteWeekliesButton.TabIndex = 13;
            this.incompleteWeekliesButton.Text = "MARK ALL INCOMPLETE";
            this.incompleteWeekliesButton.UseVisualStyleBackColor = true;
            this.incompleteWeekliesButton.Click += new System.EventHandler(this.incompleteWeekliesButton_Click);
            // 
            // weeklyButton
            // 
            this.weeklyButton.ContextMenuStrip = this.weekliesContextStrip;
            this.weeklyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.weeklyButton.Font = new System.Drawing.Font("Narkisim", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weeklyButton.Location = new System.Drawing.Point(0, 214);
            this.weeklyButton.Name = "weeklyButton";
            this.weeklyButton.Size = new System.Drawing.Size(567, 42);
            this.weeklyButton.TabIndex = 2;
            this.weeklyButton.Text = "WEEKLIES +";
            this.weeklyButton.UseVisualStyleBackColor = true;
            this.weeklyButton.Click += new System.EventHandler(this.weeklyButton_Click);
            // 
            // weekliesContextStrip
            // 
            this.weekliesContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureWeekliesMenuItem});
            this.weekliesContextStrip.Name = "dailiesContextStrip";
            this.weekliesContextStrip.Size = new System.Drawing.Size(177, 26);
            // 
            // configureWeekliesMenuItem
            // 
            this.configureWeekliesMenuItem.Name = "configureWeekliesMenuItem";
            this.configureWeekliesMenuItem.Size = new System.Drawing.Size(176, 22);
            this.configureWeekliesMenuItem.Text = "Configure Weeklies";
            this.configureWeekliesMenuItem.Click += new System.EventHandler(this.configureWeekliesMenuItem_Click);
            // 
            // dailyPanel
            // 
            this.dailyPanel.Controls.Add(this.completeDailiesList);
            this.dailyPanel.Controls.Add(this.incompleteDailiesList);
            this.dailyPanel.Controls.Add(this.label6);
            this.dailyPanel.Controls.Add(this.completeDailiesButton);
            this.dailyPanel.Controls.Add(this.incompleteDailiesButton);
            this.dailyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dailyPanel.Location = new System.Drawing.Point(0, 42);
            this.dailyPanel.Name = "dailyPanel";
            this.dailyPanel.Size = new System.Drawing.Size(567, 172);
            this.dailyPanel.TabIndex = 1;
            // 
            // completeDailiesList
            // 
            this.completeDailiesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.completeDailiesList.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeDailiesList.ForeColor = System.Drawing.Color.Green;
            this.completeDailiesList.FormattingEnabled = true;
            this.completeDailiesList.ItemHeight = 18;
            this.completeDailiesList.Location = new System.Drawing.Point(297, 32);
            this.completeDailiesList.Name = "completeDailiesList";
            this.completeDailiesList.Size = new System.Drawing.Size(267, 130);
            this.completeDailiesList.TabIndex = 14;
            this.completeDailiesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.completeDailiesList_MouseDoubleClick);
            // 
            // incompleteDailiesList
            // 
            this.incompleteDailiesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.incompleteDailiesList.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incompleteDailiesList.ForeColor = System.Drawing.Color.Crimson;
            this.incompleteDailiesList.FormattingEnabled = true;
            this.incompleteDailiesList.ItemHeight = 18;
            this.incompleteDailiesList.Location = new System.Drawing.Point(3, 32);
            this.incompleteDailiesList.Name = "incompleteDailiesList";
            this.incompleteDailiesList.Size = new System.Drawing.Size(280, 130);
            this.incompleteDailiesList.TabIndex = 13;
            this.incompleteDailiesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.incompleteDailiesList_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(289, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(2, 172);
            this.label6.TabIndex = 10;
            // 
            // completeDailiesButton
            // 
            this.completeDailiesButton.Location = new System.Drawing.Point(289, 0);
            this.completeDailiesButton.Name = "completeDailiesButton";
            this.completeDailiesButton.Size = new System.Drawing.Size(278, 29);
            this.completeDailiesButton.TabIndex = 12;
            this.completeDailiesButton.Text = "MARK ALL COMPLETE";
            this.completeDailiesButton.UseVisualStyleBackColor = true;
            this.completeDailiesButton.Click += new System.EventHandler(this.completeDailiesButton_Click);
            // 
            // incompleteDailiesButton
            // 
            this.incompleteDailiesButton.Location = new System.Drawing.Point(0, 0);
            this.incompleteDailiesButton.Name = "incompleteDailiesButton";
            this.incompleteDailiesButton.Size = new System.Drawing.Size(291, 29);
            this.incompleteDailiesButton.TabIndex = 11;
            this.incompleteDailiesButton.Text = "MARK ALL INCOMPLETE";
            this.incompleteDailiesButton.UseVisualStyleBackColor = true;
            this.incompleteDailiesButton.Click += new System.EventHandler(this.incompleteDailiesButton_Click);
            // 
            // dailyButton
            // 
            this.dailyButton.ContextMenuStrip = this.dailiesContextStrip;
            this.dailyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dailyButton.Font = new System.Drawing.Font("Narkisim", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyButton.Location = new System.Drawing.Point(0, 0);
            this.dailyButton.Name = "dailyButton";
            this.dailyButton.Size = new System.Drawing.Size(567, 42);
            this.dailyButton.TabIndex = 0;
            this.dailyButton.Text = "DAILIES +";
            this.dailyButton.UseVisualStyleBackColor = true;
            this.dailyButton.Click += new System.EventHandler(this.dailyButton_Click);
            // 
            // dailiesContextStrip
            // 
            this.dailiesContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureDailiesMenuItem});
            this.dailiesContextStrip.Name = "dailiesContextStrip";
            this.dailiesContextStrip.Size = new System.Drawing.Size(165, 26);
            // 
            // configureDailiesMenuItem
            // 
            this.configureDailiesMenuItem.Name = "configureDailiesMenuItem";
            this.configureDailiesMenuItem.Size = new System.Drawing.Size(164, 22);
            this.configureDailiesMenuItem.Text = "Configure Dailies";
            this.configureDailiesMenuItem.Click += new System.EventHandler(this.configureDailiesMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 679);
            this.Controls.Add(this.basePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "DAILYTRACKER²";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.basePanel.ResumeLayout(false);
            this.monthlyPanel.ResumeLayout(false);
            this.monthliesContextStrip.ResumeLayout(false);
            this.weeklyPanel.ResumeLayout(false);
            this.weekliesContextStrip.ResumeLayout(false);
            this.dailyPanel.ResumeLayout(false);
            this.dailiesContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel basePanel;
        private System.Windows.Forms.Button dailyButton;
        private System.Windows.Forms.Panel monthlyPanel;
        private System.Windows.Forms.Button monthlyButton;
        private System.Windows.Forms.Panel weeklyPanel;
        private System.Windows.Forms.Button weeklyButton;
        private System.Windows.Forms.Panel dailyPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button completeDailiesButton;
        private System.Windows.Forms.Button incompleteDailiesButton;
        private System.Windows.Forms.Button completeMonthliesButton;
        private System.Windows.Forms.Button incompleteMonthliesButton;
        private System.Windows.Forms.Button completeWeekliesButton;
        private System.Windows.Forms.Button incompleteWeekliesButton;
        private System.Windows.Forms.ListBox completeDailiesList;
        private System.Windows.Forms.ListBox incompleteDailiesList;
        private System.Windows.Forms.ListBox completeMonthliesList;
        private System.Windows.Forms.ListBox incompleteMonthliesList;
        private System.Windows.Forms.ListBox completeWeekliesList;
        private System.Windows.Forms.ListBox incompleteWeekliesList;
        private System.Windows.Forms.ContextMenuStrip dailiesContextStrip;
        private System.Windows.Forms.ToolStripMenuItem configureDailiesMenuItem;
        private System.Windows.Forms.ContextMenuStrip weekliesContextStrip;
        private System.Windows.Forms.ToolStripMenuItem configureWeekliesMenuItem;
        private System.Windows.Forms.ContextMenuStrip monthliesContextStrip;
        private System.Windows.Forms.ToolStripMenuItem configureMonthliesMenuitem;
    }
}

