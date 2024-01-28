using System.Numerics;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aircraft cargoCraft = new CargoAircraft("Cargo plane"); cargoCraft.printAircraftInformation();

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport fredrikstadAirport = new Airport("FRE", "Fredrikstad Flyplass", "Fredrikstad");

            Gate supergate = new Gate("Gate 1A");
            Gate nissegate = new Gate("Gate 22"); 

            fredrikstadAirport.addGateToList(nissegate);
            fredrikstadAirport.addGateToList(supergate);

            fredrikstadAirport.printAirportInformation();

            System.Console.ReadLine();
        }
    }
}