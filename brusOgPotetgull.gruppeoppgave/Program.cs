using System;
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
            Gate gate2 = new Gate("Gate G2");
            Gate gate3 = new Gate("Gate R3");
            Gate gate4 = new Gate("Gate R4");

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
            Flight flight1 = new Flight(cargoCraftV12, new DateTime(2024, 3, 1, 00, 10, 00), false, 5000, gardemoenFlyplass, ryggeFlyplass, gate1, gate3, longTaxiway, shortTaxiway, longRunway1, mediumRunway2);
            Flight flight2 = new Flight(superPlane, new DateTime(2024, 3, 1, 00, 15, 00), false, 5000, gardemoenFlyplass, ryggeFlyplass, gate2, gate4, longTaxiway, shortTaxiway, longRunway1, mediumRunway2);
            Flight flight3 = new Flight(sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), true, 5000, ryggeFlyplass, gardemoenFlyplass, gate3, gate1, shortTaxiway, mediumTaxiway, longRunway2, mediumRunway1);
            Flight flight4 = new Flight(SR71, new DateTime(2024, 3, 1, 00, 02, 00), true, 5000, ryggeFlyplass, gardemoenFlyplass, gate4, gate2, shortTaxiway, mediumTaxiway, longRunway2, mediumRunway1);

            // Deciding if flights is departuring or arraving for choosen airport.
            gardemoenFlyplass.AddDepartingFlight(flight1);
            gardemoenFlyplass.AddDepartingFlight(flight2);
            gardemoenFlyplass.AddDailyArrivingFlight(2, SR71, new DateTime(2024, 3, 1, 00, 17, 00), false, 5000, ryggeFlyplass, gardemoenFlyplass, gate3, gate1, shortTaxiway, mediumTaxiway, longRunway2, mediumRunway1);
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

            gate2.AddAircraftAllowedAtGate(brusOgPotetgull.airportLiberary.AircraftTypes.ChooseAircraftType.CargoAircraft);
            gate2.AddAircraftAllowedAtGate(brusOgPotetgull.airportLiberary.AircraftTypes.ChooseAircraftType.MilitaryAircraft);

            gate3.AddAircraftAllowedAtGate(brusOgPotetgull.airportLiberary.AircraftTypes.ChooseAircraftType.Aircraft);

            gate2.MakeAllAircraftTypesAllowedForThisGate();
            gate2.PrintGateInformation();
            gate3.PrintGateInformation();

            gate2.PrintGateInformation();
            System.Console.ReadLine();
        }
    }
}