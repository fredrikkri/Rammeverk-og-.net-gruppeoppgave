using System;
using System.Runtime.CompilerServices;
using brusOgPotetgull.airportLiberary.AircraftTypes;
using brusOgPotetgull.airportLiberary.CustomExceptions;
using brusOgPotetgull.airportLiberary.EventHandler;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary.Simulation;

namespace BrusOgPotetgull.Gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Creating aircrafts with category 
            Aircraft cargoCraftV12 = new CargoAircraft("C420", 890, 50, 35, 3);
            Aircraft superPlane = new LightAircraft("A130", 800, 70, 40, 5);
            Aircraft sickPlane = new CargoAircraft("C355", 800, 50, 30, 4);
            Aircraft SR71 = new MilitaryAircraft("S137", 700, 45, 30, 3);

            // Creating aircraft without category
            Aircraft norwegianHeyerdahl = new Aircraft("Boeing-737-900", 943, 60, 50, 100);


            // Creating airports.
            Airport ryggeFlyplass = new Airport("RYG", "Rygge Flyplass", "Rygge");





            Airport gardemoenFlyplass = new Airport("OSL", "Gardemoen Flyplass", "Oslo");

            // Creating gates.
            Gate gate1 = new ("Gate G1");
            //gardemoenFlyplass.AddGateToList(gate1);
            gardemoenFlyplass.AddGateToList(gate1);
            Gate gate2 = new ("Gate G2");
            gardemoenFlyplass.AddGateToList(gate2);
            Gate gate3 = new ("Gate R3");
            ryggeFlyplass.AddGateToList(gate3);
            Gate gate4 = new ("Gate R4");
            ryggeFlyplass.AddGateToList(gate4);

            // Making sure that all aircrafts are allowed for all gates.
            //ryggeFlyplass.MakeAllGatesAllowAllAircraftTypes();
            //gardemoenFlyplass.MakeAllGatesAllowAllAircraftTypes();

            // Make gates allow aircraft types
            try
            {
                gate1.AddAircraftAllowedAtGate(AircraftType.Cargo);
                gate2.AddAircraftAllowedAtGate(AircraftType.Light);
                gate2.AddAircraftAllowedAtGate(AircraftType.Military);
            }
            catch (DuplicateOfContentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            // Creating taxiways.
            Taxiway shortTaxiway = new (300, 35);
            ryggeFlyplass.AddTaxiwayToList(shortTaxiway);
            Taxiway mediumTaxiway = new (750, 20);
            gardemoenFlyplass.AddTaxiwayToList(mediumTaxiway);
            Taxiway longTaxiway = new (1000, 35);
            gardemoenFlyplass.AddTaxiwayToList(longTaxiway);

            // Creating runways.
            Runway longRunway1 = new (1000);
            gardemoenFlyplass.AddRunwayToList(longRunway1);
            Runway mediumRunway1 = new (800);
            gardemoenFlyplass.AddRunwayToList(mediumRunway1);
            Runway longRunway2 = new (1000);
            ryggeFlyplass.AddRunwayToList(longRunway2);
            Runway mediumRunway2 = new (800);
            ryggeFlyplass.AddRunwayToList(mediumRunway2);
            
            // Creating flights.
            Flight.Departing flight1 = new (cargoCraftV12, new DateTime(2024, 3, 1, 00, 10, 00), 5000, gardemoenFlyplass, gate1, longTaxiway, longRunway1);
            Flight.Departing flight2 = new (superPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, gardemoenFlyplass, gate2, longTaxiway, longRunway1);
            Flight.Arriving flight3 = new (sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), 5000, gardemoenFlyplass, gate1, mediumTaxiway, mediumRunway1);
            Flight.Arriving flight4 = new (SR71, new DateTime(2024, 3, 1, 00, 02, 00), 5000, gardemoenFlyplass, gate2, longTaxiway, mediumRunway1);
            
            // Creating a daily arriving flight
            gardemoenFlyplass.AddDailyArrivingFlight(2, SR71, new DateTime(2024, 3, 1, 00, 17, 00), 5000, gardemoenFlyplass, gate1, longTaxiway, longRunway1);            

            // Creating the simulation
            DateTime start = new (2024, 3, 1);
            DateTime end = new (2024, 3, 1, 4, 00, 00);
            Simulation newSim = new (gardemoenFlyplass, start, end);

            // Events setup
            AirportMonitor airportMonitor = new();
            airportMonitor.subcribeRunwayEvents(longRunway1);
            airportMonitor.subcribeRunwayEvents(mediumRunway1);

            newSim.RunSimulation();

            // Printing history for aircrafts on a given day.
            cargoCraftV12.PrintAircraftHistoryForDay(2024, 3, 1);
            superPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            sickPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            SR71.PrintAircraftHistoryForDay(2024, 3, 1);

            // Prints whole history for all aircrafts

            /* Console.Write("\n\t\tHistory for all aircrafts:\n");
            cargoCraftV12.PrintFullAircraftHistory();  // C420
            superPlane.PrintFullAircraftHistory();     // A130
            sickPlane.PrintFullAircraftHistory();      // C355
            SR71.PrintFullAircraftHistory();           // S137 */
            

            //gate2.MakeAllAircraftTypesAllowedForThisGate();
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