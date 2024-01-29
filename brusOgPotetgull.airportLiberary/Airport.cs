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

        public Airport(string airportNickname, string name, string location)
		{
            // (dosnetCore, 2020) 
            airportId = idCounter++;
            this.AirportId = airportId;
            this.AirportNickname = airportNickname;
            this.Name = name;
            this.Location = location;
            listRunway = new List<Runway>();
            listTaxiway = new List<Taxiway>();
            listGate = new List<Gate>();
        }
        public int AirportId { get; private set; }
        public string AirportNickname { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public void printAirportInformation()
        {
            Console.Write($"\nAirport id: {AirportId}\n" +
                $"Airport nickname: {AirportNickname}\n" +
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
        public void addRunwayToList(Runway Runway)
        {
            listRunway.Add(Runway);
        }
        public void addTaxiwayToList(Taxiway Taxiway)
        {
            listTaxiway.Add(Taxiway);
        }
        public void addGateToList(Gate Gate)
        {
            listGate.Add(Gate);
        }
        public void generateRunwayNumbers(int runwayNumber)
        {
            // (Nagel, 2022, s. 155)
            for (int i = 0; i < runwayNumber; i++)
            {
                //listRunway[i] = i + 1;
            }
        }
        public void generateTaxiwayNumbers(int TaxiwayNumber)
        {
            // (Nagel, 2022, s. 155)
            for (int i = 0; i < TaxiwayNumber; i++)
            {
               // listTaxiway[i] = i + 1;
            }
        }
        public void generateGateNumbers(int gateNumber)
        {
            // (Nagel, 2022, s. 155)
            for (int i = 0; i < gateNumber; i++)
            {
               // listGate[i] = i + 1;
            }
        }
    }
}