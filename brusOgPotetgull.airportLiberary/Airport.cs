using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// This class defines how a airport is defined.
    /// </summary>
	public class Airport
    {
        private static int idCounter = 1;
        private int airportId;
        private List<Runway> listRunway;
        private List<Taxiway> listTaxiway;
        private List<Gate> listGate;
        private List<Flight> arrivingFlights;
        private List<Flight> departingFlights;
        

        /// <summary>
        /// Creates an airport.
        /// </summary>
        /// <param name="airportCode">The code for the airport. typicaly 3 letters. Eksample: RYG</param>
        /// <param name="name">The name of the airport.</param>
        /// <param name="location">Where the airport is located at.</param>
        public Airport(string airportCode, string name, string location)
		{
            // (dosnetCore, 2020) 
            airportId = idCounter++;
            this.AirportId = airportId;
            this.AirportCode = airportCode;
            this.Name = name;
            this.Location = location;
            listRunway = new List<Runway>();
            listTaxiway = new List<Taxiway>();
            listGate = new List<Gate>();
            arrivingFlights = new List<Flight>();
            departingFlights = new List<Flight>();
        }

        public int AirportId { get; private set; }
        public string AirportCode { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        

        /// <summary>
        /// Prints out the information about the airport.
        /// </summary>
        public void PrintAirportInformation()
        {
            Console.Write($"\nAirport id: {AirportId}\n" +
                $"Airport nickname: {AirportCode}\n" +
                $"Name: {Name}\nLocation: {Location}\n");
            Console.Write($"List of runways: ");
            foreach (Runway runway in listRunway)
            {
                Console.Write($"{runway.Id} ");
            }

            Console.Write($"\nList of taxiways: ");
            foreach (Taxiway taxiway in listTaxiway)
            {
                Console.Write($"{taxiway.Id} ");
            }

            Console.Write($"\nList of gates: ");
            foreach (Gate gate in listGate)
            {
                Console.Write($"{gate.Id} ");
            }

            Console.Write("\n");
        }

        /// <summary>
        /// Gets Id and airport-code for the current airport.
        /// </summary>
        /// <returns>String with AirportId and AirportCode combined</returns>
        private string GetIdAndAirportCode()
        {
            string returnString = (string)(AirportId + " " + AirportCode);
            return returnString;
        }

        /// <summary>
        /// Gets the list that contains all runways for this airport.
        /// </summary>
        /// <returns>The list of runways for this airport</returns>
        public List<Runway> GetRunwayList()
        {
            return listRunway;
        }

        /// <summary>
        /// Gets the list that contains all gates for this airport.
        /// </summary>
        /// <returns>The list of gates for this airport.</returns>
        public List<Gate> GetListGates()
        {
            return listGate;
        }

        /// <summary>
        /// Gets the list that contains all taxiways for this airport.
        /// </summary>
        /// <returns>Returns the list that contains all taxiways for this airport.</returns>
        public List<Taxiway> GetListTaxiways()
        {
            return listTaxiway;
        }

        /// <summary>
        /// Prints out information about every flight in the list of departuring flights for this airport.
        /// </summary>
        public void PrintListOfDeparturingFlights()
        {

            if (departingFlights.Count == 0)
            {
                throw new InvalidOperationException($"List of departuring flights is empty for airport: '{Name}'");
            }
            else
            { 
            Console.Write($"\nAll departuring flights for airport: {Name} ({AirportCode})\n");
                foreach (Flight flight in departingFlights)
                {
                    Console.Write($"Aircraft:{flight.ActiveAircraft.ModelName}\nID: {flight.FlightId}\nDate: {flight.DateTimeFlight}\n");
                }
            }
        } 
    
        /// <summary>
        /// Adds a runway to the airport.
        /// </summary>
        /// <param name="runway">The runway that is added to the list.</param>
        public void AddRunwayToList(Runway runway)
        {
            runway.UpdateGateLocation(Name);
            if (!listRunway.Contains(runway))
            {
                listRunway.Add(runway);
                
            }
            else
            {
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{runway.Id}' allready exists in airport: '{Name}'");
            }
            
        }

        /// <summary>
        /// Adds a taxiway to the airport.
        /// </summary>
        /// <param name="taxiway">The taxiway that is added to the list.</param>
        public void AddTaxiwayToList(Taxiway taxiway)
        {
            taxiway.UpdateGateLocation(Name);
            if (!listTaxiway.Contains(taxiway))
            {
                listTaxiway.Add(taxiway);
            }
            
            else
            {
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{taxiway.Id}' allready exists in airport: '{Name}'");
            }
        }

        /// <summary>
        /// Adds a gate to the airport.
        /// </summary>
        /// <param name="gate">The gate that is added to the list.</param>
        public void AddGateToList(Gate gate)
        {
            gate.UpdateGateLocation(Name);
            if (!listGate.Contains(gate))
            {
                listGate.Add(gate);
            }
            else 
            {
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{gate.Id}' allready exists in airport: '{Name}'");
            }
        }

        /// <summary>
        /// This method makes all gates in a airport allow all aircraft types.
        /// </summary>
        public void MakeAllGatesAllowAllAircraftTypes()
        {
            foreach (Gate gate in GetListGates())
            {
                gate.MakeAllAircraftTypesAllowedForThisGate();
            }
        }

        /// <summary>
        /// Gets all arriving flights for this airport.
        /// </summary>
        /// <returns>List of arriving flights for this airport.</returns>
        public List<Flight> GetArrivingFlights()
        {
            return arrivingFlights;
        }

        /// <summary>
        /// This method adds an arriving flight to this airport.
        /// </summary>
        /// <param name="flight">The arriving flight that is added to the list.</param>
        public void AddArrivingFlight(Flight.Arriving flight)
        {
            arrivingFlights.Add(flight);
        }

        /// <summary>
        /// This method removes an arriving flight from this airport.
        /// </summary>
        /// <param name="flight">The arriving flight that is removed from the list.</param>
        public void RemoveArrivingFlight(Flight.Arriving flight)
        {   
            if (arrivingFlights.Count > 0)
            {
                arrivingFlights.Remove(flight);
            }
            
            else
            {
                Console.Write("No arriving flights in list");
            }
        }

        /// <summary>
        /// This method gets all departuring flights for this airport.
        /// </summary>
        /// <returns>List of departuring flights.</returns>
        public List<Flight> GetDepartingFlights() => departingFlights;

        /// <summary>
        /// This method adds an departuring flight to this airport.
        /// </summary>
        /// <param name="flight">The departuring flight that is added to the list.</param>
        public void AddDepartingFlight(Flight.Departing flight)
        {
            departingFlights.Add(flight);
        }

        /// <summary>
        /// This method removes an departuring flight from this airport.
        /// </summary>
        /// <param name="flight">The departuring flight that is removed from the list.</param>
        public void RemoveDepartingFlight(Flight.Departing flight)
        {
            if (departingFlights.Count > 0)
            {
                departingFlights.Remove(flight);
            }

            else
            {
                Console.Write("No departing flights in list");
            }
        }

        /// <summary>
        /// This method generates daily arriving flights. The first flight starts 24 hours after the value of the datetimeFlight object.
        /// The rest of the parameters except 'numberOfDays' is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfDays">The number of days the flight will do its flights.</param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="length"></param>
        /// <param name="arrivalAirport"></param>
        /// <param name="arrivalGate"></param>
        /// <param name="arrivalTaxiway"></param>
        /// <param name="arrivalRunway"></param>
        public void AddDailyArrivingFlight(int numberOfDays,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport arrivalAirport,
            Gate arrivalGate, Taxiway arrivalTaxiway,
            Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfDays; i++)
            {
                Flight.Arriving daily = new (activeAircraft, 
                     dateTimeFlight.AddDays(i), length,
                     arrivalAirport, arrivalGate,
                     arrivalTaxiway, arrivalRunway);

                arrivingFlights.Add(daily);
            }
        }

        /// <summary>
        /// This method generates weekly arriving flights. The first flight starts 1 week after the value of the datetimeFlight object.
        /// The rest of the parameters except 'numberOfWeeks' is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfWeeks">The number of weeks the flight will do its flights.</param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="length"></param>
        /// <param name="arrivalAirport"></param>
        /// <param name="arrivalGate"></param>
        /// <param name="arrivalTaxiway"></param>
        /// <param name="arrivalRunway"></param>
        public void AddWeeklyArrivingFlight(int numberOfWeeks,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport arrivalAirport,
            Gate arrivalGate, Taxiway arrivalTaxiway,
            Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfWeeks; i++)
            {
                Flight.Arriving weekly = new (activeAircraft,
                     dateTimeFlight.AddDays(i * 7), length,
                     arrivalAirport, arrivalGate,
                     arrivalTaxiway, arrivalRunway);

                arrivingFlights.Add(weekly);
            }
        }

        /// <summary>
        /// This method generates daily departuring flights. The first flight starts 24 hours after the value of the datetimeFlight object.
        /// The rest of the parameters except 'numberOfDays' is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfDays">The number of days the flight will do its flights.</param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="length"></param>
        /// <param name="departureAirport"></param>
        /// <param name="departureGate"></param>
        /// <param name="departureTaxiway"></param>
        /// <param name="departureRunway"></param>
        public void AddDailyDeparturingFlight(int numberOfDays,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport departureAirport, 
            Gate departureGate, Taxiway departureTaxiway,
            Runway departureRunway)
        {
            for (int i = 1; i <= numberOfDays; i++)
            {
                Flight.Departing daily = new(activeAircraft,
                    dateTimeFlight.AddDays(i), length,
                    departureAirport, departureGate,
                    departureTaxiway, departureRunway);

                departingFlights.Add(daily);
            }
        }

        /// <summary>
        /// This method generates weekly departuring flights. The first flight starts 1 week after the value of the datetimeFlight object.
        /// The rest of the parameters except 'numberOfWeeks' is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfWeeks">The number of weeks the flight will do its flights.</param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="length"></param>
        /// <param name="departureAirport"></param>
        /// <param name="departureGate"></param>
        /// <param name="departureTaxiway"></param>
        /// <param name="departureRunway"></param>
        public void AddWeeklyDeparturingFlight(int numberOfWeeks,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport departureAirport,
            Gate departureGate, Taxiway departureTaxiway,
            Runway departureRunway)
        {
            for (int i = 1; i <= numberOfWeeks; i++)
            {
                Flight.Departing weekly = new (activeAircraft,
                    dateTimeFlight.AddDays(i*7), length,
                    departureAirport, departureGate,
                    departureTaxiway, departureRunway);

                departingFlights.Add(weekly);
            }
        }
    }
}