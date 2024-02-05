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
        /// returns the id and the nickname for the airport that this taxiway is located at.
        /// eksample: "Gate 1 GAR"
        /// </summary>
        /// <returns></returns>
        public string GetIdTaxiwayAndAirportCode()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }
        /// <summary>
        /// Adds an aircraft to the queue for the taxiway.
        /// Parameter 'aircraft' is the aircraft that is insertet to the queue.
        /// </summary>
        /// <param name="aircraft"></param>
        public void AddFlightToQueue(Flight flight)
        {
            // (Nagel, 2022, s. 203)
            taxiwayQueue.Enqueue(flight);
            flight.ActiveAircraft.AddHistoryToAircraft("Taxiway " + GetIdTaxiwayAndAirportCode(), ", Arrived at taxiwayqueue");
            Console.Write($"\n{flight.ActiveAircraft.Model} has arrived at taxiwayqueue\n");
        }
        /// <summary>
        /// Checks if the next aircraft in queue is the one thats passed as parameter.
        /// </summary>
        /// <param name="aircraft"></param>
        /// 
        public Flight CheckNextFlightInQueue()
        {
            Flight nextFlight = taxiwayQueue.Peek();
            return nextFlight;
        }
        public void NextFlightLeavesTaxiway(Flight flight)
        {
            // (Nagel, 2022, s. 203)
            while (taxiwayQueue.Count >= 1)
            {
                var nextFlightInQueue = taxiwayQueue.Dequeue();
                taxiwayQueue.TrimExcess();
                flight.ActiveAircraft.AddHistoryToAircraft("Taxiway " + GetIdTaxiwayAndAirportCode(), ", Leaves taxiwayqueue");
                Console.Write($"\n{flight.ActiveAircraft.Model} leaves taxiwayqueue\n");
                //Må ha denne i addtoqueue: SimulateTaxiwayTime(nextFlightInQueue, initialspeed, flight.ActiveAircraft.AccelerationOnGround, flight.ActiveAircraft.MaxSpeedOnGround);
            }
        }
        /// <summary>
        /// Simulates the time an aircraft spends on the taxiway. Based on the length of the taxiway,
        /// acceleration and maxspeed of the aircraft on the ground defined by the aricraft object.
        /// parameter 'aircraft' is the aircraft that is using the taxiway with the simulation.
        /// </summary>
        /// <param name="aircraft"></param>
        public void SimulateTaxiwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed)
        {
            Console.Write($"\n{flight.ActiveAircraft.Model} Arrived at taxiway\n");
            flight.ActiveAircraft.AddHistoryToAircraft($"Taxiway " + GetIdTaxiwayAndAirportCode(), ", Arrived at taxiway");

            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            int time = 0;            
            while (remainingDistance != 0)
            {
                // trekker farten i meter per sekund fra Length
                Length -= (initialSpeed * (5 / 18));
                if (initialSpeed < maxSpeed)
                {
                    initialSpeed = Math.Min(initialSpeed + speedChange, maxSpeed);
                }
                else if (initialSpeed > maxSpeed)
                {
                    initialSpeed = Math.Max(initialSpeed - speedChange, maxSpeed);
                }
                time++;
            }

            flight.ActiveAircraft.AddHistoryToAircraft($"Taxiway " + GetIdTaxiwayAndAirportCode(), ", at the end of the taxiway");
            Console.Write($"\n{flight.ActiveAircraft.Model} is at the end of the taxiway\n");
            
        }
    }
}