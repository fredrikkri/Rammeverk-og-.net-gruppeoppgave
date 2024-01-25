using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class MilitaryAircraft : Aircraft
	{
        // (GeeksforGeeks, 2023)
        public MilitaryAircraft(string model) : base(model)
        {
		}
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Military aircraft\n");
        }
    }
}

