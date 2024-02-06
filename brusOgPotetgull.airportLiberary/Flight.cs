using System;
using System.Net.Security;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
    public class Flight
    {
        private static int idCounter = 1;
        private int flightId;
        private DateTime dateTimeFlight;

        public Flight(Aircraft activeAircraft, DateTime dateTimeFlight, bool isArrivingFlight, int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway,
            Runway departureRunway, Runway arrivalRunway)
        {
            // (dosnetCore, 2020) 
            flightId = idCounter++;
            this.FlightId = flightId;
            this.ActiveAircraft = activeAircraft;
            this.DateTimeFlight = dateTimeFlight;
            this.IsArrivingFlight = isArrivingFlight;
            this.Length = length;

            this.DepartureAirport = departureAirport;
            this.DepartureGate = departureGate;
            this.DepartureTaxiway = departureTaxiway;
            this.DepartureRunway = departureRunway;

            this.ArrivalAirport = arrivalAirport;
            this.ArrivalGate = arrivalGate;
            this.ArrivalTaxiway = arrivalTaxiway;
            this.ArrivalRunway = arrivalRunway;
        }

        public int FlightId { get; private set; }
        public int Length { get; private set; }
        public Aircraft ActiveAircraft { get; private set; }
        public DateTime DateTimeFlight { get; private set; }
        public bool IsArrivingFlight { get; private set; }
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
                $"Aircraft: {ActiveAircraft.Model}\n" +
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
            ActiveAircraft.AddHistoryToAircraft("Runway " + DepartureRunway.GetIdRunwayAndAirportCode(), $", Taken off and left {DepartureAirport.Name}");
            Console.Write($"\n{ActiveAircraft.Model} is now in the air\n");
            // (Marius Geide, personlig kommunikasjon, 28.januar 2024) Brukt deler av kode som foreleser har lagt ut (TimeSteppedDriver.cs).
            var remainingDistance = Length;
            var currentSpeed = speedAfterTakeoff;
            int secondCounter = 0;

            while (remainingDistance > 0)
            {
                remainingDistance = remainingDistance - currentSpeed;
                if (currentSpeed >= 0)
                {
                    currentSpeed += ActiveAircraft.AccelerationInAir;
                }
                if (currentSpeed >= ActiveAircraft.MaxSpeedInAir)
                {
                    currentSpeed = ActiveAircraft.MaxSpeedInAir;
                }
                secondCounter++;
                Thread.Sleep(5);
                //Console.WriteLine($"Current speed: {currentSpeed}, Remaining distance: {remainingDistance}");
            }
            ActiveAircraft.AddHistoryToAircraft("Runway " + ArrivalRunway.GetIdRunwayAndAirportCode(), $", Arrived at {ArrivalAirport.Name}");
            Console.Write($"\n{ActiveAircraft.Model} has landed at runway\n");
        }
        /// <summary>
        /// Starts a flight if the gates and the date for the flight is right.
        /// If the checks is ok, then the flight begins.
        /// The function simulates every event in the timespace from when a plane picks up passengers at an gate, to when the passengers are delivered to the gate at an destination.
        /// The function logs every event to the history of the used aircraft.
        /// </summary>
        /// <param name="flightDate"></param>
        public void SetupFlight(Airport airport)
        {
            if (ActiveAircraft.OutOfService == false)
            {
                // checks if the plane are adjusted for gates.
                if (DepartureGate.CheckAircraftAllowedAtGate(ActiveAircraft) && ArrivalGate.CheckAircraftAllowedAtGate(ActiveAircraft) == true)
                {
                    // TODO: ny flygning
                }
                else
                {
                    Console.Write($"\nFlight with id '{flightId}': One of the gates does not fit with the plane. The flight cannot be done...\n");
                }
            }
            else
            {
                Console.Write($"\nFlight with id '{flightId}': The Flight is out of service. The flight cannot be done...\n");
            }
        }
        /// <summary>
        /// Sets up daily flights.
        /// dateFlights is the date of when the flight will start.
        /// numberOfDays is how many days after the choosen date that will contain the same flight.
        /// </summary>
        /// <param name="dateFlight"></param>
        /// <param name="numberOfDays"></param>
        /*public void SetupDailyFlight(int numberOfDays)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                dateTimeFlight.AddDays(i);
                Console.Write($"\n\tdate of flight: \n\t" + dateTimeFlight.AddDays(i));
                SetupFlight();
            }
        }
        /// <summary>
        /// Sets up weekly flights.
        /// dateFlights is the date of when the flight will start.
        /// numberOfWeeks is how many weeks after the choosen date that will contain the same flight.
        /// </summary>
        /// <param name="dateFlight"></param>
        /// <param name="numberOfWeeks"></param>
        public void SetupWeeklyFlight(int numberOfWeeks)
        {
            for (int i = 0; i < numberOfWeeks; i++)
            {
                dateTimeFlight.AddDays(i + (6 * i));
                Console.Write($"\n\tdate of flight: \n\t" + dateTimeFlight.AddDays(i + (6 * i)));
                SetupFlight();
            }
        }
            /// <summary>
            /// Sets up monthly flights.
            /// dateFlights is the date of when the flight will start.
            /// numberOfMonths is how many months after the choosen date that will contain the same flight.
            /// </summary>
            /// <param name="dateFlight"></param>
            /// <param name="numberOfMonths"></param>
        public void SetupMonthlyFlight(DateTime dateFlight, int numberOfMonths)
        {
            for (int i = 0; i < numberOfMonths; i++)
            {
                dateTimeFlight.AddDays(i);
                Console.Write($"\n\tdate of flight: \n\t" + dateFlight.AddMonths(i));
                SetupFlight();
            }
        }*/
        public int CalculateFlightMovement(int length, int initialSpeed, int speedChange, int maxSpeed)
        {
            var remainingDistance = Length;
            int time = 0;

            while (remainingDistance == 0)
            {
                // trekker farten i meter per sekund fra Length
                Length = Math.Max(Length - (initialSpeed * 5 / 18), 0);
                if (initialSpeed < maxSpeed)
                {
                    initialSpeed = Math.Min(initialSpeed + speedChange, maxSpeed);
                }
                else if (initialSpeed > maxSpeed)
                {
                    initialSpeed = Math.Max(initialSpeed - speedChange, maxSpeed);
                }
                time++;
            }
            return time;
        }
    }
}
