﻿using System;
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
    private string currentPath;

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
      listAirports.Columns.Add("Id", (int)(listAirports.Width * 0.07));
      listAirports.Columns.Add("Name", (int)(listAirports.Width * 0.30));
      listAirports.Columns.Add("Position", (int)(listAirports.Width * 0.30));
      listAirports.Columns.Add("Passenger Traffic", (int)(listAirports.Width * 0.1632));
      listAirports.Columns.Add("Merchandise Traffic", (int)(listAirports.Width * 0.1632));

      //Setup listPlane
      listAirplanes.View = View.Details;
      listAirplanes.Columns.Add("Id", (int)(listAirports.Width * 0.07));
      listAirplanes.Columns.Add("Name", (int)(listAirports.Width * 0.236));
      listAirplanes.Columns.Add("Type", (int)(listAirports.Width * 0.20));
      listAirplanes.Columns.Add("Speed", (int)(listAirports.Width * 0.09));
      listAirplanes.Columns.Add("Capacity", (int)(listAirports.Width * 0.1));
      listAirplanes.Columns.Add("Embarking", (int)(listAirports.Width * 0.1));
      listAirplanes.Columns.Add("Disembarking", (int)(listAirports.Width * 0.1));
      listAirplanes.Columns.Add("Maintenance", (int)(listAirports.Width * 0.1));

      //Default selected type
      cmbType.SelectedIndex = 1;
    }

    /// <summary>
    ///   Show all <see cref="Airport" />s in the airportsList
    /// </summary>
    /// <param name="airports">Airports info comming from <see cref="Scenario" /></param>
    public void UpdateAirports(List<AirportInfo> airports)
    {
      listAirports.Items.Clear();

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
      listAirplanes.Items.Clear();

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
          numCapacity.Value = 15;
          numEmbarking.Enabled = true;
          numEmbarking.Value = 15;
          numDisembarking.Enabled = true;
          numDisembarking.Value = 15;
          break;
        case "Fight":
        case "Rescue":
        case "Scout":
          numCapacity.Enabled = false;
          numCapacity.Value = 0;
          numEmbarking.Enabled = false;
          numEmbarking.Value = 0;
          numDisembarking.Enabled = false;
          numDisembarking.Value = 0;
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

    private bool IsAirplaneValid()
    {
      labError.Visible = true;

      labError.Text = "Please select an airport";
      if (listAirports.SelectedItems.Count == 0) return false;
      labError.Text = "Please enter valid data";

      if (string.IsNullOrEmpty(txbAirplaneId.Text)) return false;
      if (string.IsNullOrEmpty(txbAirplaneName.Text)) return false;
      if (!int.TryParse(numSpeed.Text, out var speed)) return false;
      if (!int.TryParse(numMaintenance.Text, out var maintenance)) return false;

      return true;
    }

    private AirplaneType GetAirplaneType(string type)
    {
      return type switch
      {
        "Cargo" => AirplaneType.Cargo,
        "Passenger" => AirplaneType.Passenger,
        "Fight" => AirplaneType.Fight,
        "Rescue" => AirplaneType.Rescue,
        "Scout" => AirplaneType.Scout,
        _ => throw new ArgumentException("Unknown type"),
      };
    }

    private AirplaneInfo GetAirplaneInfo(AirplaneType type)
    {
      //Convert data
      int.TryParse(numSpeed.Text, out var speed);
      int.TryParse(numMaintenance.Text, out var maintenance);

      //Create airplane info depending on AirplaneType
      switch (type)
      {
        case AirplaneType.Cargo:
        case AirplaneType.Passenger:
          {
            if (!int.TryParse(numCapacity.Text, out var capacity)) throw new ArgumentException("Invalid data");
            if (!int.TryParse(numEmbarking.Text, out var embarking)) throw new ArgumentException("Invalid data");
            if (!int.TryParse(numDisembarking.Text, out var disembarking)) throw new ArgumentException("Invalid data");
            return new TransportInfo(txbAirplaneId.Text, txbAirplaneName.Text, type, speed, maintenance, capacity,
              embarking, disembarking);
          }
        case AirplaneType.Fight:
        case AirplaneType.Rescue:
        case AirplaneType.Scout:
          return new AirplaneInfo(txbAirplaneId.Text, txbAirplaneName.Text, type, speed, maintenance);
        default:
          throw new ArgumentException("Unknown type");
      }
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

      Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text, new Position(1, 1), pTraffic, cTraffic));

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
      if (!IsAirplaneValid()) return;
    
      //Get airplane type
      try { type = GetAirplaneType(cmbType.SelectedItem.ToString()); }
      catch
      {
        labError.Text = "Please enter valid data";
        return;
      }

      //Get airplane info
      try { info = GetAirplaneInfo(type); }
      catch
      {
        labError.Text = "Please enter valid data";
        return;
      }

      labError.Visible = false;

      //Update listAirplanes
      listAirplanes.Items.Clear();
      Controllers.Generator.Instance.AddAirplane(listAirports.SelectedItems[0].SubItems[0].Text, info);
      listAirplanes.Items[listAirplanes.Items.Count - 1].Selected = true;
    }

    private void btnDeleteAirport_Click(object sender, EventArgs e)
    {
      int selected = listAirports.SelectedIndices[0];

      Controllers.Generator.Instance.DeleteAirport(listAirports.SelectedItems[0].SubItems[0].Text);
      try { listAirports.Items[selected-1].Selected = true; }
      catch 
      {
        txbAirportId.Text = "";
        txbAirportName.Text = "";
        txbPosition.Text = "";
        numPTraffic.Text = "5";
        numCTraffic.Text = "5";
      };
    }

    private void btnDeleteAirplane_Click(object sender, EventArgs e)
    {
      int selected = listAirplanes.SelectedIndices[0];

      Controllers.Generator.Instance.DeleteAirplane(listAirplanes.SelectedItems[0].SubItems[0].Text);
      Controllers.Generator.Instance.UpdateAirplanes(listAirports.SelectedItems[0].SubItems[0].Text);

      try { listAirplanes.Items[selected-1].Selected = true; }
      catch 
      {
        txbAirplaneId.Text = "";
        txbAirplaneName.Text = "";
        cmbType.Text = "Cargo";

        numSpeed.Value = 900;
        numCapacity.Value = 15;
        numEmbarking.Value = 15;
        numDisembarking.Value = 15;
        numMaintenance.Value = 15;
      };
    }

    private void btnEditAirport_Click(object sender, EventArgs e)
    {
      int selected = listAirports.SelectedIndices[0];

      labError.Visible = true;
      labError.Text = "Please enter valid data";

      if (string.IsNullOrEmpty(txbAirportId.Text)) return;
      if (string.IsNullOrEmpty(txbAirportName.Text)) return;
      if (string.IsNullOrEmpty(txbPosition.Text)) return;
      if (!int.TryParse(numPTraffic.Text, out var pTraffic)) return;
      if (!double.TryParse(numCTraffic.Text, out var cTraffic)) return;

      labError.Visible = false;

      AirportInfo info = new AirportInfo(txbAirportId.Text, txbAirportName.Text, new Position(1, 1), pTraffic, cTraffic);
      Controllers.Generator.Instance.EditAirport(listAirports.SelectedItems[0].SubItems[0].Text, info);

      listAirports.Items[selected].Selected = true;
    }

    private void btnEditAirplane_Click(object sender, EventArgs e)
    {
      int selected = listAirplanes.SelectedIndices[0];

      AirplaneType oldType = GetAirplaneType(listAirplanes.SelectedItems[0].SubItems[2].Text);
      AirplaneType newType;
      AirplaneInfo info;

      labError.Visible = true;

      //Verify if is valid
      if (!IsAirplaneValid()) return;
      try 
      {
        newType = GetAirplaneType(cmbType.SelectedItem.ToString());
        info = GetAirplaneInfo(newType); 
      }
      catch
      {
        labError.Text = "Please enter valid data";
        return;
      }

      labError.Visible = false;

      string airplaneId = listAirplanes.SelectedItems[0].SubItems[0].Text;
      string airportId = listAirports.SelectedItems[0].SubItems[0].Text;

      Controllers.Generator.Instance.EditAirplane(airportId, airplaneId, info);

      if (oldType == newType)
        listAirplanes.Items[selected].Selected = true;
      else
        listAirplanes.Items[listAirplanes.Items.Count - 1].Selected = true;
    }

    private void txbPosition_Click(object sender, EventArgs e)
    {
      _mapPos = new FormMap();
      var result = _mapPos.ShowDialog();
      if (result != DialogResult.OK) return;

      var pos = _mapPos.Pos;

      txbPosition.Text = Position.Transpose(pos.X, pos.Y);
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

    private void subToolOpen_Click(object sender, EventArgs e)
    {
      string path = OpenPath();

      if (path == "")
      {
        return;
      }

      Controllers.Generator.Instance.Import(path);
      currentPath = path;
      this.Text = "Scenario Generator - " + currentPath;

      if (listAirports.Items.Count > 0)
        listAirports.Items[0].Selected = true;
    }

    private void subToolNew_Click(object sender, EventArgs e)
    {
      string path = SavePath();

      if (path == "")
      {
        return;
      }

      Controllers.Generator.Instance.Import(path);
      currentPath = path;
      this.Text = "Scenario Generator - " + currentPath;

      if (listAirports.Items.Count > 0)
        listAirports.Items[0].Selected = true;
    }

    private void subToolSave_Click(object sender, EventArgs e)
    {
      Controllers.Generator.Instance.Export(currentPath);
    }

    private void subToolSaveAs_Click(object sender, EventArgs e)
    {
      string path = SavePath();

      if (path == "")
      {
        MessageBox.Show("Choose a valid XML file");
        return;
      }

      Controllers.Generator.Instance.Export(path);
      currentPath = path;
      this.Text = "Scenario Generator - " + currentPath;

      if (listAirports.Items.Count > 0)
        listAirports.Items[0].Selected = true;
    }

    private void subToolDelete_Click(object sender, EventArgs e)
    {

    }

    public string OpenPath()
    {
      OpenFileDialog xmlFilePath = new OpenFileDialog();
      xmlFilePath.Filter = "XML Files (*.xml)|*.xml";
      string filePath;
      var result = xmlFilePath.ShowDialog();
      return (result != DialogResult.OK) ? "" : xmlFilePath.FileName;
    }

    public string SavePath()
    {
      SaveFileDialog xmlFilePath = new SaveFileDialog();
      xmlFilePath.Filter = "XML Files (*.xml)|*.xml";
      string filePath;
      var result = xmlFilePath.ShowDialog();
      return (result != DialogResult.OK) ? "" : xmlFilePath.FileName;
    }
  }
}