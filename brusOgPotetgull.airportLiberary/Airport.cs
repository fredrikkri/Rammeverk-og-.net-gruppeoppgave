using BrusOgPotetgull.AirportLiberary;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// This class is used to configure an airport and holds all its components.
    /// </summary>
	public class Airport
    {
        private static int idCounter = 1;
        private int airportId;
        private List<Terminal> listTerminal;
        private List<Gate> listGate;
        private List<Taxiway> listTaxiway;
        private List<Runway> listRunway;
        private List<Flight> arrivingFlights;
        private List<Flight> departingFlights;
        private List<ConnectionPoint> taxiwaySystem;

        /// <summary>
        /// Creates an airport without any components.
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
            listTerminal = new List<Terminal>();
            listGate = new List<Gate>();
            listTaxiway = new List<Taxiway>();
            listRunway = new List<Runway>();
            arrivingFlights = new List<Flight>();
            departingFlights = new List<Flight>();
            taxiwaySystem = new List<ConnectionPoint>();
        }

        /// <summary>
        /// Gets airport id
        /// </summary>
        /// <value>
        /// int value with airport id
        /// </value>
        public int AirportId { get; private set; }

        /// <summary>
        /// gets airport code
        /// </summary>
        /// <value>
        /// string with the code of the airport
        /// </value>
        public string AirportCode { get; private set; }

        /// <summary>
        /// gets airport name
        /// </summary>
        /// <value>
        /// string with the name of the airport
        /// </value>
        public string Name { get; private set; }

        /// <summary>
        /// gets airport location
        /// </summary>
        /// <value>
        /// string with location of the airport
        /// </value>
        public string Location { get; private set; }

        /// <summary>
        /// Generates a path from one taxiway to another for an arriving flight.
        /// </summary>
        /// <remarks>Only generates a path if the arrival gate on the flight is connected to one of the taxiways in the airport.</remarks>
        /// <param name="flight">The Flight you want to generate a path for.</param>
        /// <returns>Returns the path as a list of taxiway objects</returns>
        public List<Taxiway> GenerateArrivingFlightTaxiwayPath(Flight.Arriving flight)
        {
            foreach (Taxiway taxiway in GetListTaxiways())
                foreach (Gate gate in taxiway.connectedGates)
                {
                    if (gate == flight.ArrivalGate)
                    {
                        List<Taxiway> path = FindPath(flight.ArrivalTaxiway, taxiway, new List<Taxiway>());
                        return path;
                    }
                }
            return null;
        }

        /// <summary>
        /// Generates a path from one taxiway to another for an departing flight.
        /// </summary>
        /// <remarks>Only generates a path if the depature gate on the flight is connected to one of the taxiways in the airport.</remarks>
        /// <param name="flight">The Flight you want to generate a path for.</param>
        /// <returns>Returns the path as a list of taxiway objects</returns>
        public List<Taxiway> GenerateDeparturingFlightTaxiwayPath(Flight.Departing flight)
        {
            foreach (Taxiway taxiway in GetListTaxiways())
                foreach (Gate gate in taxiway.connectedGates)
                {
                    if (gate == flight.DepartureGate)
                    {
                        List<Taxiway> path = FindPath(taxiway, flight.DepartureTaxiway, new List<Taxiway>());
                        return path;
                    }
                }
            return null;
        }

        /// <summary>
        /// Prints out the name of all the taxiways in the route, and the total number of taxiways.
        /// </summary>
        /// <param name="route">The route you want to print out to the console</param>
        public void PrintTaxiwayRoute(List<Taxiway> route)
        {
            Console.WriteLine();
            foreach (Taxiway t in route)
                Console.WriteLine($"{t.Name}");

            Console.WriteLine($"antall taksebanser i rute: {route.Count()}");
        }

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
                Console.Write($"{runway.Name} ");

            Console.Write($"\nList of taxiways: ");
            foreach (Taxiway taxiway in listTaxiway)
                Console.Write($"{taxiway.Name} ");

            Console.Write($"\nList of gates: ");
            foreach (Gate gate in listGate)
                Console.Write($"{gate.Name} ");

            Console.Write("\n");
        }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the Airport.</returns>
        public override string ToString()
        {
            return $"\nAirportId: {AirportId} " +
                $"\nName: {Name}\n";
        }


        /// <summary>
        /// Returns a list of all the gates at this airport.
        /// </summary>
        /// <returns>A list of gates at this airport.</returns>
        public List<Gate> GetListGates() => listGate;

        /// <summary>
        /// Returns a list of all the terminals at this airport.
        /// </summary>
        /// <returns>A list of Terminals at this airport.</returns>
        public List<Terminal> GetListTerminals() => listTerminal;

        /// <summary>
        /// Gets a single terminal based on id.
        /// </summary>
        /// <param name="terminalId">The id of the termial that is desired.</param>
        /// <returns>The desired terminal</returns>
        /// <exception cref="InvalidOperationException">If airport has no terminals or could not find any terminals that matches the terminals that exists in this airport.</exception>
        public Terminal GetTerminalById(int terminalId)
        {
            if (listTerminal.Count <= 0)
            {
                throw new InvalidOperationException($"No terminals exists for airport: {Name}");
            }
            else
            {
                foreach (Terminal terminal in listTerminal)
                {
                    if (terminal.Id == terminalId)
                    {
                        return terminal;
                    }
                }
                throw new InvalidOperationException($"Could not find terminal with id: {terminalId}");
            }
        }

        /// <summary>
        /// Gets a single gate based on id.
        /// </summary>
        /// <param name="gateId">The id of the gate that is desired.</param>
        /// <returns>The desired gate</returns>
        /// <exception cref="InvalidOperationException">If airport has no gates or could not find any gates that matches the gates that exists in this airport.</exception>
        public Gate GetGatesById(int gateId)
        {
            if (listGate.Count <= 0)
            {
                throw new InvalidOperationException($"No terminals exists for airport: {Name}");
            }
            else
            {
                foreach (Gate gate in listGate)
                {
                    if (gate.Id == gateId)
                    {
                        return gate;
                    }
                }
                throw new InvalidOperationException($"Could not find terminal with id: {gateId}");
            }
        }

        /// <summary>
        /// Returns a list of all the taxiways at this airport.
        /// </summary>
        /// <returns>a list that contains all the taxiways at this airport.</returns>
        public List<Taxiway> GetListTaxiways() => listTaxiway;

        /// <summary>
        /// Returns a list of all the runways at this airport.
        /// </summary>
        /// <returns>A list of runways at this airport</returns>
        public List<Runway> GetRunwayList() => listRunway;

        /// <summary>
        /// Prints out the information about the taxiwaysystem (All the connected components).
        /// </summary>
        public void PrintTaxiwaySystem()
        {
            int i = 0;
            Console.WriteLine($"\n\tInformation about taxiway system for airport: {Name}");
            foreach (ConnectionPoint connection in GetTaxiwaySystem())
            {
                i++;
                Console.WriteLine($"{i}: {connection.Name}");
                foreach (var taxiway in connection.taxiways)
                {
                    Console.WriteLine($"\t{taxiway.Name}");
                    if (taxiway.connectedGates != null)
                        foreach (Gate gate in taxiway.connectedGates)
                        {
                            Console.WriteLine($"\tGateConnection: {gate.Name}");
                        }
                    else
                        Console.WriteLine($"\t{taxiway.Name}");
                }
            }
        }

        /// <summary>
        /// Adds a connection point to the taxiwaysystem
        /// </summary>
        /// <param name="connection">ConnectionPoint point to connect two or more taxiways</param>
        public void AddConnectionPoint(ConnectionPoint connection) => taxiwaySystem.Add(connection);

        /// <summary>
        /// creates the connection a taxiway has to connection points.
        /// </summary>
        /// <param name="taxiway">The taxiway you want to create a connection for.</param>
        /// <param name="to">Connection point B (to)</param>
        /// <param name="from">Connection point A (from)</param>
        public void AddTaxiwayConnection(Taxiway taxiway, ConnectionPoint to, ConnectionPoint from)
        {
            taxiway.B = to;
            taxiway.A = from;
            from.taxiways.Add(taxiway);
            to.taxiways.Add(taxiway);
        }

        /// <summary>
        /// Finds a path through the taxiway system from one taxiway to another.
        /// </summary>
        /// <param name="start">start taxiway of the path.</param>
        /// <param name="end">end taxiway of the path.</param>
        /// <param name="calculatedRoute">An empty list of taxiways to be returned as a path</param>
        /// <returns>Returns the path as a list of taxiway objects</returns>
        public List<Taxiway> FindPath(Taxiway start, Taxiway end, List<Taxiway> calculatedRoute)
        {
            if (start == end)
            {
                for (int i = 1; i < calculatedRoute.Count - 1; i++)
                {
                    Taxiway past = calculatedRoute[i - 1];
                    Taxiway current = calculatedRoute[i];
                    Taxiway next = calculatedRoute[i + 1];
                    if (current.A.taxiways.Contains(past))
                        if (!current.B.taxiways.Contains(next))
                            calculatedRoute.Remove(current);

                    if (current.B.taxiways.Contains(past))
                        if (!current.A.taxiways.Contains(next))
                            calculatedRoute.Remove(current);

                    calculatedRoute.Add(end);
                    return calculatedRoute;
                }

                calculatedRoute.Add(end);
                return calculatedRoute;
            }

            calculatedRoute.Add(start);

            foreach (Taxiway nextTaxiway in start.B.taxiways)
                if (!calculatedRoute.Contains(nextTaxiway))
                {
                    List<Taxiway> result = FindPath(nextTaxiway, end, calculatedRoute.ToList());
                    if (result != null)
                        return result;
                }

            foreach (Taxiway nextTaxiway in start.A.taxiways)
                if (!calculatedRoute.Contains(nextTaxiway))
                {
                    List<Taxiway> result = FindPath(nextTaxiway, end, calculatedRoute.ToList());
                    if (result != null)
                        return result;
                }

            return null;
        }

        /// <summary>
        /// Adds a terminal to the airport.
        /// </summary>
        /// <param name="terminal">The terminal that is added to the list of terminals for this airport.</param>
        public void AddTerminalToList(Terminal terminal)
        {
            if (listTerminal.Contains(terminal))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Terminal with id: '{terminal.Id}' allready exists in airport: '{Name}'");

            terminal.UpdateLocation(Name);
            listTerminal.Add(terminal);
        }

        /// <summary>
        /// Removes a terminal from the airport.
        /// </summary>
        /// <param name="terminal">The terminal that is removed from the list of terminals for this airport.</param>
        public void RemoveTerminalFromList(Terminal terminal)
        {
            if (!listTerminal.Contains(terminal))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Terminal with id: '{terminal.Id}' does not exists in airport: '{Name}'. It cant be removed.");

            terminal.UpdateLocation("none");
            listTerminal.Remove(terminal);
        }

        /// <summary>
        /// Adds a gate to the airport.
        /// </summary>
        /// <param name="gate">The gate that is added to the list of gates at this airport.</param>
        public void AddGateToList(Gate gate)
        {
            if (listGate.Contains(gate))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{gate.Id}' allready exists in airport: '{Name}'");

            gate.UpdateLocation(Name);
            listGate.Add(gate);
        }

        /// <summary>
        /// Removes a gate from the airport.
        /// </summary>
        /// <param name="gate">The gate that is removed from the list of gates at this airport.</param>
        public void RemoveGateFromList(Gate gate)
        {
            if (!listGate.Contains(gate))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{gate.Id}' does not exists in airport: '{Name}'. It cant be removed.");

            gate.UpdateLocation("none");
            listGate.Remove(gate);
        }

        /// <summary>
        /// Returns a gate object based on the gatename provided.
        /// </summary>
        /// <param name="gateName">Name of the gate you want to return.</param>
        /// <returns>gate object</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Gate GetGateBasedOnGateName(string gateName)
        {
            if (GetListGates().Find(currentGate => currentGate.Name == gateName) == null)
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with name: '{gateName}' does not exsist. It cannot be added to the terminal.");

            return GetListGates().Find(currentGate => currentGate.Name == gateName);
        }

        /// <summary>
        /// Adds a taxiway to the airport.
        /// </summary>
        /// <param name="taxiway">The taxiway that is added to the list of taxiways for this airport.</param>
        public void AddTaxiwayToList(Taxiway taxiway)
        {
            if (listTaxiway.Contains(taxiway))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{taxiway.Id}' allready exists in airport: '{Name}'");

            taxiway.UpdateLocation(Name);
            listTaxiway.Add(taxiway);
        }

        /// <summary>
        /// Removes a taxiway from the airport.
        /// </summary>
        /// <param name="taxiway">The taxiway that is removed from the list of taxiways at this airport.</param>
        public void RemoveTaxiwayFromList(Taxiway taxiway)
        {
            if (!listTaxiway.Contains(taxiway))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Taxiway with id: '{taxiway.Id}' does not exists in airport: '{Name}'. It cant be removed.");

            taxiway.UpdateLocation("none");
            listTaxiway.Remove(taxiway);
        }

        /// <summary>
        /// Adds a runway to the airport.
        /// </summary>
        /// <param name="runway">The runway that is being added to the list of runways at this airport.</param>
        public void AddRunwayToList(Runway runway)
        {
            if (listRunway.Contains(runway))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Gate with id: '{runway.Id}' allready exists in airport: '{Name}'");

            runway.UpdateLocation(Name);
            listRunway.Add(runway);
        }

        /// <summary>
        /// Removes a runway from the airport.
        /// </summary>
        /// <param name="runway">The taxiway that is removed from the list of taxiways at this airport.</param>
        public void RemoveRunwayFromList(Runway runway)
        {
            if (!listRunway.Contains(runway))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Runway with id: '{runway.Id}' does not exists in airport: '{Name}'. It cant be removed.");

            runway.UpdateLocation("none");
            listRunway.Remove(runway);
        }

        /// <summary>
        /// Makes all gates in this airport allow all aircraft types.
        /// </summary>
        public void MakeAllGatesAllowAllAircraftTypes()
        {
            foreach (Gate gate in GetListGates())
                gate.MakeAllAircraftTypesAllowedForThisGate();
        }

        /// <summary>
        /// Prints out information about every flight in the list of departuring flights for this airport.
        /// </summary>
        public void PrintListOfDeparturingFlights()
        {

            if (!departingFlights.Any())
                throw new InvalidOperationException($"List of departuring flights is empty for airport: '{Name}'");
            else
            {
                Console.Write($"\nAll departuring flights for airport: {Name} ({AirportCode})\n");
                foreach (Flight flight in departingFlights)
                    Console.Write($"Aircraft:{flight.ActiveAircraft.Name}\nID: {flight.FlightId}\nDate: {flight.DateTimeFlight}\n");
            }
        }

        /// <summary>
        /// Gets all arriving flights for this airport.
        /// </summary>
        /// <returns>The list containing all arriving flights for this airport.</returns>
        public List<Flight> GetArrivingFlights() => arrivingFlights;

        /// <summary>
        /// Gets all departuring flights for this airport.
        /// </summary>
        /// <returns>A list of departuring flights.</returns>
        public List<Flight> GetDepartingFlights() => departingFlights;

        /// <summary>
        /// Adds an arriving flight to this airport.
        /// </summary>
        /// <param name="flight">The arriving flight that is added to the list.</param>
        public void AddArrivingFlight(Flight.Arriving flight)
        {
            if (arrivingFlights.Contains(flight))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Flight with id: '{flight.FlightId}' allready exists in airport: '{Name}'");
            arrivingFlights.Add(flight);
        }

        /// <summary>
        /// Adds an departuring flight to this airport.
        /// </summary>
        /// <param name="flight">The departuring flight that is added to the list.</param>
        public void AddDepartingFlight(Flight.Departing flight)
        {
            if (departingFlights.Contains(flight))
                // (Nagel, 2022, s. 267)
                throw new InvalidOperationException($"Flight with id: '{flight.FlightId}' allready exists in airport: '{Name}'");
            departingFlights.Add(flight);
        }

        /// <summary>
        /// Removes an arriving flight from this airport.
        /// </summary>
        /// <param name="flight">The arriving flight that is removed from the list.</param>
        public void RemoveArrivingFlight(Flight.Arriving flight)
        {
            if (arrivingFlights.Count == 0)
                throw new InvalidOperationException("No arriving flights in list");

            arrivingFlights.Remove(flight);
        }

        /// <summary>
        /// Removes a departuring flight from this airport.
        /// </summary>
        /// <param name="flight">The departuring flight that is removed from the list.</param>
        public void RemoveDepartingFlight(Flight.Departing flight)
        {
            if (departingFlights.Count == 0)
                throw new InvalidOperationException("No departing flights in list");

            departingFlights.Remove(flight);
        }

        /// <summary>
        /// Generates daily arriving flights. The first flight starts 24 hours after the value of the datetimeFlight object.
        /// </summary>
        /// <param name="numberOfDays">The number of days the flight will do its flights.</param>
        /// <param name="activeAircraft">The aircraft that is used for this flight.</param>
        /// <param name="dateTimeFlight">Date of the flight.</param>
        /// <param name="length">Length of the flight im KM.</param>
        /// <param name="arrivalAirport">The airport that the aircraft is arriving at.</param>
        /// <param name="arrivalGate">The gate that the aircraft is arriving at.</param>
        /// <param name="arrivalTaxiway">The taxiway that the aircraft is arriving at.</param>
        /// <param name="arrivalRunway">The runway that the aircraft is arriving at.</param>
        public void AddDailyArrivingFlight(int numberOfDays,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport arrivalAirport,
            Gate arrivalGate, Taxiway arrivalTaxiway,
            Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfDays; i++)
            {
                Flight.Arriving daily = new(activeAircraft,
                     dateTimeFlight.AddDays(i), length,
                     arrivalAirport, arrivalGate,
                     arrivalTaxiway, arrivalRunway);

                arrivingFlights.Add(daily);
            }
        }

        /// <summary>
        /// Generates daily departuring flights. The first flight starts 24 hours after the value of the datetimeFlight object.
        /// </summary>
        /// <param name="numberOfDays">The number of days the flight will do its flights.</param>
        /// <param name="activeAircraft">The aircraft that is used for this flight.</param>
        /// <param name="dateTimeFlight">Date of the flight.</param>
        /// <param name="length">Length of the flight im KM.</param>
        /// <param name="departureAirport">The airport that the aircraft departure from.</param>
        /// <param name="departureGate">The gate that the aircraft departure from.</param>
        /// <param name="departureTaxiway">The taxiway that the aircraft is using to departure from.</param>
        /// <param name="departureRunway">The runway that the aircraft is departuring from.</param>
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
        /// Generates weekly arriving flights. The first flight starts 1 week after the value of the datetimeFlight object.
        /// </summary>
        /// <param name="numberOfWeeks">The number of weeks the flight will do its flights.</param>
        /// <param name="activeAircraft">The aircraft that is used for this flight.</param>
        /// <param name="dateTimeFlight">Date of the flight.</param>
        /// <param name="length">Length of the flight im KM.</param>
        /// <param name="arrivalAirport">The airport that the aircraft is arriving at.</param>
        /// <param name="arrivalGate">The gate that the aircraft is arriving at.</param>
        /// <param name="arrivalTaxiway">The taxiway that the aircraft is arriving at.</param>
        /// <param name="arrivalRunway">The runway that the aircraft is arriving at.</param>
        public void AddWeeklyArrivingFlight(int numberOfWeeks,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport arrivalAirport,
            Gate arrivalGate, Taxiway arrivalTaxiway,
            Runway arrivalRunway)
        {
            for (int i = 1; i <= numberOfWeeks; i++)
            {
                Flight.Arriving weekly = new(activeAircraft,
                     dateTimeFlight.AddDays(i * 7), length,
                     arrivalAirport, arrivalGate,
                     arrivalTaxiway, arrivalRunway);

                arrivingFlights.Add(weekly);
            }
        }

        /// <summary>
        /// Generates weekly departuring flights. The first flight starts 1 week after the value of the datetimeFlight object.
        /// </summary>
        /// <param name="numberOfWeeks">The number of weeks the flight will do its flights.</param>
        /// <param name="activeAircraft">The aircraft that is used for this flight.</param>
        /// <param name="dateTimeFlight">Date of the flight.</param>
        /// <param name="length">Length of the flight im KM.</param>
        /// <param name="departureAirport">The airport that the aircraft departure from.</param>
        /// <param name="departureGate">The gate that the aircraft departure from.</param>
        /// <param name="departureTaxiway">The taxiway that the aircraft is using to departure from.</param>
        /// <param name="departureRunway">The runway that the aircraft is departuring from.</param>
        public void AddWeeklyDeparturingFlight(int numberOfWeeks,
            Aircraft activeAircraft, DateTime dateTimeFlight,
            int length, Airport departureAirport,
            Gate departureGate, Taxiway departureTaxiway,
            Runway departureRunway)
        {
            for (int i = 1; i <= numberOfWeeks; i++)
            {
                Flight.Departing weekly = new(activeAircraft,
                    dateTimeFlight.AddDays(i * 7), length,
                    departureAirport, departureGate,
                    departureTaxiway, departureRunway);

                departingFlights.Add(weekly);
            }
        }

        /// <summary>
        /// Finds an availabel gate at the same terminal of the initially desired gate.
        /// </summary>
        /// <remarks>Will return null if there is no availabel gate at the terminal.</remarks>
        /// <param name="nameOfDesiredGate">Gate you initially wanted to use.</param>
        /// <returns>A gate object</returns>
        public Gate GetAnotherAvailabelGateAtTheSameTerminal(string nameOfDesiredGate)
        {
            Gate desiredGate = GetGateBasedOnGateName(nameOfDesiredGate);
            foreach (Terminal terminal in listTerminal)
            {
                if (terminal.GetgatesInTerminal().Contains(desiredGate))
                {
                    foreach (Gate newGate in terminal.GetgatesInTerminal())
                    {
                        if (newGate.IsAvailable == true)
                        {
                            return newGate;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns Id and airport-code for the current airport as a string.
        /// </summary>
        /// <returns>AirportId and AirportCode combined into a string</returns>
        private string GetIdAndAirportCode() => (string)(AirportId + " " + AirportCode);

        /// <summary>
        /// Gets the taxiway system at this airport. This is a list of connection points between taxiways.
        /// </summary>
        /// <returns>A List of connection points.</returns>
        public List<ConnectionPoint> GetTaxiwaySystem() => taxiwaySystem;
    }
}