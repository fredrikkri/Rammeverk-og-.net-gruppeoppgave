using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Airport
    {
        private string airportNickname = "";
        private string name = "";
        private string location = "";
        private int[] listRunway;
        private int[] listTaxiway;
        private int[] listGate;

        public Airport(string airportNickname, string name, string location, int numberOfRunways, int numberOfTaxiways, int numberOfGates)
		{
            this.AirportNickname = airportNickname;
            this.Name = name;
            this.Location = location;
            this.listRunway = new int[numberOfRunways]; generateRunwayNumbers(numberOfRunways);
            this.listTaxiway = new int[numberOfTaxiways]; generateTaxiwayNumbers(numberOfTaxiways);
            this.listGate = new int[numberOfGates]; generateGateNumbers(numberOfGates);
        }
        public string AirportNickname { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public void printAirportInformation()
        {
            Console.Write($"\nAirport mickname: {AirportNickname}\nName: {Name}\nLocation: {Location}\n");
            Console.Write($"\nList of runways: ");
            foreach (int runway in listRunway)
            {
                Console.Write($"{runway} ");
            }
            Console.Write($"\nList of taxiways: ");
            foreach (int taxiway in listTaxiway)
            {
                Console.Write($"{taxiway} ");
            }
            Console.Write($"\nList of gates: ");
            foreach (int gate in listGate)
            {
                Console.Write($"{gate} ");
            }
            Console.Write("\n");
        }
        public void addRunwayToList(int idRunway)
        {
            listRunway.Append(idRunway);
        }
        public void addTaxiwayToList(int idTaxiway)
        {
            listTaxiway.Append(idTaxiway);
        }
        public void addGateToList(int idGate)
        {
            listGate.Append(idGate);
        }
        
        public void generateRunwayNumbers(int runwayNumber)
        {
            // (Nagel, 2022, s. 155)
            for (int i = 0; i < runwayNumber; i++)
            {
                listRunway[i] = i + 1;
            }
        }
        public void generateTaxiwayNumbers(int TaxiwayNumber)
        {
            // (Nagel, 2022, s. 155)
            for (int i = 0; i < TaxiwayNumber; i++)
            {
                listTaxiway[i] = i + 1;
            }
        }
        public void generateGateNumbers(int gateNumber)
        {
            // (Nagel, 2022, s. 155)
            for (int i = 0; i < gateNumber; i++)
            {
                listGate[i] = i + 1;
            }
        }
    }
}