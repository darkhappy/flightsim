using System;
using System.Collections.Generic;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models
{
  public class Scenario
  {
    private static Scenario _instance;
    private List<Airport> _airports;
    private List<Task> _tasks;
    private List<Task> _unassignedTasks;

    public static Scenario Instance => _instance ?? (_instance = new Scenario());

    public void GenerateTasks()
    {
      throw new NotImplementedException();
    }

    public void HandleTick(double time)
    {
      throw new NotImplementedException();
    }

    public void RemoveTask(Task task)
    {
      throw new NotImplementedException();
    }

    public List<Airport> GetNearestAirports(Position position)
    {
      throw new NotImplementedException();
    }
  }
}