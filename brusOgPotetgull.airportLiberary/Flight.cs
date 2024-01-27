using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Flight
	{
        private static int idCounter = 1;
        private int flightId;
		private Airport depatureAirport;
        private Airport arrivalAirport;

		public Flight(Airport depatureAirport, Airport arrivalAirport)
		{
            // (dosnetCore, 2020) 
            flightId = idCounter++;
            this.FlightId = flightId;
            this.DepatureAirport = depatureAirport;
            this.ArrivalAirport = arrivalAirport;
        }
        public int FlightId { get; private set; }
        public Airport DepatureAirport { get; private set; }
        public Airport ArrivalAirport { get; private set; }

        public void printFlightInformation()
        {
            Console.Write($"\nFlightId: {FlightId}\nDepature: {DepatureAirport}\nArrival: {ArrivalAirport}\n");
        }
    }
}

