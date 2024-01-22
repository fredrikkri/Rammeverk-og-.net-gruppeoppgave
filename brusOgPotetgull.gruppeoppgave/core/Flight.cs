using System;
namespace brusOgPotetgull.gruppeoppgave.core
{
	public class Flight
	{
		private int flightId;
		private Fly aircraft;
        private int totalPassengers;
        private int flightLength;
		private string depatureDestination;
        private string arrivalDestination;
		private int flightTime;

		public Flight(Fly aircraft, int totalPassengers, int flightLength, string depatureDestination, string arrivalDestination)
		{
			Aircraft = aircraft;
			TotalPassengers = totalPassengers;
			FlightLength = flightLength;
			DepatureDestination = depatureDestination;
			ArrivalDestination = arrivalDestination;
        }
        public Fly Aircraft { get; init; }
        public int TotalPassengers { get; init; }
        public int FlightLength { get; init; }
        public string DepatureDestination { get; init; }
        public string ArrivalDestination { get; init; }

    }
}

