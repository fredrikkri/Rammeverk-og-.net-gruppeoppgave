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
        /// Prints the information about the airport.
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
        public string GetIdAndAirportNickname()
        {
            string returnString = (string)(AirportId + " " + AirportCode);
            return returnString;
        }
        public List<Runway> GetRunwayList()
        {
            return listRunway;
        }
        public List<Gate> GetListGates()
        {
            return listGate;
        }
        public List<Taxiway> GetListTaxiways()
        {
            return listTaxiway;
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
        public List<Flight> GetArrivingFlights()
        {
            return arrivingFlights;
        }
        public void AddArrivingFlight(Flight flight)
        {
            arrivingFlights.Add(flight);
        }
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
        public List<Flight> GetDepartingFlights()
        {
            return departingFlights;
        }
        public void AddDepartingFlight(Flight flight)
        {
            departingFlights.Add(flight);
        }
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
    }
}