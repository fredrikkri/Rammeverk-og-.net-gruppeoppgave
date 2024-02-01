using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Runway
	{
        private static int idCounter = 1;
        private int id;
        private bool inUse;

        public Runway(Airport locatedAtAirport, int length)
        {
            // (dosnetCore, 2020) 
            id = idCounter++;
            Id = id;
            this.LocatedAtAirport = locatedAtAirport;
            this.Length = length;
            this.inUse = false;
        }
        public int Id { get; private set; }
        public Airport LocatedAtAirport { get; private set; }
        public int Length { get; private set; }

        /// <summary>
        /// returns the id and the nickname for the airport that this runway is located at.
        /// </summary>
        /// <returns></returns>
        public string GetIdAndAirportNickname()
        {
            string returnString = (string)(Id + " " + LocatedAtAirport.AirportNickname);
            return returnString;
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

