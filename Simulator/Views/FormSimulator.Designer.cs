
namespace Simulator.Views
{
  partial class FormSimulator
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimulator));
      this.menueSim = new System.Windows.Forms.ToolStrip();
      this.toolFile = new System.Windows.Forms.ToolStripDropDownButton();
      this.loadScenario = new System.Windows.Forms.ToolStripMenuItem();
      this.pauseSim = new System.Windows.Forms.ToolStripMenuItem();
      this.startSim = new System.Windows.Forms.ToolStripMenuItem();
      this.mapPanel = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.grpPanes = new System.Windows.Forms.GroupBox();
      this.listAirplanes = new System.Windows.Forms.ListView();
      this.grpClients = new System.Windows.Forms.GroupBox();
      this.listClients = new System.Windows.Forms.ListView();
      this.grpAirport = new System.Windows.Forms.GroupBox();
      this.listAirports = new System.Windows.Forms.ListView();
      this.timerText = new System.Windows.Forms.TextBox();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.speedUpDown = new System.Windows.Forms.NumericUpDown();
      this.speedLbl = new System.Windows.Forms.Label();
      this.checkMute = new System.Windows.Forms.CheckBox();
      this.menueSim.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.grpPanes.SuspendLayout();
      this.grpClients.SuspendLayout();
      this.grpAirport.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.speedUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // menueSim
      // 
      this.menueSim.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menueSim.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFile});
      this.menueSim.Location = new System.Drawing.Point(0, 0);
      this.menueSim.Name = "menueSim";
      this.menueSim.Size = new System.Drawing.Size(1144, 25);
      this.menueSim.TabIndex = 14;
      this.menueSim.Text = "toolStrip1";
      // 
      // toolFile
      // 
      this.toolFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadScenario,
            this.pauseSim,
            this.startSim});
      this.toolFile.Image = ((System.Drawing.Image)(resources.GetObject("toolFile.Image")));
      this.toolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolFile.Name = "toolFile";
      this.toolFile.Size = new System.Drawing.Size(77, 22);
      this.toolFile.Text = "Simulation";
      // 
      // loadScenario
      // 
      this.loadScenario.Name = "loadScenario";
      this.loadScenario.Size = new System.Drawing.Size(180, 22);
      this.loadScenario.Text = "Load a scenario";
      this.loadScenario.Click += new System.EventHandler(this.loadScenario_Click);
      // 
      // pauseSim
      // 
      this.pauseSim.Name = "pauseSim";
      this.pauseSim.Size = new System.Drawing.Size(180, 22);
      this.pauseSim.Text = "Pause";
      this.pauseSim.Click += new System.EventHandler(this.pauseSim_Click);
      // 
      // startSim
      // 
      this.startSim.Name = "startSim";
      this.startSim.Size = new System.Drawing.Size(180, 22);
      this.startSim.Text = "Start";
      this.startSim.Click += new System.EventHandler(this.startSim_Click);
      // 
      // mapPanel
      // 
      this.mapPanel.Location = new System.Drawing.Point(11, 206);
      this.mapPanel.Name = "mapPanel";
      this.mapPanel.Size = new System.Drawing.Size(1125, 630);
      this.mapPanel.TabIndex = 15;
      this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanel_Paint);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.grpPanes);
      this.groupBox1.Controls.Add(this.grpClients);
      this.groupBox1.Controls.Add(this.grpAirport);
      this.groupBox1.Location = new System.Drawing.Point(11, 28);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1129, 172);
      this.groupBox1.TabIndex = 16;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Elements of the simulation";
      // 
      // grpPanes
      // 
      this.grpPanes.Controls.Add(this.listAirplanes);
      this.grpPanes.Location = new System.Drawing.Point(588, 13);
      this.grpPanes.Name = "grpPanes";
      this.grpPanes.Size = new System.Drawing.Size(539, 155);
      this.grpPanes.TabIndex = 3;
      this.grpPanes.TabStop = false;
      this.grpPanes.Text = "Planes";
      // 
      // listAirplanes
      // 
      this.listAirplanes.HideSelection = false;
      this.listAirplanes.Location = new System.Drawing.Point(6, 14);
      this.listAirplanes.Name = "listAirplanes";
      this.listAirplanes.Size = new System.Drawing.Size(527, 136);
      this.listAirplanes.TabIndex = 1;
      this.listAirplanes.UseCompatibleStateImageBehavior = false;
      // 
      // grpClients
      // 
      this.grpClients.Controls.Add(this.listClients);
      this.grpClients.Location = new System.Drawing.Point(210, 13);
      this.grpClients.Name = "grpClients";
      this.grpClients.Size = new System.Drawing.Size(372, 155);
      this.grpClients.TabIndex = 1;
      this.grpClients.TabStop = false;
      this.grpClients.Text = "Clients";
      // 
      // listClients
      // 
      this.listClients.HideSelection = false;
      this.listClients.Location = new System.Drawing.Point(6, 16);
      this.listClients.Name = "listClients";
      this.listClients.Size = new System.Drawing.Size(361, 134);
      this.listClients.TabIndex = 2;
      this.listClients.UseCompatibleStateImageBehavior = false;
      // 
      // grpAirport
      // 
      this.grpAirport.Controls.Add(this.listAirports);
      this.grpAirport.Location = new System.Drawing.Point(6, 13);
      this.grpAirport.Name = "grpAirport";
      this.grpAirport.Size = new System.Drawing.Size(198, 155);
      this.grpAirport.TabIndex = 0;
      this.grpAirport.TabStop = false;
      this.grpAirport.Text = "Airports";
      // 
      // listAirports
      // 
      this.listAirports.HideSelection = false;
      this.listAirports.Location = new System.Drawing.Point(6, 16);
      this.listAirports.Name = "listAirports";
      this.listAirports.Size = new System.Drawing.Size(186, 134);
      this.listAirports.TabIndex = 0;
      this.listAirports.UseCompatibleStateImageBehavior = false;
      this.listAirports.SelectedIndexChanged += new System.EventHandler(this.listAirports_SelectedIndexChanged);
      // 
      // timerText
      // 
      this.timerText.Location = new System.Drawing.Point(988, 12);
      this.timerText.Name = "timerText";
      this.timerText.ReadOnly = true;
      this.timerText.Size = new System.Drawing.Size(144, 20);
      this.timerText.TabIndex = 4;
      // 
      // timer
      // 
      this.timer.Interval = 1;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // speedUpDown
      // 
      this.speedUpDown.Location = new System.Drawing.Point(936, 12);
      this.speedUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.speedUpDown.Name = "speedUpDown";
      this.speedUpDown.ReadOnly = true;
      this.speedUpDown.Size = new System.Drawing.Size(46, 20);
      this.speedUpDown.TabIndex = 0;
      this.speedUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.speedUpDown.ValueChanged += new System.EventHandler(this.speedUpDown_ValueChanged);
      // 
      // speedLbl
      // 
      this.speedLbl.AutoSize = true;
      this.speedLbl.Location = new System.Drawing.Point(842, 14);
      this.speedLbl.Name = "speedLbl";
      this.speedLbl.Size = new System.Drawing.Size(88, 13);
      this.speedLbl.TabIndex = 17;
      this.speedLbl.Text = "Time span speed";
      // 
      // checkMute
      // 
      this.checkMute.AutoSize = true;
      this.checkMute.Location = new System.Drawing.Point(91, 5);
      this.checkMute.Name = "checkMute";
      this.checkMute.Size = new System.Drawing.Size(80, 17);
      this.checkMute.TabIndex = 18;
      this.checkMute.Text = "Mute music";
      this.checkMute.UseVisualStyleBackColor = true;
      this.checkMute.CheckedChanged += new System.EventHandler(this.checkMute_CheckedChanged);
      // 
      // FormSimulator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1144, 846);
      this.Controls.Add(this.checkMute);
      this.Controls.Add(this.speedLbl);
      this.Controls.Add(this.speedUpDown);
      this.Controls.Add(this.timerText);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.mapPanel);
      this.Controls.Add(this.menueSim);
      this.Name = "FormSimulator";
      this.Text = "FormSimulator";
      this.Load += new System.EventHandler(this.FormSimulator_Load);
      this.menueSim.ResumeLayout(false);
      this.menueSim.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.grpPanes.ResumeLayout(false);
      this.grpClients.ResumeLayout(false);
      this.grpAirport.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.speedUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip menueSim;
    private System.Windows.Forms.ToolStripDropDownButton toolFile;
    private System.Windows.Forms.ToolStripMenuItem loadScenario;
    private System.Windows.Forms.ToolStripMenuItem pauseSim;
    private System.Windows.Forms.Panel mapPanel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox grpPanes;
    private System.Windows.Forms.GroupBox grpClients;
    private System.Windows.Forms.GroupBox grpAirport;
    private System.Windows.Forms.ListView listAirports;
    private System.Windows.Forms.ListView listAirplanes;
    private System.Windows.Forms.ListView listClients;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.TextBox timerText;
    private System.Windows.Forms.NumericUpDown speedUpDown;
    private System.Windows.Forms.Label speedLbl;
    private System.Windows.Forms.ToolStripMenuItem startSim;
    private System.Windows.Forms.CheckBox checkMute;
  }
}