using Generator.Models;
using System.Drawing;
using System.Windows.Forms;

namespace Generator.Views
{
  public partial class FormMap : Form
  {
    public FormMap()
    {
      InitializeComponent();
    }

    public void DrawMapPos()
    {
      Bitmap map = new Bitmap(Properties.Resources.galaxy);
      Graphics simCanevas = mapPanelPos.CreateGraphics();
      simCanevas.DrawImage(map, 0, 0, 1129, 529);
    }

    private void mapPanelPos_Paint(object sender, PaintEventArgs e)
    {
      DrawMapPos();
    }

    public string Pos { get; set; }

    private void mapPanelPos_Click(object sender, System.EventArgs e)
    {
      var props = (MouseEventArgs)e;
      var image = (Panel)sender;
      var x = props.X;
      var y = props.Y;
      var pos = new Position(x, y);
      this.Pos = pos.ToString();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}