using System;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aircraft cargoCraftV12 = new CargoAircraft("Cargo plane v12", 890, 50, 40, 5); cargoCraftV12.PrintAircraftInformation();
            Aircraft superPlane = new LightAircraft("Cristiano Ronaldo´s Plane, siuuuuu!", 800, 56, 20, 3);
            Aircraft sickPlane = new CargoAircraft("Franceco Totti´s Plane.", 800, 56, 20, 3);

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport GardemoenFlyplass = new Airport("GAR", "Gardemoen Flyplass", "Oslo");

            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass); supergate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId); supergate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);
            Gate nissegate = new Gate("Gate 22", ryggeFlyplass); nissegate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId); nissegate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);

            Taxiway mediumTaxiway = new Taxiway(535, 20, GardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(75, 35, ryggeFlyplass);

            Runway gammelRunway = new Runway(GardemoenFlyplass, 400);
            Runway slitenRunway = new Runway(ryggeFlyplass, 500);

            Flight firstFlight = new Flight(cargoCraftV12, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            Flight coolFlight = new Flight(superPlane, 5000, ryggeFlyplass, GardemoenFlyplass, nissegate, supergate, longTaxiway, mediumTaxiway, slitenRunway, gammelRunway);
            Flight coolFlight2 = new Flight(sickPlane, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);

            coolFlight.SetupFlight(DateTime.Now);


            //coolFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //coolFlight2.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //firstFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);

            //cargoCraftV12.PrintFullAircraftHistory();
            //cargoCraftV12.PrintAircraftHistoryForDay(2024,2,1);


            superPlane.PrintFullAircraftHistory();

            //cargoCraftV12.checkPreviousLocation();

            System.Console.ReadLine();
        }
    }
}