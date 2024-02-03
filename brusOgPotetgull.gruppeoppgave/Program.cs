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

<<<<<<< HEAD
            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass); supergate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId); supergate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);
            Gate nissegate = new Gate("Gate 22", ryggeFlyplass); nissegate.AddAircraftAllowedAtGate(cargoCraftV12.AircraftTypeId); nissegate.AddAircraftAllowedAtGate(superPlane.AircraftTypeId);
=======
            Gate supergate = new Gate("Gate 1A", GardemoenFlyplass);
            Gate nissegate = new Gate("Gate 22", ryggeFlyplass); 
            Gate hallaGate = new Gate("Gate 90", ryggeFlyplass);
            Gate YOYOGate = new Gate("Gate 2A", GardemoenFlyplass); 

>>>>>>> main

            Taxiway mediumTaxiway = new Taxiway(535, 20, GardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(75, 35, ryggeFlyplass);

            Runway gammelRunway = new Runway(ryggeFlyplass, 400);
            Runway slitenRunway = new Runway(ryggeFlyplass, 500); ryggeFlyplass.AddRunwayToList(slitenRunway); ryggeFlyplass.AddRunwayToList(gammelRunway);
            gammelRunway.UseRunway();

            Flight firstFlight = new Flight(cargoCraftV12, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            Flight coolFlight = new Flight(superPlane, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);
            Flight coolFlight2 = new Flight(sickPlane, 5000, GardemoenFlyplass, ryggeFlyplass, supergate, nissegate, mediumTaxiway, longTaxiway, gammelRunway, slitenRunway);

<<<<<<< HEAD
            ryggeFlyplass.AddFlightToList(firstFlight);
=======

>>>>>>> fredrik_b_2
            //coolFlight.SetupFlight(DateTime.Now);

<<<<<<< HEAD

            //coolFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //coolFlight2.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //firstFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);

=======
            List<Flight> ListOfFlights = new List<Flight>();
            GardemoenFlyplass.GetListGates().Count();

<<<<<<< HEAD
   
            coolFlight2.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            coolFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            firstFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
>>>>>>> fredrik_b_2
=======

            //coolFlight2.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //coolFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //firstFlight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
>>>>>>> main
            //cargoCraftV12.PrintFullAircraftHistory();
            //cargoCraftV12.PrintAircraftHistoryForDay(2024,2,1);

            //Parallel.ForEach(ListOfFlights, flight =>
            //{
            //  flight.SetupDailyFlight(DateTime.Now.AddDays(0), 3);
            //});

            //superPlane.PrintFullAircraftHistory();

<<<<<<< HEAD
            //cargoCraftV12.checkPreviousLocation();
=======
            ///cargoCraftV12.CheckPreviousLocation();
            ///
>>>>>>> main

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