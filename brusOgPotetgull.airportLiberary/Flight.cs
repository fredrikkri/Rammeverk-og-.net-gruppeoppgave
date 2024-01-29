using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Flight
	{
        private static int idCounter = 1;
        private int flightId;
        private int length;
		private Airport departureAirport;
        private Airport arrivalAirport;
        private Gate departureGate;
        private Gate GatearrivalGate;
        private Taxiway departureTaxiway;
        private Taxiway arrivalTaxiway;

        public Flight(int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway)
		{
            // (dosnetCore, 2020) 
            flightId = idCounter++;
            this.FlightId = flightId;
            this.Length = length;
            this.DepartureAirport = departureAirport;
            this.ArrivalAirport = arrivalAirport;
            this.DepartureGate = departureGate;
            this.ArrivalGate = arrivalGate;
            this.DepartureTaxiway = departureTaxiway;
            this.ArrivalTaxiway = arrivalTaxiway;
        }
        public int FlightId { get; private set; }
        public int Length { get; private set; }
        public Airport DepartureAirport { get; private set; }
        public Airport ArrivalAirport { get; private set; }
        public Gate DepartureGate { get; private set; }
        public Gate ArrivalGate { get; private set; }
        public Taxiway DepartureTaxiway { get; private set; }
        public Taxiway ArrivalTaxiway { get; private set; }

        public void printFlightInformation()
        {
            Console.Write($"\nFlightId: {FlightId}\nDeparture Airport: {DepartureAirport.Name}\nArrival Airport: {ArrivalAirport.Name}\n" +
                $"Departure Gate: {DepartureGate.Id}\nArrival Gate: {ArrivalGate.Id}\nDeparture Taxiway: {DepartureTaxiway.Id}\nArrival Taxiway: {ArrivalTaxiway.Id}\n");
        }
    }
}

