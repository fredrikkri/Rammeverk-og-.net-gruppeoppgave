using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Flight
	{
        private static int idCounter = 1;
        private int flightId;
        private int flightDistance;
		private string depatureLocation = "";
        private string arrivalLocation = "";
		private int flightTime;

		public Flight(int flightLength, string depatureLocation, string arrivalLocation)
		{
            // (dosnetCore, 2020) 
            flightId = idCounter++;
            this.FlightId = flightId;
            this.FlightLength = flightLength;
            this.DepatureLocation = depatureLocation;
            this.ArrivalLocation = arrivalLocation;
        }
        public int FlightId { get; private set; }
        public int FlightLength { get; private set; }
        public string DepatureLocation { get; private set; }
        public string ArrivalLocation { get; private set; }

        public void printFlightInformation()
        {
            Console.Write($"\nFlightId: {FlightId}\nDepature: {DepatureLocation}\nArrival: {ArrivalLocation}\n");
        }
    }
}

