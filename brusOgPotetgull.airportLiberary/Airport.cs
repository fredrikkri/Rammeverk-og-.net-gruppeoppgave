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
            this.Airportcategory = airportcategory;
            this.Name = name;
            this.Location = location;
            this.listRunway = new List<string>();
            this.listTaxiway = new List<string>();
            this.listGate = new List<int>();
        }
        public string Airportcategory { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        public void printAirportInformation()
        {
            Console.Write($"\nAirportcategory: {Airportcategory}\nName: {Name}\nLocation: {Location}" +
                $"\nlistRunway:{listRunway}\nlistTaxiway: {listTaxiway}\nlistGate: {listGate}\n");
        }
    }
}