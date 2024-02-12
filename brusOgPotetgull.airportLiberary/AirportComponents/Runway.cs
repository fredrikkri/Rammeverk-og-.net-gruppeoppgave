using System;
namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The runway class is defining how a runway is designed.
    /// </summary>
	public class Runway
	{
        private static int idCounter = 1;
        private int id;
        private bool inUse;
        private Queue<Flight> runwayQueue = new Queue<Flight>();

        /// <summary>
        /// creates a runway.
        /// </summary>
        /// <param name="locatedAtAirport">Which airport it is located at.</param>
        /// <param name="length">The length of the runway.</param>
        public Runway(Airport locatedAtAirport, int length)
        {
            // (dosnetCore, 2020) 
            id = idCounter++;
            Id = id;
            this.LocatedAtAirport = locatedAtAirport;
            this.Length = length;
            this.inUse = false;
            InUse = inUse;
        }

        public int Id { get; private set; }
        public Airport LocatedAtAirport { get; private set; }
        public int Length { get; private set; }
        public bool InUse { get; private set; }
        public Queue<Flight> RunwayQueue { get {  return runwayQueue; } }

        public void PrintRunwayInformation()
        {
            Console.Write($"\nRunway id: {Id}\nLocated at airport: {LocatedAtAirport}\nLength: {Length}\nIn use: {InUse}\n");
        }

        /// <summary>
        /// returns the id and the code (nickname) for the airport that this runway is located at.
        /// </summary>
        /// <returns>String containing id and airportcode.</returns>
        public string GetIdRunwayAndAirportCode()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }

        /// <summary>
        /// Removed the flight located first in line in the runwayqueue.
        /// </summary>
        /// <returns>Flight object that is removed from the beginning of the queue.</returns>
        public Flight RemoveFromQueue()
        {
            return runwayQueue.Dequeue();
        }

        /// <summary>
        /// Adds flight to runway-queue.
        /// </summary>
        /// <param name="flight">The current flight that is added to runwayqueue.</param>
        public void AddFlightToQueue(Flight flight)
        {   
            runwayQueue.Enqueue(flight);
        }

        /// <summary>
        /// Checks which flight that is located first in line in runwayqueue.
        /// </summary>
        /// <returns>Flight object that is first in line at queue.</returns>
        public Flight CheckNextFlightInQueue()
        {
            Flight nextFlight = runwayQueue.Peek();
            return nextFlight;
        }

        /// <summary>
        /// This method lets the next flight in queue enter the runway.
        /// </summary>
        /// <param name="flight">Used to remove the flight from the runwayqueue.</param>
        public void NextFlightEntersRunway(Flight flight)
        {
            if (runwayQueue.Count != 0)
            {
                Flight nextFlight = runwayQueue.Dequeue();
                runwayQueue.TrimExcess();
            } 

            else
            {
                Console.Write($"No flights in runway - {id} queue");
            }
        }

        /// <summary>
        /// Returns the time in seconds that an aircraft uses on the runway. Given the length of runway is meters, and speed / speedChange is kph.
        /// </summary>
        /// <param name="flight">The current flight.</param>
        /// <param name="initialSpeed">Parameter for CalculateFlightMovement().</param>
        /// <param name="speedChange">Parameter for CalculateFlightMovement().</param>
        /// <param name="maxSpeed">Parameter for CalculateFlightMovement().</param>
        /// <returns>Returns the method flight.CalculateFlightMovement() which is the time taken for the simulation.</returns>
        public int SimulateRunwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed) {
            return flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);
        }

        /// <summary>
        /// Sets the runwaystatus to 'inUse = true'
        /// </summary>
        /// <param name="flight">Is the aircraft that uses the runway.</param>
        /// <param name="time">Is used to log the history of the aircraft.</param>
        public void UseRunway(Flight flight, DateTime time)
        {
            inUse = true;
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Runway " + GetIdRunwayAndAirportCode(), ", Enter the runway");
        }

        /// <summary>
        /// Sets the runwaystatus to 'inUse = false'
        /// </summary>
        /// <param name="flight">Is the aircraft that is leaving the runway.</param>
        /// <param name="time">Is used to log the history of the aircraft.</param>
        public void ExitRunway(Flight flight, DateTime time)
        {
            inUse = false;
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Runway " + GetIdRunwayAndAirportCode(), ", Leaves Runway");
        }
    }
}

