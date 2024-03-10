using System.Numerics;
using BrusOgPotetgull.AirportLiberary.CustomExceptions;

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
        private List<KeyValuePair<int, Taxiway>> connections;

        /// <summary>
        /// Creates a taxiway.
        /// </summary>
        /// <param name="name">The name of the taxiway.</param>
        /// <param name="length">Length of the taxiway.</param>
        /// <param name="maxSpeed">Legal maxspeed for the taxiway</param>
        public Taxiway(string name, int length, int maxSpeed)
        {
            // (dosnetCore, 2020)
            id = idCounter++;
            this.Id = id;
            this.Name = name;
            this.Length = length;
            this.MaxSpeed = maxSpeed;
            connections = new List<KeyValuePair<int, Taxiway>>();
        }

        public int Length { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MaxSpeed { get; private set; }

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
            Console.Write($"\n\n\tConnected taxiways:\n");
            // (Nagel, 2022, s. 216)
            foreach (var line in connections)
            {
                Console.WriteLine($"{line.Key}, {line.Value}");
            }
        }

        /// <summary>
        /// returns the id and name for the airport that this taxiway is located at.
        /// </summary>
        /// <returns>String that contain information about the taxiway.</returns>
        private string GetAirportNameAndTaxiwayId() => (string)(airportLocation + ", " + "Taxiway-id: " + Id + ", Name: " + Name);

        /// <summary>
        /// Adds an connected taxiway to an taxiway.
        /// </summary>
        /// <param name="locationAtTaxiway">The location at the taxiway.</param>
        /// <param name="taxiway">The taxiway-object.</param>
        public void AddConnectedTaxiway(int locationAtTaxiway, Taxiway taxiway)
        {
            foreach (KeyValuePair<int, Taxiway> pair in connections)
            {
                if (pair.Value == taxiway)
                {
                    throw new DuplicateOfContentException($"{taxiway} could not be added as a connection for this taxiway at location: '{locationAtTaxiway}'. It is already connected to this taxiway.");
                }
            }
            connections.Add(new KeyValuePair<int, Taxiway>(locationAtTaxiway, taxiway));
        }

        /// <summary>
        /// Adds an flight to the queue for the taxiway.
        /// </summary>
        /// <param name="flight">The flight that is insertet into the queue.</param>
        /// <param name="time">Used to log the time to the history of the used aircraft.</param>
        public void AddFlightToQueue(Flight flight, DateTime time)
        {
            // Sjekk om flight allerede finnes i køen
            if (taxiwayQueue.Contains(flight))
            {
                throw new InvalidOperationException($"Flight with id {flight.FlightId} already exists in queue");

            }
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
                Flight nextFlight = taxiwayQueue.Peek();
                return nextFlight;
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
                flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndTaxiwayId(), ", Leaves taxiwayqueue");
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
        public int SimulateTaxiwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed, DateTime time)
        {
            flight.ActiveAircraft.AddHistoryToAircraft(time, GetAirportNameAndTaxiwayId(), ", Enter taxiway");
            
            return flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);
        }

        public int GetNumberOfAircraftsInQueue()
        {
            return taxiwayQueue.Count();
        }
    }
}