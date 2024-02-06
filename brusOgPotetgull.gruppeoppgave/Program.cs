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
            Aircraft cargoCraftV12 = new CargoAircraft("C420", 890, 50, 35, 3);
            Aircraft superPlane = new LightAircraft("A130", 800, 70, 40, 5);
            Aircraft sickPlane = new CargoAircraft("C355", 800, 50, 30, 4);
            Aircraft SR71 = new MilitaryAircraft("S137", 700, 45, 30, 3);

            List<Aircraft> aircraftTypes = new List<Aircraft> {cargoCraftV12, superPlane, SR71};

            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport gardemoenFlyplass = new Airport("OSL", "Gardemoen Flyplass", "Oslo");

            Gate gate1 = new Gate("Gate G1", gardemoenFlyplass);
            Gate gate2 = new Gate("Gate G2", gardemoenFlyplass);
            Gate gate3 = new Gate("Gate R3", ryggeFlyplass);
            Gate gate4 = new Gate("Gate R4", ryggeFlyplass);

            // burde lage funksjonalitet for dette. At man kan legge til flere godkjente aircrafttypeid som får lov til å benytte gates,
            // og evt runways og taxiways
            foreach (var gate in ryggeFlyplass.GetListGates())
            {
                foreach (Aircraft aircraft in aircraftTypes)
                {
                    gate.AddAircraftAllowedAtGate(aircraft.AircraftTypeId);
                }
            }
            foreach (var gate in gardemoenFlyplass.GetListGates())
            {
                foreach(Aircraft aircraft in aircraftTypes)
                {
                    gate.AddAircraftAllowedAtGate(aircraft.AircraftTypeId);
                }
            }

            Taxiway shortTaxiway = new Taxiway(300, 35, ryggeFlyplass);
            Taxiway mediumTaxiway = new Taxiway(750, 20, gardemoenFlyplass);
            Taxiway longTaxiway = new Taxiway(1000, 35, gardemoenFlyplass);

            Runway longRunway1 = new Runway(gardemoenFlyplass, 1000); gardemoenFlyplass.AddRunwayToList(longRunway1);
            Runway mediumRunway1 = new Runway(gardemoenFlyplass, 800); gardemoenFlyplass.AddRunwayToList(mediumRunway1);
            Runway longRunway2 = new Runway(ryggeFlyplass, 1000); ryggeFlyplass.AddRunwayToList(longRunway2);
            Runway mediumRunway2 = new Runway(ryggeFlyplass, 800); ryggeFlyplass.AddRunwayToList(mediumRunway2);

            // Lagt til parameteret bool isArrivingFlight
            Flight flight1 = new Flight(cargoCraftV12, new DateTime(2024, 3, 1, 00, 10, 00), false, 5000, gardemoenFlyplass, ryggeFlyplass, gate1, gate3, longTaxiway, shortTaxiway, longRunway1, mediumRunway2);
            Flight flight2 = new Flight(superPlane, new DateTime(2024, 3, 1, 00, 15, 00), false, 5000, gardemoenFlyplass, ryggeFlyplass, gate2, gate4, longTaxiway, shortTaxiway, longRunway1, mediumRunway2);
            Flight flight3 = new Flight(sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), true, 5000, ryggeFlyplass, gardemoenFlyplass, gate3, gate1, shortTaxiway, mediumTaxiway, longRunway2, mediumRunway1);
            Flight flight4 = new Flight(SR71, new DateTime(2024, 3, 1, 00, 02, 00), true, 5000, ryggeFlyplass, gardemoenFlyplass, gate4, gate2, shortTaxiway, mediumTaxiway, longRunway2, mediumRunway1);


            // TODO: Må ordne opp i setupFlight
            /*flight3.SetupDailyFlight(3);
            flight2.SetupDailyFlight(3);
            flight1.SetupDailyFlight(3);*/

            gardemoenFlyplass.AddDepartingFlight(flight1);
            gardemoenFlyplass.AddDepartingFlight(flight2);
            gardemoenFlyplass.AddArrivingFlight(flight3);
            gardemoenFlyplass.AddArrivingFlight(flight4);

            DateTime start = new DateTime(2024, 3, 1);
            DateTime end = new DateTime(2024, 3, 1, 1,00,00);
            Simulation newSim = new Simulation(gardemoenFlyplass, start, end);

            Console.Write("\nHistory of aircrafts:\n");

            // Arriving
            sickPlane.PrintFullAircraftHistory();      // C355
            SR71.PrintFullAircraftHistory();           // S137

            // departuring
            cargoCraftV12.PrintFullAircraftHistory();  // C420
            superPlane.PrintFullAircraftHistory();     // A130



            System.Console.ReadLine();
        }
    }
}