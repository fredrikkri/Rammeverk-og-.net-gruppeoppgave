using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Taxiway
    {
        private static int idCounter = 1;
        private int id;
        private Queue<Flight> taxiwayQueue = new Queue<Flight>();

        public Taxiway(int length, int maxSpeed, Airport locatedAtAirport)
        {
            // (dosnetCore, 2020)
            id = idCounter++;
            this.Id = id;
            this.Length = length;
            this.MaxSpeed = maxSpeed;
            this.LocatedAtAirport = locatedAtAirport;
        }

        public int Length { get; private set; }
        public int Id { get; private set; }
        public int MaxSpeed { get; private set; }
        public Airport LocatedAtAirport { get; private set; }

        /// <summary>
        /// Prints the information about the taxiway.
        /// </summary>
        public void PrintTaxiwayInformation()
		{
            Console.Write($"\nTaxiwayId: {Id}\n" +
                $"Taxiway lenght: {Length}\n");
        }

        /// <summary>
        /// returns the id and the code (nickname) for the airport that this taxiway is located at.
        /// eksample: "Gate 1 GAR"
        /// </summary>
        /// <returns></returns>
        public string GetIdTaxiwayAndAirportCode()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }

        /// <summary>
        /// Adds an flight to the queue for the taxiway.
        /// Parameter 'flight' is the flight that is insertet into the queue.
        /// Parameter 'time' is used to log the time to the history of the used aircraft.
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="time"></param>
        public void AddFlightToQueue(Flight flight, DateTime time)
        {
            // (Nagel, 2022, s. 203)
            taxiwayQueue.Enqueue(flight);
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Taxiway " + GetIdTaxiwayAndAirportCode(), ", Arrived at taxiwayqueue");
            Console.Write($"\n{flight.ActiveAircraft.Model} has arrived at taxiwayqueue\n");
        }

        /// <summary>
        /// This method checks which flight is next in line for this taxiway.
        /// Returns a flight object.
        /// </summary>
        /// <returns></returns>
        public Flight CheckNextFlightInQueue()
        {
                Flight nextFlight = taxiwayQueue.Peek();
                return nextFlight;
        }

        /// <summary>
        /// The aircraft first in line for taxiwayqueue leaves the taxiwayqueue.
        /// Parameter 'flight' is used to log correct history for the used aircraft.
        /// Parameter 'time' is used to log correct history for the used aircraft.
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="time"></param>
        public void NextFlightLeavesTaxiway(Flight flight, DateTime time)
        {
            // (Nagel, 2022, s. 203)
            while (taxiwayQueue.Count > 0)
            {
                var nextFlightInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                flight.ActiveAircraft.AddHistoryToAircraft(time, "Taxiway " + GetIdTaxiwayAndAirportCode(), ", Leaves taxiwayqueue");
                Console.Write($"\n{flight.ActiveAircraft.Model} leaves taxiwayqueue\n");
                //Må ha denne i addtoqueue: SimulateTaxiwayTime(nextFlightInQueue, initialspeed, flight.ActiveAircraft.AccelerationOnGround, flight.ActiveAircraft.MaxSpeedOnGround);
            }
        }

        /// <summary>
        /// Simulates an aircraft using the taxiway
        /// Parameter 'flight' is the flight thats is using the taxiway.
        /// Parameter 'time' is used to log the history of the plane.
        /// The other parameters: initialSpeed, speedChange, maxSpeed is passed on to the CalculateFlightMovement() method.
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="initialSpeed"></param>
        /// <param name="speedChange"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int SimulateTaxiwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed, DateTime time)
        {
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Taxiway " + GetIdTaxiwayAndAirportCode(), ", Enter taxiway");
            
            return flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);
        }

        public int GetNumberOfAircraftsInQueue()
        {
            return taxiwayQueue.Count();
        }
    }
}