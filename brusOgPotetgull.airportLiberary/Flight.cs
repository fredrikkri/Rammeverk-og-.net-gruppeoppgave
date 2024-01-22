using System;
namespace brusOgPotetgull.gruppeoppgave.core
{
	public class Flight
	{
		private int flightId;
		private Fly aircraft;
        private int totalPassengers;
        private int flightDistance;
		private string depatureDestination = "";
        private string arrivalDestination = "";
		private int flightTime;

		public Flight(Fly aircraft, int totalPassengers, int flightLength, string depatureDestination, string arrivalDestination)
		{
			Aircraft = aircraft;
			TotalPassengers = totalPassengers;
			FlightLength = flightLength;
			DepatureDestination = depatureDestination;
			ArrivalDestination = arrivalDestination;
        }
        // (Nagel, C, 2021, s. 76)
        public Fly Aircraft { get; init; }
        public int TotalPassengers { get; init; }
        public int FlightLength { get; init; }
        public string DepatureDestination { get; init; }
        public string ArrivalDestination { get; init; }

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

