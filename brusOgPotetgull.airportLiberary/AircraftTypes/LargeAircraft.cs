using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LargeAircraft : Aircraft
	{
        // (GeeksforGeeks, 2023)
        public LargeAircraft(string model) : base(model)
        {
		}
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Large aircraft\n");
        }
    }
}

