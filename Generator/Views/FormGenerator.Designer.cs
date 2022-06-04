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
      this.labHelpPosition = new System.Windows.Forms.Label();
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
      this.btnEditAirport = new System.Windows.Forms.Button();
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
      this.btnEditAirplane = new System.Windows.Forms.Button();
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
      this.subToolSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.subToolClose = new System.Windows.Forms.ToolStripMenuItem();
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
      this.gbAirports.Controls.Add(this.labHelpPosition);
      this.gbAirports.Controls.Add(this.labAirportId);
      this.gbAirports.Controls.Add(this.txbAirportId);
      this.gbAirports.Controls.Add(this.gbTraffic);
      this.gbAirports.Controls.Add(this.txbPosition);
      this.gbAirports.Controls.Add(this.labPosition);
      this.gbAirports.Controls.Add(this.btnDeleteAirport);
      this.gbAirports.Controls.Add(this.btnEditAirport);
      this.gbAirports.Controls.Add(this.btnAddAirport);
      this.gbAirports.Controls.Add(this.labAiportName);
      this.gbAirports.Controls.Add(this.txbAirportName);
      this.gbAirports.Controls.Add(this.listAirports);
      this.gbAirports.Location = new System.Drawing.Point(16, 29);
      this.gbAirports.Name = "gbAirports";
      this.gbAirports.Size = new System.Drawing.Size(1119, 346);
      this.gbAirports.TabIndex = 0;
      this.gbAirports.TabStop = false;
      this.gbAirports.Text = "Airports";
      // 
      // labHelpPosition
      // 
      this.labHelpPosition.AutoSize = true;
      this.labHelpPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labHelpPosition.Location = new System.Drawing.Point(891, 88);
      this.labHelpPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labHelpPosition.Name = "labHelpPosition";
      this.labHelpPosition.Size = new System.Drawing.Size(145, 13);
      this.labHelpPosition.TabIndex = 15;
      this.labHelpPosition.Text = "*Click to select a new position";
      // 
      // labAirportId
      // 
      this.labAirportId.AutoSize = true;
      this.labAirportId.Location = new System.Drawing.Point(814, 21);
      this.labAirportId.Name = "labAirportId";
      this.labAirportId.Size = new System.Drawing.Size(50, 13);
      this.labAirportId.TabIndex = 14;
      this.labAirportId.Text = "Identifier:";
      // 
      // txbAirportId
      // 
      this.txbAirportId.Location = new System.Drawing.Point(894, 19);
      this.txbAirportId.Name = "txbAirportId";
      this.txbAirportId.Size = new System.Drawing.Size(212, 20);
      this.txbAirportId.TabIndex = 1;
      // 
      // gbTraffic
      // 
      this.gbTraffic.Controls.Add(this.numPTraffic);
      this.gbTraffic.Controls.Add(this.numCTraffic);
      this.gbTraffic.Controls.Add(this.labPTraffic);
      this.gbTraffic.Controls.Add(this.labCTraffic);
      this.gbTraffic.Location = new System.Drawing.Point(817, 143);
      this.gbTraffic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.gbTraffic.Name = "gbTraffic";
      this.gbTraffic.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.gbTraffic.Size = new System.Drawing.Size(289, 109);
      this.gbTraffic.TabIndex = 4;
      this.gbTraffic.TabStop = false;
      this.gbTraffic.Text = "Traffic (Min: 1, Max: 10)";
      // 
      // numPTraffic
      // 
      this.numPTraffic.Location = new System.Drawing.Point(126, 36);
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
      this.numPTraffic.Size = new System.Drawing.Size(157, 20);
      this.numPTraffic.TabIndex = 1;
      this.numPTraffic.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // numCTraffic
      // 
      this.numCTraffic.Location = new System.Drawing.Point(126, 71);
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
      this.numCTraffic.Size = new System.Drawing.Size(157, 20);
      this.numCTraffic.TabIndex = 2;
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
      this.labPTraffic.Location = new System.Drawing.Point(7, 36);
      this.labPTraffic.Name = "labPTraffic";
      this.labPTraffic.Size = new System.Drawing.Size(93, 13);
      this.labPTraffic.TabIndex = 8;
      this.labPTraffic.Text = "Passenger Traffic:";
      // 
      // labCTraffic
      // 
      this.labCTraffic.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labCTraffic.AutoSize = true;
      this.labCTraffic.Location = new System.Drawing.Point(7, 73);
      this.labCTraffic.Name = "labCTraffic";
      this.labCTraffic.Size = new System.Drawing.Size(71, 13);
      this.labCTraffic.TabIndex = 10;
      this.labCTraffic.Text = "Cargo Traffic:";
      // 
      // txbPosition
      // 
      this.txbPosition.Location = new System.Drawing.Point(894, 102);
      this.txbPosition.Name = "txbPosition";
      this.txbPosition.ReadOnly = true;
      this.txbPosition.Size = new System.Drawing.Size(212, 20);
      this.txbPosition.TabIndex = 3;
      this.txbPosition.Click += new System.EventHandler(this.txbPosition_Click);
      // 
      // labPosition
      // 
      this.labPosition.AutoSize = true;
      this.labPosition.Location = new System.Drawing.Point(814, 102);
      this.labPosition.Name = "labPosition";
      this.labPosition.Size = new System.Drawing.Size(47, 13);
      this.labPosition.TabIndex = 6;
      this.labPosition.Text = "Position:";
      // 
      // btnDeleteAirport
      // 
      this.btnDeleteAirport.Location = new System.Drawing.Point(1009, 317);
      this.btnDeleteAirport.Name = "btnDeleteAirport";
      this.btnDeleteAirport.Size = new System.Drawing.Size(97, 23);
      this.btnDeleteAirport.TabIndex = 7;
      this.btnDeleteAirport.Text = "Delete";
      this.btnDeleteAirport.UseVisualStyleBackColor = true;
      this.btnDeleteAirport.Click += new System.EventHandler(this.btnDeleteAirport_Click);
      // 
      // btnEditAirport
      // 
      this.btnEditAirport.Location = new System.Drawing.Point(906, 317);
      this.btnEditAirport.Name = "btnEditAirport";
      this.btnEditAirport.Size = new System.Drawing.Size(97, 23);
      this.btnEditAirport.TabIndex = 6;
      this.btnEditAirport.Text = "Edit";
      this.btnEditAirport.UseVisualStyleBackColor = true;
      this.btnEditAirport.Click += new System.EventHandler(this.btnEditAirport_Click);
      // 
      // btnAddAirport
      // 
      this.btnAddAirport.Location = new System.Drawing.Point(803, 317);
      this.btnAddAirport.Name = "btnAddAirport";
      this.btnAddAirport.Size = new System.Drawing.Size(97, 23);
      this.btnAddAirport.TabIndex = 5;
      this.btnAddAirport.Text = "Add";
      this.btnAddAirport.UseVisualStyleBackColor = true;
      this.btnAddAirport.Click += new System.EventHandler(this.btnAddAirport_Click);
      // 
      // labAiportName
      // 
      this.labAiportName.AutoSize = true;
      this.labAiportName.Location = new System.Drawing.Point(814, 60);
      this.labAiportName.Name = "labAiportName";
      this.labAiportName.Size = new System.Drawing.Size(38, 13);
      this.labAiportName.TabIndex = 2;
      this.labAiportName.Text = "Name:";
      // 
      // txbAirportName
      // 
      this.txbAirportName.Location = new System.Drawing.Point(894, 57);
      this.txbAirportName.Name = "txbAirportName";
      this.txbAirportName.Size = new System.Drawing.Size(212, 20);
      this.txbAirportName.TabIndex = 2;
      // 
      // listAirports
      // 
      this.listAirports.FullRowSelect = true;
      this.listAirports.HideSelection = false;
      this.listAirports.Location = new System.Drawing.Point(7, 20);
      this.listAirports.MultiSelect = false;
      this.listAirports.Name = "listAirports";
      this.listAirports.Size = new System.Drawing.Size(790, 320);
      this.listAirports.TabIndex = 0;
      this.listAirports.UseCompatibleStateImageBehavior = false;
      this.listAirports.SelectedIndexChanged += new System.EventHandler(this.listAirports_SelectedIndexChanged);
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
      this.gbAirplanes.Controls.Add(this.btnEditAirplane);
      this.gbAirplanes.Controls.Add(this.btnAddAirplane);
      this.gbAirplanes.Controls.Add(this.labAirplaneId);
      this.gbAirplanes.Controls.Add(this.txbAirplaneId);
      this.gbAirplanes.Controls.Add(this.listAirplanes);
      this.gbAirplanes.Location = new System.Drawing.Point(16, 391);
      this.gbAirplanes.Name = "gbAirplanes";
      this.gbAirplanes.Size = new System.Drawing.Size(1119, 346);
      this.gbAirplanes.TabIndex = 2;
      this.gbAirplanes.TabStop = false;
      this.gbAirplanes.Text = "Airplanes";
      // 
      // numSpeed
      // 
      this.numSpeed.Location = new System.Drawing.Point(894, 140);
      this.numSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
      this.numSpeed.Name = "numSpeed";
      this.numSpeed.Size = new System.Drawing.Size(61, 20);
      this.numSpeed.TabIndex = 4;
      this.numSpeed.UseWaitCursor = true;
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
      this.labSpeed.Location = new System.Drawing.Point(814, 140);
      this.labSpeed.Name = "labSpeed";
      this.labSpeed.Size = new System.Drawing.Size(75, 13);
      this.labSpeed.TabIndex = 15;
      this.labSpeed.Text = "Speed (km/h):";
      // 
      // numCapacity
      // 
      this.numCapacity.Location = new System.Drawing.Point(1039, 140);
      this.numCapacity.Name = "numCapacity";
      this.numCapacity.Size = new System.Drawing.Size(61, 20);
      this.numCapacity.TabIndex = 5;
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
      this.gbTimeOptions.Location = new System.Drawing.Point(817, 178);
      this.gbTimeOptions.Name = "gbTimeOptions";
      this.gbTimeOptions.Size = new System.Drawing.Size(289, 133);
      this.gbTimeOptions.TabIndex = 6;
      this.gbTimeOptions.TabStop = false;
      this.gbTimeOptions.Text = "Time (Minutes)";
      // 
      // numMaintenance
      // 
      this.numMaintenance.Location = new System.Drawing.Point(125, 98);
      this.numMaintenance.Name = "numMaintenance";
      this.numMaintenance.Size = new System.Drawing.Size(157, 20);
      this.numMaintenance.TabIndex = 3;
      this.numMaintenance.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // labMaintenance
      // 
      this.labMaintenance.AutoSize = true;
      this.labMaintenance.Location = new System.Drawing.Point(6, 100);
      this.labMaintenance.Name = "labMaintenance";
      this.labMaintenance.Size = new System.Drawing.Size(72, 13);
      this.labMaintenance.TabIndex = 8;
      this.labMaintenance.Text = "Maintenance:";
      // 
      // numDisembarking
      // 
      this.numDisembarking.Location = new System.Drawing.Point(126, 65);
      this.numDisembarking.Name = "numDisembarking";
      this.numDisembarking.Size = new System.Drawing.Size(157, 20);
      this.numDisembarking.TabIndex = 2;
      this.numDisembarking.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 67);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Disembarking:";
      // 
      // numEmbarking
      // 
      this.numEmbarking.Location = new System.Drawing.Point(125, 32);
      this.numEmbarking.Name = "numEmbarking";
      this.numEmbarking.Size = new System.Drawing.Size(157, 20);
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
      this.labEmbarking.Location = new System.Drawing.Point(6, 34);
      this.labEmbarking.Name = "labEmbarking";
      this.labEmbarking.Size = new System.Drawing.Size(60, 13);
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
      this.cmbType.Location = new System.Drawing.Point(894, 100);
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size(212, 21);
      this.cmbType.TabIndex = 3;
      this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
      // 
      // labCapacity
      // 
      this.labCapacity.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labCapacity.AutoSize = true;
      this.labCapacity.Location = new System.Drawing.Point(965, 140);
      this.labCapacity.Name = "labCapacity";
      this.labCapacity.Size = new System.Drawing.Size(74, 13);
      this.labCapacity.TabIndex = 10;
      this.labCapacity.Text = "Max Capacity:";
      // 
      // labType
      // 
      this.labType.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
      this.labType.AutoSize = true;
      this.labType.Location = new System.Drawing.Point(814, 100);
      this.labType.Name = "labType";
      this.labType.Size = new System.Drawing.Size(34, 13);
      this.labType.TabIndex = 8;
      this.labType.Text = "Type:";
      // 
      // txbAirplaneName
      // 
      this.txbAirplaneName.Location = new System.Drawing.Point(894, 63);
      this.txbAirplaneName.Name = "txbAirplaneName";
      this.txbAirplaneName.Size = new System.Drawing.Size(212, 20);
      this.txbAirplaneName.TabIndex = 2;
      // 
      // labNameAirport
      // 
      this.labNameAirport.AutoSize = true;
      this.labNameAirport.Location = new System.Drawing.Point(814, 63);
      this.labNameAirport.Name = "labNameAirport";
      this.labNameAirport.Size = new System.Drawing.Size(38, 13);
      this.labNameAirport.TabIndex = 6;
      this.labNameAirport.Text = "Name:";
      // 
      // btnDeleteAirplane
      // 
      this.btnDeleteAirplane.Location = new System.Drawing.Point(1009, 317);
      this.btnDeleteAirplane.Name = "btnDeleteAirplane";
      this.btnDeleteAirplane.Size = new System.Drawing.Size(97, 23);
      this.btnDeleteAirplane.TabIndex = 9;
      this.btnDeleteAirplane.Text = "Delete";
      this.btnDeleteAirplane.UseVisualStyleBackColor = true;
      this.btnDeleteAirplane.Click += new System.EventHandler(this.btnDeleteAirplane_Click);
      // 
      // btnEditAirplane
      // 
      this.btnEditAirplane.Location = new System.Drawing.Point(906, 317);
      this.btnEditAirplane.Name = "btnEditAirplane";
      this.btnEditAirplane.Size = new System.Drawing.Size(97, 23);
      this.btnEditAirplane.TabIndex = 8;
      this.btnEditAirplane.Text = "Edit";
      this.btnEditAirplane.UseVisualStyleBackColor = true;
      this.btnEditAirplane.Click += new System.EventHandler(this.btnEditAirplane_Click);
      // 
      // btnAddAirplane
      // 
      this.btnAddAirplane.Location = new System.Drawing.Point(803, 317);
      this.btnAddAirplane.Name = "btnAddAirplane";
      this.btnAddAirplane.Size = new System.Drawing.Size(97, 23);
      this.btnAddAirplane.TabIndex = 7;
      this.btnAddAirplane.Text = "Add";
      this.btnAddAirplane.UseVisualStyleBackColor = true;
      this.btnAddAirplane.Click += new System.EventHandler(this.btnAddAirplane_Click);
      // 
      // labAirplaneId
      // 
      this.labAirplaneId.AutoSize = true;
      this.labAirplaneId.Location = new System.Drawing.Point(814, 30);
      this.labAirplaneId.Name = "labAirplaneId";
      this.labAirplaneId.Size = new System.Drawing.Size(50, 13);
      this.labAirplaneId.TabIndex = 2;
      this.labAirplaneId.Text = "Identifier:";
      // 
      // txbAirplaneId
      // 
      this.txbAirplaneId.Location = new System.Drawing.Point(894, 27);
      this.txbAirplaneId.Name = "txbAirplaneId";
      this.txbAirplaneId.Size = new System.Drawing.Size(212, 20);
      this.txbAirplaneId.TabIndex = 1;
      // 
      // listAirplanes
      // 
      this.listAirplanes.FullRowSelect = true;
      this.listAirplanes.HideSelection = false;
      this.listAirplanes.Location = new System.Drawing.Point(7, 20);
      this.listAirplanes.MultiSelect = false;
      this.listAirplanes.Name = "listAirplanes";
      this.listAirplanes.Size = new System.Drawing.Size(790, 320);
      this.listAirplanes.TabIndex = 0;
      this.listAirplanes.UseCompatibleStateImageBehavior = false;
      this.listAirplanes.SelectedIndexChanged += new System.EventHandler(this.listAirplanes_SelectedIndexChanged);
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
      this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
      this.toolStrip.Size = new System.Drawing.Size(1153, 25);
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
            this.subToolSaveAs,
            this.subToolClose});
      this.toolFile.Image = ((System.Drawing.Image)(resources.GetObject("toolFile.Image")));
      this.toolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolFile.Name = "toolFile";
      this.toolFile.Size = new System.Drawing.Size(38, 22);
      this.toolFile.Text = "File";
      // 
      // subToolOpen
      // 
      this.subToolOpen.Name = "subToolOpen";
      this.subToolOpen.Size = new System.Drawing.Size(180, 22);
      this.subToolOpen.Text = "Open...";
      this.subToolOpen.Click += new System.EventHandler(this.subToolOpen_Click);
      // 
      // subToolNew
      // 
      this.subToolNew.Name = "subToolNew";
      this.subToolNew.Size = new System.Drawing.Size(180, 22);
      this.subToolNew.Text = "New...";
      this.subToolNew.Click += new System.EventHandler(this.subToolNew_Click);
      // 
      // subToolSave
      // 
      this.subToolSave.Name = "subToolSave";
      this.subToolSave.Size = new System.Drawing.Size(180, 22);
      this.subToolSave.Text = "Save";
      this.subToolSave.Click += new System.EventHandler(this.subToolSave_Click);
      // 
      // subToolSaveAs
      // 
      this.subToolSaveAs.Name = "subToolSaveAs";
      this.subToolSaveAs.Size = new System.Drawing.Size(180, 22);
      this.subToolSaveAs.Text = "Save as...";
      this.subToolSaveAs.Click += new System.EventHandler(this.subToolSaveAs_Click);
      // 
      // subToolClose
      // 
      this.subToolClose.Name = "subToolClose";
      this.subToolClose.Size = new System.Drawing.Size(180, 22);
      this.subToolClose.Text = "Close";
      this.subToolClose.Click += new System.EventHandler(this.subToolClose_Click);
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
      this.toolMusic.Size = new System.Drawing.Size(52, 22);
      this.toolMusic.Text = "Music";
      // 
      // subToolStart
      // 
      this.subToolStart.Name = "subToolStart";
      this.subToolStart.Size = new System.Drawing.Size(98, 22);
      this.subToolStart.Text = "Start";
      this.subToolStart.Click += new System.EventHandler(this.subToolStart_Click);
      // 
      // subToolStop
      // 
      this.subToolStop.Name = "subToolStop";
      this.subToolStop.Size = new System.Drawing.Size(98, 22);
      this.subToolStop.Text = "Stop";
      this.subToolStop.Click += new System.EventHandler(this.subToolStop_Click);
      // 
      // labError
      // 
      this.labError.Anchor = System.Windows.Forms.AnchorStyles.Right;
      this.labError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labError.ForeColor = System.Drawing.Color.Red;
      this.labError.Location = new System.Drawing.Point(16, 740);
      this.labError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.labError.Name = "labError";
      this.labError.Size = new System.Drawing.Size(1119, 20);
      this.labError.TabIndex = 12;
      this.labError.Text = "Error: This is an invisible error, please change text to fit your need";
      this.labError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.labError.Visible = false;
      // 
      // FormGenerator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1153, 766);
      this.Controls.Add(this.labError);
      this.Controls.Add(this.toolStrip);
      this.Controls.Add(this.gbAirplanes);
      this.Controls.Add(this.gbAirports);
      this.Name = "FormGenerator";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Scenario Generator";
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
    private Button btnEditAirport;
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
    private Button btnEditAirplane;
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
    private ToolStripMenuItem subToolClose;
    private ToolStripDropDownButton toolMusic;
    private ToolStripMenuItem subToolStart;
    private ToolStripMenuItem subToolStop;
    private Label labError;
    private GroupBox gbTraffic;
    private Label labAirportId;
    private TextBox txbAirportId;
    private Label labHelpPosition;
    private ToolStripMenuItem subToolSaveAs;
  }
}