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
      DoubleBuffered = true;

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
      listClients.View = View.Details;
      listClients.Columns.Add("Clients", (int)(listAirplanes.Width * 0.96));

      //Setup timer
      timer.Enabled = true;
      timer.Interval = 1000;
      
      //Load music
      _player = new SoundPlayer();
      _player.Stream = Resources.star_wars_theme_song;
      _player.PlayLooping();


      checkMute.Checked = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateClients(string id)
    {
      listClients.Items.Clear();
      var clients = Controllers.Simulator.Instance.Clients(id);
      foreach (var client in clients)
      {
        listClients.Items.Add(new ListViewItem(client));
      }
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
      UpdateClients(airportId);

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

    /// <summary>
    /// Draws the map as it is with all airports events and airplanes
    /// </summary>
    public void DrawMap()
    {
      int height = 45;
      int width = 45;

      var map = new Bitmap(Resources.galaxy);
      var simCanevas = mapPanel.CreateGraphics();
      simCanevas.DrawImage(map, 0, 0, mapPanel.Width, mapPanel.Height);

      var airportPositions = Controllers.Simulator.Instance.AirportPositions();

      int ind = 0;

      //Draw all airports :
      foreach (var position in airportPositions)
      {
        Image[] airports = { Resources.Corellia, Resources.Coruscant, Resources.hoth };
        var airport = new Bitmap(airports[ind%3]);
        string drawString = position.Item1;
        Font drawFont = new Font("Arial", 12);
        SolidBrush drawBrush = new SolidBrush(Color.White);
        float x = 150.0F;
        float y = 50.0F;
        StringFormat drawFormat = new StringFormat();
        simCanevas.DrawString(drawString, drawFont, drawBrush, position.Item2.X - (int)(height/2), position.Item2.Y + (int)(height / 2), drawFormat);

        simCanevas.DrawImage(airport, position.Item2.X - (int)(width / 2), (position.Item2.Y) - (int)(height/2), height, width);
        
        ind++;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="task"></param>
    /// <exception cref="ArgumentException"></exception>
    internal void DrawEvent(Tuple<TaskType, Position> task)
    {
      int height = 35;
      int width = 35;

      Bitmap image = task.Item1 switch
      {
        TaskType.Fight => new Bitmap(Resources.Rebel_Logo),
        TaskType.Rescue => new Bitmap(Resources.antenna_red),
        TaskType.Scout => new Bitmap(Resources.alert),
        _ => throw new ArgumentException($"TaskType { task.Item1 } was not found.")
      };

      var simCanevas = mapPanel.CreateGraphics();

      simCanevas.DrawImage(image, task.Item2.X - (int)(width / 2), task.Item2.Y - (int)(height / 2), height, width);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="actual"></param>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <exception cref="ArgumentException"></exception>
    public void DrawAirplane(string id, TaskType type, Position actual, Position origin, Position target)
    {
      int height = 25;
      int width = 25;

      var simCanevas = mapPanel.CreateGraphics();
      //Draw trajectory
      Pen blackPen = type switch
      {
        TaskType.Passenger => new Pen(Color.Green, 3),
        TaskType.Cargo => new Pen(Color.Blue, 3),
        TaskType.Fight => new Pen(Color.Yellow, 3),
        TaskType.Rescue => new Pen(Color.Red, 3),
        TaskType.Scout => new Pen(Color.Gray, 3),
        _ => throw new ArgumentException($"TaskType { type } was not found.")
      };

      // Create points that define line.
      PointF pointOrigin = new PointF(origin.X, origin.Y);
      PointF pointTarget = new PointF(target.X, target.Y);

      simCanevas.DrawLine(blackPen, pointOrigin, pointTarget);

      //Draw airplane
      Bitmap image = type switch
      {
        TaskType.Passenger => new Bitmap(Resources.m_flacon),
        TaskType.Cargo => new Bitmap(Resources.m_flacon),
        TaskType.Fight => new Bitmap(Resources.x_wing),
        TaskType.Rescue => new Bitmap(Resources.m_flacon),
        TaskType.Scout => new Bitmap(Resources.tie_fighter),
        _ => throw new ArgumentException($"TaskType { type } was not found.")
      };

      //Rotate Image
      int o = target.X - origin.X;
      int a = target.Y - origin.X;
      float angle = (float)(270 + Math.Acos((double)o/a));
      image = RotateImage(image, angle);
   
      simCanevas.DrawImage(image, actual.X - (int)(width / 2), actual.Y - (int)(height / 2), height, width);

      //Draw id
      string drawString = id;
      Font drawFont = new Font("Arial", 12);
      SolidBrush drawBrush = new SolidBrush(Color.White);
      float x = 150.0F;
      float y = 50.0F;
      StringFormat drawFormat = new StringFormat();
      simCanevas.DrawString(drawString, drawFont, drawBrush, actual.X - (int)(height / 2), actual.Y + (int)(height / 2), drawFormat);

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
    public Bitmap RotateImage(Bitmap img, float rotationAngle)
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
      //DrawMap();
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