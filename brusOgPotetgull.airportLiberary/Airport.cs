using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Airport
    {
        private string airportcategory = "";
        private string name = "";
        private string location = "";
        private List<string> listRunway;
        private List<string> listTaxiway;
        private List<int> listGate;


        public Airport(string airportcategory, string name, string location)
		{
            Airportcategory = airportcategory;
            Name = name;
            Location = location;
            listRunway = new List<string>();
            listTaxiway = new List<string>();
            listGate = new List<int>();
        }
        // (Nagel, C, 2021, s. 76)
        public string Airportcategory { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public void printAirportInformation()
        {
            Console.Write($"\nAirportcategory: {Airportcategory}\nName: {Name}\nLocation: {Location}" +
                $"\nlistRunway:{listRunway}\nlistTaxiway: {listTaxiway}\nlistGate: {listGate}");
        }
    }
}