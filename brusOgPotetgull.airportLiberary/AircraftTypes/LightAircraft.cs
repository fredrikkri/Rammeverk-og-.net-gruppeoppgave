using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LightAircraft : Aircraft
	{
        private int aircraftTypeId = 1;
        // (GeeksforGeeks, 2023)
        public LightAircraft(string model) : base(model)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Light aircraft\nAircraft type: {AircraftTypeId}\n");
        }
    }
}

