using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Runway
	{
        private static int idCounter = 1;
        private int id;
        private bool inUse;
        private Queue<Flight> runwayQueue = new Queue<Flight>();

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
        /// returns the id and the nickname for the airport that this runway is located at.
        /// </summary>
        /// <returns></returns>
        public string GetIdRunwayAndAirportCode()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }

        public Flight RemoveFromQueue()
        {
            return runwayQueue.Dequeue();
        }

        /// <summary>
        /// Adds flight to runway-queue.
        /// </summary>
        /// <param name="flight"></param>
        public void AddFlightToQueue(Flight flight)
        {   
            runwayQueue.Enqueue(flight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="runway"></param>
        public Flight CheckNextFlightInQueue()
        {
            Flight nextFlight = runwayQueue.Peek();
            return nextFlight;
        }

        public void NextFlightEntersRunway(Flight flight)
        {
            if (runwayQueue.Count != 0)
            {
                var nextFlight = runwayQueue.Dequeue();
                runwayQueue.TrimExcess();
            } 

            else
            {
                Console.Write($"No flights in runway - {id} queue");
            }
        }

        // Returns the time in seconds an aircraft uses on the runway. Given the length of runway is meters, and speed / speedChange is kph
        public int SimulateRunwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed) {
            return flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);
        }

        public void UseRunway(Flight flight, DateTime time)
        {
            inUse = true;
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Runway " + GetIdRunwayAndAirportCode(), ", Enter the runway");
        }

        public void ExitRunway(Flight flight, DateTime time)
        {
            inUse = false;
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Runway " + GetIdRunwayAndAirportCode(), ", Leaves Runway");
        }
    }
}

