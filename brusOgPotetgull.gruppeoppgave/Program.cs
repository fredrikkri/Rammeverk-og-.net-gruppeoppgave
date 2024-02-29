using System;
using System.Runtime.CompilerServices;
using brusOgPotetgull.airportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary.Simulation;

namespace BrusOgPotetgull.Gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating aircrafts.
            Aircraft cargoCraftV12 = new CargoAircraft("C420", 890, 50, 35, 3);
            Aircraft superPlane = new LightAircraft("A130", 800, 70, 40, 5);
            Aircraft sickPlane = new CargoAircraft("C355", 800, 50, 30, 4);
            Aircraft SR71 = new MilitaryAircraft("S137", 700, 45, 30, 3);

            // Creating airports.
            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");
            Airport gardemoenFlyplass = new Airport("OSL", "Gardemoen Flyplass", "Oslo");

            // Creating gates.
            Gate gate1 = new Gate("Gate G1");
            //gardemoenFlyplass.AddGateToList(gate1);
            gardemoenFlyplass.AddGateToList(gate1);
            Gate gate2 = new Gate("Gate G2");
            gardemoenFlyplass.AddGateToList(gate2);
            Gate gate3 = new Gate("Gate R3");
            ryggeFlyplass.AddGateToList(gate3);
            Gate gate4 = new Gate("Gate R4");
            ryggeFlyplass.AddGateToList(gate4);

            // Making sure that all aircrafts are allowed for all gates.
            ryggeFlyplass.MakeAllGatesAllowAllAircraftTypes();
            gardemoenFlyplass.MakeAllGatesAllowAllAircraftTypes();

            // Creating taxiways.
            Taxiway shortTaxiway = new Taxiway(300, 35);
            ryggeFlyplass.AddTaxiwayToList(shortTaxiway);
            Taxiway mediumTaxiway = new Taxiway(750, 20);
            gardemoenFlyplass.AddTaxiwayToList(mediumTaxiway);
            Taxiway longTaxiway = new Taxiway(1000, 35);
            gardemoenFlyplass.AddTaxiwayToList(longTaxiway);

            // Creating runways.
            Runway longRunway1 = new Runway(1000);
            gardemoenFlyplass.AddRunwayToList(longRunway1);
            Runway mediumRunway1 = new Runway(800);
            gardemoenFlyplass.AddRunwayToList(mediumRunway1);
            Runway longRunway2 = new Runway(1000);
            ryggeFlyplass.AddRunwayToList(longRunway2);
            Runway mediumRunway2 = new Runway(800);
            ryggeFlyplass.AddRunwayToList(mediumRunway2);
            
            // Creating flights.
            Flight.Departing flight1 = new Flight.Departing(cargoCraftV12, new DateTime(2024, 3, 1, 00, 10, 00), 5000, gardemoenFlyplass, gate1, longTaxiway, longRunway1);
            Flight.Departing flight2 = new Flight.Departing(superPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, gardemoenFlyplass, gate2, longTaxiway, longRunway1);
            Flight.Arriving flight3 = new Flight.Arriving(sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), 5000, ryggeFlyplass, gate3, shortTaxiway, longRunway2);
            Flight.Arriving flight4 = new Flight.Arriving(SR71, new DateTime(2024, 3, 1, 00, 02, 00), 5000, ryggeFlyplass, gate4, shortTaxiway, longRunway2);

            // Deciding if flights is departuring or arraving for choosen airport.
            gardemoenFlyplass.AddDepartingFlight(flight1);
            gardemoenFlyplass.AddDepartingFlight(flight2);
            gardemoenFlyplass.AddDailyArrivingFlight(2, SR71, new DateTime(2024, 3, 1, 00, 17, 00), 5000, ryggeFlyplass, gate3, shortTaxiway, longRunway2);
            gardemoenFlyplass.AddArrivingFlight(flight3);
            gardemoenFlyplass.AddArrivingFlight(flight4);

            // Creating the simulation
            DateTime start = new DateTime(2024, 3, 1);
            DateTime end = new DateTime(2024, 3, 1, 4, 00, 00);
            Simulation newSim = new Simulation(gardemoenFlyplass, start, end);
            newSim.RunSimulation();

            // Printing history for planes.
            cargoCraftV12.PrintAircraftHistoryForDay(2024, 3, 1);
            sickPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            superPlane.PrintAircraftHistoryForDay(2024, 3, 1);

            //Console.Write("\n\t\tHistory for all aircrafts:\n");

            // Printer ut historie for arriving-flights
            //sickPlane.PrintFullAircraftHistory();      // C355
            //SR71.PrintFullAircraftHistory();           // S137

            // Printer ut historie for departuring-flights
            //cargoCraftV12.PrintFullAircraftHistory();  // C420
            //superPlane.PrintFullAircraftHistory();     // A130

            gate2.AddAircraftAllowedAtGate(AircraftType.Cargo);
            gate2.AddAircraftAllowedAtGate(AircraftType.Military);
            gate3.AddAircraftAllowedAtGate(AircraftType.Undefined);

            gate2.MakeAllAircraftTypesAllowedForThisGate();
            gate2.PrintGateInformation();
            gate3.PrintGateInformation();
            longRunway1.PrintRunwayInformation();
            longTaxiway.PrintTaxiwayInformation();

            gardemoenFlyplass.PrintListOfDeparturingFlights();

            gardemoenFlyplass.PrintAirportInformation();
          
            System.Console.ReadLine();
        }
    }
}