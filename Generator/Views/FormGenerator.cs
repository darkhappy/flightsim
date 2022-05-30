using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Forms;
using Generator.Models;
using Generator.Properties;
using Generator.Views;

namespace Generator
{
  public partial class FormGenerator : Form
  {
    private FormMap _mapPos;
    private SoundPlayer _player;

    /// <summary>
    ///   Constructor of the form
    /// </summary>
    public FormGenerator()
    {
      InitializeComponent();
    }

    /// <summary>
    ///   First actions when the form is loading
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
      listAirports.Columns.Add("Id", (int) (listAirports.Width * 0.07));
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
    ///   Show all <see cref="Airport" />s in the airportsList
    /// </summary>
    /// <param name="airports">Airports info comming from <see cref="Scenario" /></param>
    public void UpdateAirports(List<AirportInfo> airports)
    {
      foreach (var info in airports)
      {
        string[] toAdd =
        {
          info.Id, info.Name, info.Position.ToString(), info.PassengerTraffic.ToString(), info.CargoTraffic.ToString()
        };
        listAirports.Items.Add(new ListViewItem(toAdd));
      }
    }

    /// <summary>
    ///   Show all <see cref="Airplane" />s in the selected <see cref="Airport" />
    /// </summary>
    /// <param name="airplanes">Airplanes info coming from <see cref="Scenario" /></param>
    public void UpdateAirplanes(List<AirplaneInfo> airplanes)
    {
      foreach (var info in airplanes)
      {
        string[] toAdd =
        {
          info.Id, info.Name, info.Type.ToString(), info.Speed.ToString(), info.MaxCapacity.ToString(),
          info.EmbarkingTime.ToString(), info.DisembarkingTime.ToString(), info.MaintenanceTime.ToString()
        };
        listAirplanes.Items.Add(new ListViewItem(toAdd));
      }
    }

    /// <summary>
    ///   Change enabled option in the form according to the selected airplane <see cref="AirplaneType" />
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
          break;
        case "Fight":
        case "Rescue":
        case "Scout":
          numCapacity.Enabled = false;
          numEmbarking.Enabled = false;
          numDisembarking.Enabled = false;
          break;
      }
    }

    /// <summary>
    ///   Update shown airplanes whenever the listAirports changes
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void listAirports_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listAirports.SelectedItems.Count <= 0) return;

      listAirplanes.Items.Clear();
      Controllers.Generator.Instance.UpdateAirplanes(listAirports.SelectedItems[0].SubItems[0].Text);

      txbAirportId.Text = listAirports.SelectedItems[0].SubItems[0].Text;
      txbAirportName.Text = listAirports.SelectedItems[0].SubItems[1].Text;
      txbPosition.Text = listAirports.SelectedItems[0].SubItems[2].Text;
      numPTraffic.Text = listAirports.SelectedItems[0].SubItems[3].Text;
      numCTraffic.Text = listAirports.SelectedItems[0].SubItems[4].Text;
    }

    private void listAirplanes_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (listAirplanes.SelectedItems.Count <= 0) return;

      txbAirplaneId.Text = listAirplanes.SelectedItems[0].SubItems[0].Text;
      txbAirplaneName.Text = listAirplanes.SelectedItems[0].SubItems[1].Text;
      cmbType.Text = listAirplanes.SelectedItems[0].SubItems[2].Text;

      numSpeed.Value = Int32.Parse(listAirplanes.SelectedItems[0].SubItems[3].Text);
      numCapacity.Value = Int32.Parse(listAirplanes.SelectedItems[0].SubItems[4].Text);
      numEmbarking.Value = Int32.Parse(listAirplanes.SelectedItems[0].SubItems[5].Text);
      numDisembarking.Value = Int32.Parse(listAirplanes.SelectedItems[0].SubItems[6].Text);
      numMaintenance.Value = Int32.Parse(listAirplanes.SelectedItems[0].SubItems[7].Text);
    }

    /// <summary>
    ///   Add an airport to the <see cref="Scenario" />
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void btnAddAirport_Click(object sender, EventArgs e)
    {
      labError.Visible = true;
      labError.Text = "Please enter valid data";

      if (string.IsNullOrEmpty(txbAirportId.Text)) return;
      if (string.IsNullOrEmpty(txbAirportName.Text)) return;
      if (string.IsNullOrEmpty(txbPosition.Text)) return;

      if (!int.TryParse(numPTraffic.Text, out var pTraffic)) return;
      if (!double.TryParse(numCTraffic.Text, out var cTraffic)) return;

      labError.Visible = false;

      listAirports.Items.Clear();

      //Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text, new Position(txbPosition.Text), pTraffic, mTraffic));
      Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text,
        new Position(1, 1), pTraffic, cTraffic));

      listAirports.Items[listAirports.Items.Count - 1].Selected = true;
    }

    /// <summary>
    ///   Add a new airplane to the <see cref="Scenario" />
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
      if (string.IsNullOrEmpty(txbAirplaneId.Text)) return;
      if (string.IsNullOrEmpty(txbAirplaneName.Text)) return;
      if (!int.TryParse(numSpeed.Text, out var speed)) return;
      if (!int.TryParse(numMaintenance.Text, out var maintenance)) return;

      //Select matching type
      type = cmbType.SelectedItem switch
      {
        "Cargo" => AirplaneType.Cargo,
        "Passenger" => AirplaneType.Passenger,
        "Fight" => AirplaneType.Fight,
        "Rescue" => AirplaneType.Rescue,
        "Scout" => AirplaneType.Scout,
        _ => throw new ArgumentException("Unknown type")
      };

      //Create airplane info depending on AirplaneType
      switch (type)
      {
        case AirplaneType.Cargo:
        case AirplaneType.Passenger:
        {
          if (!int.TryParse(numCapacity.Text, out var capacity)) return;
          if (!int.TryParse(numEmbarking.Text, out var embarking)) return;
          if (!int.TryParse(numDisembarking.Text, out var disembarking)) return;
          info = new TransportInfo(txbAirplaneId.Text, txbAirplaneName.Text, type, speed, maintenance, capacity,
            embarking, disembarking);
          break;
        }
        case AirplaneType.Fight:
        case AirplaneType.Rescue:
        case AirplaneType.Scout:
          info = new AirplaneInfo(txbAirplaneId.Text, txbAirplaneName.Text, type, speed, maintenance);
          break;
        default:
          throw new ArgumentException("Unknown type");
      }

      labError.Visible = false;

      //Update listAirplanes
      listAirplanes.Items.Clear();

      Controllers.Generator.Instance.AddAirplane(listAirports.SelectedItems[0].SubItems[0].Text, info);
      listAirplanes.Items[listAirplanes.Items.Count - 1].Selected = true;
    }

    private void btnDeleteAirport_Click(object sender, EventArgs e)
    {
      Controllers.Generator.Instance.DeleteAirplane(listAirports.SelectedItems[0].SubItems[0].Text);
    }

    private void btnDeleteAirplane_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    ///   Can start the music
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolStart_Click(object sender, EventArgs e)
    {
      _player.PlayLooping();
    }

    /// <summary>
    ///   Can stop the music
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
      if (result != DialogResult.OK) return;

      var pos = _mapPos.Pos;
      txbPosition.Text = pos;
    }
  }
}