using System.Numerics;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aircraft newPlane1 = new Aircraft("Jet 34"); newPlane1.printAircraftInformation();
            Aircraft newPlane2 = new Aircraft("Superjett"); newPlane2.printAircraftInformation();

            //Airport newAirport = new Airport("Militærflyplass", "Rygge Flyplass", "Rygge"); newAirport.printAirportInformation();

            //Flight newFlight1 = new Flight(200, "London", "Leeds"); newFlight1.printFlightInformation();
            //Flight newFlight2 = new Flight(5000, "Rio", "Sarpsborg"); newFlight2.printFlightInformation();

            Aircraft militarySuperJet = new MilitaryAircraft("Armed Gunplane 23"); militarySuperJet.printAircraftInformation();

            newPlane1.addHistoryToAircraft(1, "gate 2");
            newPlane1.addHistoryToAircraft(2, "Runway 12");
            newPlane1.addHistoryToAircraft(3, "gate 6");

            newPlane1.printFullAircraftHistory();



        }
    }
}