using System.Numerics;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aircraft cargoCraftV12 = new CargoAircraft("Cargo plane v12", 200, 20);
            cargoCraftV12.addHistoryToAircraft(1, "Gate 2");
            cargoCraftV12.printAircraftInformation(); cargoCraftV12.printFullAircraftHistory();

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport fredrikstadAirport = new Airport("FRE", "Fredrikstad Flyplass", "Fredrikstad");

            Gate supergate = new Gate("Gate 1A");
            Gate nissegate = new Gate("Gate 22");

            Taxiway mediumTaxiway = new Taxiway(53);
            Taxiway longTaxiway = new Taxiway(75);

            fredrikstadAirport.addGateToList(nissegate);
            fredrikstadAirport.addGateToList(supergate);

            fredrikstadAirport.printAirportInformation();
            Flight firstFlight = new Flight(10000, ryggeFlyplass, fredrikstadAirport, supergate, nissegate, longTaxiway, mediumTaxiway);
            firstFlight.printFlightInformation();

            System.Console.ReadLine();
        }
    }
}