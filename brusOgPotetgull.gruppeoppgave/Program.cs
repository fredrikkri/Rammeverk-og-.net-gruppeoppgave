using System;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aircraft cargoCraftV12 = new CargoAircraft("Cargo plane v12", 500, 30, 40, 5);

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport GardemoenFlyplass = new Airport("GAR", "Gardemoen Flyplass", "Oslo");

            Gate supergate = new Gate("Gate 1A");
            Gate nissegate = new Gate("Gate 22");

            Taxiway mediumTaxiway = new Taxiway(535, 20);
            Taxiway longTaxiway = new Taxiway(75, 35);

            mediumTaxiway.addAircraftToQueue(cargoCraftV12);
            mediumTaxiway.firstInQueueEnterTaxiway(cargoCraftV12);

            Flight firstFlight = new Flight(cargoCraftV12, 50000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway);
            firstFlight.printFlightInformation();

            System.Console.ReadLine();
        }
    }
}