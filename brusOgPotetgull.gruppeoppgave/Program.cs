using System.Numerics;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge", 10, 8, 10); ryggeFlyplass.printAirportInformation();
            Airport fredrikstadAirport = new Airport("FRE", "Fredrikstad Flyplass", "Fredrikstad", 4, 10, 20); fredrikstadAirport.printAirportInformation();

            Aircraft newPlane1 = new Aircraft("Jet 34"); newPlane1.printAircraftInformation();

            Flight firstFlight = new Flight(ryggeFlyplass, fredrikstadAirport); firstFlight.printFlightInformation();

            /// må ha denne for å se Consol av en eller annen grunn på pcen til jacob
            /// hvis ikke flasher bare consollen
            System.Console.ReadLine();
        }
    }
}