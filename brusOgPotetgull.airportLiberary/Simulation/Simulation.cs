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
                // For hver innkommende Flight i luften som ønsker å lande på rullebane...
                if (airport.GetInncommingAircraftsQueue().Count > 0)
                {
                    Aircraft currentAircraft = airport.RemoveInncommingAircraftsQueue();
                    Console.Write($"This plane: \n{airport.GetInncommingAircraftsQueue().Count}\n");
                   
                        // Flight som ønsker å lande, legges inn i en "Flight in air queue for landing"
                        foreach (var runway in airport.GetRunwayList())
                        {
                        if (runway.InUse == false)
                        {
                            Console.Write("bruker runway");
                            runway.UseRunway();
                            Console.Write("\nFlyet lander\n");
                            runway.SimulateLanding(currentAircraft);
                            runway.RemoveFromQueue();
                        }
                    }
                }
                else
                {
                    //Går igjennom departuringAircraft queue, og legger til departuringAircraft 
                    // Sjekke om det eksisterer Flight som befinner seg på Taxiway, i kø til Runway for Departure
                    foreach (var departuringAircraft in airport.GetDeparturingAircraftsQueue())
                    {
                        // Flights i listen departuringAircraft[] legges til i køen AddToDeaprturingQueue() 
                        airport.AddToDeparturingQueue(departuringAircraft);
                    }

                    // Sjekker om det er fly i lufta som MÅ lande og dermed okkupere rullebane
                    if (airport.GetInncommingAircraftsQueue().Count != 0)
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
                start = start.AddDays(1);
            }
        }
	}
}

