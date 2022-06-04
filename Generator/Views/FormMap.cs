using System;
using System.Drawing;
using System.Windows.Forms;
using Generator.Models;
using Generator.Properties;

namespace Generator.Views
{
  public partial class FormMap : Form
  {
    /// <summary>
    ///   Constructor of the form
    /// </summary>
    public FormMap()
    {
      InitializeComponent();
    }


    /// <summary>
    /// Getter and setter of the position
    /// </summary>
    public Position Pos { get; set; }

    /// <summary>
    /// Draw the map
    /// </summary>
    public void DrawMapPos()
    {
      var map = new Bitmap(Resources.galaxy);
      var simCanevas = mapPanelPos.CreateGraphics();
      simCanevas.DrawImage(map, 0, 0, 1129, 529);
    }

    /// <summary>
    ///   Can trigger the drawing of the map
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void mapPanelPos_Paint(object sender, PaintEventArgs e)
    {
      DrawMapPos();
    }

    /// <summary>
    /// Convert the pixel clicked intot position
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void mapPanelPos_Click(object sender, EventArgs e)
    {
      var props = (MouseEventArgs) e;
      var image = (Panel) sender;
      var x = props.X;
      var y = props.Y;
      Pos = new Position(x, y);
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}