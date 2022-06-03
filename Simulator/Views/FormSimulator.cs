using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using Simulator.Models;
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

    /// <summary>
    /// Initalizes everything needed to see at first when FormSimulator loads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormSimulator_Load(object sender, EventArgs e)
    {
      //Setup listAirports
      var airports = Controllers.Simulator.Instance.Airports();
      listAirports.View = View.Details;
      listAirports.Columns.Add("Id", (int)(listAirports.Width * 0.25));
      listAirports.Columns.Add("Name", (int)(listAirports.Width * 0.75));
      foreach (var airport in airports)
      {
        string[] toAdd = { airport.Id, airport.Name };
        listAirports.Items.Add(new ListViewItem(toAdd));
      }
      //Setup listAirplanes
      listAirplanes.View = View.Details;
      listAirplanes.Columns.Add("Airplanes", (int)(listAirplanes.Width));

      //Load music
      /*
      _player = new SoundPlayer();
      _player.Stream = Resources.star_wars_theme_song;
      _player.PlayLooping();
      */
    }

    private void listAirports_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listAirports.SelectedItems.Count == 0 || listAirports.SelectedItems.Count > 1)
        return;
      listAirplanes.Items.Clear();
      var airportId = listAirports.SelectedItems[0].SubItems[0].Text;
      var airplanes = Controllers.Simulator.Instance.AirplanesFromAirportId(airportId);
      foreach (var airplane in airplanes)
      {
        listAirplanes.Items.Add(new ListViewItem(airplane));
      }
    }

    public string Path()
    {
      OpenFileDialog xmlFilePath = new OpenFileDialog();
      xmlFilePath.Filter = "XML Files (*.xml)|*.xml";
      string filePath;
      var result = xmlFilePath.ShowDialog();
      return (result != DialogResult.OK) ?  "" : xmlFilePath.FileName;
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
      simCanevas.DrawImage(map, 0, 0, mapPanel.Width, mapPanel.Height);

      List<Position> airportPositions = Controllers.Simulator.Instance.AirportPositions();

      int ind = 0;

      //Draw all airports :
      foreach (var position in airportPositions)
      {
        Image[] airports = { Resources.Corellia, Resources.Coruscant, Resources.hoth };
        var airport = new Bitmap(airports[ind%3]);
        simCanevas.DrawImage(airport, position.X, position.Y, 80, 80);

        ind++;
      }
    }

    public void DrawAirplane(string type, Position position, double angle)
    {
      var simCanevas = mapPanel.CreateGraphics();
      Image[] airports = { Resources.x_wing, Resources.Coruscant, Resources.hoth };
      var airport = new Bitmap(airports[0]);
      simCanevas.DrawImage(airport, position.X - 40, position.Y - 40, 80, 80);
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