using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Flight
	{
        private static int idCounter = 1;
        private int flightId;

        public Flight(Aircraft activeAicraft, int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway)
		{
            // (dosnetCore, 2020) 
            flightId = idCounter++;
            this.FlightId = flightId;
            this.ActiveAicraft = activeAicraft;
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
        public Aircraft ActiveAicraft { get; private set; }
        public Airport DepartureAirport { get; private set; }
        public Airport ArrivalAirport { get; private set; }
        public Gate DepartureGate { get; private set; }
        public Gate ArrivalGate { get; private set; }
        public Taxiway DepartureTaxiway { get; private set; }
        public Taxiway ArrivalTaxiway { get; private set; }

        public void printFlightInformation()
        {
            Console.Write($"\nFlightId: {FlightId}\n" +
                $"Length: {Length}\n" +
                $"Aircraft: {ActiveAicraft.Model}\n" +
                $"Departure Airport: {DepartureAirport.Name}\n" +
                $"Arrival Airport: {ArrivalAirport.Name}\n" +
                $"Departure Gate: {DepartureGate.Id}\n" +
                $"Arrival Gate: {ArrivalGate.Id}\n" +
                $"Departure Taxiway: {DepartureTaxiway.Id}\n" +
                $"Arrival Taxiway: {ArrivalTaxiway.Id}\n");
        }
        public void startFlight()
        {
            Console.Write($"\nFlight from {DepartureAirport.Name} to {ArrivalAirport.Name} has started.\n");

        }
        public void simulateAirTime()
        {
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = 0;
            int secondCounter = 0;

            while (remainingDistance > 0)
            {
                remainingDistance = remainingDistance - currentSpeed;
                currentSpeed += ActiveAicraft.AccelerationOnGround;
                secondCounter++;
                Console.WriteLine(currentSpeed);
            }
        }
    }
}

