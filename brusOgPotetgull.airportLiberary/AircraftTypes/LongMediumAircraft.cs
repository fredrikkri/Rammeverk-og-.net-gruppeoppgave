using System;
namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LongMediumAircraft : Aircraft
	{
        // (GeeksforGeeks, 2023)
        public LongMediumAircraft(string model) : base(model)
        {
		}
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Long-medium aircraft\n");
        }
    }
}

