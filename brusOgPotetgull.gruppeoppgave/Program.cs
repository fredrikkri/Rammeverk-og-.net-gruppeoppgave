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

            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass); supergate.addLegalAircraftThatCanUseGate(cargoCraftV12);
            Gate nissegate = new Gate("Gate 22", ryggeFlyplass); nissegate.addLegalAircraftThatCanUseGate(cargoCraftV12);

            Taxiway mediumTaxiway = new Taxiway(535, 20, GardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(75, 35, ryggeFlyplass);

            Runway gammelRunway = new Runway(GardemoenFlyplass);
            Runway slitenRunway = new Runway(ryggeFlyplass);

            //mediumTaxiway.addAircraftToQueue(cargoCraftV12);
            //mediumTaxiway.firstInQueueEnterTaxiway(cargoCraftV12);

            Flight firstFlight = new Flight(cargoCraftV12, 50000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            //firstFlight.printFlightInformation();

            firstFlight.startFlight();
            cargoCraftV12.printFullAircraftHistory();


            System.Console.ReadLine();
        }
    }
}