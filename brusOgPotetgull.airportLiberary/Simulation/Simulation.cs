 using System;
namespace brusOgPotetgull.airportLiberary.Simulation
{
	public class Simulation
	{

        // Starter simuleringen 
        public Simulation(Airport airport, int year, int month, int day, int hour, int min)
        {
            // Oppretter et objekt for å angi sluttid for simuleringens varighet
            DateTime datetimeEnd = new DateTime(year, month, day, hour, min, 0);

            // Simulering starter, og kjører inntil tidspunktet for endelse er større eller lik starttidspunktet
            while (DateTime.Now <= datetimeEnd)
            {
                // For hver innkommende Flight i luften som ønsker å lande på rullebane...
                foreach (var incommingAircraft in airport.GetInncommingAircrafts())
                {
                    // Flight som ønsker å lande, legges inn i en "Flight in air queue for landing"
                    airport.AddToInncommingAircrafts(incommingAircraft);


                    // TODO: Fjerne flyene fra køen "GetIncomingAircraft"
                }

                // Sjekke om det eksisterer Flight som befinner seg på Taxiway, i kø til Runway for Departure
                foreach (var departuringAircraft in airport.GetDeparturingAircrafts())
                {
                    // Flights i listen departuringAircraft[] legges til i køen AddToDeaprturingQueue() 
                    airport.AddToDeparturingQueue(departuringAircraft);
                }
                
                // Sjekker om det er fly i lufta som MÅ lande og dermed okkupere rullebane
                if (airport.GetInncommingAircrafts().Count != 0)
                {
                ///land fly 1 i kø(husk å fjerne fly)
                ///og gå til taxebane exit
                ///leg til kø til gate er ledig
                }
                else
                {
                ///lett fly 1 i kø(husk å fjerne fly) fra DeparturingQueue
                }
            }
        }
	}
}

