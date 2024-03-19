using BrusOgPotetgull.AirportLiberary.CustomExceptions;
using BrusOgPotetgull.AirportLiberary;

namespace BrusOgPotetgull.AirportLiberary.Simulation
{
    /// <summary>
    /// A simulation that is used to simulate how an airport works.
    /// </summary>
	public class Simulation
	{
        /// <summary>
        /// Creates an simulation of the choosen airport.
        /// </summary>
        /// <param name="airport">Which airport that is using the simulation.</param>
        /// <param name="startTime">The day that is the start of the simulation.</param>
        /// <param name="endTime">The day that is the end of the simulation.</param>
        public Simulation(Airport airport, DateTime startTime, DateTime endTime)
        {
            this.Airport = airport;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public Airport Airport { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// This method is starting the simulation.
        /// </summary>
        public void RunSimulation()
        {
            DateTime start = StartTime;
            DateTime end = EndTime;

            while (start <= end)
            {
                // Hvis det finnnes innkommende flygninger
                if (Airport.GetArrivingFlights().Count > 0)
                {
                    // Går igjennom alle flygninger, og legger til denne dersom tiden for flygningen er denne iterasjonen (datetime.start + simulasjonstid)
                    foreach (Flight.Arriving flight in Airport.GetArrivingFlights())
                    {
                        if (flight.DateTimeFlight == start)
                        {
                            // Genererer en taxiway-rute for current arriving flight
                            flight.taxiwayPath = Airport.GenerateArrivingFlightTaxiwayPath(flight);

                            //starter handlinger for flygning  ( når tiden for flygningen er inne )
                            flight.ArrivalRunway.AddFlightToQueue(flight); //  ----------------------------------------------------------------------------  step 1 arriving
                        }
                    }
                }
                // Hvis det finnes utgående flygninger
                if (Airport.GetDepartingFlights().Count > 0)
                {
                    // Går igjennom lista med utgående flygninger
                    foreach (Flight.Departing flight in Airport.GetDepartingFlights())
                    {
                        // Hvis tiden for flygningen er lik nåværende tid i simulasjonen
                        if (flight.DateTimeFlight == start)
                        {
                            // Genererer en taxiway-rute for current departuring flight
                            flight.taxiwayPath = Airport.GenerateDeparturingFlightTaxiwayPath(flight);

                            //starter handlinger for flygning  ( når tiden for flygningen er inne )
                            flight.DepartureGate.LeaveGate(flight.ActiveAircraft, start); // ----------------------------------------------------------- step 1 Departing
                        }
                    }
                }

                // Sjekker alle runways
                foreach (Runway currentRunway in Airport.GetRunwayList())
                {
                    //Hvis det er fly i runway køen, og runway er ledig
                    if (currentRunway.RunwayQueue.Count > 0 && currentRunway.InUse == false)
                    {
                        if (currentRunway.CheckNextFlightInQueue().IsArrivingFlight == true)
                        {
                            //utfør landing
                            Flight.Arriving nextFlight = (Flight.Arriving)currentRunway.CheckNextFlightInQueue(); //  -------------------------------------------------------------------- step 2 arrving
                            currentRunway.NextFlightEntersRunway();
                            currentRunway.UseRunway(nextFlight, start);
                            currentRunway.ExitRunway(nextFlight, start);
                        }
                        else
                        {
                            //utfør take off
                            Flight.Departing nextFlight = (Flight.Departing)currentRunway.CheckNextFlightInQueue(); //  -------------------------------------------------------------------- step 2 arrving
                            currentRunway.NextFlightEntersRunway();
                            currentRunway.UseRunway(nextFlight, start);
                            currentRunway.ExitRunway(nextFlight, start);
                        }
                    }
                }
                // Hver taksebane blir brukt av et fly
                foreach (Taxiway currentTaxiway in Airport.GetListTaxiways())
                {
                    if (currentTaxiway.GetNumberOfAircraftsInQueue() > 0)
                    {
                        if (currentTaxiway.CheckAndReturnNextFlightInQueue().IsArrivingFlight == true)
                        {
                            Flight.Arriving arrivingFlight = (Flight.Arriving)currentTaxiway.CheckAndReturnNextFlightInQueue();
                            currentTaxiway.SimulateTaxiwayTime(arrivingFlight, 0, arrivingFlight.ActiveAircraft.AccelerationOnGround, arrivingFlight.ActiveAircraft.MaxSpeedOnGround, DateTime.Now);
                            currentTaxiway.NextFlightLeavesTaxiway(arrivingFlight, DateTime.Now);

                            // sjekker om det finnes et neste taxiway-objekt i taxiwaypath 
                            for (int i = 0; i < arrivingFlight.taxiwayPath.Count(); i++)
                            {
                                if (arrivingFlight.taxiwayPath[i] == arrivingFlight.currentLocationTaxiway)
                                {
                                    // setter den neste taksebanen i lista til å være nåverende lokasjon
                                    arrivingFlight.currentLocationTaxiway = arrivingFlight.taxiwayPath[i + 1];
                                }
                            }
                        }
                        else
                        {
                            Flight.Departing departuringFlight = (Flight.Departing)currentTaxiway.CheckAndReturnNextFlightInQueue();
                            currentTaxiway.SimulateTaxiwayTime(departuringFlight, 0, departuringFlight.ActiveAircraft.AccelerationOnGround, departuringFlight.ActiveAircraft.MaxSpeedOnGround, DateTime.Now);
                            currentTaxiway.NextFlightLeavesTaxiway(departuringFlight, DateTime.Now);

                            // sjekker om det finnes et neste taxiway-objekt i taxiwaypath 
                            for (int i = 0; i < departuringFlight.taxiwayPath.Count(); i++)
                            {
                                if (departuringFlight.taxiwayPath[i] == departuringFlight.currentLocationTaxiway)
                                {
                                    // setter den neste taksebanen i lista til å være nåverende lokasjon
                                    departuringFlight.currentLocationTaxiway = departuringFlight.taxiwayPath[i + 1];
                                }
                            }
                        }
                    }
                }
                // Legger til fly i kø på taksebaner
                foreach (Taxiway taxiway in Airport.GetListTaxiways())
                {
                    foreach (Flight arrivingFlight in Airport.GetArrivingFlights())
                    {
                        // Må ha taxiwaylogikk her!!!
                        if (arrivingFlight.taxiwayPath.Count > 0)
                        {
                            arrivingFlight.currentLocationTaxiway.AddFlightToQueue(arrivingFlight, DateTime.Now);
                        }

                    }
                    foreach (Flight departuringFlight in Airport.GetDepartingFlights())
                    {
                        // Må ha taxiwaylogikk her!!!
                        if (departuringFlight.taxiwayPath.Count > 0)
                        {
                            departuringFlight.currentLocationTaxiway.AddFlightToQueue(departuringFlight, DateTime.Now);
                        }
                    }
                }
                Thread.Sleep(1);
                start = start.AddMinutes(1);
            }
        }
	}
}