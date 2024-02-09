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

                // Fly drar fra Gate til en taksebane.
                //foreach (Flight flight in airport.GetDepartingFlights())
                //{
                // Må lage simulering/logikk for hvordan et fly kommer seg fra en gate til en taksebane.
                //}


                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                /*
                // fly ankommer gates
                foreach (Flight flight in airport.GetArrivingFlights())
                {
                    flight.ArrivalGate.bookGate(flight.ActiveAircraft, start);
                }
                // fly bruker runway og drar fra flyplassen
                foreach (Flight flight in airport.GetDepartingFlights())
                {
                    Aircraft flightFirstInQueue = flight.DepartureRunway.CheckNextFlightInQueue().ActiveAircraft;
                    if (flightFirstInQueue == flight.ActiveAircraft)
                    {
                        // simmulere 
                    }
                }*/
                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


                // Ankommende fly drar fra taksebane.
                foreach (Flight flight in Airport.GetArrivingFlights())
                {
                    if (flight.ArrivalTaxiway.GetNumberOfAircraftsInQueue() > 0 && flight.ArrivalTaxiway.CheckNextFlightInQueue() == flight)
                    {
                        flight.ArrivalTaxiway.NextFlightLeavesTaxiway(flight, start);
                    }
                }
                // reisende fly drar fra taksebane.
                foreach (Flight flight in Airport.GetDepartingFlights())
                {
                    if (flight.DepartureTaxiway.GetNumberOfAircraftsInQueue() > 0 && flight.DepartureTaxiway.CheckNextFlightInQueue() == flight)
                    {
                        flight.DepartureTaxiway.NextFlightLeavesTaxiway(flight, start);
                        //flight.DepartureRunway.AddFlightToQueue(flight);
                    }
                }
                // Hvis det finnnes innkommende flygninger
                if (Airport.GetArrivingFlights().Count > 0)
                {
                    // Går igjennom alle flygninger, og legger til denne dersom tiden for flygningen er denne iterasjonen (datetime.start + simulasjonstid)
                    foreach (Flight flight in Airport.GetArrivingFlights())
                    {
                        if (flight.DateTimeFlight == start)
                        {
                            //starter handlinger for flygning  ( når tiden for flygningen er inne )
                            flight.ArrivalRunway.AddFlightToQueue(flight);
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
                        Flight nextFlight = currentRunway.CheckNextFlightInQueue();
                        currentRunway.NextFlightEntersRunway(nextFlight, start);
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
                        nextFlight.ArrivalTaxiway.SimulateTaxiwayTime(nextFlight, 20, nextFlight.ActiveAircraft.AccelerationOnGround, nextFlight.ActiveAircraft.MaxSpeedOnGround, start);
                        nextFlight.ArrivalTaxiway.AddFlightToQueue(nextFlight, start);
                    }
                    // La fly forbli i køen til neste iterasjon
                }
                // For hver taxiway på flyplassen
                foreach (var taxiway in Airport.GetListTaxiways())
                {
                    // Neste fly i taxiway køen
                    if (taxiway.GetNumberOfAircraftsInQueue() > 0)
                    {
                        Flight flight = taxiway.CheckNextFlightInQueue();

                        // Dersom flygning er arriving flight og gate er ledig
                        if (flight.IsArrivingFlight == true) //&& flight.ArrivalGate.IsAvailable == true)
                        {
                            // Flygning forlater taxiway
                            flight.ArrivalTaxiway.NextFlightLeavesTaxiway(flight, start);
                            Console.Write($"\n{flight.ActiveAircraft.Model} left taxiway\n");
                            // Flygning sjekker inn på gate
                            flight.ArrivalGate.bookGate(flight.ActiveAircraft, start);
                            Console.Write($"\n{flight.ActiveAircraft.Model} reached gate\n");

                            // Fjerner flygningen fra innkommende flygninger når den er ferdig håndtert
                            Airport.RemoveArrivingFlight(flight);
                        }
                    }
                }
                // TODO: Må håndtere at arriving flight som ikke er kommet til gate ikke lander på nytt,
                // men samtidig at arriving flight forsøker å benytte gate på nytt dersom den var opptatt ved forrige iterasjon
                // Notat: Mulig det fungerer siden simuleringen kun legger til flight i runway kø dersom tiden er riktig.

                // TODO: SimulateTaxiway logikk for utregning av tid benyttes ikke atm. Vet ikke helt hvordan
                // vi skal gjøre det i forhold til simuleringstiden.

                // Eller Hvis det finnes utgående flygninger
                if (Airport.GetDepartingFlights().Count > 0)
                {
                    // Går igjennom lista med utgående flygninger
                    foreach (var flight in Airport.GetDepartingFlights())
                    {
                        // Hvis tiden for flygningen er lik nåværende tid i simulasjonen
                        if (flight.DateTimeFlight == start)
                        {
                            // Flight leaves gate
                            flight.DepartureGate.leaveGate(flight.ActiveAircraft, start);
                            Console.Write($"\n{flight.ActiveAircraft.Model} left gate\n");

                            // Tiden det tar for et fly å komme inn på taxiway til den er i enden.
                            flight.DepartureTaxiway.SimulateTaxiwayTime(flight, 0, flight.ActiveAircraft.AccelerationOnGround, flight.ActiveAircraft.MaxSpeedOnGround, start);

                            // Enters taxiway queue
                            flight.DepartureTaxiway.AddFlightToQueue(flight, start);
                            Console.Write($"\n{flight.ActiveAircraft.Model} reached taxiwayqueue\n");
                        }
                    }
                }
                // Hvis det ikke finnes arriving flights
                if (Airport.GetArrivingFlights().Count == 0)
                {
                    //For hver taxiway på flyplassen
                    foreach (var taxiway in Airport.GetListTaxiways())
                    {
                        if (taxiway.GetNumberOfAircraftsInQueue() > 0)
                        {
                            // neste fly i køen på gjeldene taxiway
                            Flight currentFlight = taxiway.CheckNextFlightInQueue();
                            Console.Write($"\n{currentFlight.ActiveAircraft.Model} fly lagt til i liste\n");
                            // Hvis det finnes en flight i køen, og rullebane er ledig
                            if (currentFlight != null && currentFlight.DepartureRunway.InUse == false)
                            {
                                currentFlight.DepartureTaxiway.NextFlightLeavesTaxiway(currentFlight, start);
                                currentFlight.DepartureRunway.UseRunway();
                                currentFlight.DepartureRunway.SimulateRunwayTime(currentFlight, 0, currentFlight.ActiveAircraft.AccelerationInAir, currentFlight.ActiveAircraft.MaxSpeedInAir, start);
                                currentFlight.DepartureRunway.ExitRunway();
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