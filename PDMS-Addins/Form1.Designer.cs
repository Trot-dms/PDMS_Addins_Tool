namespace PDMS_Addins
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDMSFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPDMSfolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addNewAddin = new System.Windows.Forms.Button();
            this.addinsOffList = new System.Windows.Forms.ListBox();
            this.turnAddinOff = new System.Windows.Forms.Button();
            this.turnAddinOn = new System.Windows.Forms.Button();
            this.addinsOnList = new System.Windows.Forms.ListBox();
            this.addinsList = new System.Windows.Forms.CheckedListBox();
            this.modulesComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(467, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pDMSFolderToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // pDMSFolderToolStripMenuItem
            // 
            this.pDMSFolderToolStripMenuItem.Name = "pDMSFolderToolStripMenuItem";
            this.pDMSFolderToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.pDMSFolderToolStripMenuItem.Text = "PDMS folder";
            this.pDMSFolderToolStripMenuItem.Click += new System.EventHandler(this.pDMSFolderToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusPDMSfolder});
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(467, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "PDMS folder:";
            // 
            // statusPDMSfolder
            // 
            this.statusPDMSfolder.Name = "statusPDMSfolder";
            this.statusPDMSfolder.Size = new System.Drawing.Size(15, 17);
            this.statusPDMSfolder.Text = "./";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addNewAddin);
            this.panel1.Controls.Add(this.addinsOffList);
            this.panel1.Controls.Add(this.turnAddinOff);
            this.panel1.Controls.Add(this.turnAddinOn);
            this.panel1.Controls.Add(this.addinsOnList);
            this.panel1.Controls.Add(this.addinsList);
            this.panel1.Controls.Add(this.modulesComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 418);
            this.panel1.TabIndex = 2;
            // 
            // addNewAddin
            // 
            this.addNewAddin.Location = new System.Drawing.Point(284, 33);
            this.addNewAddin.Name = "addNewAddin";
            this.addNewAddin.Size = new System.Drawing.Size(33, 33);
            this.addNewAddin.TabIndex = 6;
            this.addNewAddin.Text = "+";
            this.addNewAddin.UseVisualStyleBackColor = true;
            // 
            // addinsOffList
            // 
            this.addinsOffList.FormattingEnabled = true;
            this.addinsOffList.Location = new System.Drawing.Point(323, 28);
            this.addinsOffList.Name = "addinsOffList";
            this.addinsOffList.Size = new System.Drawing.Size(120, 381);
            this.addinsOffList.TabIndex = 5;
            this.addinsOffList.SelectedIndexChanged += new System.EventHandler(this.addinsOffList_SelectedIndexChanged);
            this.addinsOffList.SizeChanged += new System.EventHandler(this.addinsOnList_SizeChanged);
            this.addinsOffList.DoubleClick += new System.EventHandler(this.turnAddinOff_Click);
            // 
            // turnAddinOff
            // 
            this.turnAddinOff.Location = new System.Drawing.Point(284, 211);
            this.turnAddinOff.Name = "turnAddinOff";
            this.turnAddinOff.Size = new System.Drawing.Size(33, 66);
            this.turnAddinOff.TabIndex = 4;
            this.turnAddinOff.Text = "<<";
            this.turnAddinOff.UseVisualStyleBackColor = true;
            this.turnAddinOff.Click += new System.EventHandler(this.turnAddinOff_Click);
            // 
            // turnAddinOn
            // 
            this.turnAddinOn.Location = new System.Drawing.Point(284, 139);
            this.turnAddinOn.Name = "turnAddinOn";
            this.turnAddinOn.Size = new System.Drawing.Size(33, 66);
            this.turnAddinOn.TabIndex = 3;
            this.turnAddinOn.Text = ">>";
            this.turnAddinOn.UseVisualStyleBackColor = true;
            this.turnAddinOn.Click += new System.EventHandler(this.turnAddinOn_Click);
            // 
            // addinsOnList
            // 
            this.addinsOnList.FormattingEnabled = true;
            this.addinsOnList.Location = new System.Drawing.Point(158, 28);
            this.addinsOnList.Name = "addinsOnList";
            this.addinsOnList.Size = new System.Drawing.Size(120, 381);
            this.addinsOnList.TabIndex = 2;
            this.addinsOnList.SizeChanged += new System.EventHandler(this.addinsOnList_SizeChanged);
            this.addinsOnList.DoubleClick += new System.EventHandler(this.turnAddinOn_Click);
            // 
            // addinsList
            // 
            this.addinsList.FormattingEnabled = true;
            this.addinsList.Location = new System.Drawing.Point(3, 30);
            this.addinsList.Name = "addinsList";
            this.addinsList.Size = new System.Drawing.Size(109, 379);
            this.addinsList.TabIndex = 1;
            this.addinsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.addinsList_ItemCheck);
            // 
            // modulesComboBox
            // 
            this.modulesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modulesComboBox.FormattingEnabled = true;
            this.modulesComboBox.Location = new System.Drawing.Point(158, 6);
            this.modulesComboBox.Name = "modulesComboBox";
            this.modulesComboBox.Size = new System.Drawing.Size(285, 21);
            this.modulesComboBox.TabIndex = 0;
            this.modulesComboBox.SelectedIndexChanged += new System.EventHandler(this.modulesComboBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 32);
            this.panel2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "PDMS Addins Manager Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDMSFolderToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusPDMSfolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox addinsList;
        private System.Windows.Forms.ComboBox modulesComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox addinsOffList;
        private System.Windows.Forms.Button turnAddinOff;
        private System.Windows.Forms.Button turnAddinOn;
        private System.Windows.Forms.ListBox addinsOnList;
        private System.Windows.Forms.Button addNewAddin;
    }
}

