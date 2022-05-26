using System;
using System.Drawing;
using System.Windows.Forms;
using Generator.Models;
using Generator.Properties;

namespace Generator.Views
{
  public partial class FormMap : Form
  {
    public FormMap()
    {
      InitializeComponent();
    }

    public string Pos { get; set; }

    public void DrawMapPos()
    {
      var map = new Bitmap(Resources.galaxy);
      var simCanevas = mapPanelPos.CreateGraphics();
      simCanevas.DrawImage(map, 0, 0, 1129, 529);
    }

    private void mapPanelPos_Paint(object sender, PaintEventArgs e)
    {
      DrawMapPos();
    }

    private void mapPanelPos_Click(object sender, EventArgs e)
    {
      var props = (MouseEventArgs) e;
      var image = (Panel) sender;
      var x = props.X;
      var y = props.Y;
      var pos = new Position(x, y);
      Pos = pos.ToString();
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}