using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.Simulation;

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
            Terminal terminal2 = new Terminal("Terminal 2", heathrow);
            Terminal terminal3 = new Terminal("Terminal 3", heathrow);
            Terminal terminal4 = new Terminal("Terminal 4", heathrow);
            Terminal terminal5 = new Terminal("Terminal 5", heathrow);

            // creating runways and adding them to airport
            Runway runway27R_09L = new Runway("27R/09L", 200, heathrow);
            Runway runway27L_09R = new Runway("27L/09R", 200, heathrow);

            // creating taxiways and adding them to airport
            Taxiway alpha = new Taxiway("Alpha (A)", 500, 20, heathrow);
            Taxiway bravo = new Taxiway("Bravo (B)", 400, 20, heathrow);
            Taxiway charlie = new Taxiway("Charlie (C)", 650, 20, heathrow);
            Taxiway delta = new Taxiway("delta (D)", 650, 20, heathrow);
            Taxiway echo = new Taxiway("Echo (E)", 650, 20, heathrow);
            Taxiway foxtrot = new Taxiway("Foxtrot (F)", 650, 20, heathrow);
            Taxiway golf = new Taxiway("Golf (G)", 650, 20, heathrow);
            Taxiway hotel = new Taxiway("Hotel (H)", 650, 20, heathrow);

            // creating gates and adding them to terminals and airport
            terminal2.CreateMultipleGatesToTerminal("A", 1, 26, heathrow);
            terminal3.CreateMultipleGatesToTerminal("B", 22, 42, heathrow);
            terminal4.CreateMultipleGatesToTerminal("C", 50, 66, heathrow);
            terminal5.CreateMultipleGatesToTerminal("A", 1, 23, heathrow);
            terminal5.CreateMultipleGatesToTerminal("B", 32, 48, heathrow);
            terminal5.CreateMultipleGatesToTerminal("C", 52, 66, heathrow);

            // Creating flights.
            Flight.Arriving flight1 = new(cargoCraft, new DateTime(2024, 3, 1, 00, 05, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("C53"), echo, runway27L_09R); 
            Flight.Arriving flight2 = new(superPlane, new DateTime(2024, 3, 1, 00, 02, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), alpha, runway27R_09L); // @@@@@@@@@@@@@@@@@@@@@@@@@@@
            Flight.Arriving flight3 = new(sickPlane, new DateTime(2024, 3, 1, 00, 10, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), golf, runway27R_09L);
            Flight.Arriving flight4 = new(SR71, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A4"), alpha, runway27R_09L);
            Flight.Arriving flight5 = new(coolplane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A3"), hotel, runway27R_09L);
            Flight.Departing flight6 = new(messiPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A4"), delta, runway27R_09L);
            Flight.Departing flight7 = new(RonaldosPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("A5"), charlie, runway27R_09L);
            Flight.Departing flight8 = new(KakaPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("B22"), golf, runway27R_09L);
            Flight.Departing flight9 = new(RonaldinhoPlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("B24"), foxtrot, runway27R_09L);
            Flight.Departing flight10 = new(mbappePlane, new DateTime(2024, 3, 1, 00, 15, 00), 5000, heathrow, heathrow.GetGateBasedOnGateName("C54"), bravo, runway27R_09L); //@@@@@@@@@@@@@@@@@@@@@@

            // setup taxiway system
            ConnectionPoint A1 = new ConnectionPoint("A1", heathrow);
            ConnectionPoint B2 = new ConnectionPoint("B2", heathrow);
            ConnectionPoint C3 = new ConnectionPoint("C3", heathrow);
            ConnectionPoint D4 = new ConnectionPoint("D4", heathrow);
            ConnectionPoint E5 = new ConnectionPoint("E5", heathrow);
            ConnectionPoint F6 = new ConnectionPoint("F6", heathrow);
            ConnectionPoint G7 = new ConnectionPoint("G7", heathrow);
            ConnectionPoint H8 = new ConnectionPoint("H8", heathrow);
            ConnectionPoint I9 = new ConnectionPoint("I9", heathrow);

            heathrow.AddTaxiwayConnection(alpha, B2, A1);
            heathrow.AddTaxiwayConnection(bravo, B2, C3);
            heathrow.AddTaxiwayConnection(charlie, D4, B2);

            heathrow.AddTaxiwayConnection(delta, E5, D4);
            heathrow.AddTaxiwayConnection(echo, F6, E5);
            heathrow.AddTaxiwayConnection(foxtrot, G7, F6);

            heathrow.AddTaxiwayConnection(golf, H8, G7);
            heathrow.AddTaxiwayConnection(hotel, H8, G7);

            hotel.AddConnectedGate(heathrow.GetGateBasedOnGateName("A1"));
            hotel.AddConnectedGate(heathrow.GetGateBasedOnGateName("A2"));
            hotel.AddConnectedGate(heathrow.GetGateBasedOnGateName("A3"));
            hotel.AddConnectedGate(heathrow.GetGateBasedOnGateName("A4"));
            hotel.AddConnectedGate(heathrow.GetGateBasedOnGateName("A5"));

            foxtrot.AddConnectedGate(heathrow.GetGateBasedOnGateName("C53"));
            foxtrot.AddConnectedGate(heathrow.GetGateBasedOnGateName("C54"));
            foxtrot.AddConnectedGate(heathrow.GetGateBasedOnGateName("C55"));
            foxtrot.AddConnectedGate(heathrow.GetGateBasedOnGateName("C56"));

            charlie.AddConnectedGate(heathrow.GetGateBasedOnGateName("B22"));
            charlie.AddConnectedGate(heathrow.GetGateBasedOnGateName("B23"));
            charlie.AddConnectedGate(heathrow.GetGateBasedOnGateName("B24"));
            charlie.AddConnectedGate(heathrow.GetGateBasedOnGateName("B25"));
            charlie.AddConnectedGate(heathrow.GetGateBasedOnGateName("B26"));
            charlie.AddConnectedGate(heathrow.GetGateBasedOnGateName("B27"));

            heathrow.PrintTaxiwaySystem();

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
            DateTime end = new(2024, 3, 1, 1, 30, 00);
            Simulation heathrowSimulation = new(heathrow, start, end);
            heathrowSimulation.RunSimulation();

            /*
            Simulation heathrowSimulation = new(heathrow, start, end);
            heathrowSimulation.RunSimulation();
            */
            Console.WriteLine(mbappePlane.GetFullAircraftHistory());

            /*
            // Printing history for aircrafts on a given day.
             cargoCraft.PrintAircraftHistoryForDay(2024, 3, 1);
            superPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            sickPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            SR71.PrintAircraftHistoryForDay(2024, 3, 1);
            coolplane.PrintAircraftHistoryForDay(2024, 3, 1);
            messiPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            RonaldosPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            KakaPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            RonaldinhoPlane.PrintAircraftHistoryForDay(2024, 3, 1);
            mbappePlane.PrintAircraftHistoryForDay(2024, 3, 1);
            
            heathrow.PrintAirportInformation();

            superPlane.PrintAircraftInformation();
            //heathrow.PrintTaxiwaySystem();
            Console.WriteLine(flight7); 
            
             */
            System.Console.ReadLine();
        }
    }
}