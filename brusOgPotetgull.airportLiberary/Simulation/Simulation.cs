 using System;
using brusOgPotetgull.airportLiberary;

namespace brusOgPotetgull.airportLiberary.Simulation
{
	public class Simulation
	{
        public Simulation(Airport airport, DateTime startTime, DateTime endTime)
        {
            this.Airport = airport;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public Airport Airport { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public void RunSimulation()
        {

            DateTime start = StartTime;
            DateTime end = EndTime;

            while (start <= end)
            {
                Console.Write($"\n\t\t\t\t\t\tSimulation time: {start}\n");

                // Hvis det finnnes innkommende flygninger
                if (Airport.GetArrivingFlights().Count > 0)
                {
                    // Går igjennom alle flygninger, og legger til denne dersom tiden for flygningen er denne iterasjonen (datetime.start + simulasjonstid)
                    foreach (Flight flight in Airport.GetArrivingFlights())
                    {
                        if (flight.DateTimeFlight == start)
                        {
                            //starter handlinger for flygning  ( når tiden for flygningen er inne )
                            flight.ArrivalRunway.AddFlightToQueue(flight); //  ----------------------------------------------------------------------------  step 1 arriving
                            // trenger ikke køsystem på loggede flygninger, kun tidspunkt. Har allerede køsystem i runway og taxiway.
                        }
                    }
                }

                // Sjekker alle runways
                foreach (Runway currentRunway in Airport.GetRunwayList())
                {
                    //Hvis det er fly i runway køen, og runway er ledig
                    if (currentRunway.RunwayQueue.Count > 0 && currentRunway.InUse == false)
                    {
                        //utfør landing
                        Flight nextFlight = currentRunway.CheckNextFlightInQueue(); //  -------------------------------------------------------------------- step 2 arrving
                        currentRunway.NextFlightEntersRunway(nextFlight);
                        currentRunway.UseRunway(nextFlight, start);
                        currentRunway.ExitRunway(nextFlight, start);

                        // simulerer tid og legge fly i taxiway kø
                        nextFlight.ArrivalTaxiway.SimulateTaxiwayTime(nextFlight, 20, nextFlight.ActiveAircraft.AccelerationOnGround, nextFlight.ActiveAircraft.MaxSpeedOnGround, start);
                        nextFlight.ArrivalTaxiway.AddFlightToQueue(nextFlight, start);
                    }
                }

                // For hver taxiway på flyplassen
                foreach (Taxiway taxiway in Airport.GetListTaxiways())
                {
                    // Neste fly i taxiway køen
                    if (taxiway.GetNumberOfAircraftsInQueue() > 0)
                    {
                        Flight flight = taxiway.CheckNextFlightInQueue(); 

                        // Dersom flygning er arriving flight
                        if (flight.IsArrivingFlight == true)
                        {
                            flight.ArrivalTaxiway.NextFlightLeavesTaxiway(flight, start);  // ------------------------------------------------------------------ step 3 arrving
                            flight.ArrivalGate.BookGate(flight.ActiveAircraft, start);

                            Airport.RemoveArrivingFlight(flight);
                        }
                    }
                }

                // Eller Hvis det finnes utgående flygninger
                if (Airport.GetDepartingFlights().Count > 0)
                {
                    // Går igjennom lista med utgående flygninger
                    foreach (Flight flight in Airport.GetDepartingFlights())
                    {
                        // Hvis tiden for flygningen er lik nåværende tid i simulasjonen
                        if (flight.DateTimeFlight == start)
                        {
                            flight.DepartureGate.LeaveGate(flight.ActiveAircraft, start); // ----------------------------------------------------------- step 1 Departing
                            flight.DepartureTaxiway.SimulateTaxiwayTime(flight, 0, flight.ActiveAircraft.AccelerationOnGround, flight.ActiveAircraft.MaxSpeedOnGround, start);
                            flight.DepartureTaxiway.AddFlightToQueue(flight, start);
                        }
                    }
                }

                //For hver taxiway på flyplassen
                foreach (Taxiway taxiway in Airport.GetListTaxiways())
                {
                    if (taxiway.GetNumberOfAircraftsInQueue() > 0)
                    {
                        Flight currentFlight = taxiway.CheckNextFlightInQueue();
                        if (currentFlight.IsArrivingFlight == false) 
                        {
                            if (currentFlight != null && currentFlight.DepartureRunway.InUse == false)
                            {
                                currentFlight.DepartureTaxiway.NextFlightLeavesTaxiway(currentFlight, start); // ------------------------------------------ Departuring step 2
                                currentFlight.DepartureRunway.UseRunway(currentFlight, start);
                                currentFlight.DepartureRunway.SimulateRunwayTime(currentFlight, 0, currentFlight.ActiveAircraft.AccelerationInAir, currentFlight.ActiveAircraft.MaxSpeedInAir);
                                currentFlight.DepartureRunway.ExitRunway(currentFlight, start); // kunne tatt start + addsecounds for å få til bedre logging, men må ha med tid fra taxiway da
                            }
                        }
                    }
                }                

                Thread.Sleep(1);
                start = start.AddMinutes(1);
            }
        }
	}
}