using BrusOgPotetgull.AirportLiberary;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The Flight-class is defined with the aircraft that is used in the flight, together with some components on the airports its using.
    /// Examples of components: taxiways, gates and runways.
    /// </summary>
    public abstract class Flight
    {
        private static int idCounter = 1;
        public int FlightId { get; private set; }
        public Aircraft ActiveAircraft { get; private set; }
        public DateTime DateTimeFlight { get; private set; }
        public bool IsArrivingFlight { get; private set; }
        public int Length { get; private set; }
        public List<Taxiway> taxiwayPath;
        public DateTime Clock { get; set; }

        /// <summary>
        /// Creates a Flight-object. This must either be Arriving flight or departuring flight.
        /// </summary>
        /// <param name="activeAircraft">The aircraft that is used for this flight.</param>
        /// <param name="dateTimeFlight">Date of the flight.</param>
        /// <param name="isArrivingFlight">If the flight is an arriving flight, this value must be set to true.</param>
        /// <param name="length">The lenght of the flight in KM.</param>
        protected Flight(Aircraft activeAircraft, DateTime dateTimeFlight, bool isArrivingFlight, int length)
        {
            FlightId = idCounter++;
            ActiveAircraft = activeAircraft;
            DateTimeFlight = dateTimeFlight;
            IsArrivingFlight = isArrivingFlight;
            Length = length;
            taxiwayPath = new List<Taxiway>(); 
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
                    $"Aircraft: {ActiveAircraft.Name}\n" +
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
                $"Aircraft: {ActiveAircraft.Name}\n" +
                $"Arrival Airport: {ArrivalAirport.Name}\n" +
                $"Arrival Runway: {ArrivalRunway.Id}\n" +
                $"Arrival Taxiway: {ArrivalTaxiway.Id}\n" +
                $"Arrival Gate: {ArrivalGate.Id}\n");
            }
        }

        /// <summary>
        /// Calculates the movement of a flight object across a set length, and returning the time it took in seconds.
        /// </summary>
        /// <remarks>The time returned is based on the length, and the speed of the aircraft each second</remarks>
        /// <param name="length">Traveldistance in meters.</param>
        /// <param name="initialSpeed">The speed at which the aircraft starts traversing the lenght (Kp/h).</param>
        /// <param name="speedChange">The change in speed per second (Kp/h).</param>
        /// <param name="maxSpeed">Maximum speed of the aircraft (Kp/h).</param>
        /// <returns>The time it takes to do the movement in seconds.</returns>
        public double CalculateFlightMovement(int length, int initialSpeed, int speedChange, int maxSpeed)
        {
            int remainingDistance = length;
            double time = 0;

            while (remainingDistance > 0)
            {
                // trekker farten i meter per sekund fra Length
                remainingDistance = Math.Max(remainingDistance - (initialSpeed * 5 / 18), 0);
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

        /// <summary>
        /// This method claculates a the time it takes to go trough the taxiway-path. 
        /// </summary>
        /// <returns>The time it takes as a double-datatype.</returns>
        public double CalculateTaxiwayPathTime()
        {
            int lengthPath = GetLengthOfTaxiwayPath();
            double time = 0;

            foreach (Taxiway taxiway in taxiwayPath)
            {

                time += ((lengthPath / (taxiway.MaxSpeed / 3.6)));
            }
            return time;
        }

        /// <summary>
        /// Prints out the time it takes to go trough the taxiway-path.
        /// </summary>
        public void PrintTaxiwayPathTime()
        {
            double time = CalculateTaxiwayPathTime();
            double min = Math.Round(time / 60);
            double sec = Math.Round(time % 60);
            Console.WriteLine($"\ntime for path for flight with {FlightId} and active aircraft: {ActiveAircraft.Name} - {min}min and {sec}sec");
        }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the Flight.</returns>
        public override string ToString()
        {
            return $"\nDate: {DateTimeFlight} " +
                $"\nFlightId: {FlightId} " +
                $"\nAircraft: {ActiveAircraft.Name}\n";
        }

        /// <summary>
        /// Gets the lenght of a taxiway-path.
        /// </summary>
        /// <returns>The result as an int-datatype.</returns>
        private int GetLengthOfTaxiwayPath()
        {
            int result = 0;
            foreach (Taxiway taxiway in taxiwayPath)
            {
                result += taxiway.Length;
            }
            return result;
        }
    }
}
