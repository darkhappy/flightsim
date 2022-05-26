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
      this.labAirportId = new System.Windows.Forms.Label();
      this.txbAirportId = new System.Windows.Forms.TextBox();
      this.gbTraffic = new System.Windows.Forms.GroupBox();
      this.numPTraffic = new System.Windows.Forms.NumericUpDown();
      this.numCTraffic = new System.Windows.Forms.NumericUpDown();
      this.labPTraffic = new System.Windows.Forms.Label();
      this.labCTraffic = new System.Windows.Forms.Label();
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
      this.txbAirplaneName = new System.Windows.Forms.TextBox();
      this.labNameAirport = new System.Windows.Forms.Label();
      this.btnDeleteAirplane = new System.Windows.Forms.Button();
      this.btnModifyAirplane = new System.Windows.Forms.Button();
      this.btnAddAirplane = new System.Windows.Forms.Button();
      this.labAirplaneId = new System.Windows.Forms.Label();
      this.txbAirplaneId = new System.Windows.Forms.TextBox();
      this.listAirplanes = new System.Windows.Forms.ListView();
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
      this.labError = new System.Windows.Forms.Label();
      this.gbAirports.SuspendLayout();
      this.gbTraffic.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numPTraffic)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCTraffic)).BeginInit();
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
      this.gbAirports.Controls.Add(this.labAirportId);
      this.gbAirports.Controls.Add(this.txbAirportId);
      this.gbAirports.Controls.Add(this.gbTraffic);
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
      // labAirportId
      // 
      this.labAirportId.AutoSize = true;
      this.labAirportId.Location = new System.Drawing.Point(1221, 33);
      this.labAirportId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labAirportId.Name = "labAirportId";
      this.labAirportId.Size = new System.Drawing.Size(75, 20);
      this.labAirportId.TabIndex = 14;
      this.labAirportId.Text = "Identifier:";
      // 
      // txbAirportId
      // 
      this.txbAirportId.Location = new System.Drawing.Point(1341, 29);
      this.txbAirportId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbAirportId.Name = "txbAirportId";
      this.txbAirportId.Size = new System.Drawing.Size(316, 26);
      this.txbAirportId.TabIndex = 13;
      // 
      // gbTraffic
      // 
      this.gbTraffic.Controls.Add(this.numPTraffic);
      this.gbTraffic.Controls.Add(this.numCTraffic);
      this.gbTraffic.Controls.Add(this.labPTraffic);
      this.gbTraffic.Controls.Add(this.labCTraffic);
      this.gbTraffic.Location = new System.Drawing.Point(1226, 220);
      this.gbTraffic.Name = "gbTraffic";
      this.gbTraffic.Size = new System.Drawing.Size(434, 168);
      this.gbTraffic.TabIndex = 12;
      this.gbTraffic.TabStop = false;
      this.gbTraffic.Text = "Traffic (Min: 1, Max: 10)";
      // 
      // numPTraffic
      // 
      this.numPTraffic.Location = new System.Drawing.Point(189, 55);
      this.numPTraffic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numPTraffic.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numPTraffic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numPTraffic.Name = "numPTraffic";
      this.numPTraffic.Size = new System.Drawing.Size(235, 26);
      this.numPTraffic.TabIndex = 9;
      this.numPTraffic.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // numCTraffic
      // 
      this.numCTraffic.Location = new System.Drawing.Point(189, 110);
      this.numCTraffic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numCTraffic.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numCTraffic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numCTraffic.Name = "numCTraffic";
      this.numCTraffic.Size = new System.Drawing.Size(235, 26);
      this.numCTraffic.TabIndex = 11;
      this.numCTraffic.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // labPTraffic
      // 
      this.labPTraffic.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labPTraffic.AutoSize = true;
      this.labPTraffic.Location = new System.Drawing.Point(10, 55);
      this.labPTraffic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labPTraffic.Name = "labPTraffic";
      this.labPTraffic.Size = new System.Drawing.Size(137, 20);
      this.labPTraffic.TabIndex = 8;
      this.labPTraffic.Text = "Passenger Traffic:";
      // 
      // labCTraffic
      // 
      this.labCTraffic.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labCTraffic.AutoSize = true;
      this.labCTraffic.Location = new System.Drawing.Point(10, 112);
      this.labCTraffic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labCTraffic.Name = "labCTraffic";
      this.labCTraffic.Size = new System.Drawing.Size(104, 20);
      this.labCTraffic.TabIndex = 10;
      this.labCTraffic.Text = "Cargo Traffic:";
      // 
      // txbPosition
      // 
      this.txbPosition.Location = new System.Drawing.Point(1341, 157);
      this.txbPosition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbPosition.Name = "txbPosition";
      this.txbPosition.Size = new System.Drawing.Size(316, 26);
      this.txbPosition.TabIndex = 7;
      // 
      // labPosition
      // 
      this.labPosition.AutoSize = true;
      this.labPosition.Location = new System.Drawing.Point(1221, 157);
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
      this.btnAddAirport.Click += new System.EventHandler(this.btnAddAirport_Click);
      // 
      // labAiportName
      // 
      this.labAiportName.AutoSize = true;
      this.labAiportName.Location = new System.Drawing.Point(1221, 92);
      this.labAiportName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labAiportName.Name = "labAiportName";
      this.labAiportName.Size = new System.Drawing.Size(55, 20);
      this.labAiportName.TabIndex = 2;
      this.labAiportName.Text = "Name:";
      // 
      // txbAirportName
      // 
      this.txbAirportName.Location = new System.Drawing.Point(1341, 88);
      this.txbAirportName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbAirportName.Name = "txbAirportName";
      this.txbAirportName.Size = new System.Drawing.Size(316, 26);
      this.txbAirportName.TabIndex = 1;
      // 
      // listAirports
      // 
      this.listAirports.FullRowSelect = true;
      this.listAirports.HideSelection = false;
      this.listAirports.Location = new System.Drawing.Point(10, 31);
      this.listAirports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.listAirports.MultiSelect = false;
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
      this.gbAirplanes.Controls.Add(this.txbAirplaneName);
      this.gbAirplanes.Controls.Add(this.labNameAirport);
      this.gbAirplanes.Controls.Add(this.btnDeleteAirplane);
      this.gbAirplanes.Controls.Add(this.btnModifyAirplane);
      this.gbAirplanes.Controls.Add(this.btnAddAirplane);
      this.gbAirplanes.Controls.Add(this.labAirplaneId);
      this.gbAirplanes.Controls.Add(this.txbAirplaneId);
      this.gbAirplanes.Controls.Add(this.listAirplanes);
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
      this.numMaintenance.Location = new System.Drawing.Point(188, 151);
      this.numMaintenance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numMaintenance.Name = "numMaintenance";
      this.numMaintenance.Size = new System.Drawing.Size(236, 26);
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
      this.numDisembarking.Location = new System.Drawing.Point(189, 100);
      this.numDisembarking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numDisembarking.Name = "numDisembarking";
      this.numDisembarking.Size = new System.Drawing.Size(236, 26);
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
      this.numEmbarking.Location = new System.Drawing.Point(188, 49);
      this.numEmbarking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.numEmbarking.Name = "numEmbarking";
      this.numEmbarking.Size = new System.Drawing.Size(236, 26);
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
      this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
      // txbAirplaneName
      // 
      this.txbAirplaneName.Location = new System.Drawing.Point(1341, 97);
      this.txbAirplaneName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbAirplaneName.Name = "txbAirplaneName";
      this.txbAirplaneName.Size = new System.Drawing.Size(316, 26);
      this.txbAirplaneName.TabIndex = 7;
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
      // btnDeleteAirplane
      // 
      this.btnDeleteAirplane.Location = new System.Drawing.Point(1514, 488);
      this.btnDeleteAirplane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnDeleteAirplane.Name = "btnDeleteAirplane";
      this.btnDeleteAirplane.Size = new System.Drawing.Size(146, 35);
      this.btnDeleteAirplane.TabIndex = 5;
      this.btnDeleteAirplane.Text = "Delete";
      this.btnDeleteAirplane.UseVisualStyleBackColor = true;
      // 
      // btnModifyAirplane
      // 
      this.btnModifyAirplane.Location = new System.Drawing.Point(1359, 488);
      this.btnModifyAirplane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnModifyAirplane.Name = "btnModifyAirplane";
      this.btnModifyAirplane.Size = new System.Drawing.Size(146, 35);
      this.btnModifyAirplane.TabIndex = 4;
      this.btnModifyAirplane.Text = "Modify";
      this.btnModifyAirplane.UseVisualStyleBackColor = true;
      // 
      // btnAddAirplane
      // 
      this.btnAddAirplane.Location = new System.Drawing.Point(1204, 488);
      this.btnAddAirplane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnAddAirplane.Name = "btnAddAirplane";
      this.btnAddAirplane.Size = new System.Drawing.Size(146, 35);
      this.btnAddAirplane.TabIndex = 3;
      this.btnAddAirplane.Text = "Add";
      this.btnAddAirplane.UseVisualStyleBackColor = true;
      this.btnAddAirplane.Click += new System.EventHandler(this.btnAddAirplane_Click);
      // 
      // labAirplaneId
      // 
      this.labAirplaneId.AutoSize = true;
      this.labAirplaneId.Location = new System.Drawing.Point(1221, 46);
      this.labAirplaneId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labAirplaneId.Name = "labAirplaneId";
      this.labAirplaneId.Size = new System.Drawing.Size(75, 20);
      this.labAirplaneId.TabIndex = 2;
      this.labAirplaneId.Text = "Identifier:";
      // 
      // txbAirplaneId
      // 
      this.txbAirplaneId.Location = new System.Drawing.Point(1341, 42);
      this.txbAirplaneId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txbAirplaneId.Name = "txbAirplaneId";
      this.txbAirplaneId.Size = new System.Drawing.Size(316, 26);
      this.txbAirplaneId.TabIndex = 1;
      // 
      // listAirplanes
      // 
      this.listAirplanes.FullRowSelect = true;
      this.listAirplanes.HideSelection = false;
      this.listAirplanes.Location = new System.Drawing.Point(10, 31);
      this.listAirplanes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.listAirplanes.MultiSelect = false;
      this.listAirplanes.Name = "listAirplanes";
      this.listAirplanes.Size = new System.Drawing.Size(1183, 490);
      this.listAirplanes.TabIndex = 0;
      this.listAirplanes.UseCompatibleStateImageBehavior = false;
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
      // labError
      // 
      this.labError.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.labError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labError.ForeColor = System.Drawing.Color.Red;
      this.labError.Location = new System.Drawing.Point(24, 1139);
      this.labError.Name = "labError";
      this.labError.Size = new System.Drawing.Size(1678, 31);
      this.labError.TabIndex = 12;
      this.labError.Text = "Error: This is an invisible error, please change text to fit your need";
      this.labError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.labError.Visible = false;
      // 
      // FormGenerator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1730, 1179);
      this.Controls.Add(this.labError);
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
      this.gbTraffic.ResumeLayout(false);
      this.gbTraffic.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numPTraffic)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numCTraffic)).EndInit();
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
    private NumericUpDown numCTraffic;
    private Label labCTraffic;
    private NumericUpDown numPTraffic;
    private GroupBox gbAirplanes;
    private GroupBox gbTimeOptions;
    private ComboBox cmbType;
    private Label labCapacity;
    private Label labType;
    private TextBox txbAirplaneName;
    private Label labNameAirport;
    private Button btnDeleteAirplane;
    private Button btnModifyAirplane;
    private Button btnAddAirplane;
    private Label labAirplaneId;
    private TextBox txbAirplaneId;
    private ListView listAirplanes;
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
    private Label labError;
    private GroupBox gbTraffic;
    private Label labAirportId;
    private TextBox txbAirportId;
  }
}