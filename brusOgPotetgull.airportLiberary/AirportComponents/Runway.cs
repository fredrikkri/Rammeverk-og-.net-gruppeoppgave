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
        public string GetIdAndAirportNickname()
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
            /*if (flight.ActiveAircraft.CheckPreviousLocation() != "Runway")
            {
                // (Nagel, 2022, s. 203)
                runwayQueue.Enqueue(flight);
                flight.ActiveAircraft.AddHistoryToAircraft("Runway " + GetIdTaxiwayAndAirportCode(), ", Arrived at Runwayqueue");
                Console.Write($"\n{flight.ActiveAircraft.Model} has arrived at Runwayqueue\n");
            }
            else
            {
                runwayQueue.Prepend(flight);
                Console.Write($"\n{flight.ActiveAircraft.Model} is added to index 0 at: {runwayQueue}\n");
            }*/
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraft"></param>
        /// <param name="runway"></param>
        /*public void FirstInQueueEnterRunway(Aircraft aircraft)
        {
            // (Nagel, 2022, s. 203)
            while (runwayQueue.Count >= 1)
            {
                var nextAircraftInQueue = runwayQueue.Dequeue();
                runwayQueue.TrimExcess();
                aircraft.AddHistoryToAircraft("Taxiway " + GetIdTaxiwayAndAirportCode(), ", Arrived at taxiway");
                Console.Write($"\n{aircraft.Model} has arrived at taxiway\n");
                SimulateTakeoff(nextAircraftInQueue);
            }
        }*/
        // NY Versjon av metode over for å tilpasse den til både landing og takeoff
        public void NextFlightEntersRunway(Flight flight)
        {
            if (runwayQueue.Count != 0)
            {
                var nextFlight = runwayQueue.Dequeue();
                runwayQueue.TrimExcess();
                flight.ActiveAircraft.AddHistoryToAircraft($"Runway {id}",
                                                          $"Flight {flight.ActiveAircraft.Model}" +
                                                          $" Number: {flight.ActiveAircraft.Id} enters the runway");
            }
            else
            {
                Console.Write($"No flights in runway - {id} queue");
            }
        }
        // Returns the time in seconds an aircraft uses on the runway. Given the length of runway is meters, and speed / speedChange is kph
        public int SimulateRunwayTime(Flight flight, int initialSpeed, int speedChange, int maxSpeed) {
            flight.ActiveAircraft.AddHistoryToAircraft("", "Leaves Runway");
            return flight.CalculateFlightMovement(Length, initialSpeed, speedChange, maxSpeed);
        }
        /*public int SimulateTakeoff(Aircraft aircraft)
        {
            aircraft.AddHistoryToAircraft("Runway " + GetIdTaxiwayAndAirportCode(), $", Arrived at runway");
            UseRunway();
            Console.Write($"\n{aircraft.Model} arrived at runway!\n");
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = 0;
            int secondCounter = 0;

            while (remainingDistance > 0)
            {
                remainingDistance = remainingDistance - currentSpeed;
                currentSpeed += aircraft.AccelerationOnGround;
                secondCounter++;
                Thread.Sleep(10);
                //Console.WriteLine($"Current speed: {currentSpeed}, Remaining distance: {remainingDistance}");
            }
            aircraft.AddHistoryToAircraft("Runway " + GetIdTaxiwayAndAirportCode(), $", Taken off and left the airport");
            ExitRunway();
            Console.Write($"\n{aircraft.Model} has taken off and left the airport\n");
            return currentSpeed;
        }
        public void SimulateLanding(Aircraft aircraft)
        {
            aircraft.AddHistoryToAircraft("Runway " + GetIdTaxiwayAndAirportCode(), $", About to land at runway");
            Console.Write($"\n{aircraft.Model} is about to land at runway!\n");
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = 0;
            int secondCounter = 0;

        }*/
        public void UseRunway()
        {
            inUse = true;
        }
        public void ExitRunway()
        {
            inUse = false;
        }
    }
}

