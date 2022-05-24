using System.ComponentModel;
using System.Windows.Forms;

namespace Generator
{
  partial class FormGenerator
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerator));
      this.gbAirports = new System.Windows.Forms.GroupBox();
      this.numMTraffic = new System.Windows.Forms.NumericUpDown();
      this.labMTraffic = new System.Windows.Forms.Label();
      this.numPTraffic = new System.Windows.Forms.NumericUpDown();
      this.labPTraffic = new System.Windows.Forms.Label();
      this.txbPosition = new System.Windows.Forms.TextBox();
      this.labPosition = new System.Windows.Forms.Label();
      this.btnDeleteAirport = new System.Windows.Forms.Button();
      this.btnModifyAirport = new System.Windows.Forms.Button();
      this.btnAddAirport = new System.Windows.Forms.Button();
      this.labAiportName = new System.Windows.Forms.Label();
      this.txbAirportName = new System.Windows.Forms.TextBox();
      this.listAirports = new System.Windows.Forms.ListView();
      this.gbAirplanes = new System.Windows.Forms.GroupBox();
      this.numSpeed = new System.Windows.Forms.NumericUpDown();
      this.labSpeed = new System.Windows.Forms.Label();
      this.numCapacity = new System.Windows.Forms.NumericUpDown();
      this.gbTimeOptions = new System.Windows.Forms.GroupBox();
      this.numMaintenance = new System.Windows.Forms.NumericUpDown();
      this.labMaintenance = new System.Windows.Forms.Label();
      this.numDisembarking = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.numEmbarking = new System.Windows.Forms.NumericUpDown();
      this.labEmbarking = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.labCapacity = new System.Windows.Forms.Label();
      this.labType = new System.Windows.Forms.Label();
      this.txbNameAirport = new System.Windows.Forms.TextBox();
      this.labNameAirport = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.labIdAirport = new System.Windows.Forms.Label();
      this.txbIdAirport = new System.Windows.Forms.TextBox();
      this.listPlane = new System.Windows.Forms.ListView();
      this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolFile = new System.Windows.Forms.ToolStripDropDownButton();
      this.subToolOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.subToolNew = new System.Windows.Forms.ToolStripMenuItem();
      this.subToolSave = new System.Windows.Forms.ToolStripMenuItem();
      this.subToolDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolMusic = new System.Windows.Forms.ToolStripDropDownButton();
      this.subToolStart = new System.Windows.Forms.ToolStripMenuItem();
      this.subToolStop = new System.Windows.Forms.ToolStripMenuItem();
      this.gbAirports.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numMTraffic)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numPTraffic)).BeginInit();
      this.gbAirplanes.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
      this.gbTimeOptions.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numMaintenance)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numDisembarking)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numEmbarking)).BeginInit();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // gbAirports
      // 
      this.gbAirports.Controls.Add(this.numMTraffic);
      this.gbAirports.Controls.Add(this.labMTraffic);
      this.gbAirports.Controls.Add(this.numPTraffic);
      this.gbAirports.Controls.Add(this.labPTraffic);
      this.gbAirports.Controls.Add(this.txbPosition);
      this.gbAirports.Controls.Add(this.labPosition);
      this.gbAirports.Controls.Add(this.btnDeleteAirport);
      this.gbAirports.Controls.Add(this.btnModifyAirport);
      this.gbAirports.Controls.Add(this.btnAddAirport);
      this.gbAirports.Controls.Add(this.labAiportName);
      this.gbAirports.Controls.Add(this.txbAirportName);
      this.gbAirports.Controls.Add(this.listAirports);
      this.gbAirports.Location = new System.Drawing.Point(24, 45);
      this.gbAirports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.gbAirports.Name = "gbAirports";
      this.gbAirports.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.gbAirports.Size = new System.Drawing.Size(1678, 532);
      this.gbAirports.TabIndex = 0;
      this.gbAirports.TabStop = false;
      this.gbAirports.Text = "Airports";
      // 
      // numMTraffic
      // 
      this.numMTraffic.Location = new System.Drawing.Point(1416, 251);
      this.numMTraffic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numMTraffic.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numMTraffic.Name = "numMTraffic";
      this.numMTraffic.Size = new System.Drawing.Size(243, 26);
      this.numMTraffic.TabIndex = 11;
      // 
      // labMTraffic
      // 
      this.labMTraffic.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labMTraffic.AutoSize = true;
      this.labMTraffic.Location = new System.Drawing.Point(1221, 254);
      this.labMTraffic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labMTraffic.Name = "labMTraffic";
      this.labMTraffic.Size = new System.Drawing.Size(152, 20);
      this.labMTraffic.TabIndex = 10;
      this.labMTraffic.Text = "Merchandise Traffic:";
      // 
      // numPTraffic
      // 
      this.numPTraffic.Location = new System.Drawing.Point(1416, 178);
      this.numPTraffic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numPTraffic.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numPTraffic.Name = "numPTraffic";
      this.numPTraffic.Size = new System.Drawing.Size(243, 26);
      this.numPTraffic.TabIndex = 9;
      // 
      // labPTraffic
      // 
      this.labPTraffic.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labPTraffic.AutoSize = true;
      this.labPTraffic.Location = new System.Drawing.Point(1221, 182);
      this.labPTraffic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labPTraffic.Name = "labPTraffic";
      this.labPTraffic.Size = new System.Drawing.Size(137, 20);
      this.labPTraffic.TabIndex = 8;
      this.labPTraffic.Text = "Passenger Traffic:";
      // 
      // txbPosition
      // 
      this.txbPosition.Enabled = false;
      this.txbPosition.Location = new System.Drawing.Point(1341, 111);
      this.txbPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbPosition.Name = "txbPosition";
      this.txbPosition.Size = new System.Drawing.Size(316, 26);
      this.txbPosition.TabIndex = 7;
      // 
      // labPosition
      // 
      this.labPosition.AutoSize = true;
      this.labPosition.Location = new System.Drawing.Point(1221, 111);
      this.labPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labPosition.Name = "labPosition";
      this.labPosition.Size = new System.Drawing.Size(69, 20);
      this.labPosition.TabIndex = 6;
      this.labPosition.Text = "Position:";
      // 
      // btnDeleteAirport
      // 
      this.btnDeleteAirport.Location = new System.Drawing.Point(1514, 488);
      this.btnDeleteAirport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnDeleteAirport.Name = "btnDeleteAirport";
      this.btnDeleteAirport.Size = new System.Drawing.Size(146, 35);
      this.btnDeleteAirport.TabIndex = 5;
      this.btnDeleteAirport.Text = "Delete";
      this.btnDeleteAirport.UseVisualStyleBackColor = true;
      // 
      // btnModifyAirport
      // 
      this.btnModifyAirport.Location = new System.Drawing.Point(1359, 488);
      this.btnModifyAirport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnModifyAirport.Name = "btnModifyAirport";
      this.btnModifyAirport.Size = new System.Drawing.Size(146, 35);
      this.btnModifyAirport.TabIndex = 4;
      this.btnModifyAirport.Text = "Modify";
      this.btnModifyAirport.UseVisualStyleBackColor = true;
      // 
      // btnAddAirport
      // 
      this.btnAddAirport.Location = new System.Drawing.Point(1204, 488);
      this.btnAddAirport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnAddAirport.Name = "btnAddAirport";
      this.btnAddAirport.Size = new System.Drawing.Size(146, 35);
      this.btnAddAirport.TabIndex = 3;
      this.btnAddAirport.Text = "Add";
      this.btnAddAirport.UseVisualStyleBackColor = true;
      // 
      // labAiportName
      // 
      this.labAiportName.AutoSize = true;
      this.labAiportName.Location = new System.Drawing.Point(1221, 46);
      this.labAiportName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labAiportName.Name = "labAiportName";
      this.labAiportName.Size = new System.Drawing.Size(55, 20);
      this.labAiportName.TabIndex = 2;
      this.labAiportName.Text = "Name:";
      // 
      // txbAirportName
      // 
      this.txbAirportName.Location = new System.Drawing.Point(1341, 42);
      this.txbAirportName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbAirportName.Name = "txbAirportName";
      this.txbAirportName.Size = new System.Drawing.Size(316, 26);
      this.txbAirportName.TabIndex = 1;
      // 
      // listAirports
      // 
      this.listAirports.HideSelection = false;
      this.listAirports.Location = new System.Drawing.Point(10, 31);
      this.listAirports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.listAirports.Name = "listAirports";
      this.listAirports.Size = new System.Drawing.Size(1183, 490);
      this.listAirports.TabIndex = 0;
      this.listAirports.UseCompatibleStateImageBehavior = false;
      // 
      // gbAirplanes
      // 
      this.gbAirplanes.Controls.Add(this.numSpeed);
      this.gbAirplanes.Controls.Add(this.labSpeed);
      this.gbAirplanes.Controls.Add(this.numCapacity);
      this.gbAirplanes.Controls.Add(this.gbTimeOptions);
      this.gbAirplanes.Controls.Add(this.cmbType);
      this.gbAirplanes.Controls.Add(this.labCapacity);
      this.gbAirplanes.Controls.Add(this.labType);
      this.gbAirplanes.Controls.Add(this.txbNameAirport);
      this.gbAirplanes.Controls.Add(this.labNameAirport);
      this.gbAirplanes.Controls.Add(this.button1);
      this.gbAirplanes.Controls.Add(this.button2);
      this.gbAirplanes.Controls.Add(this.button3);
      this.gbAirplanes.Controls.Add(this.labIdAirport);
      this.gbAirplanes.Controls.Add(this.txbIdAirport);
      this.gbAirplanes.Controls.Add(this.listPlane);
      this.gbAirplanes.Location = new System.Drawing.Point(24, 602);
      this.gbAirplanes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.gbAirplanes.Name = "gbAirplanes";
      this.gbAirplanes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.gbAirplanes.Size = new System.Drawing.Size(1678, 532);
      this.gbAirplanes.TabIndex = 12;
      this.gbAirplanes.TabStop = false;
      this.gbAirplanes.Text = "Airplanes";
      // 
      // numSpeed
      // 
      this.numSpeed.Location = new System.Drawing.Point(1341, 215);
      this.numSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
      this.numSpeed.Name = "numSpeed";
      this.numSpeed.Size = new System.Drawing.Size(92, 26);
      this.numSpeed.TabIndex = 16;
      this.numSpeed.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
      // 
      // labSpeed
      // 
      this.labSpeed.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labSpeed.AutoSize = true;
      this.labSpeed.Location = new System.Drawing.Point(1221, 215);
      this.labSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labSpeed.Name = "labSpeed";
      this.labSpeed.Size = new System.Drawing.Size(108, 20);
      this.labSpeed.TabIndex = 15;
      this.labSpeed.Text = "Speed (km/h):";
      // 
      // numCapacity
      // 
      this.numCapacity.Location = new System.Drawing.Point(1558, 215);
      this.numCapacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numCapacity.Name = "numCapacity";
      this.numCapacity.Size = new System.Drawing.Size(92, 26);
      this.numCapacity.TabIndex = 14;
      this.numCapacity.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // gbTimeOptions
      // 
      this.gbTimeOptions.Controls.Add(this.numMaintenance);
      this.gbTimeOptions.Controls.Add(this.labMaintenance);
      this.gbTimeOptions.Controls.Add(this.numDisembarking);
      this.gbTimeOptions.Controls.Add(this.label1);
      this.gbTimeOptions.Controls.Add(this.numEmbarking);
      this.gbTimeOptions.Controls.Add(this.labEmbarking);
      this.gbTimeOptions.Location = new System.Drawing.Point(1226, 274);
      this.gbTimeOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.gbTimeOptions.Name = "gbTimeOptions";
      this.gbTimeOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.gbTimeOptions.Size = new System.Drawing.Size(434, 205);
      this.gbTimeOptions.TabIndex = 13;
      this.gbTimeOptions.TabStop = false;
      this.gbTimeOptions.Text = "Time (Minutes)";
      // 
      // numMaintenance
      // 
      this.numMaintenance.Location = new System.Drawing.Point(116, 151);
      this.numMaintenance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numMaintenance.Name = "numMaintenance";
      this.numMaintenance.Size = new System.Drawing.Size(308, 26);
      this.numMaintenance.TabIndex = 9;
      this.numMaintenance.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // labMaintenance
      // 
      this.labMaintenance.AutoSize = true;
      this.labMaintenance.Location = new System.Drawing.Point(9, 154);
      this.labMaintenance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labMaintenance.Name = "labMaintenance";
      this.labMaintenance.Size = new System.Drawing.Size(105, 20);
      this.labMaintenance.TabIndex = 8;
      this.labMaintenance.Text = "Maintenance:";
      // 
      // numDisembarking
      // 
      this.numDisembarking.Location = new System.Drawing.Point(117, 100);
      this.numDisembarking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numDisembarking.Name = "numDisembarking";
      this.numDisembarking.Size = new System.Drawing.Size(308, 26);
      this.numDisembarking.TabIndex = 3;
      this.numDisembarking.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 103);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(110, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Disembarking:";
      // 
      // numEmbarking
      // 
      this.numEmbarking.Location = new System.Drawing.Point(116, 49);
      this.numEmbarking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numEmbarking.Name = "numEmbarking";
      this.numEmbarking.Size = new System.Drawing.Size(308, 26);
      this.numEmbarking.TabIndex = 1;
      this.numEmbarking.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // labEmbarking
      // 
      this.labEmbarking.AutoSize = true;
      this.labEmbarking.Location = new System.Drawing.Point(9, 52);
      this.labEmbarking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labEmbarking.Name = "labEmbarking";
      this.labEmbarking.Size = new System.Drawing.Size(89, 20);
      this.labEmbarking.TabIndex = 0;
      this.labEmbarking.Text = "Embarking:";
      // 
      // cmbType
      // 
      this.cmbType.FormattingEnabled = true;
      this.cmbType.Items.AddRange(new object[] {
            "Passenger",
            "Cargo",
            "Fight",
            "Rescue",
            "Scout"});
      this.cmbType.Location = new System.Drawing.Point(1341, 154);
      this.cmbType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size(316, 28);
      this.cmbType.TabIndex = 12;
      this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
      // 
      // labCapacity
      // 
      this.labCapacity.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labCapacity.AutoSize = true;
      this.labCapacity.Location = new System.Drawing.Point(1448, 215);
      this.labCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labCapacity.Name = "labCapacity";
      this.labCapacity.Size = new System.Drawing.Size(107, 20);
      this.labCapacity.TabIndex = 10;
      this.labCapacity.Text = "Max Capacity:";
      // 
      // labType
      // 
      this.labType.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labType.AutoSize = true;
      this.labType.Location = new System.Drawing.Point(1221, 154);
      this.labType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labType.Name = "labType";
      this.labType.Size = new System.Drawing.Size(47, 20);
      this.labType.TabIndex = 8;
      this.labType.Text = "Type:";
      // 
      // txbNameAirport
      // 
      this.txbNameAirport.Location = new System.Drawing.Point(1341, 97);
      this.txbNameAirport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbNameAirport.Name = "txbNameAirport";
      this.txbNameAirport.Size = new System.Drawing.Size(316, 26);
      this.txbNameAirport.TabIndex = 7;
      // 
      // labNameAirport
      // 
      this.labNameAirport.AutoSize = true;
      this.labNameAirport.Location = new System.Drawing.Point(1221, 97);
      this.labNameAirport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labNameAirport.Name = "labNameAirport";
      this.labNameAirport.Size = new System.Drawing.Size(55, 20);
      this.labNameAirport.TabIndex = 6;
      this.labNameAirport.Text = "Name:";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(1514, 488);
      this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(146, 35);
      this.button1.TabIndex = 5;
      this.button1.Text = "Delete";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(1359, 488);
      this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(146, 35);
      this.button2.TabIndex = 4;
      this.button2.Text = "Modify";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(1204, 488);
      this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(146, 35);
      this.button3.TabIndex = 3;
      this.button3.Text = "Add";
      this.button3.UseVisualStyleBackColor = true;
      // 
      // labIdAirport
      // 
      this.labIdAirport.AutoSize = true;
      this.labIdAirport.Location = new System.Drawing.Point(1221, 46);
      this.labIdAirport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labIdAirport.Name = "labIdAirport";
      this.labIdAirport.Size = new System.Drawing.Size(75, 20);
      this.labIdAirport.TabIndex = 2;
      this.labIdAirport.Text = "Identifier:";
      // 
      // txbIdAirport
      // 
      this.txbIdAirport.Location = new System.Drawing.Point(1341, 42);
      this.txbIdAirport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbIdAirport.Name = "txbIdAirport";
      this.txbIdAirport.Size = new System.Drawing.Size(316, 26);
      this.txbIdAirport.TabIndex = 1;
      // 
      // listPlane
      // 
      this.listPlane.HideSelection = false;
      this.listPlane.Location = new System.Drawing.Point(10, 31);
      this.listPlane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.listPlane.Name = "listPlane";
      this.listPlane.Size = new System.Drawing.Size(1183, 490);
      this.listPlane.TabIndex = 0;
      this.listPlane.UseCompatibleStateImageBehavior = false;
      // 
      // toolStripDropDownButton1
      // 
      this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
      this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
      this.toolStripDropDownButton1.Size = new System.Drawing.Size(164, 22);
      this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
      // 
      // toolStrip
      // 
      this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFile,
            this.toolMusic});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.toolStrip.Size = new System.Drawing.Size(1730, 34);
      this.toolStrip.TabIndex = 13;
      this.toolStrip.Text = "toolStrip1";
      // 
      // toolFile
      // 
      this.toolFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subToolOpen,
            this.subToolNew,
            this.subToolSave,
            this.subToolDelete});
      this.toolFile.Image = ((System.Drawing.Image)(resources.GetObject("toolFile.Image")));
      this.toolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolFile.Name = "toolFile";
      this.toolFile.Size = new System.Drawing.Size(56, 29);
      this.toolFile.Text = "File";
      // 
      // subToolOpen
      // 
      this.subToolOpen.Name = "subToolOpen";
      this.subToolOpen.Size = new System.Drawing.Size(242, 34);
      this.subToolOpen.Text = "Open Scenario...";
      // 
      // subToolNew
      // 
      this.subToolNew.Name = "subToolNew";
      this.subToolNew.Size = new System.Drawing.Size(242, 34);
      this.subToolNew.Text = "New Scenario...";
      // 
      // subToolSave
      // 
      this.subToolSave.Name = "subToolSave";
      this.subToolSave.Size = new System.Drawing.Size(242, 34);
      this.subToolSave.Text = "Save Scenario";
      // 
      // subToolDelete
      // 
      this.subToolDelete.Name = "subToolDelete";
      this.subToolDelete.Size = new System.Drawing.Size(242, 34);
      this.subToolDelete.Text = "Delete Scenario";
      // 
      // toolMusic
      // 
      this.toolMusic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolMusic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subToolStart,
            this.subToolStop});
      this.toolMusic.Image = ((System.Drawing.Image)(resources.GetObject("toolMusic.Image")));
      this.toolMusic.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolMusic.Name = "toolMusic";
      this.toolMusic.Size = new System.Drawing.Size(76, 29);
      this.toolMusic.Text = "Music";
      // 
      // subToolStart
      // 
      this.subToolStart.Name = "subToolStart";
      this.subToolStart.Size = new System.Drawing.Size(151, 34);
      this.subToolStart.Text = "Start";
      this.subToolStart.Click += new System.EventHandler(this.subToolStart_Click);
      // 
      // subToolStop
      // 
      this.subToolStop.Name = "subToolStop";
      this.subToolStop.Size = new System.Drawing.Size(151, 34);
      this.subToolStop.Text = "Stop";
      this.subToolStop.Click += new System.EventHandler(this.subToolStop_Click);
      // 
      // FormGenerator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1730, 1149);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.gbAirplanes);
      this.Controls.Add(this.gbAirports);
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "FormGenerator";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "FormGenerator";
      this.Load += new System.EventHandler(this.FormGenerator_Load);
      this.gbAirports.ResumeLayout(false);
      this.gbAirports.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numMTraffic)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numPTraffic)).EndInit();
      this.gbAirplanes.ResumeLayout(false);
      this.gbAirplanes.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
      this.gbTimeOptions.ResumeLayout(false);
      this.gbTimeOptions.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numMaintenance)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numDisembarking)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numEmbarking)).EndInit();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private GroupBox gbAirports;
    private Label labPTraffic;
    private TextBox txbPosition;
    private Label labPosition;
    private Button btnDeleteAirport;
    private Button btnModifyAirport;
    private Button btnAddAirport;
    private Label labAiportName;
    private TextBox txbAirportName;
    private ListView listAirports;
    private NumericUpDown numMTraffic;
    private Label labMTraffic;
    private NumericUpDown numPTraffic;
    private GroupBox gbAirplanes;
    private GroupBox gbTimeOptions;
    private ComboBox cmbType;
    private Label labCapacity;
    private Label labType;
    private TextBox txbNameAirport;
    private Label labNameAirport;
    private Button button1;
    private Button button2;
    private Button button3;
    private Label labIdAirport;
    private TextBox txbIdAirport;
    private ListView listPlane;
    private NumericUpDown numMaintenance;
    private Label labMaintenance;
    private NumericUpDown numDisembarking;
    private Label label1;
    private NumericUpDown numEmbarking;
    private Label labEmbarking;
    private NumericUpDown numSpeed;
    private Label labSpeed;
    private NumericUpDown numCapacity;
    private ToolStripDropDownButton toolStripDropDownButton1;
    private ToolStrip toolStrip;
    private ToolStripDropDownButton toolFile;
    private ToolStripMenuItem subToolOpen;
    private ToolStripMenuItem subToolNew;
    private ToolStripMenuItem subToolSave;
    private ToolStripMenuItem subToolDelete;
    private ToolStripDropDownButton toolMusic;
    private ToolStripMenuItem subToolStart;
    private ToolStripMenuItem subToolStop;
  }
}