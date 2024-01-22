using System;
using System.Reflection;

namespace brusOgPotetgull.gruppeoppgave.core
{
	public class Airport
    {
        private string airportcategory = "";
        private string name = "";
        private string location = "";
        private List<string> listRunway;
        private List<string> listTaxiway;
        private List<string> listGate;


        public Airport(string airportcategory, string name, string location)
		{
            Airportcategory = airportcategory;
            Name = name;
            Location = location;
            listRunway = new List<string>();
            listTaxiway = new List<string>();
            listGate = new List<string>();
        }
        public string Airportcategory { get; init; }
        public string Name { get; init; }
        public string Location { get; init; }

        public void getAirportInformation()
        {
            Console.Write($"\nAirportcategory: {Airportcategory}\nName: {Name}\nLocation: {Location}" +
                $"\nlistRunway:{listRunway}\nlistTaxiway: {listTaxiway}\nlistGate: {listGate}");
        }
    }
}