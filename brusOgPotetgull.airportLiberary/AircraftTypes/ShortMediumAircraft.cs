using System;
namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class ShortMediumAircraft : Aircraft
	{
        // (GeeksforGeeks, 2023)
        public ShortMediumAircraft(string model) : base(model)
        {
		}
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Short-medium aircraft\n");
        }
    }
}

