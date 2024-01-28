using System;
namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class ShortMediumAircraft : Aircraft
	{
        private int aircraftTypeId = 2;
        // (GeeksforGeeks, 2023)
        public ShortMediumAircraft(string model) : base(model)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Short-medium aircraft\nAircraft type: {AircraftTypeId}\n");
        }
    }
}

