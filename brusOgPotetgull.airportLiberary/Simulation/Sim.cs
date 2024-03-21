using BrusOgPotetgull.AirportLiberary.CustomExceptions;
using BrusOgPotetgull.AirportLiberary;

namespace BrusOgPotetgull.AirportLiberary.Sim
{
    /// <summary>
    /// A simulation that is used to simulate how an airport works.
    /// </summary>
	public class Sim
    {
        /// <summary>
        /// Creates an simulation of the choosen airport.
        /// </summary>
        /// <param name="airport">Which airport that is using the simulation.</param>
        /// <param name="startTime">The day that is the start of the simulation.</param>
        /// <param name="endTime">The day that is the end of the simulation.</param>
        public Sim(Airport airport, DateTime startTime, DateTime endTime)
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
                Console.WriteLine(start);
                // Sette i gang flygninger når tiden er inne
                // Arriving flights
                if (Airport.GetArrivingFlights().Count > 0)
                {
                    foreach (Flight.Arriving flight in Airport.GetArrivingFlights())
                    {
                        if (flight.DateTimeFlight == start)
                        {
                            flight.taxiwayPath = Airport.GenerateArrivingFlightTaxiwayPath(flight);
                            flight.ArrivalRunway.AddFlightToQueue(flight);
                            flight.ArrivalRunway.UseRunway(flight, start);
                            flight.ArrivalRunway.ExitRunway(flight, start);
                            Taxiway startTaxiway = flight.taxiwayPath[0];
                            if (startTaxiway != null) 
                            {
                                startTaxiway.AddFlightToQueue(flight, start);
                                flight.taxiwayPath.Remove(startTaxiway);
                            }
                        }
                    }
                }
                // Departing flights
                if (Airport.GetDepartingFlights().Count > 0) 
                {
                    foreach (Flight.Departing flight in Airport.GetDepartingFlights()) 
                    {
                        if (flight.DateTimeFlight == start)
                        {
                            flight.taxiwayPath = Airport.GenerateDeparturingFlightTaxiwayPath(flight);
                            flight.DepartureGate.LeaveGate(flight.ActiveAircraft, start);                            
                            Taxiway startTaxiway = flight.taxiwayPath[0];
                            if (startTaxiway != null) 
                            {
                                startTaxiway.AddFlightToQueue(flight, start);
                                flight.taxiwayPath.Remove(startTaxiway);
                            }
                        }
                    }
                }

                foreach (var taxiway in Airport.GetListTaxiways())
                {
                    if (taxiway.GetNumberOfAircraftsInQueue() > 0)
                    {
                        // neste fly i kø
                        Flight currentFlight = taxiway.CheckNextFlightInQueue();

                        // neste fly forlater taksebane
                        taxiway.NextFlightLeavesTaxiway(currentFlight, start);

                        if (currentFlight.taxiwayPath.Count > 0 && currentFlight.taxiwayPath[0] != null)
                        {
                            //setter neste taksebane i path
                            Taxiway nextLocation = currentFlight.taxiwayPath[0];

                            //Legger fly i kø på neste taksebane
                            nextLocation.AddFlightToQueue(currentFlight, start);

                            //Fjerner taksebane fra path
                            currentFlight.taxiwayPath.Remove(nextLocation);
                        }
                        else
                        {
                            if (currentFlight.IsArrivingFlight == false)
                            {
                                Flight.Departing currentDeparting = (Flight.Departing)currentFlight;
                                currentDeparting.DepartureRunway.AddFlightToQueue(currentDeparting);
                                currentDeparting.DepartureRunway.UseRunway(currentDeparting, start);
                                currentDeparting.DepartureRunway.ExitRunway(currentDeparting, start);
                                Airport.RemoveDepartingFlight(currentDeparting);
                            }
                            else
                            {
                                Flight.Arriving currentArriving = (Flight.Arriving)currentFlight;
                                currentArriving.ArrivalGate.BookGate(currentArriving.ActiveAircraft, start);
                                Airport.RemoveArrivingFlight(currentArriving);
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