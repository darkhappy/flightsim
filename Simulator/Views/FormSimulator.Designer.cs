
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimulator));
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.toolFile = new System.Windows.Forms.ToolStripDropDownButton();
      this.subToolOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.subToolNew = new System.Windows.Forms.ToolStripMenuItem();
      this.mapPanel = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.grpPanes = new System.Windows.Forms.GroupBox();
      this.listAirplanes = new System.Windows.Forms.ListView();
      this.grpClients = new System.Windows.Forms.GroupBox();
      this.grpAirport = new System.Windows.Forms.GroupBox();
      this.listAirports = new System.Windows.Forms.ListView();
      this.listClients = new System.Windows.Forms.ListView();
      this.toolStrip.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.grpPanes.SuspendLayout();
      this.grpClients.SuspendLayout();
      this.grpAirport.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip
      // 
      this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFile});
      this.toolStrip.Location = new System.Drawing.Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(1144, 25);
      this.toolStrip.TabIndex = 14;
      this.toolStrip.Text = "toolStrip1";
      // 
      // toolFile
      // 
      this.toolFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subToolOpen,
            this.subToolNew});
      this.toolFile.Image = ((System.Drawing.Image)(resources.GetObject("toolFile.Image")));
      this.toolFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolFile.Name = "toolFile";
      this.toolFile.Size = new System.Drawing.Size(77, 22);
      this.toolFile.Text = "Simulation";
      // 
      // subToolOpen
      // 
      this.subToolOpen.Name = "subToolOpen";
      this.subToolOpen.Size = new System.Drawing.Size(156, 22);
      this.subToolOpen.Text = "Load a scenario";
      // 
      // subToolNew
      // 
      this.subToolNew.Name = "subToolNew";
      this.subToolNew.Size = new System.Drawing.Size(156, 22);
      this.subToolNew.Text = "Pause";
      this.subToolNew.Click += new System.EventHandler(this.subToolNew_Click);
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
      this.grpPanes.Size = new System.Drawing.Size(537, 155);
      this.grpPanes.TabIndex = 3;
      this.grpPanes.TabStop = false;
      this.grpPanes.Text = "Planes";
      // 
      // listAirplanes
      // 
      this.listAirplanes.HideSelection = false;
      this.listAirplanes.Location = new System.Drawing.Point(6, 14);
      this.listAirplanes.Name = "listAirplanes";
      this.listAirplanes.Size = new System.Drawing.Size(525, 136);
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
      // listClients
      // 
      this.listClients.HideSelection = false;
      this.listClients.Location = new System.Drawing.Point(6, 16);
      this.listClients.Name = "listClients";
      this.listClients.Size = new System.Drawing.Size(361, 134);
      this.listClients.TabIndex = 2;
      this.listClients.UseCompatibleStateImageBehavior = false;
      // 
      // FormSimulator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1144, 846);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.mapPanel);
      this.Controls.Add(this.toolStrip);
      this.Name = "FormSimulator";
      this.Text = "FormSimulator";
      this.Load += new System.EventHandler(this.FormSimulator_Load);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.grpPanes.ResumeLayout(false);
      this.grpClients.ResumeLayout(false);
      this.grpAirport.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripDropDownButton toolFile;
    private System.Windows.Forms.ToolStripMenuItem subToolOpen;
    private System.Windows.Forms.ToolStripMenuItem subToolNew;
    private System.Windows.Forms.Panel mapPanel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox grpPanes;
    private System.Windows.Forms.GroupBox grpClients;
    private System.Windows.Forms.GroupBox grpAirport;
    private System.Windows.Forms.ListView listAirports;
    private System.Windows.Forms.ListView listAirplanes;
    private System.Windows.Forms.ListView listClients;
  }
}