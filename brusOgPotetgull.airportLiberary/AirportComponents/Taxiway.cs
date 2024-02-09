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
        /// <returns>String that contain id and airportcode.</returns>
        public string GetIdTaxiwayAndAirportCode()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }

        /// <summary>
        /// Adds an flight to the queue for the taxiway.
        /// </summary>
        /// <param name="flight">The flight that is insertet into the queue.</param>
        /// <param name="time">Used to log the time to the history of the used aircraft.</param>
        public void AddFlightToQueue(Flight flight, DateTime time)
        {
            // (Nagel, 2022, s. 203)
            taxiwayQueue.Enqueue(flight);
            flight.ActiveAircraft.AddHistoryToAircraft(time, "Taxiway " + GetIdTaxiwayAndAirportCode(), ", Arrived at taxiwayqueue");
            Console.Write($"\n{flight.ActiveAircraft.Model} has arrived at taxiwayqueue\n");
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
                var nextFlightInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                flight.ActiveAircraft.AddHistoryToAircraft(time, "Taxiway " + GetIdTaxiwayAndAirportCode(), ", Leaves taxiwayqueue");
                Console.Write($"\n{flight.ActiveAircraft.Model} leaves taxiwayqueue\n");
                //Må ha denne i addtoqueue: SimulateTaxiwayTime(nextFlightInQueue, initialspeed, flight.ActiveAircraft.AccelerationOnGround, flight.ActiveAircraft.MaxSpeedOnGround);
            }
        }

        /// <summary>
        /// Simulates an aircraft using the taxiway
        /// The parameters: initialSpeed, speedChange, maxSpeed is passed on to the CalculateFlightMovement() method.
        /// </summary>
        /// <param name="flight">The flight thats is using the taxiway.</param>
        /// <param name="initialSpeed"></param>
        /// <param name="speedChange"></param>
        /// <param name="maxSpeed"></param>
        /// <param name="time">Used to log the history of the plane.</param>
        /// <returns>Returns the method flight.CalculateFlightMovement() which is the time taken for the simulation.</returns>
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