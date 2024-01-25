using System;
namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class CargoAircraft : Aircraft
	{
        // (GeeksforGeeks, 2023)
        public CargoAircraft(string model) : base(model)
		{
		}
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Cargo aircraft\n");
        }

    }
}

