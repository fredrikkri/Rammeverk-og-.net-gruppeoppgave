using System;
using System.Net.Security;
using System.Reflection;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The Flight class is defined with the aircraft that is used in the flight, together with all the components on the airports its using. Eksamples is: taxiways, gates and runways.
    /// </summary>
    public class Flight
    {
        private static int idCounter = 1;
        private int flightId;

        /// <summary>
        /// Creates a flight object.
        /// </summary>
        /// <param name="activeAircraft">The aircraft that is used for this flight</param>
        /// <param name="dateTimeFlight">Date of the flight.</param>
        /// <param name="isArrivingFlight">True if the flight it arriving at the airport.</param>
        /// <param name="length">Length of the flight im KM.</param>
        /// <param name="departureAirport">The airport that the aircraft departure from.</param>
        /// <param name="arrivalAirport">The airport that the aircraft is arriving at.</param>
        /// <param name="departureGate">The gate that the aircraft departure from.</param>
        /// <param name="arrivalGate">The gate that the aircraft is arriving at.</param>
        /// <param name="departureTaxiway">The taxiway that the aircraft is using to departure from.</param>
        /// <param name="arrivalTaxiway">The taxiway that the aircraft is arriving at.</param>
        /// <param name="departureRunway">The runway that the aircraft is departuring from.</param>
        /// <param name="arrivalRunway">The runway that the aircraft is arriving at.</param>
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
        public DateTime DateTimeFlight { get; set; }
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
        /// simulates the movement for an flight object for landing and takeoff.
        /// </summary>
        /// <param name="length">Traveldistance.</param>
        /// <param name="initialSpeed">The speed at which the aircraft starts with in kph.</param>
        /// <param name="speedChange">The change in speed (kph).</param>
        /// <param name="maxSpeed">Maximum speed for this calculation. (kph)</param>
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
