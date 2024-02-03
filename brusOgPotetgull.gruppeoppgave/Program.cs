using System;
using brusOgPotetgull.airportLiberary;
using brusOgPotetgull.airportLiberary.AircraftTypes;
using brusOgPotetgull.airportLiberary.Simulation;

namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport GardemoenFlyplass = new Airport("GAR", "Gardemoen Flyplass", "Oslo");

            Aircraft cargoCraftV12 = new CargoAircraft("Cargo plane v12", 890, 50, 40, 5);
            Aircraft superPlane = new LightAircraft("Cristiano Ronaldo´s Plane, siuuuuu!", 800, 56, 20, 3);
            Aircraft sickPlane = new CargoAircraft("Franceco Totti´s Plane.", 800, 56, 20, 3);

            

            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass);
            supergate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId);
            supergate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);

            Gate nissegate = new Gate("Gate 22", ryggeFlyplass);
            nissegate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId);
            nissegate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);

            Gate hallaGate = new Gate("Gate 90", ryggeFlyplass);


            Gate YOYOGate = new Gate("Gate 2A", GardemoenFlyplass);
            YOYOGate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId);
            YOYOGate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);

            Taxiway mediumTaxiway = new Taxiway(535, 20, GardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(75, 35, ryggeFlyplass);

            Runway gammelRunway = new Runway(ryggeFlyplass, 400);
            Runway slitenRunway = new Runway(ryggeFlyplass, 500); ryggeFlyplass.AddRunwayToList(slitenRunway); ryggeFlyplass.AddRunwayToList(gammelRunway); gammelRunway.UseRunway();

            Flight firstFlight = new Flight(cargoCraftV12, new DateTime(2024, 3, 2), 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            Flight coolFlight = new Flight(superPlane, new DateTime(2024, 3, 3), 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            Flight coolFlight2 = new Flight(sickPlane, new DateTime(2024, 3, 4), 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);

            List<Flight> ListOfFlights = new List<Flight>();
            GardemoenFlyplass.GetListGates().Count();

            coolFlight2.SetupDailyFlight(3);
            coolFlight.SetupDailyFlight(3);
            firstFlight.SetupDailyFlight(3);

            ryggeFlyplass.AddToIncommingFlightsQueue(superPlane);
            ryggeFlyplass.AddToIncommingFlightsQueue(sickPlane);



            //Aircraft currentAircraft = ryggeFlyplass.RemoveIncomingFlightsQueue();
            Console.Write($"This plane: \n{ryggeFlyplass.GetIncomingFlightsQueue().Count}\n");

            /*foreach (var runway in ryggeFlyplass.GetRunwayList())
            {
                if (runway.InUse == false)
                {
                    runway.PrintRunwayInformation();
                    runway.UseRunway();
                    Console.Write("\nFlyet lander\n");
                    //runway.SimulateLanding(currentAircraft);
                    runway.RemoveFromQueue();
                }
            }*/
            DateTime start = new DateTime(2024, 3, 2);
            DateTime end = new DateTime(2024, 3, 4);
            Simulation newSim = new Simulation(ryggeFlyplass, start, end);

            
            System.Console.ReadLine();
        }
    }
}