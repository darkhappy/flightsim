
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
      this.lstPlanes = new System.Windows.Forms.ListBox();
      this.grpTasks = new System.Windows.Forms.GroupBox();
      this.lstTasks = new System.Windows.Forms.ListBox();
      this.grpClients = new System.Windows.Forms.GroupBox();
      this.lstClients = new System.Windows.Forms.ListBox();
      this.grpAirport = new System.Windows.Forms.GroupBox();
      this.listAirport = new System.Windows.Forms.ListBox();
      this.toolStrip.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.grpPanes.SuspendLayout();
      this.grpTasks.SuspendLayout();
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
      this.mapPanel.Size = new System.Drawing.Size(1500, 650);
      this.mapPanel.TabIndex = 15;
      this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanel_Paint);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.grpPanes);
      this.groupBox1.Controls.Add(this.grpTasks);
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
      this.grpPanes.Controls.Add(this.lstPlanes);
      this.grpPanes.Location = new System.Drawing.Point(832, 13);
      this.grpPanes.Name = "grpPanes";
      this.grpPanes.Size = new System.Drawing.Size(291, 155);
      this.grpPanes.TabIndex = 3;
      this.grpPanes.TabStop = false;
      this.grpPanes.Text = "Planes";
      // 
      // lstPlanes
      // 
      this.lstPlanes.FormattingEnabled = true;
      this.lstPlanes.Location = new System.Drawing.Point(6, 16);
      this.lstPlanes.Name = "lstPlanes";
      this.lstPlanes.Size = new System.Drawing.Size(279, 134);
      this.lstPlanes.TabIndex = 3;
      // 
      // grpTasks
      // 
      this.grpTasks.Controls.Add(this.lstTasks);
      this.grpTasks.Location = new System.Drawing.Point(521, 13);
      this.grpTasks.Name = "grpTasks";
      this.grpTasks.Size = new System.Drawing.Size(305, 155);
      this.grpTasks.TabIndex = 2;
      this.grpTasks.TabStop = false;
      this.grpTasks.Text = "Tasks";
      // 
      // lstTasks
      // 
      this.lstTasks.FormattingEnabled = true;
      this.lstTasks.Location = new System.Drawing.Point(5, 17);
      this.lstTasks.Name = "lstTasks";
      this.lstTasks.Size = new System.Drawing.Size(295, 134);
      this.lstTasks.TabIndex = 2;
      // 
      // grpClients
      // 
      this.grpClients.Controls.Add(this.lstClients);
      this.grpClients.Location = new System.Drawing.Point(210, 13);
      this.grpClients.Name = "grpClients";
      this.grpClients.Size = new System.Drawing.Size(305, 155);
      this.grpClients.TabIndex = 1;
      this.grpClients.TabStop = false;
      this.grpClients.Text = "Clients";
      // 
      // lstClients
      // 
      this.lstClients.FormattingEnabled = true;
      this.lstClients.Location = new System.Drawing.Point(5, 16);
      this.lstClients.Name = "lstClients";
      this.lstClients.Size = new System.Drawing.Size(295, 134);
      this.lstClients.TabIndex = 1;
      // 
      // grpAirport
      // 
      this.grpAirport.Controls.Add(this.listAirport);
      this.grpAirport.Location = new System.Drawing.Point(6, 13);
      this.grpAirport.Name = "grpAirport";
      this.grpAirport.Size = new System.Drawing.Size(198, 155);
      this.grpAirport.TabIndex = 0;
      this.grpAirport.TabStop = false;
      this.grpAirport.Text = "Airports";
      // 
      // listAirport
      // 
      this.listAirport.FormattingEnabled = true;
      this.listAirport.Location = new System.Drawing.Point(3, 16);
      this.listAirport.Name = "listAirport";
      this.listAirport.Size = new System.Drawing.Size(192, 134);
      this.listAirport.TabIndex = 0;
      // 
      // FormSimulator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1144, 696);
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
      this.grpTasks.ResumeLayout(false);
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
    private System.Windows.Forms.GroupBox grpTasks;
    private System.Windows.Forms.ListBox lstTasks;
    private System.Windows.Forms.GroupBox grpClients;
    private System.Windows.Forms.ListBox lstClients;
    private System.Windows.Forms.GroupBox grpAirport;
    private System.Windows.Forms.ListBox listAirport;
    private System.Windows.Forms.ListBox lstPlanes;
  }
}