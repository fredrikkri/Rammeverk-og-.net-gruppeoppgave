using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Runway
	{
        private static int idCounter = 1;
        private int id;
        private bool inUse;
        private Queue<Aircraft> runwayQueue = new Queue<Aircraft>();

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

        /// <summary>
        /// returns the id and the nickname for the airport that this runway is located at.
        /// </summary>
        /// <returns></returns>
        public string GetIdAndAirportNickname()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }
        /// <summary>
        /// Adds aircraft to runway-queue.
        /// </summary>
        /// <param name="aircraft"></param>
        public void AddAircraftToQueue(Aircraft aircraft)
        {
            if (aircraft.CheckPreviousLocation() != "Runway")
            {
                // (Nagel, 2022, s. 203)
                runwayQueue.Enqueue(aircraft);
                aircraft.AddHistoryToAircraft("Runway " + GetIdAndAirportNickname(), ", Arrived at Runwayqueue");
                Console.Write($"\n{aircraft.Model} has arrived at Runwayqueue\n");
            }
            else
            {
                runwayQueue.Prepend(aircraft);
                Console.Write($"\n{aircraft.Model} is added to index 0 at: {runwayQueue}\n");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraft"></param>
        /// <param name="runway"></param>
        public void PeekToSeIfYourAircraftIsNext(Aircraft aircraft)
        {
            if (runwayQueue.Peek() == aircraft)
            {
                Console.Write($"\n{aircraft.Model} is first in line to use runway\n");
                FirstInQueueEnterRunway(aircraft);
            }
            else
            {
                while (runwayQueue.Peek() != aircraft)
                {
                    Console.Write($"\n{aircraft.Model} waiting to be next in line to use runway...\n");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraft"></param>
        /// <param name="runway"></param>
        public void FirstInQueueEnterRunway(Aircraft aircraft)
        {
            // (Nagel, 2022, s. 203)
            if (runwayQueue.Count >= 1)
            {
                var nextAircraftInQueue = runwayQueue.Dequeue();
                runwayQueue.TrimExcess();
                aircraft.AddHistoryToAircraft("Taxiway " + GetIdAndAirportNickname(), ", Arrived at taxiway");
                Console.Write($"\n{aircraft.Model} has arrived at taxiway\n");
                SimulateTakeoff(nextAircraftInQueue);
            }
        }
        public int SimulateTakeoff(Aircraft aircraft)
        {
            aircraft.AddHistoryToAircraft("Runway " + GetIdAndAirportNickname(), $", Arrived at runway");
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
            aircraft.AddHistoryToAircraft("Runway " + GetIdAndAirportNickname(), $", Taken off and left the airport");
            Console.Write($"\n{aircraft.Model} has taken off and left the airport\n");
            return currentSpeed;
        }
        public void SimulateLanding(Aircraft aircraft)
        {
            aircraft.AddHistoryToAircraft("Runway " + GetIdAndAirportNickname(), $", About to land at runway");
            Console.Write($"\n{aircraft.Model} is about to land at runway!\n");
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = 0;
            int secondCounter = 0;

        }
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

