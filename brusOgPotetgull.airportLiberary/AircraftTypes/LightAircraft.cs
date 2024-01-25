using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LightAircraft : Aircraft
	{
        // (GeeksforGeeks, 2023)
        public LightAircraft(string model) : base(model)
        {
		}
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Light aircraft\n");
        }
    }
}

