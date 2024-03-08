using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary.CustomExceptions;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.AirportComponents.Runway;
using BrusOgPotetgull.AirportLiberary.Simulation;
using BrusOgPotetgull.AirportLiberary.AirportComponents;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            // creating the airport
            Airport heathrow = new Airport("LHR", "London Heathrow Airport", "London");

            // creating terminals and adding them to airport
            Terminal terminal2 = new Terminal("terminal2");
            heathrow.AddTerminalToList(terminal2);
            Terminal terminal3 = new Terminal("terminal3");
            heathrow.AddTerminalToList(terminal3);
            Terminal terminal4 = new Terminal("terminal4");
            heathrow.AddTerminalToList(terminal4);
            Terminal terminal5 = new Terminal("terminal5");
            heathrow.AddTerminalToList(terminal5);

            // creating runways and adding them to airport
            Runway runway27R_09L = new Runway("27R/09L", 200);
            heathrow.AddRunwayToList(runway27R_09L);
            Runway runway27L_09R = new Runway("27L/09R", 200);
            heathrow.AddRunwayToList(runway27L_09R);

            // creatting taxiways and adding them to airport
            Taxiway alpha = new Taxiway("Alpha (A)", 500, 20);
            heathrow.AddTaxiwayToList(alpha);
            Taxiway bravo = new Taxiway("Bravo (B)", 400, 20);
            heathrow.AddTaxiwayToList(bravo);
            Taxiway charlie = new Taxiway("Charlie (C)", 650, 20);
            heathrow.AddTaxiwayToList(charlie);

            // creating gates and adding them to terminals and airport
            Gate gate21 = new Gate("Gate 21");
            terminal2.AddGatesToList(gate21);
            heathrow.AddGateToList(gate21);
            Gate gate22 = new Gate("Gate 22");
            terminal2.AddGatesToList(gate22);
            heathrow.AddGateToList(gate22);
            Gate gate23 = new Gate("Gate 23");
            terminal2.AddGatesToList(gate23);
            heathrow.AddGateToList(gate23);
            Gate gate24 = new Gate("Gate 24");
            terminal2.AddGatesToList(gate24);
            heathrow.AddGateToList(gate24);

            Gate gate31 = new Gate("Gate 31");
            terminal3.AddGatesToList(gate31);
            heathrow.AddGateToList(gate31);
            Gate gate32 = new Gate("Gate 32");
            terminal3.AddGatesToList(gate32);
            heathrow.AddGateToList(gate32);
            Gate gate33 = new Gate("Gate 33");
            terminal3.AddGatesToList(gate33);
            heathrow.AddGateToList(gate33);
            Gate gate34 = new Gate("Gate 34");
            terminal3.AddGatesToList(gate34);
            heathrow.AddGateToList(gate34);

            Gate gate41 = new Gate("Gate 41");
            terminal4.AddGatesToList(gate41);
            heathrow.AddGateToList(gate41);
            Gate gate42 = new Gate("Gate 42");
            terminal4.AddGatesToList(gate42);
            heathrow.AddGateToList(gate42);
            Gate gate43 = new Gate("Gate 43");
            terminal4.AddGatesToList(gate43);
            heathrow.AddGateToList(gate43);
            Gate gate44 = new Gate("Gate 44");
            terminal4.AddGatesToList(gate44);
            heathrow.AddGateToList(gate44);

            Gate gate51 = new Gate("Gate 51");
            terminal5.AddGatesToList(gate51);
            heathrow.AddGateToList(gate51);
            Gate gate52 = new Gate("Gate 52");
            terminal5.AddGatesToList(gate52);
            heathrow.AddGateToList(gate52);
            Gate gate53 = new Gate("Gate 53");
            terminal5.AddGatesToList(gate53);
            heathrow.AddGateToList(gate53);
            Gate gate54 = new Gate("Gate 54");
            terminal5.AddGatesToList(gate54);
            heathrow.AddGateToList(gate54);

            // Making sure that all aircrafts are allowed for all gates.
            heathrow.MakeAllGatesAllowAllAircraftTypes();

            // Creating flights.
            Flight.Departing flight1 = new(cargoCraftV12, new DateTime(2024, 3, 1, 00, 10, 00), 5000, heathrow, gate21, alpha, runway27R_09L);
            Flight.Departing flight2 = new(superPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, gate34, bravo, runway27R_09L);
            Flight.Arriving flight3 = new(sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), 5000, heathrow, gate43, alpha, runway27L_09R);
            Flight.Arriving flight4 = new(SR71, new DateTime(2024, 3, 1, 00, 02, 00), 5000, heathrow, gate41, alpha, runway27R_09L);

            // Events setup
            static void OnFlightArrived(object? sender, ArrivingEventArgs e)
            {
                e.Flight.ActiveAircraft.AddHistoryToAircraft(e.Time, e.Flight.ArrivalRunway.GetAirportNameAndRunwayId(), ", Enters the runway");
                Console.WriteLine("Arrival: " + e.Message);
            }

            static void OnFlightDeparted(object? sender, DepartingEventArgs e)
            {
                e.Flight.ActiveAircraft.AddHistoryToAircraft(e.Time, e.Flight.DepartureRunway.GetAirportNameAndRunwayId(), ", Leaves the runway");
                Console.WriteLine("Departure: " + e.Message);
            }

            runway27R_09L.FlightArrived += OnFlightArrived;
            runway27L_09R.FlightArrived += OnFlightArrived;
            runway27R_09L.FlightDeparted += OnFlightDeparted;
            runway27L_09R.FlightDeparted += OnFlightDeparted;

            // simulation
            DateTime start = new(2024, 3, 1);
            DateTime end = new(2024, 3, 1, 4, 00, 00);
            Simulation heathrowSimulation = new(heathrow, start, end);
            heathrowSimulation.RunSimulation();

            // Printing history for aircrafts on a given day.
            cargoCraftV12.PrintAircraftHistoryForDay(2024, 3, 1);
            superPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            sickPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            SR71.PrintAircraftHistoryForDay(2024, 3, 1);

            System.Console.ReadLine();
        }
    }
}