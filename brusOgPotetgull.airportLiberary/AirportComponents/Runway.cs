using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Runway
	{
        private static int idCounter = 1;
        private int id;

        public Runway()
		{
            // (dosnetCore, 2020) 
            id = idCounter++;
            Id = id;
        }
        public int Id { get; private set; }
    }
}

