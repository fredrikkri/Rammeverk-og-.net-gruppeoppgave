using System;
using System.Net.Security;
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

        public void PrintFlightInformation()
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
        /// <summary>
        /// Simulates the time it takes to fly from one runway to another.
        /// </summary>
        /// <param name="speedAfterTakeoff"></param>
        public void SimulateAirTime(int speedAfterTakeoff)
        {
            ActiveAicraft.AddHistoryToAircraft("Runway " + DepartureRunway.GetIdAndAirportNickname(), $", Taken off and left {DepartureAirport.Name}");
            Console.Write($"\n{ActiveAicraft.Model} is now in the air\n");
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = speedAfterTakeoff;
            int secondCounter = 0;

            while (remainingDistance > 0)
            {
                remainingDistance = remainingDistance - currentSpeed;
                if (currentSpeed >= 0)
                {
                    currentSpeed += ActiveAicraft.AccelerationInAir;
                }
                if (currentSpeed >= ActiveAicraft.MaxSpeedInAir)
                {
                    currentSpeed = ActiveAicraft.MaxSpeedInAir;
                }
                secondCounter++;
                Thread.Sleep(5);
                Console.WriteLine($"Current speed: {currentSpeed}, Remaining distance: {remainingDistance}");
            }
            ActiveAicraft.AddHistoryToAircraft("Runway " + ArrivalRunway.GetIdAndAirportNickname(), $", Arrived at {ArrivalAirport.Name}");
            Console.Write($"\n{ActiveAicraft.Model} has landed at runway\n");
        }
        /// <summary>
        /// Starts a flight if the gates and the date for the flight is right.
        /// If the checks is ok, then the flight begins.
        /// The function simulates every event in the timespace from when a plane picks up passengers at an gate, to when the passengers are delivered to the gate at an destination.
        /// The function logs every event to the history of the used aircraft.
        /// </summary>
        /// <param name="flightDate"></param>
        public void StartFlight(DateTime flightDate)
        {
            // checks if the plane are adjusted for gates.
            if (DepartureGate.CheckIfAircraftCanUseGate(ActiveAicraft) && ArrivalGate.CheckIfAircraftCanUseGate(ActiveAicraft) == true)
            {
                // If the date it right, the flight will proceed. We dont care about seconds.
                if (flightDate.Year == DateTime.Now.Year &&
                    flightDate.Month == DateTime.Now.Month &&
                    flightDate.Day == DateTime.Now.Day &&
                    flightDate.Hour == DateTime.Now.Hour &&
                    flightDate.Minute == DateTime.Now.Minute)
                {
                    // Start-gate
                    Console.Write($"\n\t\t\t\t\tFlight with aircraft: {ActiveAicraft.Model} has started\n");
                    ActiveAicraft.AddHistoryToAircraft("Gate " + DepartureGate.GetIdAndAirportNickname(), ", Left Gate");
                    Console.Write($"\n{ActiveAicraft.Model} has Left Gate\n");
                    // Taxiway
                    DepartureTaxiway.AddAircraftToQueue(ActiveAicraft);
                    DepartureTaxiway.PeekToSeIfYourAircraftIsNext(ActiveAicraft);

                    // Runway
                    var speedAfterTakeoff = DepartureRunway.SimulateTakeoff(ActiveAicraft);

                    // In air
                    SimulateAirTime(speedAfterTakeoff);

                    // Arrival-gate
                    ActiveAicraft.AddHistoryToAircraft("Gate " + ArrivalGate.GetIdAndAirportNickname(), ", Arrived at Gate");
                }
                // checks every minute to see if the date of the flight is now.
                Thread.Sleep(1000);
            }
            else
            {
                Console.Write($"\nFlight with id '{flightId}': One of the gates does not fit with the plane. The flight cannot be done...\n");
            }
        }
        /// <summary>
        /// Sets up daily flights.
        /// dateFlights is the date of when the flight will start.
        /// numberOfDays is how many days after the choosen date that will contain the same flight.
        /// </summary>
        /// <param name="dateFlight"></param>
        /// <param name="numberOfDays"></param>
        public void SetupDailyFlight(DateTime dateFlight, int numberOfDays)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                Console.Write($"\n\tdate of flight: \n\t" + dateFlight.AddDays(i));
                StartFlight(dateFlight.AddDays(i));
                
            }
        }
    }
}