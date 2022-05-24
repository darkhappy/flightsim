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
      listAirports.Columns.Add("Id", (int)(listAirports.Width * 0.07));
      listAirports.Columns.Add("Name", (int) (listAirports.Width * 0.30));
      listAirports.Columns.Add("Position", (int) (listAirports.Width * 0.30));
      listAirports.Columns.Add("Passenger Traffic", (int) (listAirports.Width * 0.1632));
      listAirports.Columns.Add("Merchandise Traffic", (int) (listAirports.Width * 0.1632));

      //Setup listPlane
      listPlane.View = View.Details;
      listPlane.Columns.Add("Id", (int) (listAirports.Width * 0.07));
      listPlane.Columns.Add("Name", (int) (listAirports.Width * 0.236));
      listPlane.Columns.Add("Type", (int) (listAirports.Width * 0.20));
      listPlane.Columns.Add("Speed", (int) (listAirports.Width * 0.09));
      listPlane.Columns.Add("Capacity", (int) (listAirports.Width * 0.1));
      listPlane.Columns.Add("Embarking", (int) (listAirports.Width * 0.1));
      listPlane.Columns.Add("Disembarking", (int) (listAirports.Width * 0.1));
      listPlane.Columns.Add("Maintenance", (int) (listAirports.Width * 0.1));

      //Default selected type
      cmbType.SelectedIndex = 1;
    }

    public void UpdateView(List<AirportInfo> airports)
    {
      foreach (AirportInfo info in airports)
      {
        string[] toAdd = {info.Id, info.Name, info.Position.ToString(), info.PassengerTraffic.ToString(), info.CargoTraffic.ToString()};
        listAirports.Items.Add(new ListViewItem(toAdd));
      }
    }


    /// <summary>
    /// Change enabled option in the form according to the selected airplane <see cref="AirplaneType"/>
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

    /// <summary>
    /// Add an airplane to the <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
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

    private void btnAddAirplane_Click(object sender, EventArgs e)
    {
      AirplaneType type;
      AirplaneInfo info;

      labError.Visible = true;
      labError.Text = "Please enter valid data";

      if (String.IsNullOrEmpty(txbAirplaneId.Text)) return;
      if (String.IsNullOrEmpty(txbAirplaneName.Text)) return;

      if (!int.TryParse(numSpeed.Text, out int speed)) return;
      if (!int.TryParse(numMaintenance.Text, out int maintenance)) return;

      switch (cmbType.SelectedItem)
      {
        case "Cargo":
          type = AirplaneType.Cargo;
          break;
        case "Passenger":
          type = AirplaneType.Passenger;
          break;
        case "Fight":
          type = AirplaneType.Fight;
          break;
        case "Rescue":
          type = AirplaneType.Rescue;
          break;
        case "Scout":
          type = AirplaneType.Scout;
          break;
        default:
          throw new Exception("Unknown type");    
      }

      switch (cmbType.SelectedItem)
      {
        case "Cargo":
        case "Passenger":
          if (!int.TryParse(numCapacity.Text, out int capacity)) return;
          if (!int.TryParse(numEmbarking.Text, out int embarking)) return;
          if (!int.TryParse(numDisembarking.Text, out int disembarking)) return;
          info = new TransportInfo(txbAirplaneId.Text, txbAirplaneName.Text, type, speed, maintenance, capacity, embarking, disembarking);
          break;
        case "Fight":
        case "Rescue":
        case "Scout":
          info = new AirplaneInfo(txbAirplaneId.Text, txbAirplaneName.Text, type, speed, maintenance);
          break;
      }

      if (listAirports.SelectedItems.Count == 0) return;

      labError.Text = listAirports.SelectedItems[0].SubItems[0].ToString();
      //labError.Visible = false;
      //Controllers.Generator.Instance.AddAirplane(listAirports.SelectedItems[0].SubItems[0],info);
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
  }
}