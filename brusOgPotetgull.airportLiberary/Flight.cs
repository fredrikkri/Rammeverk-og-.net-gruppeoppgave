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
            Taxiway departureTaxiway, Taxiway arrivalTaxiway,
            Runway departureRunway, Runway arrivalRunway)
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
            this.DepartureRunway = departureRunway;
            this.ArrivalRunway = arrivalRunway;
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
        public Runway DepartureRunway { get; private set; }
        public Runway ArrivalRunway { get; private set; }

        public void printFlightInformation()
        {
            Console.Write($"\nFlightId: {FlightId}\n" +
                $"Length: {Length}\n" +
                $"Aircraft: {ActiveAicraft.Model}\n" +
                $"Departure Airport: {DepartureAirport.Name}\n" +
                $"Departure Gate: {DepartureGate.Id}\n" +
                $"Departure Taxiway: {DepartureTaxiway.Id}\n" +
                $"Departure Runway: {DepartureRunway.Id}\n" +
                $"Arrival Airport: {ArrivalAirport.Name}\n" +
                $"Arrival Runway: {ArrivalRunway.Id}\n" +
                $"Arrival Taxiway: {ArrivalTaxiway.Id}\n" +
                $"Arrival Gate: {ArrivalGate.Id}\n");

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
        public void startFlight()
        {
            // checks if the plane are adjusted for gates.
            if (DepartureGate.checkIfAircraftCanUseGate(ActiveAicraft) && ArrivalGate.checkIfAircraftCanUseGate(ActiveAicraft) == true)
            {
                Console.Write($"\nFlight with {ActiveAicraft.Model} from {DepartureAirport.Name} to {ArrivalAirport.Name} has started.\n");
                ActiveAicraft.addHistoryToAircraft(1, DepartureGate.getIdAndAirportNickname());

                Console.Write("\nAircraft has joined the queue for the taxiway\n");
                DepartureTaxiway.addAircraftToQueue(ActiveAicraft);
                DepartureTaxiway.peekToSeIfYourAircraftIsNext(ActiveAicraft);
                ActiveAicraft.addHistoryToAircraft(2, DepartureTaxiway.getIdAndAirportNickname());

                ActiveAicraft.addHistoryToAircraft(3, DepartureRunway.getIdAndAirportNickname());

                ActiveAicraft.addHistoryToAircraft(4, ArrivalRunway.getIdAndAirportNickname());

                ActiveAicraft.addHistoryToAircraft(5, ArrivalTaxiway.getIdAndAirportNickname());

                ActiveAicraft.addHistoryToAircraft(6, ArrivalGate.getIdAndAirportNickname());

                Console.Write($"\n{ActiveAicraft.Model} has taken off!\n");
                simulateAirTime();
            }
            else
            {
                Console.Write($"\nFlight with id '{flightId}': One of the gates does not fit with the plane. The flight cannot be done...\n");
            }
        }
    }
}

