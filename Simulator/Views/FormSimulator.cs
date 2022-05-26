using System;
using System.Drawing;
using System.Windows.Forms;
using Simulator.Properties;

namespace Simulator.Views
{
  public partial class FormSimulator : Form
  {
    public FormSimulator()
    {
      InitializeComponent();
    }

    private void toolStripComboBox1_Click(object sender, EventArgs e)
    {
    }

    private void subToolNew_Click(object sender, EventArgs e)
    {
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    public void DrawMap()
    {
      var map = new Bitmap(Resources.galaxy);
      var simCanevas = mapPanel.CreateGraphics();
      simCanevas.DrawImage(map, 0, 0, 1129, 529);
    }

    private void mapPanel_Paint(object sender, PaintEventArgs e)
    {
      DrawMap();
    }
  }
}