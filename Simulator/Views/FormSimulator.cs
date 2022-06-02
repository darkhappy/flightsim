using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Simulator.Properties;

namespace Simulator.Views
{
  public partial class FormSimulator : Form
  {
    private SoundPlayer _player;
    public FormSimulator()
    {
      InitializeComponent();
    }

    private void FormSimulator_Load(object sender, EventArgs e)
    {
      //Load music
      _player = new SoundPlayer();
      _player.Stream = Resources.star_wars_theme_song;
      _player.PlayLooping();
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

      int aireportDim = 80;
      int aireplaneDim = 50;

      int x = 385;
      int y = 165;

      Image planeImg = RotateImage(Resources.x_wing, 45);

      var airport = new Bitmap(Resources.hoth);
      simCanevas.DrawImage(airport, x - 40, y - 40, 80, 80);
      simCanevas.DrawImage(planeImg, x - 25, y - 25, 50, 50);

    }

    public Image RotateImage(Image img, float rotationAngle)
    {
      //create an empty Bitmap image
      Bitmap bmp = new Bitmap(img.Width, img.Height);

      //turn the Bitmap into a Graphics object
      Graphics gfx = Graphics.FromImage(bmp);

      //now we set the rotation point to the center of our image
      gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

      //now rotate the image
      gfx.RotateTransform(rotationAngle);

      gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

      //now draw our new image onto the graphics object
      gfx.DrawImage(img, new Point(0, 0));

      //dispose of our Graphics object
      gfx.Dispose();

      //return the image
      return bmp;
    }

    private void mapPanel_Paint(object sender, PaintEventArgs e)
    {
      DrawMap();
    }
  }
}