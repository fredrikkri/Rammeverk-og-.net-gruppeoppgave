namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The Flight-class is defined with the aircraft that is used in the flight, together with all the components on the airports its using. Eksamples is: taxiways, gates and runways.
    /// </summary>
    public abstract class Flight
    {
        private static int idCounter = 1;
        public int FlightId { get; private set; }
        public Aircraft ActiveAircraft { get; private set; }
        public DateTime DateTimeFlight { get; private set; }
        public bool IsArrivingFlight { get; private set; }
        public int Length { get; private set; }

        protected Flight(Aircraft activeAircraft, DateTime dateTimeFlight, bool isArrivingFlight, int length)
        {
            FlightId = idCounter++;
            ActiveAircraft = activeAircraft;
            DateTimeFlight = dateTimeFlight;
            IsArrivingFlight = isArrivingFlight;
            Length = length;
        }

        /// <summary>
        /// The Departuring-class represents a departing flight. The class inherits from the Flight-class.
        /// </summary>
        public class Departing : Flight
        {
            public Airport DepartureAirport { get; private set; }
            public Gate DepartureGate { get; private set; }
            public Taxiway DepartureTaxiway { get; private set; }
            public Runway DepartureRunway { get; private set; }

            /// <summary>
            /// Creates a departing flight object.
            /// </summary>
            /// <param name="activeAircraft">The aircraft that is used for this flight.</param>
            /// <param name="dateTimeFlight">Date of the flight.</param>
            /// <param name="length">Length of the flight im KM.</param>
            /// <param name="departureAirport">The airport that the aircraft departure from.</param>
            /// <param name="departureGate">The gate that the aircraft departure from.</param>
            /// <param name="departureTaxiway">The taxiway that the aircraft is using to departure from.</param>
            /// <param name="departureRunway">The runway that the aircraft is departuring from.</param>
            public Departing(Aircraft activeAircraft, DateTime dateTimeFlight, int length, Airport departureAirport, Gate departureGate, Taxiway departureTaxiway, Runway departureRunway)
                : base(activeAircraft, dateTimeFlight, false, length)
            {
                DepartureAirport = departureAirport;
                DepartureGate = departureGate;
                DepartureTaxiway = departureTaxiway;
                DepartureRunway = departureRunway;
                departureAirport.AddDepartingFlight(this);
            }

            /// <summary>
            /// Prints information about the flight.
            /// This includes the date, flights ID, length of the flight, modelname, runway id, taxiway id and gate id.
            /// </summary>
            public void PrintFlightInformation()
            {
                Console.Write($"\n" +
                    $"Date: {DateTimeFlight} " +
                    $"FlightId: {FlightId}\n" +
                    $"Length: {Length}\n" +
                    $"Aircraft: {ActiveAircraft.ModelName}\n" +
                    $"Departure Airport: {DepartureAirport.Name}\n" +
                    $"Departure Gate: {DepartureGate.Id}\n" +
                    $"Departure Taxiway: {DepartureTaxiway.Id}\n" +
                    $"Departure Runway: {DepartureRunway.Id}\n");
            }
        }

        /// <summary>
        /// The Arriving-class represents an arriving flight. The class inherits from the Flight-class.
        /// </summary>
        public class Arriving : Flight
        {
            public Airport ArrivalAirport { get; private set; }
            public Gate ArrivalGate { get; private set; }
            public Taxiway ArrivalTaxiway { get; private set; }
            public Runway ArrivalRunway { get; private set; }

            /// <summary>
            /// Creates an arriving flight object.
            /// </summary>
            /// <param name="activeAircraft">The aircraft that is used for this flight</param>
            /// <param name="dateTimeFlight">Date of the flight.</param>
            /// <param name="length">Length of the flight im KM.</param>
            /// <param name="arrivalAirport">The airport that the aircraft is arriving at.</param>
            /// <param name="arrivalGate">The gate that the aircraft is arriving at.</param>
            /// <param name="arrivalTaxiway">The taxiway that the aircraft is arriving at.</param>
            /// <param name="arrivalRunway">The runway that the aircraft is arriving at.</param>
            public Arriving(Aircraft activeAircraft, DateTime dateTimeFlight, int length, Airport arrivalAirport, Gate arrivalGate, Taxiway arrivalTaxiway, Runway arrivalRunway)
                : base(activeAircraft, dateTimeFlight, true, length)
            {
                ArrivalAirport = arrivalAirport;
                ArrivalGate = arrivalGate;
                ArrivalTaxiway = arrivalTaxiway;
                ArrivalRunway = arrivalRunway;
                arrivalAirport.AddArrivingFlight(this);
            }

            /// <summary>
            /// Prints information about the flight.
            /// This includes the date, flights ID, length of the flight, modelname, runway id, taxiway id and gate id.
            /// </summary>
            public void PrintFlightInformation()
            {
                Console.Write($"\n" +
                $"Date: {DateTimeFlight} " +
                $"FlightId: {FlightId}\n" +
                $"Length: {Length}\n" +
                $"Aircraft: {ActiveAircraft.ModelName}\n" +
                $"Arrival Airport: {ArrivalAirport.Name}\n" +
                $"Arrival Runway: {ArrivalRunway.Id}\n" +
                $"Arrival Taxiway: {ArrivalTaxiway.Id}\n" +
                $"Arrival Gate: {ArrivalGate.Id}\n");
            }
        }

        /// <summary>
        /// simulates the movement for an flight object for landing and takeoff.
        /// </summary>
        /// <param name="length">Traveldistance in KM.</param>
        /// <param name="initialSpeed">The speed at which the aircraft starts with (Kp/h).</param>
        /// <param name="speedChange">The change in speed (Kp/h).</param>
        /// <param name="maxSpeed">Maximum speed for this calculation (Kp/h).</param>
        /// <returns>The time it takes to do the simulation.</returns>
        public int CalculateFlightMovement(int length, int initialSpeed, int speedChange, int maxSpeed)
        {
            int remainingDistance = Length;
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
