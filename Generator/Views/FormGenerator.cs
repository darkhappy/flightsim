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
    private string currentPath = "";

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
      gbAirplanes.Enabled = false; 
      gbAirports.Enabled = false;

      EnableGroups(false);
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
    ///   Update shown airports whenever the listAirports changes
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

    /// <summary>
    ///   Update shown airplanes whenever the listAirports changes
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
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
    ///   Check if all airplane data are valid
    /// </summary>
    /// <returns>Whether airplane info are valid</returns>
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

    /// <summary>
    ///   Convert the string enter in the form into an <see cref="AirplaneType"/>
    /// </summary>
    /// <param name="type"></param>
    /// <returns>The <see cref="AirplaneType"/></returns>
    /// <exception cref="ArgumentException">Unknown <see cref="AirplaneType"/></exception>
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

    /// <summary>
    ///   Convert all airport info into either a <see cref="TransportInfo"/> or a <see cref="AirplaneInfo"/>
    /// </summary>
    /// <param name="type">The <see cref="AirplaneType"/> entered in the form</param>
    /// <returns> The airplane info entered in the form</returns>
    /// <exception cref="ArgumentException">Unknown <see cref="AirplaneType"/></exception>
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

      Controllers.Generator.Instance.AddAirport(new AirportInfo(txbAirportId.Text, txbAirportName.Text, Position.StringToPosition(txbPosition.Text), pTraffic, cTraffic));

      listAirports.Items[listAirports.Items.Count - 1].Selected = true;
    }

    /// <summary>
    ///   Add a new <see cref="Airplane"/> to the <see cref="Scenario" />
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

    /// <summary>
    ///   Delete the selected <see cref="Airport"/> of the <see cref="Scenario" />
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void btnDeleteAirport_Click(object sender, EventArgs e)
    {
      if (listAirports.SelectedIndices.Count == 0)
      {
        labError.Visible = true;
        labError.Text = "Please select an airport to delete it";
        return;
      }

      int selected = listAirports.SelectedIndices[0];

      Controllers.Generator.Instance.DeleteAirport(listAirports.SelectedItems[0].SubItems[0].Text);
      try 
      { 
        if(selected == 0)
          listAirports.Items[selected].Selected = true;
        else
          listAirports.Items[selected-1].Selected = true; 
      }
      catch 
      {
        ResetAirportInfo();
        listAirplanes.Items.Clear();
      };

      labError.Visible = false;
    }

    /// <summary>
    ///   Delete the selected <see cref="Airplane"/> of the <see cref="Scenario" />
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void btnDeleteAirplane_Click(object sender, EventArgs e)
    {
      if (listAirplanes.SelectedIndices.Count == 0)
      {
        labError.Visible = true;
        labError.Text = "Please select a plane to delete it";
        return;
      }

      int selected = listAirplanes.SelectedIndices[0];

      Controllers.Generator.Instance.DeleteAirplane(listAirplanes.SelectedItems[0].SubItems[0].Text);
      Controllers.Generator.Instance.UpdateAirplanes(listAirports.SelectedItems[0].SubItems[0].Text);

      try 
      { 
        if (selected == 0)
          listAirplanes.Items[selected].Selected = true;
        else
          listAirplanes.Items[selected - 1].Selected = true;
      }
      catch 
      {
        ResetAirplaneInfo();
      };

      labError.Visible = false;
    }

    /// <summary>
    ///   Edit the selected <see cref="Airport"/> of the <see cref="Scenario" />
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void btnEditAirport_Click(object sender, EventArgs e)
    {
      if (listAirplanes.SelectedIndices.Count == 0)
      {
        labError.Visible = true;
        labError.Text = "Please select an airport to edit it";
        return;
      }

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

    /// <summary>
    ///   Edit the selected <see cref="Airplane"/> of the <see cref="Scenario" />
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void btnEditAirplane_Click(object sender, EventArgs e)
    {
      if (listAirplanes.SelectedIndices.Count == 0)
      {
        labError.Visible = true;
        labError.Text = "Please select a plane to edit it";
        return;
      }

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

    /// <summary>
    ///   Open the <see cref="FormMap"/> to obtain the <see cref="Airport"/> positon
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void txbPosition_Click(object sender, EventArgs e)
    {
      _mapPos = new FormMap();
      var result = _mapPos.ShowDialog();
      if (result != DialogResult.OK) return;

      var pos = _mapPos.Pos;

      txbPosition.Text = Position.Transpose(pos.X, pos.Y);
      Position.StringToPosition(txbPosition.Text);
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

    /// <summary>
    ///   Can open a <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolOpen_Click(object sender, EventArgs e)
    {
      if (currentPath != "")
      {
        DialogResult dialogResult = MessageBox.Show("Before leaving, do you want to save any modification?", "Are you sure?", MessageBoxButtons.YesNoCancel);
        if (dialogResult == DialogResult.Yes)
        {
          if (!Controllers.Generator.Instance.CanSerialize())
          {
            MessageBox.Show("You need at least two airports to save the scenario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }
          Controllers.Generator.Instance.Export(currentPath);
        }
        else if (dialogResult == DialogResult.Cancel)
        {
          return;
        }
      }

      string path = OpenPath();

      if (path == "") return;

      Controllers.Generator.Instance.Import(path);
    }

    /// <summary>
    ///   Can create a new <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolNew_Click(object sender, EventArgs e)
    {
      if (currentPath != "")
      {
        DialogResult dialogResult = MessageBox.Show("Before leaving, do you want to save any modification?", "Are you sure?", MessageBoxButtons.YesNoCancel);
        if (dialogResult == DialogResult.Yes)
        {
          Controllers.Generator.Instance.Export(currentPath);
        }
        else if (dialogResult == DialogResult.Cancel)
        {
          return;
        }
      }

      string path = SavePath();

      if (path == "") return;
      
      Controllers.Generator.Instance.Export(path);
    }

    /// <summary>
    ///   Can save the <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolSave_Click(object sender, EventArgs e)
    {
      if (currentPath == "")
      {
        MessageBox.Show("No scenario to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (!Controllers.Generator.Instance.CanSerialize())
      {
        MessageBox.Show("You need at least two airports to save the scenario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      Controllers.Generator.Instance.Export(currentPath);
    }

    /// <summary>
    ///   Can save at specific location and rename the <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolSaveAs_Click(object sender, EventArgs e)
    {
      if (currentPath == "")
      {
        MessageBox.Show("No scenario to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (!Controllers.Generator.Instance.CanSerialize())
      {
        MessageBox.Show("You need at least two airports to save the scenario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      string path = SavePath();

      if (path == "")
      {
        MessageBox.Show("Choose a valid XML file", "XML Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      Controllers.Generator.Instance.Export(path);
    }

    /// <summary>
    ///   Can close the current <see cref="Scenario"/>
    /// </summary>
    /// <param name="sender">Object that trigger the event</param>
    /// <param name="e">The event</param>
    private void subToolClose_Click(object sender, EventArgs e)
    {
      if (currentPath == "")
      {
        MessageBox.Show("No scenario to close", "Warning" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      DialogResult dialogResult = MessageBox.Show("Before leaving, do you want to save any modification?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
      if (dialogResult == DialogResult.Yes)
      {
        if (!Controllers.Generator.Instance.CanSerialize())
        {
          MessageBox.Show("You need at least two airports to save the scenario", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }
        Controllers.Generator.Instance.Export(currentPath);
      }
      else if (dialogResult == DialogResult.Cancel)
      {
        return;
      }

      //Reset View
      listAirports.Items.Clear();
      listAirplanes.Items.Clear();
      ResetAirplaneInfo();
      ResetAirportInfo();

      ResetPath();

      EnableGroups(false);
    }

    /// <summary>
    ///   Set the new XML <see cref="Scenario"/> file for the <see cref="Generator"/>
    /// </summary>
    /// <param name="path">The path of the XML file</param>
    public void SetPath(string path) 
    {
      currentPath = path;
      this.Text = "Scenario Generator - " + currentPath;

      if (listAirports.Items.Count > 0)
        listAirports.Items[0].Selected = true;
    }

    /// <summary>
    ///   Reset the XML path for the <see cref="Generator"/>
    /// </summary>
    public void ResetPath()
    {
      this.Text = "Scenario Generator";
      currentPath = "";
    }

    /// <summary>
    ///   Will give the path of the <see cref="Scenario"/> that will be opened
    /// </summary>
    /// <returns>The path of the <see cref="Scenario"/></returns>
    public string OpenPath()
    {
      OpenFileDialog xmlFilePath = new OpenFileDialog();
      xmlFilePath.Filter = "XML Files (*.xml)|*.xml";
      var result = xmlFilePath.ShowDialog();

      return (result != DialogResult.OK) ? "" : xmlFilePath.FileName;
    }

    /// <summary>
    ///   Will give the path of the <see cref="Scenario"/> that will be saved
    /// </summary>
    /// <returns>The path of the <see cref="Scenario"/></returns>
    public string SavePath()
    {
      SaveFileDialog xmlFilePath = new SaveFileDialog();
      xmlFilePath.Filter = "XML Files (*.xml)|*.xml";
      var result = xmlFilePath.ShowDialog();

      return (result != DialogResult.OK) ? "" : xmlFilePath.FileName;
    }

    /// <summary>
    /// Will enable or disable all the <see cref="FormGenerator"/> elements
    /// </summary>
    /// <param name="enabled">Whether the groups are enabled or not</param>
    public void EnableGroups(bool enabled)
    {
      gbAirplanes.Enabled = enabled;
      gbAirports.Enabled = enabled;
    }

    /// <summary>
    /// Will reset all <see cref="Airport"/> info in the <see cref="FormGenerator"/> fields
    /// </summary>
    private void ResetAirportInfo()
    {
      txbAirportId.Text = "";
      txbAirportName.Text = "";
      txbPosition.Text = "";
      numPTraffic.Text = "5";
      numCTraffic.Text = "5";
    }

    /// <summary>
    /// Will reset all <see cref="Airplane"/> info in the <see cref="FormGenerator"/> fields
    /// </summary>
    private void ResetAirplaneInfo()
    {
      txbAirplaneId.Text = "";
      txbAirplaneName.Text = "";
      cmbType.Text = "Cargo";

      numSpeed.Value = 900;
      numCapacity.Value = 15;
      numEmbarking.Value = 15;
      numDisembarking.Value = 15;
      numMaintenance.Value = 15;
    }
  }
}