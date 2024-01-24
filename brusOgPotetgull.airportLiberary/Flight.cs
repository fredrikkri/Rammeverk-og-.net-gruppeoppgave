using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Flight
	{
		private int flightId;
		private Fly aircraft;
        //private int totalPassengers; Dette kan implementeres senere.
        private int flightDistance;
		private string depatureDestination = "";
        private string arrivalDestination = "";
		private int flightTime;

		public Flight(Fly aircraft, int flightLength, string depatureDestination, string arrivalDestination)
		{
            this.Aircraft = aircraft;
            this.FlightLength = flightLength;
            this.DepatureDestination = depatureDestination;
            this.ArrivalDestination = arrivalDestination;
        }
        // (Nagel, C, 2021, s. 76)
        public Fly Aircraft { get; private set; }
        public int FlightLength { get; private set; }
        public string DepatureDestination { get; private set; }
        public string ArrivalDestination { get; private set; }

		public int getFlightTime()
		{
			return 0;
		}
		public int getFlightDistanceLeft()
		{
			return 0;
		}
    }
}

