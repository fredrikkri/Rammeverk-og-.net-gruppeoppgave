using System.Numerics;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge", 3, 8, 10); ryggeFlyplass.printAirportInformation();

            Aircraft newPlane1 = new Aircraft("Jet 34"); newPlane1.printAircraftInformation();
            Aircraft newPlane2 = new Aircraft("Superjett"); newPlane2.printAircraftInformation();
            Aircraft militarySuperJet = new MilitaryAircraft("Armed Gunplane 23"); militarySuperJet.printAircraftInformation();

            newPlane1.addHistoryToAircraft(1, "gate 2");
            newPlane1.addHistoryToAircraft(2, "Runway 12");
            newPlane1.addHistoryToAircraft(3, "gate 6");

            newPlane1.printFullAircraftHistory();

            Gate gate1 = new Gate();
            gate1.addLegalAircraftToGate("ShortMediumAircraft");
            gate1.addLegalAircraftToGate("CargoAircaft");

            gate1.printGateInformation();

            /// må ha denne for å se Consol av en eller annen grunn på pcen til jacob
            /// hvis ikke flasher bare consollen
            System.Console.ReadLine();
        }
    }
}