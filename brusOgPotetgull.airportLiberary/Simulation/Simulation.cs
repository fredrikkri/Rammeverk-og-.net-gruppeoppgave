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
                Console.Write($"\n\t\t\t\t\t\tSimulation time: {start}\n");

                // Fly drar fra Gate til en taksebane.
                //foreach (Flight flight in airport.GetDepartingFlights())
                //{
                    // Må lage simulering/logikk for hvordan et fly kommer seg fra en gate til en taksebane.
                //}
                // Ankommende fly drar fra taksebane.
                foreach (Flight flight in airport.GetArrivingFlights()) 
                {
                    if (flight.ArrivalTaxiway.GetNumberOfAircraftsInQueue() > 0 && flight.ArrivalTaxiway.CheckNextFlightInQueue() == flight)
                    {
                        flight.ArrivalTaxiway.NextFlightLeavesTaxiway(flight);
                    }
                    else { continue; }
                }
                // reisende fly drar fra taksebane.
                foreach (Flight flight in airport.GetDepartingFlights())
                {
                    if (flight.DepartureTaxiway.GetNumberOfAircraftsInQueue() > 0 && flight.DepartureTaxiway.CheckNextFlightInQueue() == flight)
                    {
                        flight.DepartureTaxiway.NextFlightLeavesTaxiway(flight);
                    }
                    else { continue; }
                }
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
                            // trenger ikke køsystem på loggede flygninger, kun tidspunkt. Har allerede køsystem i runway og taxiway.
                        }
                        else
                        {
                            continue;
                        }
                    }                             
                    // Sjekker alle runways
                    foreach (Runway currentRunway in airport.GetRunwayList())
                    {
                        //Hvis det er fly i runway køen, og runway er ledig
                        if (currentRunway.RunwayQueue.Count > 0 && currentRunway.InUse == false)                       
                        {
                            //utfør landing
                            Flight nextFlight = currentRunway.CheckNextFlightInQueue();
                            currentRunway.NextFlightEntersRunway(nextFlight);
                            Console.Write($"\n{nextFlight.ActiveAircraft.Model} using runway\n");
                            currentRunway.UseRunway();
                            // funksjonen og lokale variabelen under brukes ikke foreløpig.
                            // Vurderer å benytte funksjonen til å logge et annet exit tidspunkt basert på tid brukt på runway
                            // i tillegg er den veldig lik SimulateTaxiwayTime, slik at den kan egentlig flyttes til flight, og
                            // kan egt flyttes til flight. Der kan den heller brukes for flybevegelser generelt.
                            //int secondsOnRunway = currentRunway.SimulateRunwayTime(nextFlight, 300, 40, nextFlight.ActiveAircraft.MaxSpeedOnGround);
                            currentRunway.ExitRunway();
                            Console.Write($"\n{nextFlight.ActiveAircraft.Model} left runway\n");

                            Console.Write($"\n{nextFlight.ActiveAircraft.Model} using taxiyway\n");
                            nextFlight.DepartureTaxiway.SimulateTaxiwayTime(nextFlight, 20, nextFlight.ActiveAircraft.AccelerationOnGround, nextFlight.ActiveAircraft.MaxSpeedOnGround);
                            nextFlight.ArrivalTaxiway.AddFlightToQueue(nextFlight);
                        }
                        // La fly forbli i køen til neste iterasjon
                        else { continue; }
                    }

                    // For hver taxiway på flyplassen
                    foreach (var taxiway in airport.GetListTaxiways())
                    {
                        // Neste fly i taxiway køen
                        Flight flight = taxiway.CheckNextFlightInQueue();
                        // Dersom flygning er arriving flight og gate er ledig
                        if (flight.IsArrivingFlight == true && flight.ArrivalGate.IsAvailable == true)
                        {
                            // Flygning forlater taxiway
                            flight.ArrivalTaxiway.NextFlightLeavesTaxiway(flight);
                            Console.Write($"\n{flight.ActiveAircraft.Model} forlatt taxiway\n");
                            // Flygning sjekker inn på gate
                            flight.ArrivalGate.bookGate(flight.ActiveAircraft);
                            Console.Write($"\n{flight.ActiveAircraft.Model} ankommet gate\n");

                            // Fjerner flygningen fra innkommende flygninger når den er ferdig håndtert
                            airport.RemoveArrivingFlight(flight);
                        }
                        else { continue; }                                                 
                    }
                    // TODO: Må håndtere at arriving flight som ikke er kommet til gate ikke lander på nytt,
                    // men samtidig at arriving flight forsøker å benytte gate på nytt dersom den var opptatt ved forrige iterasjon
                    // Notat: Mulig det fungerer siden simuleringen kun legger til flight i runway kø dersom tiden er riktig.

                    // TODO: SimulateTaxiway logikk for utregning av tid benyttes ikke atm. Vet ikke helt hvordan
                    // vi skal gjøre det i forhold til simuleringstiden.
                }
                // Eller Hvis det finnes utgående flygninger
                if (airport.GetDepartingFlights().Count > 0)
                {
                    // Går igjennom lista med utgående flygninger
                    foreach (var flight in airport.GetDepartingFlights())
                    {
                        // Hvis tiden for flygningen er lik nåværende tid i simulasjonen
                        if (flight.DateTimeFlight == start)
                        {
                            // Flight leaves gate
                            flight.DepartureGate.leaveGate(flight.ActiveAircraft);
                            Console.Write($"\n{flight.ActiveAircraft.Model} forlatt gate\n");

                            // Tiden det tar for et fly å komme inn på taxiway til den er i enden.
                            flight.DepartureTaxiway.SimulateTaxiwayTime(flight, 0, flight.ActiveAircraft.AccelerationOnGround, flight.ActiveAircraft.MaxSpeedOnGround);

                            // Enters taxiway queue
                            flight.DepartureTaxiway.AddFlightToQueue(flight);
                            Console.Write($"\n{flight.ActiveAircraft.Model} ankommet taxiwaykø\n");
                        }
                        else { continue; }
                    }
                    // Hvis det ikke finnes arriving flights
                    if (airport.GetArrivingFlights().Count == 0)
                    {   
                        //For hver taxiway på flyplassen
                        foreach (var taxiway in airport.GetListTaxiways())
                        {
                            // neste fly i køen på gjeldene taxiway
                            Flight currentFlight = taxiway.CheckNextFlightInQueue();
                            Console.Write($"\n{currentFlight.ActiveAircraft.Model} fly lagt til i liste\n");
                            // Hvis det finnes en flight i køen, og rullebane er ledig
                            if (currentFlight != null && currentFlight.DepartureRunway.InUse == false)
                            {
                                currentFlight.DepartureTaxiway.NextFlightLeavesTaxiway(currentFlight);
                                currentFlight.DepartureRunway.UseRunway();
                                currentFlight.DepartureRunway.SimulateRunwayTime(currentFlight, 0, currentFlight.ActiveAircraft.AccelerationInAir, currentFlight.ActiveAircraft.MaxSpeedInAir);
                                currentFlight.DepartureRunway.ExitRunway();
                            }
                            else { continue; }
                        }                                                
                    }                                                    
                }
                else { continue; }
                Thread.Sleep(4);
                start = start.AddMinutes(1);
            }
        }
	}
}