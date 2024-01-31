using System;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Aircraft cargoCraftV12 = new CargoAircraft("Cargo plane v12", 890, 50, 40, 5);

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport GardemoenFlyplass = new Airport("GAR", "Gardemoen Flyplass", "Oslo");

            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass); supergate.AddLegalAircraftThatCanUseGate(cargoCraftV12);
            Gate nissegate = new Gate("Gate 22", ryggeFlyplass); nissegate.AddLegalAircraftThatCanUseGate(cargoCraftV12);

            Taxiway mediumTaxiway = new Taxiway(535, 20, GardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(75, 35, ryggeFlyplass);

            Runway gammelRunway = new Runway(GardemoenFlyplass, 400);
            Runway slitenRunway = new Runway(ryggeFlyplass, 500);

            Flight firstFlight = new Flight(cargoCraftV12, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);

            //firstFlight.StartFlight(DateTime.Now);
            cargoCraftV12.PrintFullAircraftHistory();

            firstFlight.SetupDailyFlight(DateTime.Now, 3);
            firstFlight.SetupWeeklyFlight(DateTime.Now, 3);  

            System.Console.ReadLine();
        }
    }
}