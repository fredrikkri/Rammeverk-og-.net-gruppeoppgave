using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.AirportComponents.Runway;
using BrusOgPotetgull.AirportLiberary.Simulation;

namespace BrusOgPotetgull.Gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating aircrafts with category 
            Aircraft cargoCraftV12 = new LongMediumAircraft("C420", 890, 50, 35, 3);
            Aircraft superPlane = new ShortMediumAircraft("A130", 800, 70, 40, 5);
            Aircraft sickPlane = new LongMediumAircraft("C355", 800, 50, 30, 4);
            Aircraft SR71 = new LongMediumAircraft("S137", 700, 45, 30, 3);
            Aircraft boeing737 = new ShortMediumAircraft("Boeing 737", 775, 36, 24, 4);
            Aircraft boeing747 = new ShortMediumAircraft("Boeing 747", 750, 30, 18, 5);
            Aircraft boeing767 = new LargeAircraft("Boeing 767", 850, 35, 20, 3);
            Aircraft airbusA380 = new LargeAircraft("Airbus A380", 900, 30, 20, 2);
            Aircraft airbusA340 = new LongMediumAircraft("Airbus A340", 800, 28, 22, 5);
            Aircraft airbusA320 = new ShortMediumAircraft("Airbus A320", 700, 26, 24, 5);

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
            terminal2.CreateMultipleGatesToTerminal("A", 1, 26, heathrow);
            terminal3.CreateMultipleGatesToTerminal("B", 22, 42, heathrow);
            terminal4.CreateMultipleGatesToTerminal("C", 50, 66, heathrow);
            terminal5.CreateMultipleGatesToTerminal("A", 1, 23, heathrow);
            terminal5.CreateMultipleGatesToTerminal("B", 32, 48, heathrow);
            terminal5.CreateMultipleGatesToTerminal("C", 52, 66, heathrow);

            // Making sure that aircrafts are allowed at gates.
            terminal2.AddAircraftAllowedAtGatesAtTerminal(AircraftType.Large);
            terminal2.AddAircraftAllowedAtGatesAtTerminal(AircraftType.LongMedium);
            terminal2.AddAircraftAllowedAtGatesAtTerminal(AircraftType.ShortMedium);

            terminal3.AddAircraftAllowedAtGatesAtTerminal(AircraftType.LongMedium);
            terminal3.AddAircraftAllowedAtGatesAtTerminal(AircraftType.ShortMedium);

            terminal4.AddAircraftAllowedAtGatesAtTerminal(AircraftType.Large);
            terminal4.AddAircraftAllowedAtGatesAtTerminal(AircraftType.LongMedium);

            terminal5.AddAircraftAllowedAtGatesAtTerminal(AircraftType.Large);
            terminal5.AddAircraftAllowedAtGatesAtTerminal(AircraftType.LongMedium);
            terminal5.AddAircraftAllowedAtGatesAtTerminal(AircraftType.ShortMedium);
            terminal5.AddAircraftAllowedAtGatesAtTerminal(AircraftType.Cargo);

            // Creating flights.
            Flight.Departing flight1 = new(cargoCraftV12, new DateTime(2024, 3, 1, 00, 10, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A1"), alpha, runway27R_09L);
            Flight.Departing flight2 = new(superPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("B25"), bravo, runway27R_09L);
            Flight.Arriving flight3 = new(sickPlane, new DateTime(2024, 3, 1, 00, 05, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("C53"), alpha, runway27L_09R);
            Flight.Arriving flight4 = new(SR71, new DateTime(2024, 3, 1, 00, 02, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), alpha, runway27R_09L);

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

            heathrow.PrintAirportInformation();

            System.Console.ReadLine();
        }
    }
}