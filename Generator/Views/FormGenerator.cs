using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using Generator.Controllers;
using Generator.Models;
using Generator.Properties;
using Generator.Views;

namespace Generator
{
  public partial class FormGenerator : Form
  {
    private SoundPlayer _player;
    private FormMap _mapPos;

    /// <summary>
    /// Constructor of the form
    /// </summary>
    public FormGenerator()
    {
      InitializeComponent();
    }

    /// <summary>
    /// First actions when the form is loading
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
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
      listAirplanes.View = View.Details;
      listAirplanes.Columns.Add("Id", (int) (listAirports.Width * 0.07));
      listAirplanes.Columns.Add("Name", (int) (listAirports.Width * 0.236));
      listAirplanes.Columns.Add("Type", (int) (listAirports.Width * 0.20));
      listAirplanes.Columns.Add("Speed", (int) (listAirports.Width * 0.09));
      listAirplanes.Columns.Add("Capacity", (int) (listAirports.Width * 0.1));
      listAirplanes.Columns.Add("Embarking", (int) (listAirports.Width * 0.1));
      listAirplanes.Columns.Add("Disembarking", (int) (listAirports.Width * 0.1));
      listAirplanes.Columns.Add("Maintenance", (int) (listAirports.Width * 0.1));

      //Default selected type
      cmbType.SelectedIndex = 1;
    }

    /// <summary>
    /// Show all <see cref="Airport"/>s in the airportsList
    /// </summary>
    /// <param name="airports">Airports info comming from <see cref="Scenario"/></param>
    public void UpdateAirports(List<AirportInfo> airports)
    {
      foreach (AirportInfo info in airports)
      {
        string[] toAdd = { info.Id, info.Name, info.Position.ToString(), info.PassengerTraffic.ToString(), info.CargoTraffic.ToString() };
        listAirports.Items.Add(new ListViewItem(toAdd));
      }
    }

    /// <summary>
    /// Show all <see cref="Airplane"/>s in the selected <see cref="Airport"/>
    /// </summary>
    /// <param name="airplanes">Airplanes info coming from <see cref="Scenario"/></param>
    public void UpdateAirplanes(List<AirplaneInfo> airplanes)
    {
      foreach (AirplaneInfo info in airplanes)
      {
        string[] toAdd = {info.Id, info.Name, info.Type.ToString(), info.Speed.ToString(), info.MaxCapacity.ToString(), info.EmbarkingTime.ToString(), info.DisembarkingTime.ToString(), info.MaintenanceTime.ToString()};
        listAirplanes.Items.Add(new ListViewItem(toAdd));
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
    /// Add an airport to the <see cref="Scenario"/>
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
      if (!double.TryParse(numCTraffic.Text, out double cTraffic)) return;

      labError.Visible = false;

      listAirports.Items.Clear();

      //Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text, new Position(txbPosition.Text), pTraffic, mTraffic));
      Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text, new Position(1,1), pTraffic, cTraffic));

      listAirports.Items[listAirports.Items.Count - 1].Selected = true;
    }

    /// <summary>
    /// Update shown airplanes whenever the listAirports changes
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void listAirports_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(listAirports.SelectedItems.Count > 0)
      {
        listAirplanes.Items.Clear();
        Controllers.Generator.Instance.UpdateAirplanes(listAirports.SelectedItems[0].SubItems[0].Text);
      }
    }

    /// <summary>
    /// Add a new airplane to the <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void btnAddAirplane_Click(object sender, EventArgs e)
    {
      AirplaneType type;
      AirplaneInfo info;

      //Verify if is valid
      labError.Visible = true;
      labError.Text = "Please select an airport";

      if (listAirports.SelectedItems.Count == 0) return;
      labError.Text = "Please enter valid data";

      if (String.IsNullOrEmpty(txbAirplaneId.Text)) return;
      if (String.IsNullOrEmpty(txbAirplaneName.Text)) return;
      if (!int.TryParse(numSpeed.Text, out int speed)) return;
      if (!int.TryParse(numMaintenance.Text, out int maintenance)) return;

      //Select matching type
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

      //Create airplane info depending on AirplaneType
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
        default:
          throw new Exception("Unknown type");
      }

      labError.Visible = false;

      //Update listAirplanes
      listAirplanes.Items.Clear();
      Controllers.Generator.Instance.AddAirplane(listAirports.SelectedItems[0].SubItems[0].Text, info);
      listAirplanes.Items[listAirplanes.Items.Count - 1].Selected = true;
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

    private void txbPosition_DoubleClick(object sender, EventArgs e)
    {
      _mapPos = new FormMap();
      var result = _mapPos.ShowDialog();
      if (result == DialogResult.OK)
      {
        string pos = _mapPos.Pos;
        this.txbPosition.Text = pos;
      }
    }
  }
}