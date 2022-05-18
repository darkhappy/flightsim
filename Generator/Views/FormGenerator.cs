using System;
using System.Media;
using System.Windows.Forms;

namespace Generator
{
  public partial class FormGenerator : Form
  {
    SoundPlayer _player;

    public FormGenerator()
    {
      InitializeComponent();
    }

    private void FormGenerator_Load(object sender, EventArgs e)
    {
      _player = new SoundPlayer();
      _player.Stream = Properties.Resources.Cantina_Band;
      _player.PlayLooping();

      listAirports.View = View.Details;
      listAirports.Columns.Add("Name", (int)(listAirports.Width * 0.33));
      listAirports.Columns.Add("Location", (int)(listAirports.Width * 0.33));
      listAirports.Columns.Add("Passenger Traffic", (int)(listAirports.Width * 0.168));
      listAirports.Columns.Add("Merchandise Traffic", (int)(listAirports.Width * 0.168));

      listView1.View = View.Details;
      listView1.Columns.Add("Id", (int)(listAirports.Width * 0.07));
      listView1.Columns.Add("Name", (int)(listAirports.Width * 0.18));
      listView1.Columns.Add("Type", (int)(listAirports.Width * 0.18));
      listView1.Columns.Add("Speed", (int)(listAirports.Width * 0.08));
      listView1.Columns.Add("Capacity", (int)(listAirports.Width * 0.08));
      listView1.Columns.Add("Embarking", (int)(listAirports.Width * 0.08));
      listView1.Columns.Add("Disembarking", (int)(listAirports.Width * 0.08));
      listView1.Columns.Add("Charging", (int)(listAirports.Width * 0.08));
      listView1.Columns.Add("Dropping", (int)(listAirports.Width * 0.08));
      listView1.Columns.Add("Maintenance", (int)(listAirports.Width * 0.088));
    }

    private void subToolStart_Click(object sender, EventArgs e)
    {
      _player.PlayLooping();
    }

    private void subToolStop_Click(object sender, EventArgs e)
    {
      _player.Stop();
    }
  }
}
