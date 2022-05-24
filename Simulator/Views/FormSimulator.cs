using Simulator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
      Bitmap map = new Bitmap(Resources.galaxy);
      Graphics simCanevas = mapPanel.CreateGraphics();
      simCanevas.DrawImage(map, 0, 0, 1129, 529);
    }

    private void mapPanel_Paint(object sender, PaintEventArgs e)
    {
      DrawMap();
    }
  }
}
