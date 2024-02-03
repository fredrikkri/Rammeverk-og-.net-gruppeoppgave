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
            Aircraft cargoCraftV12 = new CargoAircraft("Cargo plane v12", 890, 50, 40, 5);
            Aircraft superPlane = new LightAircraft("Cristiano Ronaldo´s Plane, siuuuuu!", 800, 56, 20, 3);
            Aircraft sickPlane = new CargoAircraft("Franceco Totti´s Plane.", 800, 56, 20, 3);

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport GardemoenFlyplass = new Airport("GAR", "Gardemoen Flyplass", "Oslo");

            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass);
            Gate nissegate = new Gate("Gate 22", ryggeFlyplass); 
            Gate hallaGate = new Gate("Gate 90", ryggeFlyplass);
            Gate YOYOGate = new Gate("Gate 2A", GardemoenFlyplass); 


            Taxiway mediumTaxiway = new Taxiway(535, 20, GardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(75, 35, ryggeFlyplass);

            Runway gammelRunway = new Runway(ryggeFlyplass, 400);
            Runway slitenRunway = new Runway(ryggeFlyplass, 500); ryggeFlyplass.AddRunwayToList(slitenRunway); ryggeFlyplass.AddRunwayToList(gammelRunway);
            gammelRunway.UseRunway();

            Flight firstFlight = new Flight(cargoCraftV12, 5000, GardemoenFlyplass, ryggeFlyplass, YOYOGate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            Flight coolFlight = new Flight(superPlane, 5000, ryggeFlyplass, GardemoenFlyplass, nissegate, supergate, longTaxiway, mediumTaxiway, slitenRunway, gammelRunway);
            Flight coolFlight2 = new Flight(sickPlane, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, hallaGate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);


            //coolFlight.SetupFlight(DateTime.Now);
            //coolFlight2.SetupFlight(DateTime.Now);
            //firstFlight.SetupFlight(DateTime.Now);

            List<Flight> ListOfFlights = new List<Flight>();
            GardemoenFlyplass.GetListGates().Count();


            //coolFlight2.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //coolFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //firstFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //cargoCraftV12.PrintFullAircraftHistory();
            //cargoCraftV12.PrintAircraftHistoryForDay(2024,2,1);

            //Parallel.ForEach(ListOfFlights, flight =>
            //{
            //  flight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //});

            //superPlane.PrintFullAircraftHistory();

            ///cargoCraftV12.CheckPreviousLocation();
            ///

            ryggeFlyplass.AddToInncommingAircraftsQueue(superPlane);
            ryggeFlyplass.AddToInncommingAircraftsQueue(sickPlane);



            //Aircraft currentAircraft = ryggeFlyplass.RemoveInncommingAircraftsQueue();
            Console.Write($"This plane: \n{ryggeFlyplass.GetInncommingAircraftsQueue().Count}\n");

            foreach (var runway in ryggeFlyplass.GetRunwayList())
            {
                if (runway.InUse == false)
                {
                    runway.PrintRunwayInformation();
                    runway.UseRunway();
                    Console.Write("\nFlyet lander\n");
                    //runway.SimulateLanding(currentAircraft);
                    runway.RemoveFromQueue();
                }
            }

            //Simulation newSim = new Simulation(ryggeFlyplass, 2024, 2, 3, 14, 3);

            
            System.Console.ReadLine();
        }
    }
}