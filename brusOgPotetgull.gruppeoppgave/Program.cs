using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.Simulation;
using BrusOgPotetgull.AirportLiberary.Sim;

namespace BrusOgPotetgull.Gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating Aircraft types
            AircraftType boeing737 = new AircraftType("Boeing 737");
            AircraftType boeing747 = new AircraftType("Boeing 747");
            AircraftType boeing767 = new AircraftType("Boeing 767");
            AircraftType boeing777 = new AircraftType("Boeing 777");
            AircraftType boeing787 = new AircraftType("Boeing 787");

            AircraftType airbusA320 = new AircraftType("Airbus A320");
            AircraftType airbusA330 = new AircraftType("Airbus A330");
            AircraftType airbusA340 = new AircraftType("Airbus A340");
            AircraftType airbusA380 = new AircraftType("Airbus A380");

            // Creating aircrafts with category 
            Aircraft cargoCraft = new Aircraft("cargoCraft", boeing737, 890, 50, 35, 3);
            Aircraft superPlane = new Aircraft("superPlane", boeing737, 800, 70, 40, 5);
            Aircraft sickPlane = new Aircraft("sickPlane", boeing737, 800, 50, 30, 4);
            Aircraft SR71 = new Aircraft("SR71", boeing737, 700, 45, 30, 3);
            Aircraft coolplane = new Aircraft("cool Plane", boeing737, 775, 36, 24, 4);
            Aircraft messiPlane = new Aircraft("Messi Aircraft", boeing737, 750, 30, 18, 5);
            Aircraft RonaldosPlane = new Aircraft("Ronaldo Aircraft", boeing737, 850, 35, 20, 3);
            Aircraft KakaPlane = new Aircraft("Kaka Aircraft", boeing737, 900, 30, 20, 2);
            Aircraft RonaldinhoPlane = new Aircraft("Ronaldinho SambaAircraft", boeing737, 800, 28, 22, 5);
            Aircraft mbappePlane = new Aircraft("Mbappe Aircraft", boeing737, 700, 26, 24, 5);

            // creating the airport
            Airport heathrow = new Airport("LHR", "London Heathrow Airport", "London");

            // creating terminals and adding them to airport
            Terminal terminal2 = new Terminal("Terminal 2");
            heathrow.AddTerminalToList(terminal2);
            Terminal terminal3 = new Terminal("Terminal 3");
            heathrow.AddTerminalToList(terminal3);
            Terminal terminal4 = new Terminal("Terminal 4");
            heathrow.AddTerminalToList(terminal4);
            Terminal terminal5 = new Terminal("Terminal 5");
            heathrow.AddTerminalToList(terminal5);

            // creating runways and adding them to airport
            Runway runway27R_09L = new Runway("27R/09L", 200);
            heathrow.AddRunwayToList(runway27R_09L);
            Runway runway27L_09R = new Runway("27L/09R", 200);
            heathrow.AddRunwayToList(runway27L_09R);

            // creating taxiways and adding them to airport
            Taxiway alpha = new Taxiway("Alpha (A)", 500, 20);
            heathrow.AddTaxiwayToList(alpha);
            Taxiway bravo = new Taxiway("Bravo (B)", 400, 20);
            heathrow.AddTaxiwayToList(bravo);
            Taxiway charlie = new Taxiway("Charlie (C)", 650, 20);
            heathrow.AddTaxiwayToList(charlie);
            Taxiway dimitri = new Taxiway("Dimitri (D)", 650, 20);
            heathrow.AddTaxiwayToList(dimitri);
            Taxiway elf = new Taxiway("Elf (E)", 650, 20);
            heathrow.AddTaxiwayToList(elf);
            Taxiway frodoBaggins = new Taxiway("Frodo Baggins (F)", 650, 20);
            heathrow.AddTaxiwayToList(frodoBaggins);
            Taxiway gandalf = new Taxiway("Gandalf (G)", 650, 20);
            heathrow.AddTaxiwayToList(gandalf);
            Taxiway harryPotter = new Taxiway("Harry Potter (H)", 650, 20);
            heathrow.AddTaxiwayToList(harryPotter);

            // creating gates and adding them to terminals and airport
            terminal2.CreateMultipleGatesToTerminal("A", 1, 26, heathrow);
            terminal3.CreateMultipleGatesToTerminal("B", 22, 42, heathrow);
            terminal4.CreateMultipleGatesToTerminal("C", 50, 66, heathrow);
            terminal5.CreateMultipleGatesToTerminal("A", 1, 23, heathrow);
            terminal5.CreateMultipleGatesToTerminal("B", 32, 48, heathrow);
            terminal5.CreateMultipleGatesToTerminal("C", 52, 66, heathrow);

            // Creating flights.
            
            Flight.Arriving flight1 = new(sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("C53"), elf, runway27L_09R);
            Flight.Arriving flight2 = new(SR71, new DateTime(2024, 3, 1, 00, 02, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), alpha, runway27R_09L);
            Flight.Departing flight3 = new(cargoCraft, new DateTime(2024, 3, 1, 00, 10, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), frodoBaggins, runway27R_09L);
            Flight.Departing flight4 = new(superPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), bravo, runway27R_09L);

            // setup taxiway system
            ConnectionPoint A1 = new ConnectionPoint("A1");
            ConnectionPoint B1 = new ConnectionPoint("B1");
            ConnectionPoint C1 = new ConnectionPoint("C1");
            ConnectionPoint D1 = new ConnectionPoint("D1");
            ConnectionPoint E1 = new ConnectionPoint("E1");
            ConnectionPoint F1 = new ConnectionPoint("F1");
            ConnectionPoint G1 = new ConnectionPoint("G1");
            ConnectionPoint H1 = new ConnectionPoint("H1");
            ConnectionPoint I1 = new ConnectionPoint("I1");

            heathrow.AddConnectionPoint(A1);
            heathrow.AddConnectionPoint(B1);
            heathrow.AddConnectionPoint(C1);
            heathrow.AddConnectionPoint(D1);
            heathrow.AddConnectionPoint(E1);
            heathrow.AddConnectionPoint(F1);
            heathrow.AddConnectionPoint(G1);
            heathrow.AddConnectionPoint(H1);
            heathrow.AddConnectionPoint(I1);

            heathrow.AddTaxiwayConnection(alpha, B1, A1);
            heathrow.AddTaxiwayConnection(bravo, B1, C1);
            heathrow.AddTaxiwayConnection(charlie, D1, B1);
            heathrow.AddTaxiwayConnection(dimitri, E1, D1);
            heathrow.AddTaxiwayConnection(elf, F1, E1);
            heathrow.AddTaxiwayConnection(frodoBaggins, G1, F1, heathrow.GetGateBasedOnGateName("C53"));
            heathrow.AddTaxiwayConnection(gandalf, H1, G1);
            heathrow.AddTaxiwayConnection(harryPotter, H1, G1, heathrow.GetGateBasedOnGateName("A3"));

            heathrow.PrintTaxiwaySystem();

            heathrow.PrintTaxiwayRoute(flight1.taxiwayPath);
            heathrow.PrintTaxiwayRoute(flight2.taxiwayPath);
            heathrow.PrintTaxiwayRoute(flight3.taxiwayPath);
            heathrow.PrintTaxiwayRoute(flight4.taxiwayPath);

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
            Sim heathrowSimulation = new(heathrow, start, end);
            heathrowSimulation.RunSimulation();
            /*
            Simulation heathrowSimulation = new(heathrow, start, end);
            heathrowSimulation.RunSimulation();
            */
            // Printing history for aircrafts on a given day.
            cargoCraft.PrintAircraftHistoryForDay(2024, 3, 1);
            superPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            sickPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            SR71.PrintAircraftHistoryForDay(2024, 3, 1);

            heathrow.PrintAirportInformation();

            superPlane.PrintAircraftInformation();
            //heathrow.PrintTaxiwaySystem();
            System.Console.ReadLine();
        }
    }
}