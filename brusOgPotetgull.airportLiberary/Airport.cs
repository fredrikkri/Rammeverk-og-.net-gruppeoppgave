using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Airport
    {
        private static int idCounter = 1;
        private int airportId;
        private List<Runway> listRunway;
        private List<Taxiway> listTaxiway;
        private List<Gate> listGate;
        private List<Flight> arrivingFlights;
        private List<Flight> departingFlights;

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
        /// The function returns AirportId and AirportCode combined together into a string.
        /// </summary>
        /// <returns></returns>
        public string GetIdAndAirportCode()
        {
            string returnString = (string)(AirportId + " " + AirportCode);
            return returnString;
        }

        /// <summary>
        /// returns the list that contains all runways for this airport.
        /// </summary>
        /// <returns></returns>
        public List<Runway> GetRunwayList()
        {
            return listRunway;
        }

        /// <summary>
        /// returns the list that contains all gates for this airport.
        /// </summary>
        /// <returns></returns>
        public List<Gate> GetListGates()
        {
            return listGate;
        }

        /// <summary>
        /// returns the list that contains all taxiways for this airport.
        /// </summary>
        /// <returns></returns>
        public List<Taxiway> GetListTaxiways()
        {
            return listTaxiway;
        }

        /// <summary>
        /// Prints out information about every flight in the list of departuring flights for this airport.
        /// </summary>
        public void PrintListOfDeparturingFlights()
        {
            Console.Write($"\nAll departuring flights for airport: {Name} ({AirportCode})\n");
            foreach (Flight flight in departingFlights)
            {
                Console.Write($"Aircraft:{flight.ActiveAircraft.Model}\nID: {flight.FlightId}\nDate: {flight.DateTimeFlight}\n");
            }
        } 
    
        /// <summary>
        /// Adds a runway to the airport.
        /// </summary>
        /// <param name="Runway"></param>
        public void AddRunwayToList(Runway Runway)
        {
            listRunway.Add(Runway);
        }

        /// <summary>
        /// Adds a taxiway to the airport.
        /// </summary>
        /// <param name="Taxiway"></param>
        public void AddTaxiwayToList(Taxiway Taxiway)
        {
            listTaxiway.Add(Taxiway);
        }

        /// <summary>
        /// Adds a gate to the airport.
        /// </summary>
        /// <param name="Gate"></param>
        public void AddGateToList(Gate Gate)
        {
            listGate.Add(Gate);
        }

        /// <summary>
        /// This method makes all gates in a airport allow all aircraft types.
        /// </summary>
        public void MakeAllGatesAllowAllAircraftTypes()
        {
            foreach (var gate in GetListGates())
            {
                gate.MakeAllAircraftTypesAllowedForThisGate();
            }
        }

        /// <summary>
        /// This method returns all arriving flights for this airport.
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetArrivingFlights()
        {
            return arrivingFlights;
        }


        /// <summary>
        /// This method adds an arriving flight to this airport.
        /// </summary>
        /// <param name="flight"></param>
        public void AddArrivingFlight(Flight flight)
        {
            arrivingFlights.Add(flight);
        }

        /// <summary>
        /// This method removes an arriving flight from this airport.
        /// </summary>
        /// <param name="flight"></param>
        public void RemoveArrivingFlight(Flight flight)
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
        /// This method returns all departuring flights for this airport.
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetDepartingFlights()
        {
            return departingFlights;
        }

        /// <summary>
        /// This method adds an departuring flight to this airport.
        /// </summary>
        /// <param name="flight"></param>
        public void AddDepartingFlight(Flight flight)
        {
            departingFlights.Add(flight);
        }

        /// <summary>
        /// This method removes an departuring flight from this airport.
        /// </summary>
        /// <param name="flight"></param>
        public void RemoveDepartingFlight(Flight flight)
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
        /// Parameter 'numberOfDays' is the number of days the flight will do its flights.
        /// The rest of the parameters is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfDays"></param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="isArrivingFlight"></param>
        /// <param name="length"></param>
        /// <param name="departureAirport"></param>
        /// <param name="arrivalAirport"></param>
        /// <param name="departureGate"></param>
        /// <param name="arrivalGate"></param>
        /// <param name="departureTaxiway"></param>
        /// <param name="arrivalTaxiway"></param>
        /// <param name="departureRunway"></param>
        /// <param name="arrivalRunway"></param>
        public void AddDailyArrivingFlight(int numberOfDays,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            bool isArrivingFlight, int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway,
            Runway departureRunway, Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfDays; i++)
            {
                Flight daily = new Flight(activeAircraft, dateTimeFlight.AddDays(i),
                    isArrivingFlight, length,
                    departureAirport, arrivalAirport,
                    departureGate, arrivalGate,
                    departureTaxiway, arrivalTaxiway,
                    departureRunway, arrivalRunway);

                arrivingFlights.Add(daily);
            }
        }

        /// <summary>
        /// This method generates weekly arriving flights. The first flight starts 1 week after the value of the datetimeFlight object.
        /// Parameter 'numberOfWeeks' is the number of weeks the flight will do its flights.
        /// The rest of the parameters is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfWeeks"></param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="isArrivingFlight"></param>
        /// <param name="length"></param>
        /// <param name="departureAirport"></param>
        /// <param name="arrivalAirport"></param>
        /// <param name="departureGate"></param>
        /// <param name="arrivalGate"></param>
        /// <param name="departureTaxiway"></param>
        /// <param name="arrivalTaxiway"></param>
        /// <param name="departureRunway"></param>
        /// <param name="arrivalRunway"></param>
        public void AddWeeklyArrivingFlight(int numberOfWeeks,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            bool isArrivingFlight, int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway,
            Runway departureRunway, Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfWeeks; i++)
            {
                Flight weekly = new Flight(activeAircraft, dateTimeFlight.AddDays(i * 7),
                    isArrivingFlight, length,
                    departureAirport, arrivalAirport,
                    departureGate, arrivalGate,
                    departureTaxiway, arrivalTaxiway,
                    departureRunway, arrivalRunway);

                arrivingFlights.Add(weekly);
            }
        }

        /// <summary>
        /// This method generates daily departuring flights. The first flight starts 24 hours after the value of the datetimeFlight object.
        /// Parameter 'numberOfDays' is the number of days the flight will do its flights.
        /// The rest of the parameters is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfDays"></param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="isArrivingFlight"></param>
        /// <param name="length"></param>
        /// <param name="departureAirport"></param>
        /// <param name="arrivalAirport"></param>
        /// <param name="departureGate"></param>
        /// <param name="arrivalGate"></param>
        /// <param name="departureTaxiway"></param>
        /// <param name="arrivalTaxiway"></param>
        /// <param name="departureRunway"></param>
        /// <param name="arrivalRunway"></param>
        public void AddDailyDeparturingFlight(int numberOfDays,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            bool isArrivingFlight, int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway,
            Runway departureRunway, Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfDays; i++)
            {
                Flight daily = new Flight(activeAircraft, dateTimeFlight.AddDays(i),
                    isArrivingFlight,  length,
                    departureAirport,  arrivalAirport,
                    departureGate,  arrivalGate,
                    departureTaxiway,  arrivalTaxiway,
                    departureRunway,  arrivalRunway);

                departingFlights.Add(daily);
            }
        }

        /// <summary>
        /// This method generates weekly departuring flights. The first flight starts 1 week after the value of the datetimeFlight object.
        /// Parameter 'numberOfWeeks' is the number of weeks the flight will do its flights.
        /// The rest of the parameters is values for creating the Flight objects.
        /// </summary>
        /// <param name="numberOfWeeks"></param>
        /// <param name="activeAircraft"></param>
        /// <param name="dateTimeFlight"></param>
        /// <param name="isArrivingFlight"></param>
        /// <param name="length"></param>
        /// <param name="departureAirport"></param>
        /// <param name="arrivalAirport"></param>
        /// <param name="departureGate"></param>
        /// <param name="arrivalGate"></param>
        /// <param name="departureTaxiway"></param>
        /// <param name="arrivalTaxiway"></param>
        /// <param name="departureRunway"></param>
        /// <param name="arrivalRunway"></param>
        public void AddWeeklyDeparturingFlight(int numberOfWeeks,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            bool isArrivingFlight, int length,
            Airport departureAirport, Airport arrivalAirport,
            Gate departureGate, Gate arrivalGate,
            Taxiway departureTaxiway, Taxiway arrivalTaxiway,
            Runway departureRunway, Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfWeeks; i++)
            {
                Flight weekly = new Flight(activeAircraft, dateTimeFlight.AddDays(i*7),
                    isArrivingFlight, length,
                    departureAirport, arrivalAirport,
                    departureGate, arrivalGate,
                    departureTaxiway, arrivalTaxiway,
                    departureRunway, arrivalRunway);

                departingFlights.Add(weekly);
            }
        }
    }
}