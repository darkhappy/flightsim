using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using Generator.Controllers;
using Generator.Models;
using Generator.Properties;

namespace Generator
{
  public partial class FormGenerator : Form
  {
    private SoundPlayer _player;

    public FormGenerator()
    {
      InitializeComponent();
    }

    private void FormGenerator_Load(object sender, EventArgs e)
    {
      //Load music
      _player = new SoundPlayer();
      _player.Stream = Resources.Cantina_Band;
      _player.PlayLooping();

      //Setup listAirports
      listAirports.View = View.Details;
      listAirports.Columns.Add("Name", (int) (listAirports.Width * 0.33));
      listAirports.Columns.Add("Position", (int) (listAirports.Width * 0.33));
      listAirports.Columns.Add("Passenger Traffic", (int) (listAirports.Width * 0.168));
      listAirports.Columns.Add("Merchandise Traffic", (int) (listAirports.Width * 0.168));

      //Setup listPlane
      listPlane.View = View.Details;
      listPlane.Columns.Add("Id", (int) (listAirports.Width * 0.07));
      listPlane.Columns.Add("Name", (int) (listAirports.Width * 0.18));
      listPlane.Columns.Add("Type", (int) (listAirports.Width * 0.18));
      listPlane.Columns.Add("Speed", (int) (listAirports.Width * 0.08));
      listPlane.Columns.Add("Capacity", (int) (listAirports.Width * 0.08));
      listPlane.Columns.Add("Embarking", (int) (listAirports.Width * 0.08));
      listPlane.Columns.Add("Disembarking", (int) (listAirports.Width * 0.08));
      listPlane.Columns.Add("Charging", (int) (listAirports.Width * 0.08));
      listPlane.Columns.Add("Dropping", (int) (listAirports.Width * 0.08));
      listPlane.Columns.Add("Maintenance", (int) (listAirports.Width * 0.088));

      //Default selected type
      cmbType.SelectedIndex = 1;
    }

    public void UpdateView(List<AirportInfo> airports)
    {
      
    }

    /// <summary>
    /// Can start the music
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolStart_Click(object sender, EventArgs e)
    {
      _player.PlayLooping();
    }

    /// <summary>
    /// Can stop the music
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolStop_Click(object sender, EventArgs e)
    {
      _player.Stop();
    }

    /// <summary>
    /// Change enabled option in the form according to the selected plane type
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (cmbType.SelectedItem)
      {
        case "Cargo":
        case "Passenger":
          numCapacity.Enabled = true;
          numEmbarking.Enabled = true;
          numDisembarking.Enabled = true;
          numMaintenance.Enabled = true;       
          break;
        case "Fight":
        case "Rescue":
        case "Scout":
          numCapacity.Enabled = false;
          numEmbarking.Enabled = false;
          numDisembarking.Enabled = false;
          numMaintenance.Enabled = false;
          break;

      }
    }

    private void btnAddAirport_Click(object sender, EventArgs e)
    {
      labError.Visible = true;
      labError.Text = "Please enter valid data";

      if (String.IsNullOrEmpty(txbAirportId.Text)) return;
      if (String.IsNullOrEmpty(txbAirportName.Text)) return;
      if (String.IsNullOrEmpty(txbPosition.Text)) return;
      if (String.IsNullOrEmpty(numPTraffic.Text)) return;

      if (!int.TryParse(numPTraffic.Text, out int pTraffic)) return;
      if (!double.TryParse(numPTraffic.Text, out double mTraffic)) return;

      labError.Visible = false;
      Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text, new Position(txbPosition.Text), pTraffic, mTraffic));
    }
  }
}