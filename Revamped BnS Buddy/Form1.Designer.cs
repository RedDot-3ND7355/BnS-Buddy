using System;
using System.Threading;

namespace Revamped_BnS_Buddy
{
    unsafe partial class Form1
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
        [System.STAThread]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.Launcher = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel78 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox9 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel72 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel73 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel70 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel71 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox8 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel65 = new MetroFramework.Controls.MetroLabel();
            this.metroButton30 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.Settings = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage8 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel44 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroToggle4 = new MetroFramework.Controls.MetroToggle();
            this.metroButton19 = new MetroFramework.Controls.MetroButton();
            this.metroButton20 = new MetroFramework.Controls.MetroButton();
            this.metroButton18 = new MetroFramework.Controls.MetroButton();
            this.metroButton17 = new MetroFramework.Controls.MetroButton();
            this.metroButton16 = new MetroFramework.Controls.MetroButton();
            this.metroButton15 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel27 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel26 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroToggle3 = new MetroFramework.Controls.MetroToggle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroToggle5 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle2 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel28 = new MetroFramework.Controls.MetroLabel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.metroToggle12 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel35 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle13 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel36 = new MetroFramework.Controls.MetroLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroToggle6 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel29 = new MetroFramework.Controls.MetroLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.metroToggle9 = new MetroFramework.Controls.MetroToggle();
            this.metroToggle8 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel32 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel31 = new MetroFramework.Controls.MetroLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroToggle7 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel30 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage10 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.metroLabel95 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle25 = new MetroFramework.Controls.MetroToggle();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.metroLabel76 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel92 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle24 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel90 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel91 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle21 = new MetroFramework.Controls.MetroToggle();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.metroComboBox7 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel68 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel62 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel61 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle18 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel69 = new MetroFramework.Controls.MetroLabel();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.metroLabel67 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle20 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel60 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel59 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel57 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel58 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox6 = new MetroFramework.Controls.MetroComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.metroLabel56 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel54 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox5 = new MetroFramework.Controls.MetroComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.metroButton29 = new MetroFramework.Controls.MetroButton();
            this.metroButton31 = new MetroFramework.Controls.MetroButton();
            this.metroButton33 = new MetroFramework.Controls.MetroButton();
            this.metroLabel55 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox7 = new MetroFramework.Controls.MetroTextBox();
            this.metroToggle19 = new MetroFramework.Controls.MetroToggle();
            this.metroTabPage9 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton21 = new MetroFramework.Controls.MetroButton();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.metroButton24 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox5 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel46 = new MetroFramework.Controls.MetroLabel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.metroComboBox4 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel48 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle17 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel47 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel45 = new MetroFramework.Controls.MetroLabel();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.metroToggle16 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel43 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle14 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel41 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle15 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel42 = new MetroFramework.Controls.MetroLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.metroToggle11 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel34 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle10 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel33 = new MetroFramework.Controls.MetroLabel();
            this.Extras = new MetroFramework.Controls.MetroTabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.metroLabel75 = new MetroFramework.Controls.MetroLabel();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.metroLabel50 = new MetroFramework.Controls.MetroLabel();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroPanel8 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel84 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel85 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel86 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel87 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle23 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel88 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel89 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel7 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel82 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel83 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel81 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel77 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle22 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel74 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel51 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox8 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel80 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel79 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroComboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel37 = new MetroFramework.Controls.MetroLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel39 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.findCTRLFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findReplaceCTRLRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel40 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel38 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressBar2 = new MetroFramework.Controls.MetroProgressBar();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton11 = new MetroFramework.Controls.MetroButton();
            this.metroButton10 = new MetroFramework.Controls.MetroButton();
            this.metroButton9 = new MetroFramework.Controls.MetroButton();
            this.metroButton8 = new MetroFramework.Controls.MetroButton();
            this.Addons = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.metroRadioButton2 = new MetroFramework.Controls.MetroRadioButton();
            this.metroRadioButton1 = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel66 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel63 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel64 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel53 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox6 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton28 = new MetroFramework.Controls.MetroButton();
            this.metroButton27 = new MetroFramework.Controls.MetroButton();
            this.metroButton26 = new MetroFramework.Controls.MetroButton();
            this.metroButton25 = new MetroFramework.Controls.MetroButton();
            this.metroLabel52 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel49 = new MetroFramework.Controls.MetroLabel();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.Donators = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.About = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.metroButton12 = new MetroFramework.Controls.MetroButton();
            this.metroButton13 = new MetroFramework.Controls.MetroButton();
            this.metroButton14 = new MetroFramework.Controls.MetroButton();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroButton22 = new MetroFramework.Controls.MetroButton();
            this.metroButton23 = new MetroFramework.Controls.MetroButton();
            this.RegionCB = new MetroFramework.Controls.MetroComboBox();
            this.CClock = new System.Windows.Forms.Timer(this.components);
            this.metroTabControl1.SuspendLayout();
            this.Launcher.SuspendLayout();
            this.metroPanel6.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.Settings.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.metroTabPage10.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.metroTabPage9.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.Extras.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.metroPanel8.SuspendLayout();
            this.metroPanel7.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.Addons.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.Donators.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.About.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.Launcher);
            this.metroTabControl1.Controls.Add(this.Addons);
            this.metroTabControl1.Controls.Add(this.Settings);
            this.metroTabControl1.Controls.Add(this.Extras);
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.Donators);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.About);
            this.metroTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(695, 357);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_TabChanged);
            // 
            // Launcher
            // 
            this.Launcher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Launcher.Controls.Add(this.metroPanel6);
            this.Launcher.Controls.Add(this.metroLabel72);
            this.Launcher.Controls.Add(this.metroLabel73);
            this.Launcher.Controls.Add(this.metroLabel70);
            this.Launcher.Controls.Add(this.metroLabel71);
            this.Launcher.Controls.Add(this.metroComboBox8);
            this.Launcher.Controls.Add(this.metroLabel65);
            this.Launcher.Controls.Add(this.metroButton30);
            this.Launcher.Controls.Add(this.metroButton3);
            this.Launcher.Controls.Add(this.metroLabel18);
            this.Launcher.Controls.Add(this.metroToggle1);
            this.Launcher.Controls.Add(this.metroLabel22);
            this.Launcher.Controls.Add(this.metroLabel14);
            this.Launcher.Controls.Add(this.metroLabel13);
            this.Launcher.Controls.Add(this.metroLabel12);
            this.Launcher.Controls.Add(this.metroLabel11);
            this.Launcher.Controls.Add(this.metroLabel10);
            this.Launcher.Controls.Add(this.metroLabel6);
            this.Launcher.Controls.Add(this.metroLabel3);
            this.Launcher.Controls.Add(this.metroLabel5);
            this.Launcher.Controls.Add(this.metroLabel4);
            this.Launcher.Controls.Add(this.metroLabel2);
            this.Launcher.Controls.Add(this.metroButton2);
            this.Launcher.Controls.Add(this.metroProgressSpinner1);
            this.Launcher.Controls.Add(this.metroPanel1);
            this.Launcher.Controls.Add(this.metroTextBox1);
            this.Launcher.Controls.Add(this.metroLabel1);
            this.Launcher.Controls.Add(this.metroButton1);
            this.Launcher.HorizontalScrollbarBarColor = true;
            this.Launcher.HorizontalScrollbarSize = 1;
            this.Launcher.Location = new System.Drawing.Point(4, 35);
            this.Launcher.Name = "Launcher";
            this.Launcher.Size = new System.Drawing.Size(687, 318);
            this.Launcher.TabIndex = 0;
            this.Launcher.Text = "Launcher";
            this.Launcher.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Launcher.VerticalScrollbarBarColor = true;
            this.Launcher.VerticalScrollbarSize = 1;
            // 
            // metroPanel6
            // 
            this.metroPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.metroPanel6.Controls.Add(this.metroLabel78);
            this.metroPanel6.Controls.Add(this.metroComboBox9);
            this.metroPanel6.CustomBackground = true;
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(455, 221);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(229, 50);
            this.metroPanel6.TabIndex = 35;
            this.metroPanel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            this.metroPanel6.Visible = false;
            // 
            // metroLabel78
            // 
            this.metroLabel78.AutoSize = true;
            this.metroLabel78.CustomBackground = true;
            this.metroLabel78.Location = new System.Drawing.Point(81, 0);
            this.metroLabel78.Name = "metroLabel78";
            this.metroLabel78.Size = new System.Drawing.Size(68, 19);
            this.metroLabel78.TabIndex = 35;
            this.metroLabel78.Text = "Multiclient";
            this.metroLabel78.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox9
            // 
            this.metroComboBox9.FormattingEnabled = true;
            this.metroComboBox9.ItemHeight = 23;
            this.metroComboBox9.Items.AddRange(new object[] {
            "",
            "New Instance"});
            this.metroComboBox9.Location = new System.Drawing.Point(0, 21);
            this.metroComboBox9.Name = "metroComboBox9";
            this.metroComboBox9.Size = new System.Drawing.Size(229, 29);
            this.metroComboBox9.TabIndex = 34;
            this.metroComboBox9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox9.SelectedIndexChanged += new System.EventHandler(this.metroComboBox9_SelectedIndexChanged);
            // 
            // metroLabel72
            // 
            this.metroLabel72.AutoSize = true;
            this.metroLabel72.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel72.Location = new System.Drawing.Point(334, 233);
            this.metroLabel72.Name = "metroLabel72";
            this.metroLabel72.Size = new System.Drawing.Size(19, 25);
            this.metroLabel72.TabIndex = 33;
            this.metroLabel72.Text = "-";
            this.metroLabel72.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel72.UseStyleColors = true;
            this.metroLabel72.Visible = false;
            // 
            // metroLabel73
            // 
            this.metroLabel73.AutoSize = true;
            this.metroLabel73.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel73.Location = new System.Drawing.Point(277, 233);
            this.metroLabel73.Name = "metroLabel73";
            this.metroLabel73.Size = new System.Drawing.Size(51, 25);
            this.metroLabel73.TabIndex = 32;
            this.metroLabel73.Text = "GCD:";
            this.metroLabel73.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel73, "Estimation of what GCD Should be");
            this.metroLabel73.Visible = false;
            // 
            // metroLabel70
            // 
            this.metroLabel70.AutoSize = true;
            this.metroLabel70.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel70.Location = new System.Drawing.Point(204, 233);
            this.metroLabel70.Name = "metroLabel70";
            this.metroLabel70.Size = new System.Drawing.Size(19, 25);
            this.metroLabel70.TabIndex = 31;
            this.metroLabel70.Text = "-";
            this.metroLabel70.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel70.UseStyleColors = true;
            this.metroLabel70.Visible = false;
            // 
            // metroLabel71
            // 
            this.metroLabel71.AutoSize = true;
            this.metroLabel71.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel71.Location = new System.Drawing.Point(123, 233);
            this.metroLabel71.Name = "metroLabel71";
            this.metroLabel71.Size = new System.Drawing.Size(75, 25);
            this.metroLabel71.TabIndex = 30;
            this.metroLabel71.Text = "InGame:";
            this.metroLabel71.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel71, "Estimation of ingame ping");
            this.metroLabel71.Visible = false;
            // 
            // metroComboBox8
            // 
            this.metroComboBox8.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroComboBox8.FormattingEnabled = true;
            this.metroComboBox8.ItemHeight = 29;
            this.metroComboBox8.Items.AddRange(new object[] {
            "Live",
            "Test"});
            this.metroComboBox8.Location = new System.Drawing.Point(242, 195);
            this.metroComboBox8.Name = "metroComboBox8";
            this.metroComboBox8.Size = new System.Drawing.Size(106, 35);
            this.metroComboBox8.TabIndex = 29;
            this.metroComboBox8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox8.Visible = false;
            this.metroComboBox8.SelectedIndexChanged += new System.EventHandler(this.metroComboBox8_SelectedIndexChanged);
            // 
            // metroLabel65
            // 
            this.metroLabel65.AutoSize = true;
            this.metroLabel65.CustomForeColor = true;
            this.metroLabel65.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel65.ForeColor = System.Drawing.Color.Red;
            this.metroLabel65.Location = new System.Drawing.Point(254, 167);
            this.metroLabel65.Name = "metroLabel65";
            this.metroLabel65.Size = new System.Drawing.Size(186, 25);
            this.metroLabel65.TabIndex = 10;
            this.metroLabel65.Text = "MXM Conflict Detected";
            this.metroLabel65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel65.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel65.Visible = false;
            // 
            // metroButton30
            // 
            this.metroButton30.Location = new System.Drawing.Point(341, 277);
            this.metroButton30.Name = "metroButton30";
            this.metroButton30.Size = new System.Drawing.Size(115, 35);
            this.metroButton30.TabIndex = 28;
            this.metroButton30.Text = "Clean Memory";
            this.metroButton30.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton30, "Clean used memory before Playing!");
            this.metroButton30.Click += new System.EventHandler(this.metroButton30_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(242, 82);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(207, 44);
            this.metroButton3.TabIndex = 27;
            this.metroButton3.Text = "Click to Update";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.Visible = false;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel18.Location = new System.Drawing.Point(46, 3);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(151, 25);
            this.metroLabel18.TabIndex = 26;
            this.metroLabel18.Text = "Launcher Options:";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle1
            // 
            this.metroToggle1.Appearance = System.Windows.Forms.Appearance.Button;
            this.metroToggle1.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroToggle1.Enabled = false;
            this.metroToggle1.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle1.Location = new System.Drawing.Point(162, 285);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(96, 26);
            this.metroToggle1.TabIndex = 4;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle1.UseStyleColors = true;
            this.metroToggle1.UseVisualStyleBackColor = true;
            this.metroToggle1.Click += new System.EventHandler(this.metroToggle1_Click);
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel22.Location = new System.Drawing.Point(254, 139);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(12, 15);
            this.metroLabel22.TabIndex = 25;
            this.metroLabel22.Text = "-";
            this.metroLabel22.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel22.UseStyleColors = true;
            this.metroLabel22.Visible = false;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel14.Location = new System.Drawing.Point(309, 54);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(19, 25);
            this.metroLabel14.TabIndex = 23;
            this.metroLabel14.Text = "-";
            this.metroLabel14.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel14.UseStyleColors = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel13.Location = new System.Drawing.Point(242, 54);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(61, 25);
            this.metroLabel13.TabIndex = 22;
            this.metroLabel13.Text = "Status:";
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel12.Location = new System.Drawing.Point(154, 258);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(19, 25);
            this.metroLabel12.TabIndex = 20;
            this.metroLabel12.Text = "-";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel12.UseStyleColors = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel11.Location = new System.Drawing.Point(59, 233);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(19, 25);
            this.metroLabel11.TabIndex = 19;
            this.metroLabel11.Text = "-";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel11.UseStyleColors = true;
            this.metroLabel11.TextChanged += new System.EventHandler(this.metroLabel11_TextChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel10.Location = new System.Drawing.Point(3, 258);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(145, 25);
            this.metroLabel10.TabIndex = 18;
            this.metroLabel10.Text = "Connection State:";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(375, 29);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(19, 25);
            this.metroLabel6.TabIndex = 17;
            this.metroLabel6.Text = "-";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(319, 4);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(19, 25);
            this.metroLabel3.TabIndex = 16;
            this.metroLabel3.Text = "-";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(242, 29);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(127, 25);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Online Version:";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(3, 233);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(50, 25);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Ping:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(242, 4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 25);
            this.metroLabel2.TabIndex = 12;
            this.metroLabel2.Text = "Version:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton2
            // 
            this.metroButton2.Enabled = false;
            this.metroButton2.Location = new System.Drawing.Point(455, 277);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(115, 35);
            this.metroButton2.TabIndex = 11;
            this.metroButton2.Text = "Restore!";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton2, "Restore your client\'s config");
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(264, 285);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(26, 26);
            this.metroProgressSpinner1.TabIndex = 10;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressSpinner1.Visible = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.metroPanel1.Controls.Add(this.metroCheckBox3);
            this.metroPanel1.Controls.Add(this.metroLabel9);
            this.metroPanel1.Controls.Add(this.metroLabel8);
            this.metroPanel1.Controls.Add(this.metroComboBox2);
            this.metroPanel1.Controls.Add(this.metroComboBox1);
            this.metroPanel1.Controls.Add(this.metroCheckBox2);
            this.metroPanel1.Controls.Add(this.metroCheckBox1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 25);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(236, 205);
            this.metroPanel1.TabIndex = 9;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroCheckBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroCheckBox3.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroCheckBox3.Location = new System.Drawing.Point(0, 50);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(236, 25);
            this.metroCheckBox3.TabIndex = 26;
            this.metroCheckBox3.Text = "Use all Cores";
            this.metroCheckBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroCheckBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox3.UseVisualStyleBackColor = true;
            this.metroCheckBox3.Click += new System.EventHandler(this.metroCheckBox3_CheckedChanged);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(88, 143);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(60, 25);
            this.metroLabel9.TabIndex = 12;
            this.metroLabel9.Text = "Server";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(76, 76);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(87, 25);
            this.metroLabel8.TabIndex = 11;
            this.metroLabel8.Text = "Language";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 29;
            this.metroComboBox2.Items.AddRange(new object[] {
            "English",
            "French",
            "German",
            "Taiwan",
            "Japanese",
            "Korean"});
            this.metroComboBox2.Location = new System.Drawing.Point(0, 105);
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.Size = new System.Drawing.Size(236, 35);
            this.metroComboBox2.TabIndex = 10;
            this.metroComboBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox2.SelectedIndexChanged += new System.EventHandler(this.metroComboBox2_SelectedIndexChanged);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroComboBox1.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 29;
            this.metroComboBox1.Items.AddRange(new object[] {
            "North America",
            "Europe",
            "Taiwan",
            "Japanese",
            "Korean"});
            this.metroComboBox1.Location = new System.Drawing.Point(0, 170);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(236, 35);
            this.metroComboBox1.TabIndex = 9;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroCheckBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroCheckBox2.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroCheckBox2.Location = new System.Drawing.Point(0, 25);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(236, 25);
            this.metroCheckBox2.TabIndex = 8;
            this.metroCheckBox2.Text = "No Texture Streaming";
            this.metroCheckBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroCheckBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox2.UseVisualStyleBackColor = true;
            this.metroCheckBox2.CheckedChanged += new System.EventHandler(this.metroCheckBox2_CheckedChanged);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroCheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroCheckBox1.FontSize = MetroFramework.MetroLinkSize.Tall;
            this.metroCheckBox1.Location = new System.Drawing.Point(0, 0);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(236, 25);
            this.metroCheckBox1.TabIndex = 3;
            this.metroCheckBox1.Text = "Unattended";
            this.metroCheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseVisualStyleBackColor = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.Location = new System.Drawing.Point(455, 4);
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.ReadOnly = true;
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.metroTextBox1.Size = new System.Drawing.Size(229, 267);
            this.metroTextBox1.TabIndex = 7;
            this.metroTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(3, 284);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(154, 25);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Fix Loading Screen";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton1
            // 
            this.metroButton1.Enabled = false;
            this.metroButton1.Location = new System.Drawing.Point(569, 277);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(115, 35);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Patch!";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton1, "Patch! and/or Play!");
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.Transparent;
            this.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Settings.Controls.Add(this.metroTabControl2);
            this.Settings.HorizontalScrollbar = true;
            this.Settings.HorizontalScrollbarBarColor = true;
            this.Settings.Location = new System.Drawing.Point(4, 35);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(687, 318);
            this.Settings.TabIndex = 6;
            this.Settings.Text = "Settings";
            this.Settings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Settings.VerticalScrollbar = true;
            this.Settings.VerticalScrollbarBarColor = true;
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage8);
            this.metroTabControl2.Controls.Add(this.metroTabPage10);
            this.metroTabControl2.Controls.Add(this.metroTabPage9);
            this.metroTabControl2.Location = new System.Drawing.Point(0, 4);
            this.metroTabControl2.Multiline = true;
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 1;
            this.metroTabControl2.ShowToolTips = true;
            this.metroTabControl2.Size = new System.Drawing.Size(687, 319);
            this.metroTabControl2.TabIndex = 15;
            this.metroTabControl2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl2.SelectedIndexChanged += new System.EventHandler(this.metroTabControl2_SelectedIndexChanged);
            // 
            // metroTabPage8
            // 
            this.metroTabPage8.Controls.Add(this.metroLabel44);
            this.metroTabPage8.Controls.Add(this.groupBox1);
            this.metroTabPage8.Controls.Add(this.groupBox2);
            this.metroTabPage8.Controls.Add(this.groupBox7);
            this.metroTabPage8.Controls.Add(this.groupBox3);
            this.metroTabPage8.Controls.Add(this.groupBox5);
            this.metroTabPage8.Controls.Add(this.groupBox4);
            this.metroTabPage8.HorizontalScrollbarBarColor = true;
            this.metroTabPage8.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage8.Name = "metroTabPage8";
            this.metroTabPage8.Size = new System.Drawing.Size(192, 61);
            this.metroTabPage8.TabIndex = 0;
            this.metroTabPage8.Text = "Page 1";
            this.metroTabPage8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage8.VerticalScrollbarBarColor = true;
            // 
            // metroLabel44
            // 
            this.metroLabel44.Location = new System.Drawing.Point(0, 225);
            this.metroLabel44.Name = "metroLabel44";
            this.metroLabel44.Size = new System.Drawing.Size(196, 54);
            this.metroLabel44.TabIndex = 14;
            this.metroLabel44.Text = "Notice: Some settings are \r\nnot applied until next restart.";
            this.metroLabel44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel44.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel44.UseStyleColors = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.metroToggle4);
            this.groupBox1.Controls.Add(this.metroButton19);
            this.groupBox1.Controls.Add(this.metroButton20);
            this.groupBox1.Controls.Add(this.metroButton18);
            this.groupBox1.Controls.Add(this.metroButton17);
            this.groupBox1.Controls.Add(this.metroButton16);
            this.groupBox1.Controls.Add(this.metroButton15);
            this.groupBox1.Controls.Add(this.metroTextBox4);
            this.groupBox1.Controls.Add(this.metroLabel27);
            this.groupBox1.Controls.Add(this.metroLabel26);
            this.groupBox1.Controls.Add(this.metroTextBox3);
            this.groupBox1.Controls.Add(this.metroToggle3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 138);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path Settings";
            // 
            // metroToggle4
            // 
            this.metroToggle4.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle4.Location = new System.Drawing.Point(182, 74);
            this.metroToggle4.Name = "metroToggle4";
            this.metroToggle4.Size = new System.Drawing.Size(104, 25);
            this.metroToggle4.TabIndex = 8;
            this.metroToggle4.Text = "Off";
            this.metroToggle4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle4.UseStyleColors = true;
            this.metroToggle4.UseVisualStyleBackColor = true;
            this.metroToggle4.Click += new System.EventHandler(this.metroToggle4_CheckedChanged);
            // 
            // metroButton19
            // 
            this.metroButton19.Enabled = false;
            this.metroButton19.Location = new System.Drawing.Point(346, 74);
            this.metroButton19.Name = "metroButton19";
            this.metroButton19.Size = new System.Drawing.Size(67, 25);
            this.metroButton19.TabIndex = 11;
            this.metroButton19.Text = "Browse";
            this.metroButton19.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton19.Click += new System.EventHandler(this.metroButton19_Click);
            // 
            // metroButton20
            // 
            this.metroButton20.Enabled = false;
            this.metroButton20.Location = new System.Drawing.Point(346, 16);
            this.metroButton20.Name = "metroButton20";
            this.metroButton20.Size = new System.Drawing.Size(67, 25);
            this.metroButton20.TabIndex = 12;
            this.metroButton20.Text = "Browse";
            this.metroButton20.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton20.Click += new System.EventHandler(this.metroButton20_Click);
            // 
            // metroButton18
            // 
            this.metroButton18.Enabled = false;
            this.metroButton18.Location = new System.Drawing.Point(414, 74);
            this.metroButton18.Name = "metroButton18";
            this.metroButton18.Size = new System.Drawing.Size(54, 25);
            this.metroButton18.TabIndex = 10;
            this.metroButton18.Text = "Default";
            this.metroButton18.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton18.Click += new System.EventHandler(this.metroButton18_Click);
            // 
            // metroButton17
            // 
            this.metroButton17.Enabled = false;
            this.metroButton17.Location = new System.Drawing.Point(414, 16);
            this.metroButton17.Name = "metroButton17";
            this.metroButton17.Size = new System.Drawing.Size(54, 25);
            this.metroButton17.TabIndex = 10;
            this.metroButton17.Text = "Default";
            this.metroButton17.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton17.Click += new System.EventHandler(this.metroButton17_Click);
            // 
            // metroButton16
            // 
            this.metroButton16.Enabled = false;
            this.metroButton16.Location = new System.Drawing.Point(289, 74);
            this.metroButton16.Name = "metroButton16";
            this.metroButton16.Size = new System.Drawing.Size(56, 25);
            this.metroButton16.TabIndex = 10;
            this.metroButton16.Text = "Save";
            this.metroButton16.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton16.Click += new System.EventHandler(this.metroButton16_Click);
            // 
            // metroButton15
            // 
            this.metroButton15.Enabled = false;
            this.metroButton15.Location = new System.Drawing.Point(289, 16);
            this.metroButton15.Name = "metroButton15";
            this.metroButton15.Size = new System.Drawing.Size(56, 25);
            this.metroButton15.TabIndex = 9;
            this.metroButton15.Text = "Save";
            this.metroButton15.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton15.Click += new System.EventHandler(this.metroButton15_Click);
            // 
            // metroTextBox4
            // 
            this.metroTextBox4.Enabled = false;
            this.metroTextBox4.Location = new System.Drawing.Point(6, 104);
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.ReadOnly = true;
            this.metroTextBox4.Size = new System.Drawing.Size(462, 23);
            this.metroTextBox4.TabIndex = 8;
            this.metroTextBox4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel27
            // 
            this.metroLabel27.AutoSize = true;
            this.metroLabel27.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel27.Location = new System.Drawing.Point(6, 73);
            this.metroLabel27.Name = "metroLabel27";
            this.metroLabel27.Size = new System.Drawing.Size(183, 25);
            this.metroLabel27.TabIndex = 7;
            this.metroLabel27.Text = "Custom Launcher Path";
            this.metroLabel27.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel26
            // 
            this.metroLabel26.AutoSize = true;
            this.metroLabel26.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel26.Location = new System.Drawing.Point(6, 16);
            this.metroLabel26.Name = "metroLabel26";
            this.metroLabel26.Size = new System.Drawing.Size(156, 25);
            this.metroLabel26.TabIndex = 4;
            this.metroLabel26.Text = "Custom Client Path";
            this.metroLabel26.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox3
            // 
            this.metroTextBox3.Enabled = false;
            this.metroTextBox3.Location = new System.Drawing.Point(6, 46);
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.ReadOnly = true;
            this.metroTextBox3.Size = new System.Drawing.Size(462, 23);
            this.metroTextBox3.TabIndex = 6;
            this.metroTextBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle3
            // 
            this.metroToggle3.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle3.Location = new System.Drawing.Point(182, 16);
            this.metroToggle3.Name = "metroToggle3";
            this.metroToggle3.Size = new System.Drawing.Size(104, 25);
            this.metroToggle3.TabIndex = 5;
            this.metroToggle3.Text = "Off";
            this.metroToggle3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle3.UseStyleColors = true;
            this.metroToggle3.UseVisualStyleBackColor = true;
            this.metroToggle3.Click += new System.EventHandler(this.metroToggle3_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.metroToggle5);
            this.groupBox2.Controls.Add(this.metroLabel25);
            this.groupBox2.Controls.Add(this.metroToggle2);
            this.groupBox2.Controls.Add(this.metroLabel28);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(474, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logging Settings";
            // 
            // metroToggle5
            // 
            this.metroToggle5.Checked = true;
            this.metroToggle5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle5.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle5.Location = new System.Drawing.Point(101, 47);
            this.metroToggle5.Name = "metroToggle5";
            this.metroToggle5.Size = new System.Drawing.Size(95, 25);
            this.metroToggle5.TabIndex = 4;
            this.metroToggle5.Text = "On";
            this.metroToggle5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle5.UseStyleColors = true;
            this.metroToggle5.UseVisualStyleBackColor = true;
            this.metroToggle5.Click += new System.EventHandler(this.metroToggle5_CheckedChanged);
            // 
            // metroLabel25
            // 
            this.metroLabel25.AutoSize = true;
            this.metroLabel25.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel25.Location = new System.Drawing.Point(6, 16);
            this.metroLabel25.Name = "metroLabel25";
            this.metroLabel25.Size = new System.Drawing.Size(87, 25);
            this.metroLabel25.TabIndex = 3;
            this.metroLabel25.Text = "Save Logs";
            this.metroLabel25.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle2
            // 
            this.metroToggle2.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle2.Location = new System.Drawing.Point(101, 16);
            this.metroToggle2.Name = "metroToggle2";
            this.metroToggle2.Size = new System.Drawing.Size(95, 25);
            this.metroToggle2.TabIndex = 2;
            this.metroToggle2.Text = "Off";
            this.metroToggle2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle2.UseStyleColors = true;
            this.metroToggle2.UseVisualStyleBackColor = true;
            this.metroToggle2.Click += new System.EventHandler(this.metroToggle2_CheckedChanged);
            // 
            // metroLabel28
            // 
            this.metroLabel28.AutoSize = true;
            this.metroLabel28.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel28.Location = new System.Drawing.Point(6, 47);
            this.metroLabel28.Name = "metroLabel28";
            this.metroLabel28.Size = new System.Drawing.Size(93, 25);
            this.metroLabel28.TabIndex = 5;
            this.metroLabel28.Text = "Show Logs";
            this.metroLabel28.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.metroToggle12);
            this.groupBox7.Controls.Add(this.metroLabel35);
            this.groupBox7.Controls.Add(this.metroToggle13);
            this.groupBox7.Controls.Add(this.metroLabel36);
            this.groupBox7.Enabled = false;
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(0, 143);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(196, 79);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Advanced Logging";
            // 
            // metroToggle12
            // 
            this.metroToggle12.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle12.Location = new System.Drawing.Point(93, 47);
            this.metroToggle12.Name = "metroToggle12";
            this.metroToggle12.Size = new System.Drawing.Size(95, 25);
            this.metroToggle12.TabIndex = 4;
            this.metroToggle12.Text = "Off";
            this.metroToggle12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle12.UseStyleColors = true;
            this.metroToggle12.UseVisualStyleBackColor = true;
            this.metroToggle12.Click += new System.EventHandler(this.metroToggle12_CheckedChanged);
            // 
            // metroLabel35
            // 
            this.metroLabel35.AutoSize = true;
            this.metroLabel35.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel35.Location = new System.Drawing.Point(6, 16);
            this.metroLabel35.Name = "metroLabel35";
            this.metroLabel35.Size = new System.Drawing.Size(82, 25);
            this.metroLabel35.TabIndex = 3;
            this.metroLabel35.Text = "Launcher";
            this.metroLabel35.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle13
            // 
            this.metroToggle13.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle13.Location = new System.Drawing.Point(93, 16);
            this.metroToggle13.Name = "metroToggle13";
            this.metroToggle13.Size = new System.Drawing.Size(95, 25);
            this.metroToggle13.TabIndex = 2;
            this.metroToggle13.Text = "Off";
            this.metroToggle13.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle13.UseStyleColors = true;
            this.metroToggle13.UseVisualStyleBackColor = true;
            this.metroToggle13.Click += new System.EventHandler(this.metroToggle13_CheckedChanged);
            // 
            // metroLabel36
            // 
            this.metroLabel36.AutoSize = true;
            this.metroLabel36.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel36.Location = new System.Drawing.Point(6, 47);
            this.metroLabel36.Name = "metroLabel36";
            this.metroLabel36.Size = new System.Drawing.Size(81, 25);
            this.metroLabel36.TabIndex = 5;
            this.metroLabel36.Text = "ModMan";
            this.metroLabel36.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel36, "Mod Manager");
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.metroToggle6);
            this.groupBox3.Controls.Add(this.metroLabel29);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(200, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 51);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ToolTip Settings";
            // 
            // metroToggle6
            // 
            this.metroToggle6.Checked = true;
            this.metroToggle6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle6.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle6.Location = new System.Drawing.Point(375, 16);
            this.metroToggle6.Name = "metroToggle6";
            this.metroToggle6.Size = new System.Drawing.Size(95, 25);
            this.metroToggle6.TabIndex = 10;
            this.metroToggle6.Text = "On";
            this.metroToggle6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle6.UseStyleColors = true;
            this.metroToggle6.UseVisualStyleBackColor = true;
            this.metroToggle6.Click += new System.EventHandler(this.metroToggle6_CheckedChanged);
            // 
            // metroLabel29
            // 
            this.metroLabel29.AutoSize = true;
            this.metroLabel29.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel29.Location = new System.Drawing.Point(6, 16);
            this.metroLabel29.Name = "metroLabel29";
            this.metroLabel29.Size = new System.Drawing.Size(185, 25);
            this.metroLabel29.TabIndex = 11;
            this.metroLabel29.Text = "Show ToolTips for hints";
            this.metroLabel29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel29.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.metroToggle9);
            this.groupBox5.Controls.Add(this.metroToggle8);
            this.groupBox5.Controls.Add(this.metroLabel32);
            this.groupBox5.Controls.Add(this.metroLabel31);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(200, 199);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(476, 80);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Application Settings";
            // 
            // metroToggle9
            // 
            this.metroToggle9.Checked = true;
            this.metroToggle9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle9.Enabled = false;
            this.metroToggle9.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle9.Location = new System.Drawing.Point(373, 47);
            this.metroToggle9.Name = "metroToggle9";
            this.metroToggle9.Size = new System.Drawing.Size(95, 25);
            this.metroToggle9.TabIndex = 12;
            this.metroToggle9.Text = "On";
            this.metroToggle9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle9.UseStyleColors = true;
            this.metroToggle9.UseVisualStyleBackColor = true;
            this.metroToggle9.Click += new System.EventHandler(this.metroToggle9_CheckedChanged);
            // 
            // metroToggle8
            // 
            this.metroToggle8.Checked = true;
            this.metroToggle8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle8.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle8.Location = new System.Drawing.Point(373, 16);
            this.metroToggle8.Name = "metroToggle8";
            this.metroToggle8.Size = new System.Drawing.Size(95, 25);
            this.metroToggle8.TabIndex = 10;
            this.metroToggle8.Text = "On";
            this.metroToggle8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle8.UseStyleColors = true;
            this.metroToggle8.UseVisualStyleBackColor = true;
            this.metroToggle8.Click += new System.EventHandler(this.metroToggle8_CheckedChanged);
            // 
            // metroLabel32
            // 
            this.metroLabel32.AutoSize = true;
            this.metroLabel32.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel32.Location = new System.Drawing.Point(6, 47);
            this.metroLabel32.Name = "metroLabel32";
            this.metroLabel32.Size = new System.Drawing.Size(288, 25);
            this.metroLabel32.TabIndex = 13;
            this.metroLabel32.Text = "NCSoft Game Login (NA/EU/TW/KR)";
            this.metroLabel32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel32.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel31
            // 
            this.metroLabel31.AutoSize = true;
            this.metroLabel31.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel31.Location = new System.Drawing.Point(6, 16);
            this.metroLabel31.Name = "metroLabel31";
            this.metroLabel31.Size = new System.Drawing.Size(263, 25);
            this.metroLabel31.TabIndex = 11;
            this.metroLabel31.Text = "Admin Application Startup Check";
            this.metroLabel31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel31.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.metroToggle7);
            this.groupBox4.Controls.Add(this.metroLabel30);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(474, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 53);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Launcher Settings";
            // 
            // metroToggle7
            // 
            this.metroToggle7.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle7.Location = new System.Drawing.Point(101, 16);
            this.metroToggle7.Name = "metroToggle7";
            this.metroToggle7.Size = new System.Drawing.Size(95, 25);
            this.metroToggle7.TabIndex = 10;
            this.metroToggle7.Text = "Off";
            this.metroToggle7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle7.UseStyleColors = true;
            this.metroToggle7.UseVisualStyleBackColor = true;
            this.metroToggle7.Click += new System.EventHandler(this.metroToggle7_CheckedChanged);
            // 
            // metroLabel30
            // 
            this.metroLabel30.AutoSize = true;
            this.metroLabel30.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel30.Location = new System.Drawing.Point(6, 16);
            this.metroLabel30.Name = "metroLabel30";
            this.metroLabel30.Size = new System.Drawing.Size(79, 25);
            this.metroLabel30.TabIndex = 11;
            this.metroLabel30.Text = "Variables";
            this.metroLabel30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel30.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTabPage10
            // 
            this.metroTabPage10.Controls.Add(this.groupBox18);
            this.metroTabPage10.Controls.Add(this.groupBox17);
            this.metroTabPage10.Controls.Add(this.groupBox13);
            this.metroTabPage10.Controls.Add(this.groupBox12);
            this.metroTabPage10.Controls.Add(this.groupBox11);
            this.metroTabPage10.Controls.Add(this.groupBox10);
            this.metroTabPage10.HorizontalScrollbarBarColor = true;
            this.metroTabPage10.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage10.Name = "metroTabPage10";
            this.metroTabPage10.Size = new System.Drawing.Size(679, 280);
            this.metroTabPage10.TabIndex = 2;
            this.metroTabPage10.Text = "Page 3";
            this.metroTabPage10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage10.VerticalScrollbarBarColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.Transparent;
            this.groupBox18.Controls.Add(this.metroLabel95);
            this.groupBox18.Controls.Add(this.metroToggle25);
            this.groupBox18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox18.ForeColor = System.Drawing.Color.White;
            this.groupBox18.Location = new System.Drawing.Point(474, 114);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(202, 62);
            this.groupBox18.TabIndex = 13;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Login Settings";
            // 
            // metroLabel95
            // 
            this.metroLabel95.AutoSize = true;
            this.metroLabel95.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel95.Location = new System.Drawing.Point(3, 20);
            this.metroLabel95.Name = "metroLabel95";
            this.metroLabel95.Size = new System.Drawing.Size(95, 25);
            this.metroLabel95.TabIndex = 5;
            this.metroLabel95.Text = "Auto Login";
            this.metroLabel95.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle25
            // 
            this.metroToggle25.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle25.Location = new System.Drawing.Point(98, 20);
            this.metroToggle25.Name = "metroToggle25";
            this.metroToggle25.Size = new System.Drawing.Size(95, 25);
            this.metroToggle25.TabIndex = 3;
            this.metroToggle25.Text = "Off";
            this.metroToggle25.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle25.UseStyleColors = true;
            this.metroToggle25.UseVisualStyleBackColor = true;
            this.metroToggle25.Click += new System.EventHandler(this.metroToggle25_CheckedChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Transparent;
            this.groupBox17.Controls.Add(this.metroLabel76);
            this.groupBox17.Controls.Add(this.metroLabel92);
            this.groupBox17.Controls.Add(this.metroToggle24);
            this.groupBox17.Controls.Add(this.metroLabel90);
            this.groupBox17.Controls.Add(this.metroLabel91);
            this.groupBox17.Controls.Add(this.metroToggle21);
            this.groupBox17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox17.ForeColor = System.Drawing.Color.White;
            this.groupBox17.Location = new System.Drawing.Point(292, 84);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(176, 127);
            this.groupBox17.TabIndex = 12;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Ping Related";
            // 
            // metroLabel76
            // 
            this.metroLabel76.Location = new System.Drawing.Point(3, 95);
            this.metroLabel76.Name = "metroLabel76";
            this.metroLabel76.Size = new System.Drawing.Size(164, 23);
            this.metroLabel76.TabIndex = 9;
            this.metroLabel76.Text = "Shows Estimation of IGP";
            this.metroLabel76.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel76.UseStyleColors = true;
            // 
            // metroLabel92
            // 
            this.metroLabel92.AutoSize = true;
            this.metroLabel92.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel92.Location = new System.Drawing.Point(6, 70);
            this.metroLabel92.Name = "metroLabel92";
            this.metroLabel92.Size = new System.Drawing.Size(38, 25);
            this.metroLabel92.TabIndex = 8;
            this.metroLabel92.Text = "IGP";
            this.metroLabel92.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel92, "Ingame Ping");
            // 
            // metroToggle24
            // 
            this.metroToggle24.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle24.Location = new System.Drawing.Point(54, 73);
            this.metroToggle24.Name = "metroToggle24";
            this.metroToggle24.Size = new System.Drawing.Size(95, 19);
            this.metroToggle24.TabIndex = 7;
            this.metroToggle24.Text = "Off";
            this.metroToggle24.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle24.UseStyleColors = true;
            this.metroToggle24.UseVisualStyleBackColor = true;
            this.metroToggle24.Click += new System.EventHandler(this.metroToggle24_CheckedChanged);
            // 
            // metroLabel90
            // 
            this.metroLabel90.Location = new System.Drawing.Point(3, 47);
            this.metroLabel90.Name = "metroLabel90";
            this.metroLabel90.Size = new System.Drawing.Size(167, 23);
            this.metroLabel90.TabIndex = 6;
            this.metroLabel90.Text = "Shows Estimation of GCD";
            this.metroLabel90.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel90.UseStyleColors = true;
            // 
            // metroLabel91
            // 
            this.metroLabel91.AutoSize = true;
            this.metroLabel91.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel91.Location = new System.Drawing.Point(3, 20);
            this.metroLabel91.Name = "metroLabel91";
            this.metroLabel91.Size = new System.Drawing.Size(47, 25);
            this.metroLabel91.TabIndex = 5;
            this.metroLabel91.Text = "GCD";
            this.metroLabel91.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel91, "Global Cool Down");
            // 
            // metroToggle21
            // 
            this.metroToggle21.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle21.Location = new System.Drawing.Point(54, 22);
            this.metroToggle21.Name = "metroToggle21";
            this.metroToggle21.Size = new System.Drawing.Size(95, 19);
            this.metroToggle21.TabIndex = 3;
            this.metroToggle21.Text = "Off";
            this.metroToggle21.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle21.UseStyleColors = true;
            this.metroToggle21.UseVisualStyleBackColor = true;
            this.metroToggle21.Click += new System.EventHandler(this.metroToggle21_CheckedChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.Transparent;
            this.groupBox13.Controls.Add(this.metroComboBox7);
            this.groupBox13.Controls.Add(this.metroLabel68);
            this.groupBox13.Controls.Add(this.metroLabel62);
            this.groupBox13.Controls.Add(this.metroLabel61);
            this.groupBox13.Controls.Add(this.metroToggle18);
            this.groupBox13.Controls.Add(this.metroLabel69);
            this.groupBox13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox13.ForeColor = System.Drawing.Color.White;
            this.groupBox13.Location = new System.Drawing.Point(474, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(202, 105);
            this.groupBox13.TabIndex = 11;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Memory Settings";
            // 
            // metroComboBox7
            // 
            this.metroComboBox7.FormattingEnabled = true;
            this.metroComboBox7.ItemHeight = 23;
            this.metroComboBox7.Items.AddRange(new object[] {
            "OFF",
            "1",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60"});
            this.metroComboBox7.Location = new System.Drawing.Point(70, 70);
            this.metroComboBox7.Name = "metroComboBox7";
            this.metroComboBox7.Size = new System.Drawing.Size(79, 29);
            this.metroComboBox7.TabIndex = 8;
            this.metroComboBox7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox7.SelectedIndexChanged += new System.EventHandler(this.metroComboBox7_SelectedIndexChanged);
            // 
            // metroLabel68
            // 
            this.metroLabel68.AutoSize = true;
            this.metroLabel68.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel68.Location = new System.Drawing.Point(3, 70);
            this.metroLabel68.Name = "metroLabel68";
            this.metroLabel68.Size = new System.Drawing.Size(68, 25);
            this.metroLabel68.TabIndex = 7;
            this.metroLabel68.Text = "Interval";
            this.metroLabel68.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel68, "Repeats cleanup after every x minutes");
            // 
            // metroLabel62
            // 
            this.metroLabel62.Location = new System.Drawing.Point(9, 47);
            this.metroLabel62.Name = "metroLabel62";
            this.metroLabel62.Size = new System.Drawing.Size(186, 23);
            this.metroLabel62.TabIndex = 6;
            this.metroLabel62.Text = "Clean memory at game start";
            this.metroLabel62.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel62.UseStyleColors = true;
            // 
            // metroLabel61
            // 
            this.metroLabel61.AutoSize = true;
            this.metroLabel61.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel61.Location = new System.Drawing.Point(3, 20);
            this.metroLabel61.Name = "metroLabel61";
            this.metroLabel61.Size = new System.Drawing.Size(96, 25);
            this.metroLabel61.TabIndex = 5;
            this.metroLabel61.Text = "Auto Clean";
            this.metroLabel61.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle18
            // 
            this.metroToggle18.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle18.Location = new System.Drawing.Point(98, 20);
            this.metroToggle18.Name = "metroToggle18";
            this.metroToggle18.Size = new System.Drawing.Size(95, 25);
            this.metroToggle18.TabIndex = 3;
            this.metroToggle18.Text = "Off";
            this.metroToggle18.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle18.UseStyleColors = true;
            this.metroToggle18.UseVisualStyleBackColor = true;
            this.metroToggle18.CheckedChanged += new System.EventHandler(this.metroToggle18_CheckedChanged);
            // 
            // metroLabel69
            // 
            this.metroLabel69.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel69.Location = new System.Drawing.Point(149, 70);
            this.metroLabel69.Name = "metroLabel69";
            this.metroLabel69.Size = new System.Drawing.Size(43, 25);
            this.metroLabel69.TabIndex = 9;
            this.metroLabel69.Text = "min";
            this.metroLabel69.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel69, "minutes");
            // 
            // groupBox12
            // 
            this.groupBox12.BackColor = System.Drawing.Color.Transparent;
            this.groupBox12.Controls.Add(this.metroLabel67);
            this.groupBox12.Controls.Add(this.metroToggle20);
            this.groupBox12.Controls.Add(this.metroLabel60);
            this.groupBox12.Controls.Add(this.metroLabel59);
            this.groupBox12.Controls.Add(this.metroLabel57);
            this.groupBox12.Controls.Add(this.metroLabel58);
            this.groupBox12.Controls.Add(this.metroComboBox6);
            this.groupBox12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox12.ForeColor = System.Drawing.Color.White;
            this.groupBox12.Location = new System.Drawing.Point(0, 170);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(286, 107);
            this.groupBox12.TabIndex = 10;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Client Priority";
            // 
            // metroLabel67
            // 
            this.metroLabel67.AutoSize = true;
            this.metroLabel67.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel67.Location = new System.Drawing.Point(6, 72);
            this.metroLabel67.Name = "metroLabel67";
            this.metroLabel67.Size = new System.Drawing.Size(174, 25);
            this.metroLabel67.TabIndex = 6;
            this.metroLabel67.Text = "Boost Process Priority";
            this.metroLabel67.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel67, "When focused");
            // 
            // metroToggle20
            // 
            this.metroToggle20.Checked = true;
            this.metroToggle20.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle20.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle20.Location = new System.Drawing.Point(182, 72);
            this.metroToggle20.Name = "metroToggle20";
            this.metroToggle20.Size = new System.Drawing.Size(95, 25);
            this.metroToggle20.TabIndex = 5;
            this.metroToggle20.Text = "On";
            this.metroToggle20.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle20.UseStyleColors = true;
            this.metroToggle20.UseVisualStyleBackColor = true;
            this.metroToggle20.Click += new System.EventHandler(this.metroToggle20_CheckedChanged);
            // 
            // metroLabel60
            // 
            this.metroLabel60.Location = new System.Drawing.Point(169, 52);
            this.metroLabel60.Name = "metroLabel60";
            this.metroLabel60.Size = new System.Drawing.Size(111, 23);
            this.metroLabel60.TabIndex = 4;
            this.metroLabel60.Text = "-";
            this.metroLabel60.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel60.UseStyleColors = true;
            // 
            // metroLabel59
            // 
            this.metroLabel59.Location = new System.Drawing.Point(106, 52);
            this.metroLabel59.Name = "metroLabel59";
            this.metroLabel59.Size = new System.Drawing.Size(57, 23);
            this.metroLabel59.TabIndex = 3;
            this.metroLabel59.Text = "Priority:";
            this.metroLabel59.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel57
            // 
            this.metroLabel57.Location = new System.Drawing.Point(49, 52);
            this.metroLabel57.Name = "metroLabel57";
            this.metroLabel57.Size = new System.Drawing.Size(60, 23);
            this.metroLabel57.TabIndex = 2;
            this.metroLabel57.Text = "Closed";
            this.metroLabel57.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel57.UseStyleColors = true;
            // 
            // metroLabel58
            // 
            this.metroLabel58.AutoSize = true;
            this.metroLabel58.Location = new System.Drawing.Point(6, 52);
            this.metroLabel58.Name = "metroLabel58";
            this.metroLabel58.Size = new System.Drawing.Size(37, 19);
            this.metroLabel58.TabIndex = 1;
            this.metroLabel58.Text = "App:";
            this.metroLabel58.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox6
            // 
            this.metroComboBox6.FormattingEnabled = true;
            this.metroComboBox6.ItemHeight = 23;
            this.metroComboBox6.Items.AddRange(new object[] {
            "Realtime",
            "High",
            "Above normal",
            "Normal",
            "Below normal",
            "Low"});
            this.metroComboBox6.Location = new System.Drawing.Point(6, 20);
            this.metroComboBox6.Name = "metroComboBox6";
            this.metroComboBox6.Size = new System.Drawing.Size(274, 29);
            this.metroComboBox6.TabIndex = 0;
            this.metroComboBox6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox6.SelectedIndexChanged += new System.EventHandler(this.metroComboBox6_SelectedIndexChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.Color.Transparent;
            this.groupBox11.Controls.Add(this.metroLabel56);
            this.groupBox11.Controls.Add(this.metroLabel54);
            this.groupBox11.Controls.Add(this.metroComboBox5);
            this.groupBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox11.ForeColor = System.Drawing.Color.White;
            this.groupBox11.Location = new System.Drawing.Point(0, 84);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(286, 80);
            this.groupBox11.TabIndex = 9;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Default Language";
            // 
            // metroLabel56
            // 
            this.metroLabel56.Location = new System.Drawing.Point(38, 52);
            this.metroLabel56.Name = "metroLabel56";
            this.metroLabel56.Size = new System.Drawing.Size(242, 23);
            this.metroLabel56.TabIndex = 2;
            this.metroLabel56.Text = "-";
            this.metroLabel56.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel56.UseStyleColors = true;
            // 
            // metroLabel54
            // 
            this.metroLabel54.AutoSize = true;
            this.metroLabel54.Location = new System.Drawing.Point(6, 52);
            this.metroLabel54.Name = "metroLabel54";
            this.metroLabel54.Size = new System.Drawing.Size(26, 19);
            this.metroLabel54.TabIndex = 1;
            this.metroLabel54.Text = "In: ";
            this.metroLabel54.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox5
            // 
            this.metroComboBox5.FormattingEnabled = true;
            this.metroComboBox5.ItemHeight = 23;
            this.metroComboBox5.Location = new System.Drawing.Point(6, 20);
            this.metroComboBox5.Name = "metroComboBox5";
            this.metroComboBox5.Size = new System.Drawing.Size(274, 29);
            this.metroComboBox5.TabIndex = 0;
            this.metroComboBox5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox5.SelectedIndexChanged += new System.EventHandler(this.metroComboBox5_SelectedIndexChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.Color.Transparent;
            this.groupBox10.Controls.Add(this.metroButton29);
            this.groupBox10.Controls.Add(this.metroButton31);
            this.groupBox10.Controls.Add(this.metroButton33);
            this.groupBox10.Controls.Add(this.metroLabel55);
            this.groupBox10.Controls.Add(this.metroTextBox7);
            this.groupBox10.Controls.Add(this.metroToggle19);
            this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox10.ForeColor = System.Drawing.Color.White;
            this.groupBox10.Location = new System.Drawing.Point(0, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(471, 75);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Mod Manager Path Settings";
            // 
            // metroButton29
            // 
            this.metroButton29.Enabled = false;
            this.metroButton29.Location = new System.Drawing.Point(346, 16);
            this.metroButton29.Name = "metroButton29";
            this.metroButton29.Size = new System.Drawing.Size(67, 25);
            this.metroButton29.TabIndex = 12;
            this.metroButton29.Text = "Browse";
            this.metroButton29.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton29.Click += new System.EventHandler(this.metroButton29_Click);
            // 
            // metroButton31
            // 
            this.metroButton31.Enabled = false;
            this.metroButton31.Location = new System.Drawing.Point(414, 16);
            this.metroButton31.Name = "metroButton31";
            this.metroButton31.Size = new System.Drawing.Size(54, 25);
            this.metroButton31.TabIndex = 10;
            this.metroButton31.Text = "Default";
            this.metroButton31.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton31.Click += new System.EventHandler(this.metroButton31_Click);
            // 
            // metroButton33
            // 
            this.metroButton33.Enabled = false;
            this.metroButton33.Location = new System.Drawing.Point(289, 16);
            this.metroButton33.Name = "metroButton33";
            this.metroButton33.Size = new System.Drawing.Size(56, 25);
            this.metroButton33.TabIndex = 9;
            this.metroButton33.Text = "Save";
            this.metroButton33.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton33.Click += new System.EventHandler(this.metroButton33_Click);
            // 
            // metroLabel55
            // 
            this.metroLabel55.AutoSize = true;
            this.metroLabel55.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel55.Location = new System.Drawing.Point(6, 16);
            this.metroLabel55.Name = "metroLabel55";
            this.metroLabel55.Size = new System.Drawing.Size(155, 25);
            this.metroLabel55.TabIndex = 4;
            this.metroLabel55.Text = "Custom Mods Path";
            this.metroLabel55.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox7
            // 
            this.metroTextBox7.Enabled = false;
            this.metroTextBox7.Location = new System.Drawing.Point(6, 46);
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.ReadOnly = true;
            this.metroTextBox7.Size = new System.Drawing.Size(462, 23);
            this.metroTextBox7.TabIndex = 6;
            this.metroTextBox7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle19
            // 
            this.metroToggle19.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle19.Location = new System.Drawing.Point(182, 16);
            this.metroToggle19.Name = "metroToggle19";
            this.metroToggle19.Size = new System.Drawing.Size(104, 25);
            this.metroToggle19.TabIndex = 5;
            this.metroToggle19.Text = "Off";
            this.metroToggle19.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle19.UseStyleColors = true;
            this.metroToggle19.UseVisualStyleBackColor = true;
            this.metroToggle19.CheckedChanged += new System.EventHandler(this.metroToggle19_CheckedChanged);
            // 
            // metroTabPage9
            // 
            this.metroTabPage9.Controls.Add(this.metroButton21);
            this.metroTabPage9.Controls.Add(this.groupBox9);
            this.metroTabPage9.Controls.Add(this.groupBox8);
            this.metroTabPage9.Controls.Add(this.groupBox6);
            this.metroTabPage9.HorizontalScrollbarBarColor = true;
            this.metroTabPage9.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage9.Name = "metroTabPage9";
            this.metroTabPage9.Size = new System.Drawing.Size(192, 61);
            this.metroTabPage9.TabIndex = 1;
            this.metroTabPage9.Text = "Page 2";
            this.metroTabPage9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage9.VerticalScrollbarBarColor = true;
            // 
            // metroButton21
            // 
            this.metroButton21.Location = new System.Drawing.Point(546, 7);
            this.metroButton21.Name = "metroButton21";
            this.metroButton21.Size = new System.Drawing.Size(127, 70);
            this.metroButton21.TabIndex = 15;
            this.metroButton21.Text = "Restore Settings";
            this.metroButton21.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.Transparent;
            this.groupBox9.Controls.Add(this.metroButton24);
            this.groupBox9.Controls.Add(this.metroTextBox5);
            this.groupBox9.Controls.Add(this.metroLabel46);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox9.ForeColor = System.Drawing.Color.White;
            this.groupBox9.Location = new System.Drawing.Point(0, 223);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(673, 53);
            this.groupBox9.TabIndex = 16;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Game Settings";
            // 
            // metroButton24
            // 
            this.metroButton24.Location = new System.Drawing.Point(603, 18);
            this.metroButton24.Name = "metroButton24";
            this.metroButton24.Size = new System.Drawing.Size(63, 23);
            this.metroButton24.TabIndex = 13;
            this.metroButton24.Text = "Save";
            this.metroButton24.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton24.Click += new System.EventHandler(this.metroButton24_Click);
            // 
            // metroTextBox5
            // 
            this.metroTextBox5.Location = new System.Drawing.Point(116, 18);
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.Size = new System.Drawing.Size(481, 23);
            this.metroTextBox5.TabIndex = 12;
            this.metroTextBox5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel46
            // 
            this.metroLabel46.AutoSize = true;
            this.metroLabel46.Cursor = System.Windows.Forms.Cursors.Help;
            this.metroLabel46.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel46.Location = new System.Drawing.Point(6, 16);
            this.metroLabel46.Name = "metroLabel46";
            this.metroLabel46.Size = new System.Drawing.Size(104, 25);
            this.metroLabel46.TabIndex = 11;
            this.metroLabel46.Text = "Arguements";
            this.metroLabel46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel46.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel46, "Click for reference");
            this.metroLabel46.UseStyleColors = true;
            this.metroLabel46.Click += new System.EventHandler(this.metroLabel46_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.metroComboBox4);
            this.groupBox8.Controls.Add(this.metroLabel20);
            this.groupBox8.Controls.Add(this.metroLabel48);
            this.groupBox8.Controls.Add(this.metroLabel21);
            this.groupBox8.Controls.Add(this.metroToggle17);
            this.groupBox8.Controls.Add(this.metroLabel19);
            this.groupBox8.Controls.Add(this.metroLabel47);
            this.groupBox8.Controls.Add(this.metroLabel45);
            this.groupBox8.Controls.Add(this.metroTrackBar1);
            this.groupBox8.Controls.Add(this.metroToggle16);
            this.groupBox8.Controls.Add(this.metroLabel43);
            this.groupBox8.Controls.Add(this.metroToggle14);
            this.groupBox8.Controls.Add(this.metroLabel41);
            this.groupBox8.Controls.Add(this.metroToggle15);
            this.groupBox8.Controls.Add(this.metroLabel42);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.ForeColor = System.Drawing.Color.White;
            this.groupBox8.Location = new System.Drawing.Point(0, 80);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(673, 137);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Startup";
            // 
            // metroComboBox4
            // 
            this.metroComboBox4.FormattingEnabled = true;
            this.metroComboBox4.ItemHeight = 23;
            this.metroComboBox4.Items.AddRange(new object[] {
            "32bit",
            "64bit"});
            this.metroComboBox4.Location = new System.Drawing.Point(420, 34);
            this.metroComboBox4.Name = "metroComboBox4";
            this.metroComboBox4.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox4.Sorted = true;
            this.metroComboBox4.TabIndex = 24;
            this.metroComboBox4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox4.SelectedIndexChanged += new System.EventHandler(this.metroComboBox4_SelectedIndexChanged);
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel20.Location = new System.Drawing.Point(287, 36);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(127, 25);
            this.metroLabel20.TabIndex = 23;
            this.metroLabel20.Text = "| Default Client:";
            this.metroLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel20.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel48
            // 
            this.metroLabel48.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel48.Location = new System.Drawing.Point(410, 12);
            this.metroLabel48.Name = "metroLabel48";
            this.metroLabel48.Size = new System.Drawing.Size(257, 22);
            this.metroLabel48.TabIndex = 22;
            this.metroLabel48.Text = "None";
            this.metroLabel48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel48.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel48, "Click here to clear default value");
            this.metroLabel48.UseStyleColors = true;
            this.metroLabel48.Click += new System.EventHandler(this.metroLabel48_Click);
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel21.Location = new System.Drawing.Point(287, 9);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(117, 25);
            this.metroLabel21.TabIndex = 21;
            this.metroLabel21.Text = "| Default Path:";
            this.metroLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel21.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel21, "This is used when multiple installations of BnS is found.");
            // 
            // metroToggle17
            // 
            this.metroToggle17.Checked = true;
            this.metroToggle17.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle17.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle17.Location = new System.Drawing.Point(571, 63);
            this.metroToggle17.Name = "metroToggle17";
            this.metroToggle17.Size = new System.Drawing.Size(95, 25);
            this.metroToggle17.TabIndex = 19;
            this.metroToggle17.Text = "On";
            this.metroToggle17.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle17.UseStyleColors = true;
            this.metroToggle17.UseVisualStyleBackColor = true;
            this.metroToggle17.Click += new System.EventHandler(this.metroToggle17_CheckedChanged);
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel19.Location = new System.Drawing.Point(287, 63);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(213, 25);
            this.metroLabel19.TabIndex = 20;
            this.metroLabel19.Text = "| Application Auto Updater";
            this.metroLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel19.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel47
            // 
            this.metroLabel47.AutoSize = true;
            this.metroLabel47.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel47.Location = new System.Drawing.Point(617, 96);
            this.metroLabel47.Name = "metroLabel47";
            this.metroLabel47.Size = new System.Drawing.Size(39, 25);
            this.metroLabel47.TabIndex = 18;
            this.metroLabel47.Text = "500";
            this.metroLabel47.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel47.UseStyleColors = true;
            // 
            // metroLabel45
            // 
            this.metroLabel45.AutoSize = true;
            this.metroLabel45.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel45.Location = new System.Drawing.Point(6, 95);
            this.metroLabel45.Name = "metroLabel45";
            this.metroLabel45.Size = new System.Drawing.Size(211, 25);
            this.metroLabel45.TabIndex = 17;
            this.metroLabel45.Text = "Ping Checker Refresh Rate";
            this.metroLabel45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel45.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(223, 97);
            this.metroTrackBar1.Maximum = 1000;
            this.metroTrackBar1.MouseWheelBarPartitions = 1;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(388, 23);
            this.metroTrackBar1.TabIndex = 16;
            this.metroTrackBar1.Text = "Refresh Rate";
            this.metroTrackBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBar1.Value = 500;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            // 
            // metroToggle16
            // 
            this.metroToggle16.Checked = true;
            this.metroToggle16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle16.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle16.Location = new System.Drawing.Point(186, 63);
            this.metroToggle16.Name = "metroToggle16";
            this.metroToggle16.Size = new System.Drawing.Size(95, 25);
            this.metroToggle16.TabIndex = 14;
            this.metroToggle16.Text = "On";
            this.metroToggle16.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle16.UseStyleColors = true;
            this.metroToggle16.UseVisualStyleBackColor = true;
            this.metroToggle16.CheckedChanged += new System.EventHandler(this.metroToggle16_CheckedChanged);
            // 
            // metroLabel43
            // 
            this.metroLabel43.AutoSize = true;
            this.metroLabel43.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel43.Location = new System.Drawing.Point(6, 63);
            this.metroLabel43.Name = "metroLabel43";
            this.metroLabel43.Size = new System.Drawing.Size(174, 25);
            this.metroLabel43.TabIndex = 15;
            this.metroLabel43.Text = "Online Update Check";
            this.metroLabel43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel43.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle14
            // 
            this.metroToggle14.Checked = true;
            this.metroToggle14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle14.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle14.Location = new System.Drawing.Point(186, 36);
            this.metroToggle14.Name = "metroToggle14";
            this.metroToggle14.Size = new System.Drawing.Size(95, 25);
            this.metroToggle14.TabIndex = 12;
            this.metroToggle14.Text = "On";
            this.metroToggle14.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle14.UseStyleColors = true;
            this.metroToggle14.UseVisualStyleBackColor = true;
            this.metroToggle14.CheckedChanged += new System.EventHandler(this.metroToggle14_CheckedChanged);
            // 
            // metroLabel41
            // 
            this.metroLabel41.AutoSize = true;
            this.metroLabel41.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel41.Location = new System.Drawing.Point(6, 38);
            this.metroLabel41.Name = "metroLabel41";
            this.metroLabel41.Size = new System.Drawing.Size(165, 25);
            this.metroLabel41.TabIndex = 13;
            this.metroLabel41.Text = "Server Ping Checker";
            this.metroLabel41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel41.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle15
            // 
            this.metroToggle15.Checked = true;
            this.metroToggle15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle15.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle15.Location = new System.Drawing.Point(186, 9);
            this.metroToggle15.Name = "metroToggle15";
            this.metroToggle15.Size = new System.Drawing.Size(95, 25);
            this.metroToggle15.TabIndex = 10;
            this.metroToggle15.Text = "On";
            this.metroToggle15.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle15.UseStyleColors = true;
            this.metroToggle15.UseVisualStyleBackColor = true;
            this.metroToggle15.CheckedChanged += new System.EventHandler(this.metroToggle15_CheckedChanged);
            // 
            // metroLabel42
            // 
            this.metroLabel42.AutoSize = true;
            this.metroLabel42.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel42.Location = new System.Drawing.Point(6, 13);
            this.metroLabel42.Name = "metroLabel42";
            this.metroLabel42.Size = new System.Drawing.Size(139, 25);
            this.metroLabel42.TabIndex = 11;
            this.metroLabel42.Text = "Auto Game Killer";
            this.metroLabel42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel42.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.metroToggle11);
            this.groupBox6.Controls.Add(this.metroLabel34);
            this.groupBox6.Controls.Add(this.metroToggle10);
            this.groupBox6.Controls.Add(this.metroLabel33);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(0, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(541, 74);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Miscs";
            // 
            // metroToggle11
            // 
            this.metroToggle11.Checked = true;
            this.metroToggle11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle11.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle11.Location = new System.Drawing.Point(438, 38);
            this.metroToggle11.Name = "metroToggle11";
            this.metroToggle11.Size = new System.Drawing.Size(95, 25);
            this.metroToggle11.TabIndex = 12;
            this.metroToggle11.Text = "On";
            this.metroToggle11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle11.UseStyleColors = true;
            this.metroToggle11.UseVisualStyleBackColor = true;
            this.metroToggle11.Click += new System.EventHandler(this.metroToggle11_CheckedChanged);
            // 
            // metroLabel34
            // 
            this.metroLabel34.AutoSize = true;
            this.metroLabel34.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel34.Location = new System.Drawing.Point(6, 38);
            this.metroLabel34.Name = "metroLabel34";
            this.metroLabel34.Size = new System.Drawing.Size(134, 25);
            this.metroLabel34.TabIndex = 13;
            this.metroLabel34.Text = "Minimize to tray";
            this.metroLabel34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel34.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle10
            // 
            this.metroToggle10.Checked = true;
            this.metroToggle10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle10.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle10.Location = new System.Drawing.Point(438, 13);
            this.metroToggle10.Name = "metroToggle10";
            this.metroToggle10.Size = new System.Drawing.Size(95, 25);
            this.metroToggle10.TabIndex = 10;
            this.metroToggle10.Text = "On";
            this.metroToggle10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle10.UseStyleColors = true;
            this.metroToggle10.UseVisualStyleBackColor = true;
            this.metroToggle10.Click += new System.EventHandler(this.metroToggle10_CheckedChanged);
            // 
            // metroLabel33
            // 
            this.metroLabel33.AutoSize = true;
            this.metroLabel33.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel33.Location = new System.Drawing.Point(6, 13);
            this.metroLabel33.Name = "metroLabel33";
            this.metroLabel33.Size = new System.Drawing.Size(218, 25);
            this.metroLabel33.TabIndex = 11;
            this.metroLabel33.Text = "Show Donate Button at Top";
            this.metroLabel33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel33.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Extras
            // 
            this.Extras.Controls.Add(this.groupBox16);
            this.Extras.Controls.Add(this.groupBox15);
            this.Extras.Controls.Add(this.groupBox14);
            this.Extras.HorizontalScrollbarBarColor = true;
            this.Extras.Location = new System.Drawing.Point(4, 35);
            this.Extras.Name = "Extras";
            this.Extras.Size = new System.Drawing.Size(687, 318);
            this.Extras.TabIndex = 8;
            this.Extras.Text = "Extras";
            this.Extras.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Extras.VerticalScrollbarBarColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.Transparent;
            this.groupBox16.Controls.Add(this.metroLabel75);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox16.ForeColor = System.Drawing.Color.White;
            this.groupBox16.Location = new System.Drawing.Point(281, 0);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(211, 318);
            this.groupBox16.TabIndex = 14;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Customization";
            // 
            // metroLabel75
            // 
            this.metroLabel75.AutoSize = true;
            this.metroLabel75.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel75.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel75.Location = new System.Drawing.Point(3, 18);
            this.metroLabel75.Name = "metroLabel75";
            this.metroLabel75.Size = new System.Drawing.Size(119, 25);
            this.metroLabel75.TabIndex = 17;
            this.metroLabel75.Text = "Coming soon!";
            this.metroLabel75.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.Transparent;
            this.groupBox15.Controls.Add(this.metroLabel50);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox15.ForeColor = System.Drawing.Color.White;
            this.groupBox15.Location = new System.Drawing.Point(492, 0);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(195, 318);
            this.groupBox15.TabIndex = 13;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Submissions";
            // 
            // metroLabel50
            // 
            this.metroLabel50.AutoSize = true;
            this.metroLabel50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel50.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel50.Location = new System.Drawing.Point(3, 18);
            this.metroLabel50.Name = "metroLabel50";
            this.metroLabel50.Size = new System.Drawing.Size(119, 25);
            this.metroLabel50.TabIndex = 17;
            this.metroLabel50.Text = "Coming soon!";
            this.metroLabel50.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.Transparent;
            this.groupBox14.Controls.Add(this.metroTile1);
            this.groupBox14.Controls.Add(this.metroPanel8);
            this.groupBox14.Controls.Add(this.metroPanel7);
            this.groupBox14.Controls.Add(this.metroTextBox8);
            this.groupBox14.Controls.Add(this.metroLabel80);
            this.groupBox14.Controls.Add(this.metroLabel79);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox14.ForeColor = System.Drawing.Color.White;
            this.groupBox14.Location = new System.Drawing.Point(0, 0);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(281, 318);
            this.groupBox14.TabIndex = 12;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Extra Features";
            // 
            // metroTile1
            // 
            this.metroTile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroTile1.CustomBackground = true;
            this.metroTile1.ForeColor = System.Drawing.Color.White;
            this.metroTile1.Location = new System.Drawing.Point(6, 17);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.PaintTileCount = false;
            this.metroTile1.Size = new System.Drawing.Size(269, 109);
            this.metroTile1.TabIndex = 19;
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel8
            // 
            this.metroPanel8.Controls.Add(this.metroLabel84);
            this.metroPanel8.Controls.Add(this.metroLabel85);
            this.metroPanel8.Controls.Add(this.metroLabel86);
            this.metroPanel8.Controls.Add(this.metroLabel87);
            this.metroPanel8.Controls.Add(this.metroToggle23);
            this.metroPanel8.Controls.Add(this.metroLabel88);
            this.metroPanel8.Controls.Add(this.metroLabel89);
            this.metroPanel8.HorizontalScrollbarBarColor = true;
            this.metroPanel8.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel8.HorizontalScrollbarSize = 10;
            this.metroPanel8.Location = new System.Drawing.Point(19, 21);
            this.metroPanel8.Name = "metroPanel8";
            this.metroPanel8.Size = new System.Drawing.Size(227, 105);
            this.metroPanel8.TabIndex = 25;
            this.metroPanel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel8.VerticalScrollbarBarColor = true;
            this.metroPanel8.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel8.VerticalScrollbarSize = 10;
            // 
            // metroLabel84
            // 
            this.metroLabel84.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel84.Location = new System.Drawing.Point(80, 76);
            this.metroLabel84.Name = "metroLabel84";
            this.metroLabel84.Size = new System.Drawing.Size(98, 25);
            this.metroLabel84.TabIndex = 23;
            this.metroLabel84.Text = "Inactive";
            this.metroLabel84.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel84.UseStyleColors = true;
            // 
            // metroLabel85
            // 
            this.metroLabel85.AutoSize = true;
            this.metroLabel85.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel85.Location = new System.Drawing.Point(21, 76);
            this.metroLabel85.Name = "metroLabel85";
            this.metroLabel85.Size = new System.Drawing.Size(54, 25);
            this.metroLabel85.TabIndex = 22;
            this.metroLabel85.Text = "64Bit:";
            this.metroLabel85.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel86
            // 
            this.metroLabel86.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel86.Location = new System.Drawing.Point(80, 51);
            this.metroLabel86.Name = "metroLabel86";
            this.metroLabel86.Size = new System.Drawing.Size(98, 25);
            this.metroLabel86.TabIndex = 21;
            this.metroLabel86.Text = "Inactive";
            this.metroLabel86.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel86.UseStyleColors = true;
            // 
            // metroLabel87
            // 
            this.metroLabel87.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel87.Location = new System.Drawing.Point(5, 31);
            this.metroLabel87.Name = "metroLabel87";
            this.metroLabel87.Size = new System.Drawing.Size(219, 23);
            this.metroLabel87.TabIndex = 9;
            this.metroLabel87.Text = "Boost\'s BnS by eliminating useless process";
            this.metroLabel87.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel87.UseStyleColors = true;
            // 
            // metroToggle23
            // 
            this.metroToggle23.Enabled = false;
            this.metroToggle23.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle23.Location = new System.Drawing.Point(109, 3);
            this.metroToggle23.Name = "metroToggle23";
            this.metroToggle23.Size = new System.Drawing.Size(110, 25);
            this.metroToggle23.TabIndex = 8;
            this.metroToggle23.Text = "Off";
            this.metroToggle23.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle23.UseStyleColors = true;
            this.metroToggle23.UseVisualStyleBackColor = true;
            // 
            // metroLabel88
            // 
            this.metroLabel88.AutoSize = true;
            this.metroLabel88.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel88.Location = new System.Drawing.Point(10, 3);
            this.metroLabel88.Name = "metroLabel88";
            this.metroLabel88.Size = new System.Drawing.Size(91, 25);
            this.metroLabel88.TabIndex = 7;
            this.metroLabel88.Text = "Perf. Boost";
            this.metroLabel88.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel89
            // 
            this.metroLabel89.AutoSize = true;
            this.metroLabel89.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel89.Location = new System.Drawing.Point(21, 51);
            this.metroLabel89.Name = "metroLabel89";
            this.metroLabel89.Size = new System.Drawing.Size(53, 25);
            this.metroLabel89.TabIndex = 20;
            this.metroLabel89.Text = "32Bit:";
            this.metroLabel89.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroPanel7
            // 
            this.metroPanel7.Controls.Add(this.metroLabel82);
            this.metroPanel7.Controls.Add(this.metroLabel83);
            this.metroPanel7.Controls.Add(this.metroLabel81);
            this.metroPanel7.Controls.Add(this.metroLabel77);
            this.metroPanel7.Controls.Add(this.metroToggle22);
            this.metroPanel7.Controls.Add(this.metroLabel74);
            this.metroPanel7.Controls.Add(this.metroLabel51);
            this.metroPanel7.HorizontalScrollbarBarColor = true;
            this.metroPanel7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel7.HorizontalScrollbarSize = 10;
            this.metroPanel7.Location = new System.Drawing.Point(19, 124);
            this.metroPanel7.Name = "metroPanel7";
            this.metroPanel7.Size = new System.Drawing.Size(227, 105);
            this.metroPanel7.TabIndex = 24;
            this.metroPanel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel7.VerticalScrollbarBarColor = true;
            this.metroPanel7.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel7.VerticalScrollbarSize = 10;
            // 
            // metroLabel82
            // 
            this.metroLabel82.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel82.Location = new System.Drawing.Point(80, 76);
            this.metroLabel82.Name = "metroLabel82";
            this.metroLabel82.Size = new System.Drawing.Size(98, 25);
            this.metroLabel82.TabIndex = 23;
            this.metroLabel82.Text = "Inactive";
            this.metroLabel82.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel82.UseStyleColors = true;
            // 
            // metroLabel83
            // 
            this.metroLabel83.AutoSize = true;
            this.metroLabel83.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel83.Location = new System.Drawing.Point(21, 76);
            this.metroLabel83.Name = "metroLabel83";
            this.metroLabel83.Size = new System.Drawing.Size(54, 25);
            this.metroLabel83.TabIndex = 22;
            this.metroLabel83.Text = "64Bit:";
            this.metroLabel83.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel81
            // 
            this.metroLabel81.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel81.Location = new System.Drawing.Point(80, 51);
            this.metroLabel81.Name = "metroLabel81";
            this.metroLabel81.Size = new System.Drawing.Size(98, 25);
            this.metroLabel81.TabIndex = 21;
            this.metroLabel81.Text = "Inactive";
            this.metroLabel81.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel81.UseStyleColors = true;
            // 
            // metroLabel77
            // 
            this.metroLabel77.Location = new System.Drawing.Point(10, 28);
            this.metroLabel77.Name = "metroLabel77";
            this.metroLabel77.Size = new System.Drawing.Size(209, 23);
            this.metroLabel77.TabIndex = 9;
            this.metroLabel77.Text = "Bypass BnS\'s Process Active Check";
            this.metroLabel77.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel77.UseStyleColors = true;
            // 
            // metroToggle22
            // 
            this.metroToggle22.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle22.Location = new System.Drawing.Point(109, 3);
            this.metroToggle22.Name = "metroToggle22";
            this.metroToggle22.Size = new System.Drawing.Size(110, 25);
            this.metroToggle22.TabIndex = 8;
            this.metroToggle22.Text = "Off";
            this.metroToggle22.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle22.UseStyleColors = true;
            this.metroToggle22.UseVisualStyleBackColor = true;
            this.metroToggle22.Click += new System.EventHandler(this.metroToggle22_CheckedChanged);
            // 
            // metroLabel74
            // 
            this.metroLabel74.AutoSize = true;
            this.metroLabel74.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel74.Location = new System.Drawing.Point(10, 3);
            this.metroLabel74.Name = "metroLabel74";
            this.metroLabel74.Size = new System.Drawing.Size(98, 25);
            this.metroLabel74.TabIndex = 7;
            this.metroLabel74.Text = "Multi Client";
            this.metroLabel74.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel51
            // 
            this.metroLabel51.AutoSize = true;
            this.metroLabel51.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel51.Location = new System.Drawing.Point(21, 51);
            this.metroLabel51.Name = "metroLabel51";
            this.metroLabel51.Size = new System.Drawing.Size(53, 25);
            this.metroLabel51.TabIndex = 20;
            this.metroLabel51.Text = "32Bit:";
            this.metroLabel51.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox8
            // 
            this.metroTextBox8.Location = new System.Drawing.Point(33, 259);
            this.metroTextBox8.Name = "metroTextBox8";
            this.metroTextBox8.Size = new System.Drawing.Size(218, 23);
            this.metroTextBox8.TabIndex = 18;
            this.metroTextBox8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox8.TextChanged += new System.EventHandler(this.metroTextBox8_Click);
            // 
            // metroLabel80
            // 
            this.metroLabel80.AutoSize = true;
            this.metroLabel80.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel80.Location = new System.Drawing.Point(58, 279);
            this.metroLabel80.Name = "metroLabel80";
            this.metroLabel80.Size = new System.Drawing.Size(166, 25);
            this.metroLabel80.TabIndex = 17;
            this.metroLabel80.Text = "More to come soon!";
            this.metroLabel80.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel79
            // 
            this.metroLabel79.Location = new System.Drawing.Point(19, 232);
            this.metroLabel79.Name = "metroLabel79";
            this.metroLabel79.Size = new System.Drawing.Size(247, 23);
            this.metroLabel79.TabIndex = 16;
            this.metroLabel79.Text = "Good luck finding your unique pass ;)";
            this.metroLabel79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel79.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel79.UseStyleColors = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.metroPanel3);
            this.metroTabPage5.Controls.Add(this.metroPanel2);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(687, 318);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = "Dat Editor";
            this.metroTabPage5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.metroPanel3.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.metroComboBox3);
            this.metroPanel3.Controls.Add(this.metroLabel37);
            this.metroPanel3.Controls.Add(this.treeView1);
            this.metroPanel3.Controls.Add(this.toolStrip1);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(234, 318);
            this.metroPanel3.TabIndex = 7;
            this.metroPanel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroComboBox3
            // 
            this.metroComboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroComboBox3.FormattingEnabled = true;
            this.metroComboBox3.ItemHeight = 23;
            this.metroComboBox3.Location = new System.Drawing.Point(33, 29);
            this.metroComboBox3.Name = "metroComboBox3";
            this.metroComboBox3.Size = new System.Drawing.Size(198, 29);
            this.metroComboBox3.TabIndex = 4;
            this.metroComboBox3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox3.SelectedIndexChanged += new System.EventHandler(this.metroComboBox3_SelectedIndexChanged);
            // 
            // metroLabel37
            // 
            this.metroLabel37.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel37.AutoSize = true;
            this.metroLabel37.Location = new System.Drawing.Point(2, 34);
            this.metroLabel37.Name = "metroLabel37";
            this.metroLabel37.Size = new System.Drawing.Size(32, 19);
            this.metroLabel37.TabIndex = 3;
            this.metroLabel37.Text = "File:";
            this.metroLabel37.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Location = new System.Drawing.Point(0, 64);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(234, 257);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(234, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "Backup";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.ForeColor = System.Drawing.Color.MediumOrchid;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton2.Text = "Decompile";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton3.Text = "Compile";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(42, 22);
            this.toolStripButton4.Text = "Apply";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(50, 19);
            this.toolStripButton5.Text = "Restore";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel2.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.metroLabel39);
            this.metroPanel2.Controls.Add(this.metroLabel15);
            this.metroPanel2.Controls.Add(this.fastColoredTextBox1);
            this.metroPanel2.Controls.Add(this.toolStrip2);
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(237, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(495, 257);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel39
            // 
            this.metroLabel39.AutoSize = true;
            this.metroLabel39.Location = new System.Drawing.Point(193, 2);
            this.metroLabel39.Name = "metroLabel39";
            this.metroLabel39.Size = new System.Drawing.Size(45, 19);
            this.metroLabel39.TabIndex = 8;
            this.metroLabel39.Text = "Ready";
            this.metroLabel39.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel39.UseStyleColors = true;
            this.metroLabel39.TextChanged += new System.EventHandler(this.metroLabel39_TextChanged);
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(147, 2);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(46, 19);
            this.metroLabel15.TabIndex = 7;
            this.metroLabel15.Text = "Status:";
            this.metroLabel15.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel15.UseStyleColors = true;
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.fastColoredTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fastColoredTextBox1.CaretColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(0, 24);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = null;
            this.fastColoredTextBox1.Size = new System.Drawing.Size(454, 297);
            this.fastColoredTextBox1.TabIndex = 2;
            this.fastColoredTextBox1.TextAreaBorderColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.Zoom = 100;
            this.fastColoredTextBox1.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChanged);
            this.fastColoredTextBox1.VisibleRangeChangedDelayed += new System.EventHandler(this.fctb_VisibilityChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton6,
            this.toolStripSeparator1,
            this.toolStripButton7});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(495, 25);
            this.toolStrip2.TabIndex = 3;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findCTRLFToolStripMenuItem,
            this.findReplaceCTRLRToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownButton1.Text = "Edit";
            // 
            // findCTRLFToolStripMenuItem
            // 
            this.findCTRLFToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.findCTRLFToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.findCTRLFToolStripMenuItem.Name = "findCTRLFToolStripMenuItem";
            this.findCTRLFToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findCTRLFToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.findCTRLFToolStripMenuItem.Text = "Find";
            this.findCTRLFToolStripMenuItem.Click += new System.EventHandler(this.findCTRLFToolStripMenuItem_Click);
            // 
            // findReplaceCTRLRToolStripMenuItem
            // 
            this.findReplaceCTRLRToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.findReplaceCTRLRToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.findReplaceCTRLRToolStripMenuItem.Name = "findReplaceCTRLRToolStripMenuItem";
            this.findReplaceCTRLRToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.findReplaceCTRLRToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.findReplaceCTRLRToolStripMenuItem.Text = "Find and Replace";
            this.findReplaceCTRLRToolStripMenuItem.Click += new System.EventHandler(this.findReplaceCTRLRToolStripMenuItem_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton6.Text = "Save";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.ForeColor = System.Drawing.Color.White;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(39, 22);
            this.toolStripButton7.Text = "Help!";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroPanel4);
            this.metroTabPage2.Controls.Add(this.metroProgressBar2);
            this.metroTabPage2.Controls.Add(this.treeView2);
            this.metroTabPage2.Controls.Add(this.metroTextBox2);
            this.metroTabPage2.Controls.Add(this.metroButton11);
            this.metroTabPage2.Controls.Add(this.metroButton10);
            this.metroTabPage2.Controls.Add(this.metroButton9);
            this.metroTabPage2.Controls.Add(this.metroButton8);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(687, 318);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Mod Manager";
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.metroLabel40);
            this.metroPanel4.Controls.Add(this.metroLabel38);
            this.metroPanel4.HorizontalScrollbar = true;
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = true;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(4, 224);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(391, 30);
            this.metroPanel4.TabIndex = 18;
            this.metroPanel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel4.VerticalScrollbar = true;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroLabel40
            // 
            this.metroLabel40.Location = new System.Drawing.Point(86, 6);
            this.metroLabel40.Name = "metroLabel40";
            this.metroLabel40.Size = new System.Drawing.Size(302, 19);
            this.metroLabel40.TabIndex = 3;
            this.metroLabel40.Text = "-";
            this.metroLabel40.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel40.UseStyleColors = true;
            // 
            // metroLabel38
            // 
            this.metroLabel38.AutoSize = true;
            this.metroLabel38.Location = new System.Drawing.Point(3, 6);
            this.metroLabel38.Name = "metroLabel38";
            this.metroLabel38.Size = new System.Drawing.Size(77, 19);
            this.metroLabel38.TabIndex = 2;
            this.metroLabel38.Text = "Description:";
            this.metroLabel38.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroProgressBar2
            // 
            this.metroProgressBar2.FontWeight = MetroFramework.MetroProgressBarWeight.Regular;
            this.metroProgressBar2.HideProgressText = false;
            this.metroProgressBar2.Location = new System.Drawing.Point(401, 3);
            this.metroProgressBar2.Name = "metroProgressBar2";
            this.metroProgressBar2.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.metroProgressBar2.Size = new System.Drawing.Size(283, 23);
            this.metroProgressBar2.Step = 1;
            this.metroProgressBar2.TabIndex = 17;
            this.metroProgressBar2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroProgressBar2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressBar2.Visible = false;
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView2.CheckBoxes = true;
            this.treeView2.ForeColor = System.Drawing.Color.White;
            this.treeView2.FullRowSelect = true;
            this.treeView2.Location = new System.Drawing.Point(3, 3);
            this.treeView2.Name = "treeView2";
            this.treeView2.ShowLines = false;
            this.treeView2.Size = new System.Drawing.Size(392, 214);
            this.treeView2.TabIndex = 16;
            this.treeView2.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox2.Location = new System.Drawing.Point(401, 3);
            this.metroTextBox2.Multiline = true;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.ReadOnly = true;
            this.metroTextBox2.Size = new System.Drawing.Size(283, 309);
            this.metroTextBox2.TabIndex = 7;
            this.metroTextBox2.Text = " ";
            this.metroTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton11
            // 
            this.metroButton11.Enabled = false;
            this.metroButton11.Location = new System.Drawing.Point(7, 260);
            this.metroButton11.Name = "metroButton11";
            this.metroButton11.Size = new System.Drawing.Size(191, 23);
            this.metroButton11.TabIndex = 5;
            this.metroButton11.Text = "Mod Selected";
            this.metroButton11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton11, "Mod your game");
            this.metroButton11.Click += new System.EventHandler(this.metroButton11_Click);
            // 
            // metroButton10
            // 
            this.metroButton10.Location = new System.Drawing.Point(7, 289);
            this.metroButton10.Name = "metroButton10";
            this.metroButton10.Size = new System.Drawing.Size(191, 23);
            this.metroButton10.TabIndex = 4;
            this.metroButton10.Text = "Mod Folder";
            this.metroButton10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton10, "Browse your mods folder");
            this.metroButton10.Click += new System.EventHandler(this.metroButton10_Click);
            // 
            // metroButton9
            // 
            this.metroButton9.Enabled = false;
            this.metroButton9.Location = new System.Drawing.Point(204, 260);
            this.metroButton9.Name = "metroButton9";
            this.metroButton9.Size = new System.Drawing.Size(191, 23);
            this.metroButton9.TabIndex = 3;
            this.metroButton9.Text = "Undo Selected";
            this.metroButton9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton9, "Undo mods");
            this.metroButton9.Click += new System.EventHandler(this.metroButton9_Click);
            // 
            // metroButton8
            // 
            this.metroButton8.Location = new System.Drawing.Point(204, 289);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.Size = new System.Drawing.Size(191, 23);
            this.metroButton8.TabIndex = 2;
            this.metroButton8.Text = "Refresh Mods";
            this.metroButton8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton8, "Rescan mods folder");
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // Addons
            // 
            this.Addons.Controls.Add(this.metroPanel5);
            this.Addons.Controls.Add(this.metroLabel63);
            this.Addons.Controls.Add(this.metroLabel64);
            this.Addons.Controls.Add(this.metroLabel53);
            this.Addons.Controls.Add(this.metroTextBox6);
            this.Addons.Controls.Add(this.metroButton28);
            this.Addons.Controls.Add(this.metroButton27);
            this.Addons.Controls.Add(this.metroButton26);
            this.Addons.Controls.Add(this.metroButton25);
            this.Addons.Controls.Add(this.metroLabel52);
            this.Addons.Controls.Add(this.metroLabel49);
            this.Addons.Controls.Add(this.treeView3);
            this.Addons.HorizontalScrollbarBarColor = true;
            this.Addons.Location = new System.Drawing.Point(4, 35);
            this.Addons.Name = "Addons";
            this.Addons.Size = new System.Drawing.Size(687, 318);
            this.Addons.TabIndex = 7;
            this.Addons.Text = "Addons";
            this.Addons.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Addons.VerticalScrollbarBarColor = true;
            // 
            // metroPanel5
            // 
            this.metroPanel5.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel5.Controls.Add(this.metroRadioButton2);
            this.metroPanel5.Controls.Add(this.metroRadioButton1);
            this.metroPanel5.Controls.Add(this.metroLabel66);
            this.metroPanel5.HorizontalScrollbarBarColor = false;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(351, 290);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(319, 25);
            this.metroPanel5.TabIndex = 37;
            this.metroPanel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel5.VerticalScrollbarBarColor = false;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // metroRadioButton2
            // 
            this.metroRadioButton2.AutoSize = true;
            this.metroRadioButton2.Location = new System.Drawing.Point(249, 6);
            this.metroRadioButton2.Name = "metroRadioButton2";
            this.metroRadioButton2.Size = new System.Drawing.Size(52, 15);
            this.metroRadioButton2.TabIndex = 36;
            this.metroRadioButton2.Text = "64 Bit";
            this.metroRadioButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroRadioButton2.UseVisualStyleBackColor = true;
            // 
            // metroRadioButton1
            // 
            this.metroRadioButton1.AutoSize = true;
            this.metroRadioButton1.Location = new System.Drawing.Point(155, 6);
            this.metroRadioButton1.Name = "metroRadioButton1";
            this.metroRadioButton1.Size = new System.Drawing.Size(52, 15);
            this.metroRadioButton1.TabIndex = 35;
            this.metroRadioButton1.TabStop = true;
            this.metroRadioButton1.Text = "32 Bit";
            this.metroRadioButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroRadioButton1.UseVisualStyleBackColor = true;
            // 
            // metroLabel66
            // 
            this.metroLabel66.AutoSize = true;
            this.metroLabel66.Location = new System.Drawing.Point(11, 3);
            this.metroLabel66.Name = "metroLabel66";
            this.metroLabel66.Size = new System.Drawing.Size(100, 19);
            this.metroLabel66.TabIndex = 33;
            this.metroLabel66.Text = "Bitness to patch";
            this.metroLabel66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel66.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel63
            // 
            this.metroLabel63.AutoSize = true;
            this.metroLabel63.Location = new System.Drawing.Point(133, 150);
            this.metroLabel63.Name = "metroLabel63";
            this.metroLabel63.Size = new System.Drawing.Size(45, 19);
            this.metroLabel63.TabIndex = 31;
            this.metroLabel63.Text = "Ready";
            this.metroLabel63.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel63.UseStyleColors = true;
            this.metroLabel63.Visible = false;
            // 
            // metroLabel64
            // 
            this.metroLabel64.AutoSize = true;
            this.metroLabel64.Location = new System.Drawing.Point(87, 150);
            this.metroLabel64.Name = "metroLabel64";
            this.metroLabel64.Size = new System.Drawing.Size(46, 19);
            this.metroLabel64.TabIndex = 30;
            this.metroLabel64.Text = "Status:";
            this.metroLabel64.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel64.UseStyleColors = true;
            this.metroLabel64.Visible = false;
            // 
            // metroLabel53
            // 
            this.metroLabel53.AutoSize = true;
            this.metroLabel53.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel53.Location = new System.Drawing.Point(121, 125);
            this.metroLabel53.Name = "metroLabel53";
            this.metroLabel53.Size = new System.Drawing.Size(87, 25);
            this.metroLabel53.TabIndex = 29;
            this.metroLabel53.Text = "Working...";
            this.metroLabel53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel53.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel53.UseStyleColors = true;
            this.metroLabel53.Visible = false;
            // 
            // metroTextBox6
            // 
            this.metroTextBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroTextBox6.CustomBackground = true;
            this.metroTextBox6.Location = new System.Drawing.Point(339, 25);
            this.metroTextBox6.Multiline = true;
            this.metroTextBox6.Name = "metroTextBox6";
            this.metroTextBox6.ReadOnly = true;
            this.metroTextBox6.Size = new System.Drawing.Size(345, 177);
            this.metroTextBox6.TabIndex = 27;
            this.metroTextBox6.TabStop = false;
            this.metroTextBox6.Text = "-";
            this.metroTextBox6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton28
            // 
            this.metroButton28.Location = new System.Drawing.Point(260, 289);
            this.metroButton28.Name = "metroButton28";
            this.metroButton28.Size = new System.Drawing.Size(73, 29);
            this.metroButton28.TabIndex = 26;
            this.metroButton28.Text = "Restore";
            this.metroButton28.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton28.Click += new System.EventHandler(this.metroButton28_Click);
            // 
            // metroButton27
            // 
            this.metroButton27.Location = new System.Drawing.Point(160, 289);
            this.metroButton27.Name = "metroButton27";
            this.metroButton27.Size = new System.Drawing.Size(102, 29);
            this.metroButton27.TabIndex = 25;
            this.metroButton27.Text = "Addon Creator";
            this.metroButton27.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton27.Click += new System.EventHandler(this.metroButton27_Click);
            // 
            // metroButton26
            // 
            this.metroButton26.Location = new System.Drawing.Point(87, 289);
            this.metroButton26.Name = "metroButton26";
            this.metroButton26.Size = new System.Drawing.Size(75, 29);
            this.metroButton26.TabIndex = 24;
            this.metroButton26.Text = "Refresh";
            this.metroButton26.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton26.Click += new System.EventHandler(this.metroButton26_Click);
            // 
            // metroButton25
            // 
            this.metroButton25.Location = new System.Drawing.Point(3, 289);
            this.metroButton25.Name = "metroButton25";
            this.metroButton25.Size = new System.Drawing.Size(88, 29);
            this.metroButton25.TabIndex = 23;
            this.metroButton25.Text = "Addon Folder";
            this.metroButton25.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton25.Click += new System.EventHandler(this.metroButton25_Click);
            // 
            // metroLabel52
            // 
            this.metroLabel52.Location = new System.Drawing.Point(339, 205);
            this.metroLabel52.Name = "metroLabel52";
            this.metroLabel52.Size = new System.Drawing.Size(348, 78);
            this.metroLabel52.TabIndex = 21;
            this.metroLabel52.Text = "How to use: \r\n  1: Add mods in \"addon\" folder\r\n  2: Press refresh, then tick the " +
    "addon you want to use\r\n  3: Patch/Play to automatically apply addons";
            this.metroLabel52.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel49
            // 
            this.metroLabel49.AutoSize = true;
            this.metroLabel49.Location = new System.Drawing.Point(339, 3);
            this.metroLabel49.Name = "metroLabel49";
            this.metroLabel49.Size = new System.Drawing.Size(81, 19);
            this.metroLabel49.TabIndex = 18;
            this.metroLabel49.Text = "Description: ";
            this.metroLabel49.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // treeView3
            // 
            this.treeView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView3.CheckBoxes = true;
            this.treeView3.ForeColor = System.Drawing.Color.White;
            this.treeView3.FullRowSelect = true;
            this.treeView3.Location = new System.Drawing.Point(3, 3);
            this.treeView3.Name = "treeView3";
            this.treeView3.ShowLines = false;
            this.treeView3.Size = new System.Drawing.Size(330, 280);
            this.treeView3.TabIndex = 17;
            this.treeView3.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView3_AfterSelect);
            this.treeView3.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView3_AfterSelect);
            // 
            // Donators
            // 
            this.Donators.Controls.Add(this.metroLabel23);
            this.Donators.Controls.Add(this.metroLabel24);
            this.Donators.HorizontalScrollbarBarColor = true;
            this.Donators.Location = new System.Drawing.Point(4, 35);
            this.Donators.Name = "Donators";
            this.Donators.Size = new System.Drawing.Size(687, 318);
            this.Donators.TabIndex = 5;
            this.Donators.Text = "Donators";
            this.Donators.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Donators.VerticalScrollbarBarColor = true;
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel23.Location = new System.Drawing.Point(192, 131);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(301, 25);
            this.metroLabel23.TabIndex = 3;
            this.metroLabel23.Text = "Thanks everyone for the donations <3";
            this.metroLabel23.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel24
            // 
            this.metroLabel24.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel24.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel24.Location = new System.Drawing.Point(3, 9);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(681, 295);
            this.metroLabel24.TabIndex = 4;
            this.metroLabel24.Text = resources.GetString("metroLabel24.Text");
            this.metroLabel24.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel24.UseStyleColors = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.pictureBox1);
            this.metroTabPage3.Controls.Add(this.listBox1);
            this.metroTabPage3.Controls.Add(this.metroLabel17);
            this.metroTabPage3.Controls.Add(this.metroLabel16);
            this.metroTabPage3.Controls.Add(this.metroButton7);
            this.metroTabPage3.Controls.Add(this.metroButton6);
            this.metroTabPage3.Controls.Add(this.metroButton5);
            this.metroTabPage3.Controls.Add(this.metroButton4);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(687, 318);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Splash Changer";
            this.metroTabPage3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage3.UseVisualStyleBackColor = true;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(232, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(452, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(221, 275);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel17.Location = new System.Drawing.Point(526, 287);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(19, 25);
            this.metroLabel17.TabIndex = 7;
            this.metroLabel17.Text = "-";
            this.metroLabel17.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel17.UseStyleColors = true;
            this.metroLabel17.TextChanged += new System.EventHandler(this.metroLabel17_TextChanged);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel16.Location = new System.Drawing.Point(459, 287);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(61, 25);
            this.metroLabel16.TabIndex = 6;
            this.metroLabel16.Text = "Status:";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton7
            // 
            this.metroButton7.Location = new System.Drawing.Point(345, 287);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(108, 28);
            this.metroButton7.TabIndex = 5;
            this.metroButton7.Text = "Refresh";
            this.metroButton7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton7, "Rescan splash folder");
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click_1);
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(231, 287);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(108, 28);
            this.metroButton6.TabIndex = 4;
            this.metroButton6.Text = "Splash Folder";
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton6, "Browse splash folder");
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(117, 287);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(108, 28);
            this.metroButton5.TabIndex = 3;
            this.metroButton5.Text = "Restore";
            this.metroButton5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton5, "Restore splash art");
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click_1);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(3, 287);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(108, 28);
            this.metroButton4.TabIndex = 2;
            this.metroButton4.Text = "Change";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton4, "Change splash art");
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click_1);
            // 
            // About
            // 
            this.About.Controls.Add(this.metroLabel7);
            this.About.HorizontalScrollbarBarColor = true;
            this.About.Location = new System.Drawing.Point(4, 35);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(687, 318);
            this.About.TabIndex = 3;
            this.About.Text = "About";
            this.About.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.About.VerticalScrollbarBarColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(54, 37);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(550, 247);
            this.metroLabel7.TabIndex = 2;
            this.metroLabel7.Text = resources.GetString("metroLabel7.Text");
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BnS Buddy - Launcher";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // metroButton12
            // 
            this.metroButton12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton12.Highlight = true;
            this.metroButton12.Location = new System.Drawing.Point(496, 25);
            this.metroButton12.Name = "metroButton12";
            this.metroButton12.Size = new System.Drawing.Size(72, 31);
            this.metroButton12.TabIndex = 3;
            this.metroButton12.Text = "Donate <3";
            this.metroButton12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton12, "Donate a coffee <3");
            this.metroButton12.Click += new System.EventHandler(this.metroButton12_Click);
            // 
            // metroButton13
            // 
            this.metroButton13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton13.Highlight = true;
            this.metroButton13.Location = new System.Drawing.Point(574, 25);
            this.metroButton13.Name = "metroButton13";
            this.metroButton13.Size = new System.Drawing.Size(34, 31);
            this.metroButton13.TabIndex = 4;
            this.metroButton13.Text = "--";
            this.metroButton13.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton13, "Minimize");
            this.metroButton13.Click += new System.EventHandler(this.metroButton13_Click);
            // 
            // metroButton14
            // 
            this.metroButton14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton14.Highlight = true;
            this.metroButton14.Location = new System.Drawing.Point(654, 25);
            this.metroButton14.Name = "metroButton14";
            this.metroButton14.Size = new System.Drawing.Size(34, 31);
            this.metroButton14.TabIndex = 5;
            this.metroButton14.Text = "X";
            this.metroButton14.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton14, "Close");
            this.metroButton14.Click += new System.EventHandler(this.metroButton14_Click);
            // 
            // metroButton22
            // 
            this.metroButton22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroButton22.Highlight = true;
            this.metroButton22.Location = new System.Drawing.Point(614, 25);
            this.metroButton22.Name = "metroButton22";
            this.metroButton22.Size = new System.Drawing.Size(34, 31);
            this.metroButton22.TabIndex = 7;
            this.metroButton22.Text = "+";
            this.metroButton22.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton22, "Maximize");
            this.metroButton22.Visible = false;
            this.metroButton22.Click += new System.EventHandler(this.metroButton22_Click);
            // 
            // metroButton23
            // 
            this.metroButton23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton23.Highlight = true;
            this.metroButton23.Location = new System.Drawing.Point(614, 25);
            this.metroButton23.Name = "metroButton23";
            this.metroButton23.Size = new System.Drawing.Size(34, 31);
            this.metroButton23.TabIndex = 8;
            this.metroButton23.Text = "+";
            this.metroButton23.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroButton23, "Restore");
            this.metroButton23.Visible = false;
            this.metroButton23.Click += new System.EventHandler(this.metroButton23_Click);
            // 
            // RegionCB
            // 
            this.RegionCB.FormattingEnabled = true;
            this.RegionCB.ItemHeight = 23;
            this.RegionCB.Location = new System.Drawing.Point(0, 25);
            this.RegionCB.Name = "RegionCB";
            this.RegionCB.Size = new System.Drawing.Size(24, 29);
            this.RegionCB.TabIndex = 9;
            this.RegionCB.TabStop = false;
            this.RegionCB.Visible = false;
            // 
            // CClock
            // 
            this.CClock.Interval = 1000;
            this.CClock.Tick += new System.EventHandler(this.CClock_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(697, 422);
            this.ControlBox = false;
            this.Controls.Add(this.RegionCB);
            this.Controls.Add(this.metroButton14);
            this.Controls.Add(this.metroButton13);
            this.Controls.Add(this.metroButton12);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroButton22);
            this.Controls.Add(this.metroButton23);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BnS Buddy - Made by Endless";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.metroTabControl1.ResumeLayout(false);
            this.Launcher.ResumeLayout(false);
            this.Launcher.PerformLayout();
            this.metroPanel6.ResumeLayout(false);
            this.metroPanel6.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage8.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.metroTabPage10.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.metroTabPage9.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.Extras.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.metroPanel8.ResumeLayout(false);
            this.metroPanel8.PerformLayout();
            this.metroPanel7.ResumeLayout(false);
            this.metroPanel7.PerformLayout();
            this.metroTabPage5.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.Addons.ResumeLayout(false);
            this.Addons.PerformLayout();
            this.metroPanel5.ResumeLayout(false);
            this.metroPanel5.PerformLayout();
            this.Donators.ResumeLayout(false);
            this.Donators.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroTabPage About;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        public MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroButton metroButton11;
        private MetroFramework.Controls.MetroButton metroButton10;
        private MetroFramework.Controls.MetroButton metroButton9;
        private MetroFramework.Controls.MetroButton metroButton8;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroButton metroButton12;
        private MetroFramework.Controls.MetroButton metroButton13;
        private MetroFramework.Controls.MetroButton metroButton14;
        private MetroFramework.Controls.MetroTabPage Donators;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTabPage Launcher;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTabPage Settings;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private MetroFramework.Controls.MetroToggle metroToggle2;
        private MetroFramework.Controls.MetroToggle metroToggle3;
        private MetroFramework.Controls.MetroLabel metroLabel26;
        private MetroFramework.Controls.MetroTextBox metroTextBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox4;
        private MetroFramework.Controls.MetroLabel metroLabel27;
        private MetroFramework.Controls.MetroToggle metroToggle4;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton metroButton16;
        private MetroFramework.Controls.MetroButton metroButton15;
        private MetroFramework.Controls.MetroButton metroButton18;
        private MetroFramework.Controls.MetroButton metroButton17;
        private MetroFramework.Controls.MetroToggle metroToggle5;
        private MetroFramework.Controls.MetroLabel metroLabel28;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroToggle metroToggle6;
        private MetroFramework.Controls.MetroLabel metroLabel29;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroToggle metroToggle7;
        private MetroFramework.Controls.MetroLabel metroLabel30;
        private MetroFramework.Controls.MetroButton metroButton19;
        private MetroFramework.Controls.MetroButton metroButton20;
        private System.Windows.Forms.GroupBox groupBox5;
        private MetroFramework.Controls.MetroToggle metroToggle8;
        private MetroFramework.Controls.MetroLabel metroLabel31;
        private MetroFramework.Controls.MetroToggle metroToggle9;
        private MetroFramework.Controls.MetroLabel metroLabel32;
        private System.Windows.Forms.GroupBox groupBox6;
        private MetroFramework.Controls.MetroToggle metroToggle11;
        private MetroFramework.Controls.MetroLabel metroLabel34;
        private MetroFramework.Controls.MetroToggle metroToggle10;
        private MetroFramework.Controls.MetroLabel metroLabel33;
        private System.Windows.Forms.GroupBox groupBox7;
        private MetroFramework.Controls.MetroToggle metroToggle12;
        private MetroFramework.Controls.MetroLabel metroLabel35;
        private MetroFramework.Controls.MetroToggle metroToggle13;
        private MetroFramework.Controls.MetroLabel metroLabel36;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem findCTRLFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findReplaceCTRLRToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private System.Windows.Forms.TreeView treeView1;
        private MetroFramework.Controls.MetroLabel metroLabel37;
        private MetroFramework.Controls.MetroComboBox metroComboBox3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        public MetroFramework.Controls.MetroLabel metroLabel39;
        private MetroFramework.Controls.MetroButton metroButton22;
        private MetroFramework.Controls.MetroButton metroButton23;
        private System.Windows.Forms.TreeView treeView2;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar2;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel40;
        private MetroFramework.Controls.MetroLabel metroLabel38;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox3;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage8;
        private MetroFramework.Controls.MetroTabPage metroTabPage9;
        private MetroFramework.Controls.MetroButton metroButton21;
        private System.Windows.Forms.GroupBox groupBox8;
        private MetroFramework.Controls.MetroToggle metroToggle16;
        private MetroFramework.Controls.MetroLabel metroLabel43;
        private MetroFramework.Controls.MetroToggle metroToggle14;
        private MetroFramework.Controls.MetroLabel metroLabel41;
        private MetroFramework.Controls.MetroToggle metroToggle15;
        private MetroFramework.Controls.MetroLabel metroLabel42;
        private MetroFramework.Controls.MetroLabel metroLabel44;
        private System.Windows.Forms.GroupBox groupBox9;
        private MetroFramework.Controls.MetroLabel metroLabel46;
        private MetroFramework.Controls.MetroTextBox metroTextBox5;
        private MetroFramework.Controls.MetroButton metroButton24;
        private MetroFramework.Controls.MetroLabel metroLabel45;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroLabel metroLabel47;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroToggle metroToggle17;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroLabel metroLabel48;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroTabPage Addons;
        private System.Windows.Forms.TreeView treeView3;
        private MetroFramework.Controls.MetroLabel metroLabel49;
        private MetroFramework.Controls.MetroLabel metroLabel52;
        private MetroFramework.Controls.MetroButton metroButton25;
        private MetroFramework.Controls.MetroButton metroButton26;
        private MetroFramework.Controls.MetroButton metroButton27;
        private MetroFramework.Controls.MetroComboBox metroComboBox4;
        private MetroFramework.Controls.MetroTabPage metroTabPage10;
        private System.Windows.Forms.GroupBox groupBox10;
        private MetroFramework.Controls.MetroButton metroButton29;
        private MetroFramework.Controls.MetroButton metroButton31;
        private MetroFramework.Controls.MetroButton metroButton33;
        private MetroFramework.Controls.MetroLabel metroLabel55;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroToggle metroToggle19;
        private System.Windows.Forms.GroupBox groupBox11;
        private MetroFramework.Controls.MetroComboBox metroComboBox5;
        private MetroFramework.Controls.MetroLabel metroLabel54;
        private MetroFramework.Controls.MetroLabel metroLabel56;
        private MetroFramework.Controls.MetroComboBox RegionCB;
        private System.Windows.Forms.GroupBox groupBox12;
        private MetroFramework.Controls.MetroLabel metroLabel57;
        private MetroFramework.Controls.MetroLabel metroLabel58;
        private MetroFramework.Controls.MetroComboBox metroComboBox6;
        private MetroFramework.Controls.MetroLabel metroLabel60;
        private MetroFramework.Controls.MetroLabel metroLabel59;
        private MetroFramework.Controls.MetroButton metroButton28;
        private MetroFramework.Controls.MetroButton metroButton30;
        private System.Windows.Forms.GroupBox groupBox13;
        private MetroFramework.Controls.MetroToggle metroToggle18;
        private MetroFramework.Controls.MetroLabel metroLabel61;
        private MetroFramework.Controls.MetroLabel metroLabel62;
        private MetroFramework.Controls.MetroTextBox metroTextBox6;
        private MetroFramework.Controls.MetroLabel metroLabel53;
        public MetroFramework.Controls.MetroLabel metroLabel63;
        private MetroFramework.Controls.MetroLabel metroLabel64;
        private MetroFramework.Controls.MetroLabel metroLabel65;
        private MetroFramework.Controls.MetroLabel metroLabel66;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton2;
        private MetroFramework.Controls.MetroRadioButton metroRadioButton1;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroToggle metroToggle20;
        private MetroFramework.Controls.MetroLabel metroLabel67;
        private MetroFramework.Controls.MetroComboBox metroComboBox7;
        private MetroFramework.Controls.MetroLabel metroLabel68;
        private MetroFramework.Controls.MetroLabel metroLabel69;
        private MetroFramework.Controls.MetroTabPage Extras;
        private System.Windows.Forms.Timer CClock;
        private MetroFramework.Controls.MetroComboBox metroComboBox8;
        private MetroFramework.Controls.MetroLabel metroLabel70;
        private MetroFramework.Controls.MetroLabel metroLabel71;
        private MetroFramework.Controls.MetroLabel metroLabel72;
        private MetroFramework.Controls.MetroLabel metroLabel73;
        private System.Windows.Forms.GroupBox groupBox14;
        private MetroFramework.Controls.MetroLabel metroLabel74;
        private MetroFramework.Controls.MetroLabel metroLabel77;
        private MetroFramework.Controls.MetroToggle metroToggle22;
        private MetroFramework.Controls.MetroLabel metroLabel79;
        private MetroFramework.Controls.MetroLabel metroLabel80;
        private System.Windows.Forms.GroupBox groupBox15;
        private MetroFramework.Controls.MetroLabel metroLabel50;
        private MetroFramework.Controls.MetroTextBox metroTextBox8;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroLabel metroLabel51;
        private MetroFramework.Controls.MetroComboBox metroComboBox9;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroLabel metroLabel78;
        private MetroFramework.Controls.MetroLabel metroLabel82;
        private MetroFramework.Controls.MetroLabel metroLabel83;
        private MetroFramework.Controls.MetroLabel metroLabel81;
        private MetroFramework.Controls.MetroPanel metroPanel8;
        private MetroFramework.Controls.MetroLabel metroLabel84;
        private MetroFramework.Controls.MetroLabel metroLabel85;
        private MetroFramework.Controls.MetroLabel metroLabel86;
        private MetroFramework.Controls.MetroLabel metroLabel87;
        private MetroFramework.Controls.MetroToggle metroToggle23;
        private MetroFramework.Controls.MetroLabel metroLabel88;
        private MetroFramework.Controls.MetroLabel metroLabel89;
        private MetroFramework.Controls.MetroPanel metroPanel7;
        private System.Windows.Forms.GroupBox groupBox16;
        private MetroFramework.Controls.MetroLabel metroLabel75;
        private System.Windows.Forms.GroupBox groupBox17;
        private MetroFramework.Controls.MetroLabel metroLabel76;
        private MetroFramework.Controls.MetroLabel metroLabel92;
        private MetroFramework.Controls.MetroToggle metroToggle24;
        private MetroFramework.Controls.MetroLabel metroLabel90;
        private MetroFramework.Controls.MetroLabel metroLabel91;
        private MetroFramework.Controls.MetroToggle metroToggle21;
        private System.Windows.Forms.GroupBox groupBox18;
        private MetroFramework.Controls.MetroLabel metroLabel95;
        private MetroFramework.Controls.MetroToggle metroToggle25;
    }
}

