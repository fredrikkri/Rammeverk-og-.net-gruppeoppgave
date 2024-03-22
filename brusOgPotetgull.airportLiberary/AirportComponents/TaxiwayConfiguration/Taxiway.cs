using BrusOgPotetgull.AirportLiberary.CustomExceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The taxiway class is defining how a taxiway is designed.
    /// </summary>
	public class Taxiway
    {
        private static int idCounter = 1;
        private int id;
        private Queue<Flight> taxiwayQueue = new Queue<Flight>();
        private string? airportLocation;
        public List<Gate> connectedGates;
        public List<Taxiway> connectedTaxiways;
        public List<Runway> connectedRunways;

        /// <summary>
        /// Creates a taxiway.
        /// </summary>
        /// <param name="name">The name of the taxiway.</param>
        /// <param name="length">Length of the taxiway (meters).</param>
        /// <param name="maxSpeed">Legal maxspeed for the taxiway (Kp/h).</param>
        public Taxiway(string name, int length, int maxSpeed)
        {
            // (dosnetCore, 2020)
            id = idCounter++;
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.MaxSpeed = maxSpeed;
            this.connectedGates = new List<Gate>(); 
            this.connectedTaxiways = new List<Taxiway>();
            this.connectedRunways = new List<Runway>();
        }

        public int Length { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MaxSpeed { get; private set; }
        public ConnectionPoint A {  get; set; }
        public ConnectionPoint B { get; set; }
        //public List<Runway> connectedRunways { get; set; }
        //public List<Gate> connectedGates { get; set; }

        /// <summary>
        /// Adds a gate to the list of connected gates for this taxiway.
        /// </summary>
        /// <param name="gate">The gate that will be added to the list.</param>
        public void AddConnectedGate(Gate gate)
        {
            if (connectedGates.Contains(gate))
                throw new InvalidOperationException($"Gate: '{gate.Name}' is already connected to taxiway: '{Name}'");
            connectedGates.Add(gate);
        }

        /// <summary>
        /// Removes a gate from the list of connected gates for this taxiway.
        /// </summary>
        /// <param name="gate">The gate that will be removed from the list.</param>
        public void RemoveConnectedGate(Gate gate)
        {
            if (!connectedGates.Contains(gate))
                throw new InvalidOperationException($"Gate: '{gate.Name}' cannot be removed as an connection for taxiway: '{Name}'. It does not exist as an connection to this taxiway.");
            connectedGates.Remove(gate);
        }

        /// <summary>
        /// Adds a taxiway to the list of connected taxiways for this taxiway.
        /// </summary>
        /// <param name="taxiway">The taxiway that will be added to the list.</param>
        public void AddConnectedTaxiway(Taxiway taxiway)
        {
            /*if (connectedTaxiways.Contains(taxiway))
            {
                throw new InvalidOperationException($"Taxiway: '{taxiway.Name}' is already connected to taxiway: '{Name}'");
            }*/
            connectedTaxiways.Add(taxiway);
            taxiway.AddConnectedTaxiway(this);
            
        }

        /// <summary>
        /// Removes a taxiway from the list of connected taxiways for this taxiway.
        /// </summary>
        /// <param name="taxiway">The taxiway that will be removed to the list.</param>
        public void RemoveConnectedTaxiway(Taxiway taxiway)
        {
            if (!connectedTaxiways.Contains(taxiway))
                throw new InvalidOperationException($"Taxiway: '{taxiway.Name}' cannot be removed as an connection for taxiway: '{Name}'. It does not exist as an connection to this taxiway.");
            connectedTaxiways.Remove(taxiway);
        }

        public List<Taxiway> GetConnectedTaxiways() => connectedTaxiways;

        /// <summary>
        /// Adds a runway to the list of connected runways for this taxiway.
        /// </summary>
        /// <param name="runway">The runway that will be added to the list.</param>
        public void AddConnectedRunway(Runway runway)
        {
            if (connectedRunways.Contains(runway))
                throw new InvalidOperationException($"Runway: '{runway.Name}' is already connected to taxiway: '{Name}'");
            connectedRunways.Add(runway);
        }

        /// <summary>
        /// Removes a runway from the list of connected runways for this taxiway.
        /// </summary>
        /// <param name="runway">The runway that will be removed from the list.</param>
        public void RemoveConnectedRunway(Runway runway)
        {
            if (!connectedRunways.Contains(runway))
                throw new InvalidOperationException($"Runway: '{runway.Name}' cannot be removed as an connection for taxiway: '{Name}'. It does not exist as an connection to this taxiway.");
            connectedRunways.Remove(runway);
        }

        /// <summary>
        /// Updates the information for which airport the taxiway is located at.
        /// </summary>
        /// <param name="airportName">Name of the airport that the taxiway is located at now.</param>
        public void UpdateLocation(string airportName)
        {
            airportLocation = airportName;
        }

        /// <summary>
        /// Prints the information about the taxiway.
        /// </summary>
        public void PrintTaxiwayInformation()
		{
            Console.Write($"\nTaxiwayId: {Id}\n" +
                $"Name: {Name}\n" +
                $"Taxiway lenght: {Length}\n" +
                $"Airport location: { airportLocation}\n");
            Console.WriteLine("Connections:");
            foreach (Gate gate in connectedGates)
                Console.Write($"Gate: {gate.Name} ");
            foreach (Taxiway taxiway in connectedTaxiways)
                Console.Write($"Taxiway: {taxiway.Name} ");
            foreach (Runway runway in connectedRunways)
                Console.Write($"Runway: {runway.Name} ");
        }

        /// <summary>
        /// returns the id and name for the airport that this taxiway is located at.
        /// </summary>
        /// <returns>String that contain information about the taxiway.</returns>
        private string GetAirportNameAndTaxiwayId() => (string)(airportLocation + ", " + "Taxiway-id: " + Id + ", Name: " + Name);

        /// <summary>
        /// Adds an flight to the queue for the taxiway.
        /// </summary>
        /// <param name="flight">The flight that is insertet into the queue.</param>
        /// <param name="time">Used to log the time to the history of the used aircraft.</param>
        public void AddFlightToQueue(Flight flight, DateTime time)
        {
            // Sjekk om flight allerede finnes i køen
            if (taxiwayQueue.Contains(flight))
                throw new InvalidOperationException($"Flight with id {flight.FlightId} already exists in queue");
            // (Nagel, 2022, s. 203)
            taxiwayQueue.Enqueue(flight);
            flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndTaxiwayId(), ", Arrived at taxiwayqueue");
        }

        /// <summary>
        /// This method checks which flight is next in line for this taxiway.
        /// </summary>
        /// <returns>A flight object.</returns>
        public Flight CheckNextFlightInQueue()
        {
            if (taxiwayQueue.Count > 0)
            {
                Flight nextFlight = taxiwayQueue.Peek();
                return nextFlight;
            }
            else
            {
                throw new InvalidOperationException("taxiway kø er tom");
            }
        }

        /// <summary>
        /// The aircraft first in line for taxiwayqueue leaves the taxiwayqueue.
        /// </summary>
        /// <param name="flight">Used to log correct history for the used aircraft.</param>
        /// <param name="time">Used to log correct history for the used aircraft.</param>
        public void NextFlightLeavesTaxiway(Flight flight, DateTime time)
        {
            // (Nagel, 2022, s. 203)
            while (taxiwayQueue.Count > 0)
            {
                Flight nextFlightInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndTaxiwayId(), ", Leaves taxiway");
            }
        }

        /// <summary>
        /// Simulates an aircraft using the taxiway
        /// </summary>
        /// <param name="flight">The flight thats is using the taxiway.</param>
        /// <param name="initialSpeed">The speed at which the aircraft starts with (Kp/h).</param>
        /// <param name="speedChange">The change in speed (Kp/h).</param>
        /// <param name="maxSpeed">Maximum speed for this calculation (Kp/h).</param>
        /// <param name="time">Used to log the history of the plane.</param>
        /// <returns>Returns the method flight.CalculateFlightMovement() which is the time taken for the simulation.</returns>
        public double SimulateTaxiwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed, DateTime time)
        {
            flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndTaxiwayId(), ", Enter taxiway");
            
            return flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);
        }

        /// <summary>
        /// Gets the number og aircrafts in queue.
        /// </summary>
        /// <returns>An int value</returns>
        public int GetNumberOfAircraftsInQueue()
        {
            return taxiwayQueue.Count();
        }
    }
}