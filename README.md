# flightsim

Flight simulator for C#

Made by:

* 1409427 - Raphaël Rail
* 1927230 - Jean-Philippe Miguel-Gagnon
* 2074857 - Jérémy Gaouette

Happy correction!

## Generator

There's some jazzy music in the background.

There are also multiple options: you can create a new scenario, open an old one, save and save as, etc.

## Simulator

There's some jazzy music in the background.

There are multiple simulations available in `Simulator/`.
There is:

* `HugeScenario.xml` - a large simulation with many objects
* `Simple_Scenario.xml` - a simple simulation with a few objects
* `Test_Cargo.xml` - a simulation where a CargoTask is handled
* `Test_Fight.xml` - a simulation where a FightTask is handled
* `Test_Passenger.xml` - a simulation where a PassengerTask is handled
* `Test_Scout.xml` - a simulation where a ScoutTask is handled
* `Test_Rescue.xml` - a simulation where a RescueTask is handled

## Important

A scout plane currently bugs out as there is an issue handling a circle. It will simply stay in the air in a specific
angle. We did not have enough time to handle this bug.

The simulator might seem slow at first. We didn't have a lot of time to balance all constants (they are found
in `Controllers/Constants.cs`).
We recommend setting the tick to a high number (20-50).

It might seem at first that the client list is empty. This is because if a client is embarking in a plane, it will be
removed from this list.

Tasks are also not shown in the list, as they are on the map.

## GRASP

### Low coupling

One of the hardest challenges was achieving low between each of the classes. One particular issue was during the
construction airplanes.

Since the construction of a plane requires the ID, the Name, the Type, the Speed, the Maintenance speed, and more, this
resulted in a constructor that had over 9 parameters. We initially did a dictionary of parameters, but this resulted in
a lot of code to simply process the dictionary ( ensuring all types are correct, casting every single parameter, etc).

To counter this, we decided to use a class that would be able to store the parameters. This resulted in a much cleaner
code, and a much more readable code. However, the drawback was that there was more coupling between the classes, as the
class must be passed in the form, the controller, the scenario, the airport and the airplane.

### High cohesion

Every class did it's own thing. All logic involving moving the plane was in the FlyingState class, all airport's jobs
was to manage the planes as well as its clients, etc.

There weren't classes in which it handled things outside of its class.

### Expert

Every class follows this pattern. There aren't any classes that do jobs outside of their class.

### Polymorphism

Most if not all calls are polymorphic. The only calls that aren't polymorphic are when the airplane is assigned a task.

Each airplane is associated a task type. All events are also associated with a task type. When we assign an airplane to
a task, we check if these two types are equal.

However, this brings problems further down the line, such as:

* What if we want a plane that can do two types of tasks?
* What if we want a task that can be done by two types of planes?

The solution to this would have been to assign multiple virtual methods in the abstract Airplane task "CanHandleXEvent",
but it would've required a lot of work and boilerplate to fix the issue.

### Creator

The only thing that was fabricated in the simulator were tasks, which were done by the scenario. The scenario had a list
of tasks, so it made sense for ti to create them.
The exception would be the TaskTransport class, as it can split and merge itself. However, as it is a task creating a
task, it still follows the Creator pattern.

## GOF

### Singleton

The following classes are Singletons:

#### Generator

* `Controllers/Simulator.cs` - Controller
* `Models/AirplaneFactory.cs` - AirplaneFactory, creates airplanes

#### Simulator

* `Models/Scenario.cs` - Scenario, ensure that there is only one scenario ongoing
* `Controllers/Simulator.cs` - Controller
* `Models/Task/TaskFactory.cs` - TaskFactory, creates tasks

These are to ensure that there is only one instance of each class. Scenario was a particular case, as it is a singleton,
but since it gets deserialized, we had a difficulty setting it as a singleton.

### Factory

The following classes are factories:

#### Generator

* `Models/AirplaneFactory.cs` - AirplaneFactory, creates airplanes

#### Simulator

* `Models/Task/TaskFactory.cs` - TaskFactory, creates tasks

These factories ensured the ease of creating new instances of classes.

### State

The following classes are states:

#### Simulator

* `Models/States/DisembarkingState.cs` - DisembarkingState, when the plane is disembarking
* `Models/States/EmbarkingState.cs` - EmbarkingState, when the plane is embarking
* `Models/States/FightingFlight.cs` - FightingFlight, when the plane is fighting
* `Models/States/MaintenanceState.cs` - MaintenanceState, when the plane is in maintenance
* `Models/States/RescueFlight.cs` - RescueFlight, when the plane is rescuing a client
* `Models/States/ScoutFlight.cs` - ScoutFlight, when the plane is scouting
* `Models/States/TransportFlight.cs` - TransportingState, when the plane is transporting a client


### Facade

The following classes are facades:

#### Generator

* `Models/Scenario.cs` - Scenario, the scenario

#### Simulator

* `Models/Scenario.cs` - Scenario, the scenario

These two classes are the main entry points to the models, and the only classes that are exposed to the controller of their respective programs.