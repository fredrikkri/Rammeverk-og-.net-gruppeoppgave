using BrusOgPotetgull.AirportLiberary.CustomExceptions;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The runway class is used to define how a runway is designed.
    /// It is also used to conduct operations on the runway.
    /// </summary>
	public class Runway
	{
        private static int idCounter = 1;
        private int id;
        private bool inUse;
        private Queue<Flight> runwayQueue = new Queue<Flight>();
        private string? airportLocation;

        /// <summary>
        /// Event to be used when a flight is ariving
        /// </summary>
        public event EventHandler<ArrivingEventArgs>? FlightArrived;

        /// <summary>
        /// Event to be used when a flight is departing
        /// </summary>
        public event EventHandler<DepartingEventArgs>? FlightDeparted;

        /// <summary>
        /// creates a runway.
        /// </summary>
        /// <param name="name">The name of the runway (meters).</param>
        /// <param name="length">The length of the runway (meters).</param>
        /// <param name="airport">The airport that the taxiway will be located at.</param>
        public Runway(string name, int length, Airport airport)
        {
            // (dosnetCore, 2020) 
            id = idCounter++;
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.inUse = false;
            InUse = inUse;
            airport.AddRunwayToList(this);
        }

        /// <summary>
        /// Gets the Id of the runway.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the runway.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the length of the runway.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Gets a bool value i wheter the runway is in use or not.
        /// </summary>
        public bool InUse { get; private set; }

        /// <summary>
        /// Gets the queue of flights waiting for the runway.
        /// </summary>
        public Queue<Flight> RunwayQueue { get {  return runwayQueue; } }

        /// <summary>
        /// Updates the airport the Runway is located at.
        /// </summary>
        /// <param name="airportName">Name of the airport that you want to update the location to.</param>
        public void UpdateLocation(string airportName)
        {
            airportLocation = airportName;
        }

        /// <summary>
        /// Prints the information about the Runway.
        /// </summary>
        public void PrintRunwayInformation()
        {
            Console.Write($"\nRunway id: {Id} + " +
                $"\nName: {Name} + " +
                $"\nLength: {Length} + " +
                $"\nIn use: {InUse} + " +
                $"\nAirport location: {airportLocation}\n");
        }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the Runway.</returns>
        public override string ToString()
        {
            return $"\nRunway id: {Id} + " +
                $"\nName: {Name}";
        }

        /// <summary>
        /// Returns the airport location aswell as the runwayname and id.
        /// </summary>
        /// <returns>String that contain information about the runway.</returns>
        public string GetAirportNameAndRunwayId() => (string)(airportLocation + ", " + "Runway-id: " + Id + ", Name: " + Name);

        /// <summary>
        /// Removes the first flight in the runwayqueue and returns it.
        /// </summary>
        /// <returns>Flight object that is removed from the beginning of the queue.</returns>
        public Flight RemoveFromQueue()
        {
            if (runwayQueue.Peek() == null)
                throw new InvalidOperationException("Runwayqueue is empty. An object cannot be removed from the beginning of the queue.");
            return runwayQueue.Dequeue();
        }

        /// <summary>
        /// Adds a flight to the runway-queue.
        /// </summary>
        /// <param name="flight">The flight you want to add to the runwayqueue.</param>
        public void AddFlightToQueue(Flight flight)
        {   
            runwayQueue.Enqueue(flight);
        }

        /// <summary>
        /// Returns the first flight in the runwayqueue.
        /// </summary>
        /// <returns>Flight object that is first in line at the queue.</returns>
        public Flight CheckNextFlightInQueue() => runwayQueue.Peek();

        /// <summary>
        /// This method lets the next flight in queue enter the runway.
        /// </summary>
        public void NextFlightEntersRunway()
        {
            if (runwayQueue.Count < 0)
                throw new NegativeNumberException("Number of values in runwayQueue is a negative number.");
            if (runwayQueue.Count == 0)
                throw new InvalidOperationException($"No flights in runway - {id} queue");
            Flight nextFlight = runwayQueue.Dequeue();
            runwayQueue.TrimExcess();
        }

        /// <summary>
        /// Returns the time in seconds that an aircraft uses on the runway. Given the length of runway is meters, and speed / speedChange is kph.
        /// </summary>
        /// <param name="flight">The current flight.</param>
        /// <param name="initialSpeed">The speed at which the aircraft starts with (Kp/h).</param>
        /// <param name="speedChange">The change in speed (Kp/h).</param>
        /// <param name="maxSpeed">Maximum speed for this calculation (Kp/h).</param>
        /// <returns>Returns the method flight.CalculateFlightMovement() which is the time spent on the runway in seconds.</returns>
        public double SimulateRunwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed) => flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);

        /// <summary>
        /// Method to signal that an aircraft is using the runway.
        /// Sets the field inUse to true and logs the event.
        /// </summary>
        /// <remarks>
        /// If the flight is an arriving flight. The method RaiseFlightArrived is used to handle the event and logging.
        /// </remarks>
        /// <param name="flight">Is the aircraft that uses the runway.</param>
        /// <param name="time">Is used to log the history of the aircraft.</param>
        public void UseRunway(Flight flight, DateTime time)
        {
            inUse = true;
            if (flight.IsArrivingFlight == true)
                RaiseFlightArrived((Flight.Arriving)flight, time, $"{flight.ActiveAircraft.Name} has landed");
            else
                flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndRunwayId(), ", Enters the runway");
        }

        /// <summary>
        /// Method to signal that an aircraft has left the runway.
        /// Set the field inUse to false and logs to event
        /// </summary>
        /// <remarks>
        /// If the flight is a departing flight, the method RaiseFlightDeparted() triggers the FlightDeparted event.
        /// </remarks>
        /// <param name="flight">Is the aircraft that is leaving the runway.</param>
        /// <param name="time">Is used to log the history of the aircraft.</param>
        public void ExitRunway(Flight flight, DateTime time)
        {
            inUse = false;
            if (flight.IsArrivingFlight == false)
                RaiseFlightDeparted((Flight.Departing)flight, time, $"{flight.ActiveAircraft.Name} has departed");
            else
                flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndRunwayId(), ", Leaves the runway");
        }

        /// <summary>
        /// Method to trigger the event FlightArrived
        /// </summary>
        /// <param name="flight">The flight which triggers the event</param>
        /// <param name="time">Time of the event</param>
        /// <param name="message">Message of what occured at the time of the event</param>
        protected virtual void RaiseFlightArrived(Flight.Arriving flight, DateTime time, string message)
        {
            FlightArrived?.Invoke(this, new ArrivingEventArgs(flight, time, message));
        }

        /// <summary>
        /// Method to trigger the event FlightDeparted
        /// </summary>
        /// <param name="flight">The flight which triggers the event</param>
        /// <param name="time">Time of the event</param>
        /// <param name="message">Message of what occured at the time of the event</param>
        protected virtual void RaiseFlightDeparted(Flight.Departing flight, DateTime time, string message)
        {
            FlightDeparted?.Invoke(this, new DepartingEventArgs(flight, time, message));
        }
    }
}

