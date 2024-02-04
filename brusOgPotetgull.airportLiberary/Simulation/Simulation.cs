 using System;
namespace brusOgPotetgull.airportLiberary.Simulation
{
	public class Simulation
	{

        // Starter simuleringen 
        public Simulation(Airport airport, DateTime startTime, DateTime endTime)
        {
            //Angir start og slutt tid for simulasjon
            DateTime start = startTime;
            DateTime end = endTime;

            // Simulering starter ved startTime, og kjører inntil tidspunktet for endtime er <= starttime
            while (start <= end)
            {   
                // Hvis det finnnes innkommende flygninger
                if (airport.GetArrivingFlights().Count > 0)
                {   
                    // Går igjennom alle flygninger, og legger til denne dersom tiden for flygningen er denne iterasjonen (datetime.start + simulasjonstid)
                    foreach (Flight flight in airport.GetArrivingFlights())
                    {
                        if (flight.DateTimeFlight == start)
                        {
                            //starter handlinger for flygning  ( når tiden for flygningen er inne )
                            flight.ArrivalRunway.AddFlightToQueue(flight);
                            // Fjerner flygningen fra innkommende flygninger når den legges til i runway kø
                            airport.RemoveArrivingFlight(flight); 
                            // Kan være lurt å endre fra queue til liste ????
                            // trenger ikke køsystem på loggede flygninger, kun tidspunkt. Har allerede køsystem i runway og taxiway.
                        }
                        else
                        {
                            continue;
                        }
                    }

                    // Starte landingsprosess for fly i runway kø                                     
                    // Sjekker alle runways
                    foreach (Runway runway in airport.GetRunwayList())
                    {   
                        Runway currentRunway = runway;
                        //Hvis det er fly i runway køen, og runway er ledig
                        if (currentRunway.RunwayQueue.Count > 0 && currentRunway.InUse == false)                       
                        {
                            //utfør landing
                            Flight nextFlight = currentRunway.CheckNextFlightInQueue();
                            currentRunway.NextFlightEntersRunway(nextFlight);
                            Console.Write($"{nextFlight.ActiveAircraft.Model} bruker runway");
                            currentRunway.UseRunway();
                            int secondsOnRunway = currentRunway.SimulateRunwayTime(nextFlight, 300, 40, nextFlight.ActiveAircraft.MaxSpeedOnGround);
                            // potensielt problem - at sekundene for simulasjon blir lagt til for hver av rullebanene
                            // som benyttes dersom vi har flere rullebaner.
                            // --> start.AddSeconds(secondsOnRunway);
                            currentRunway.ExitRunway();
                        }
                        else 
                        {
                            //La fly forbli i køen til neste iterasjon
                            continue;
                        }
                    }
                }
                // Eller Hvis det finnes utgående flygninger
                else if (airport.GetDepartingFlights().Count > 0)
                {
                    // Går igjennom lista med utgående flygninger
                    foreach (var flight in airport.GetDepartingFlights())
                    {
                        // Hvis tiden for flygningen er lik nåværende tid i simulasjonen
                        if (flight.DateTimeFlight == start)
                        {
                            // Flight leaves gate
                            flight.DepartureGate.leaveGate(flight.ActiveAircraft);

                            // Enters taxiway queue
                            flight.DepartureTaxiway.AddFlightToQueue(flight);
                        }
                    }
                    // Hvis det ikke finnes arriving flights
                    if (airport.GetArrivingFlights().Count == 0)
                    {   
                        foreach (var taxiway in airport.GetListTaxiways())
                        {
                            Flight currentFlight = taxiway.CheckNextFlightInQueue();
                            currentFlight.DepartureTaxiway.NextFlightEnterTaxiway(currentFlight, currentFlight.DepartureRunway);
                        }

                        // Først
                        
                    }
                    // Sjekker om runway queue er tom
                    // Sjekker om runway er ledig
                    // Hvis først i køen --> Enters runway for takeoff                                                          
                }
                else { continue; }
                start = start.AddMinutes(1);
            }
        }
	}
}