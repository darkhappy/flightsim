using System.ComponentModel;

namespace Generator.Views
{
  partial class FormMap
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
      this.mapPanelPos = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // mapPanelPos
      // 
      this.mapPanelPos.Location = new System.Drawing.Point(5, 4);
      this.mapPanelPos.Name = "mapPanelPos";
      this.mapPanelPos.Size = new System.Drawing.Size(1129, 529);
      this.mapPanelPos.TabIndex = 16;
      this.mapPanelPos.Click += new System.EventHandler(this.mapPanelPos_Click);
      this.mapPanelPos.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanelPos_Paint);
      // 
      // FormMap
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1139, 536);
      this.Controls.Add(this.mapPanelPos);
      this.Name = "FormMap";
      this.Text = "FormMap";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel mapPanelPos;
  }
}