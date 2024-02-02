using System;
namespace brusOgPotetgull.airportLiberary.Simulation
{
	public class Simulation
	{
        public Simulation(Airport airport, int year, int month, int day, int hour, int min)
        {
            DateTime datetimeEnd = new DateTime(year, month, day, hour, min, 0);
            while (DateTime.Now <= datetimeEnd)
            {
                foreach (var incommingAircraft in airport.GetInncommingAircrafts())
                {
                    airport.AddToInncommingAircrafts(incommingAircraft);
                }

                foreach (var departuringAircraft in airport.GetDeparturingAircrafts())
                {
                    airport.AddToDeparturingQueue(departuringAircraft);
                }

                    
                    
                    

                ///finne fly som skal lette(for loop ?)
                ///legge dem til i kø(kom til taxebane)

                if (airport.GetInncommingAircrafts().Count != 0)
                {
                ///land fly 1 i kø(husk å fjærne fly)
                ///og gå til taxebane exit
                ///leg til kø til gate er ledig
                }
                else
                {
                ///lett fly 1 i kø(husk å fjærne fly)
                }
            }
        }
	}
}

