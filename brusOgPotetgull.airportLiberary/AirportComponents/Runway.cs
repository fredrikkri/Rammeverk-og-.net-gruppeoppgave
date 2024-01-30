using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Runway
	{
        private static int idCounter = 1;
        private int id;

        public Runway(Airport locatedAtAirport)
        {
            // (dosnetCore, 2020) 
            id = idCounter++;
            Id = id;
            this.LocatedAtAirport = locatedAtAirport;
        }
        public int Id { get; private set; }
        public Airport LocatedAtAirport { get; private set; }

        public string GetIdAndAirportNickname()
        {
            string returnString = (string)(Id + ", " + LocatedAtAirport.AirportNickname);
            return returnString;
        }
    }
}

