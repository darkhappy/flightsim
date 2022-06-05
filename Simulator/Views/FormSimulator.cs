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
    private int _ticks = 0;
    public FormSimulator()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initalizes everything needed to see at first when FormSimulator loads.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormSimulator_Load(object sender, EventArgs e)
    {
      //Setup listAirports
      var airports = Controllers.Simulator.Instance.Airports();
      listAirports.View = View.Details;
      listAirports.Columns.Add("Id", (int)(listAirports.Width * 0.25));
      listAirports.Columns.Add("Name", (int)(listAirports.Width * 0.63));
      foreach (var airport in airports)
      {
        string[] toAdd = { airport.Id, airport.Name };
        listAirports.Items.Add(new ListViewItem(toAdd));
      }
      //Setup listAirplanes
      listAirplanes.View = View.Details;
      listAirplanes.Columns.Add("Airplanes", (int)(listAirplanes.Width * 0.96));

      //Setup first clients
      var clients = Controllers.Simulator.Instance.Clients();
      listClients.View = View.Details;
      listClients.Columns.Add("Clients", (int)(listAirplanes.Width * 0.96));
      foreach (var client in clients)
      {
        listClients.Items.Add(new ListViewItem(client));
      }

      //Setup timer
      timer.Enabled = true;
      timer.Interval = 1000;
      
      //Load music
      _player = new SoundPlayer();
      _player.Stream = Resources.star_wars_theme_song;
      _player.PlayLooping();
      
    }

    //not sure of it
    private void UpdateClients()
    {

    }

    /// <summary>
    /// Each time an airport is selected in the List of airport, Airplanes are updated.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    /// <summary>
    /// Opens a form from wich the user selects a .xml file.
    /// </summary>
    /// <returns>
    /// A string as the path to the file.
    /// </returns>
    public string Path()
    {
      OpenFileDialog xmlFilePath = new OpenFileDialog();
      xmlFilePath.Filter = "XML Files (*.xml)|*.xml";
      xmlFilePath.Title = "Choose a scenario";
      var result = xmlFilePath.ShowDialog();
      return (result != DialogResult.OK) ?  "" : xmlFilePath.FileName;
    }

    private void toolStripComboBox1_Click(object sender, EventArgs e)
    {
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Draws the map as it is with all airports events and airplanes
    /// </summary>
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
        simCanevas.DrawImage(airport, position.X, position.Y, 40, 40);

        ind++;
      }
    }

    internal void DrawEvents(Tuple<TaskType, Position> task)
    {
      var image = new Bitmap(Resources.Rebel_Logo);
      var simCanevas = mapPanel.CreateGraphics();

      simCanevas.DrawImage(image, task.Item2.X, task.Item2.Y, 40, 40);
    }

    /// <summary>
    /// Rotates the image with a given angle.
    /// </summary>
    /// <param name="img">
    /// Image to be rotated.
    /// </param>
    /// <param name="rotationAngle">
    /// Angle for the rotation.
    /// </param>
    /// <returns></returns>
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

    /// <summary>
    /// Method that refresh the form every periode of time.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mapPanel_Paint(object sender, PaintEventArgs e)
    {
      DrawMap();
    }

    /// <summary>
    /// Actions made at each tick of the control timer.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timer_Tick(object sender, EventArgs e)
    {
      timerText.Text = DateTime.MinValue.AddSeconds(15 * _ticks).TimeOfDay.ToString();
      ++_ticks;

      //OnTick
      Controllers.Simulator.Instance.OnTick(_ticks * 15);

    }

    /// <summary>
    /// Called when the buttons up or down of the speedUpDown control is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void speedUpDown_ValueChanged(object sender, EventArgs e)
    {
      timer.Interval = (int)(1000 / (int)speedUpDown.Value);
    }

    private void pauseSim_Click(object sender, EventArgs e)
    {
      timer.Enabled = false;
    }

    private void startSim_Click(object sender, EventArgs e)
    {
      timer.Enabled = true;
    }

    private void checkMute_CheckedChanged(object sender, EventArgs e)
    {
      if (checkMute.Checked)
        _player.Stop();
      else
        _player.PlayLooping();
    }
  }
}