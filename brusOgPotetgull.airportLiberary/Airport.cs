using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Airport
    {
        private static int idCounter = 1;
        private int airportId;
        private string airportNickname = "";
        private string name = "";
        private string location = "";
        private int[] listRunway;
        private int[] listTaxiway;
        private int[] listGate;

        public Airport(string airportNickname, string name, string location, int numberOfRunways, int numberOfTaxiways, int numberOfGates)
		{
            // (dosnetCore, 2020) 
            airportId = idCounter++;
            this.AirportId = airportId;
            this.AirportNickname = airportNickname;
            this.Name = name;
            this.Location = location;
            this.listRunway = new int[numberOfRunways]; generateRunwayNumbers(numberOfRunways);
            this.listTaxiway = new int[numberOfTaxiways]; generateTaxiwayNumbers(numberOfTaxiways);
            this.listGate = new int[numberOfGates]; generateGateNumbers(numberOfGates);
        }
        public int AirportId { get; private set; }
        public string AirportNickname { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public void printAirportInformation()
        {
            Console.Write($"\nAirport id: {AirportId}\nAirport nickname: {AirportNickname}\nName: {Name}\nLocation: {Location}\n");
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
        // Dette gjelder for alle funksjonene nedenfor.
        // Vi må gjøre slik at listRunway, ListTaxiway og ListGates inneholder objekter. Ikke int.
        // Det blir da lettere senere og lage funksjoner til rammeverket.
        // det vi kan gjøre istedenfor funksjonene nedenfor er å lage funksjoner som legger til en Gate,Taxiway eller Runway objekt
        // til en Airport.
        // Kanskje noe som dette:
        // public void addGateToAirport(int AirportId, Gate gateToAdd)
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