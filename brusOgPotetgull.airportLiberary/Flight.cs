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

        /// <summary>
        /// Gets flight id
        /// </summary>
        /// <value>
        /// Flight id that is assosiated with the flight
        /// </value>
        public int FlightId { get; private set; }

        /// <summary>
        /// Gets active aircraft
        /// </summary>
        /// <value>
        /// Aircraft object that is set to fly
        /// </value>
        public Aircraft ActiveAircraft { get; private set; }

        /// <summary>
        /// Gets the time of the flight
        /// </summary>
        /// <value>
        /// DateTime object that desides when the flight is.
        /// </value>
        public DateTime DateTimeFlight { get; private set; }

        /// <summary>
        /// Gets bool to se if flight is ariving or taking off
        /// </summary>
        /// <value>
        /// bool value that is true if flight is ariving and false if leaving
        /// </value>
        public bool IsArrivingFlight { get; private set; }

        /// <summary>
        /// Gets flight length
        /// </summary>
        /// <value>
        /// int value of the length of the flight
        /// </value>
        public int Length { get; private set; }

        /// <summary>
        /// list of taxiways tahat is the path it took
        /// </summary>
        public List<Taxiway> taxiwayPath;

        /// <summary>
        /// Gets or sets the time on clock
        /// </summary>
        /// <value>
        /// DateTime value of the clock
        /// </value>
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

            /// <summary>
            /// Gets departure airport
            /// </summary>
            /// <value>
            /// Airport object of the departure airport for the flight
            /// </value>
            public Airport DepartureAirport { get; private set; }

            /// <summary>
            /// Gets departure gate
            /// </summary>
            /// <value>
            /// Gate object of the departure gate for the flight
            /// </value>
            public Gate DepartureGate { get; private set; }

            /// <summary>
            /// Gets departure taxiway
            /// </summary>
            /// <value>
            /// Taxiway object of the departure taxiway for the flight
            /// </value>
            public Taxiway DepartureTaxiway { get; private set; }

            /// <summary>
            /// Gets departure runway
            /// </summary>
            /// <value>
            /// Runway object of the departure runway for the flight
            /// </value>
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
            /// <summary>
            /// Gets the arival airport
            /// </summary>
            /// <value>
            /// Airport object of the arivaø airport of the flight
            /// </value>
            public Airport ArrivalAirport { get; private set; }

            /// <summary>
            /// Gets the arival gate
            /// </summary>
            /// <value>
            /// Gate object of the arival gate of the flight
            /// </value>
            public Gate ArrivalGate { get; private set; }

            /// <summary>
            /// Gets the arival taxiway
            /// </summary>
            /// <value>
            /// Taxiway object of the arival taxiway of the flight
            /// </value>
            public Taxiway ArrivalTaxiway { get; private set; }

            /// <summary>
            /// gets the arival runnway
            /// </summary>
            /// <value>
            /// Runway object of the arival runway of the flight
            /// </value>
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
    }
}
