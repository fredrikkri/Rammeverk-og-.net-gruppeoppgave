using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class MilitaryAircraft : Aircraft
	{
        private int aircraftTypeId = 6;
        // (GeeksforGeeks, 2023)
        public MilitaryAircraft(string model) : base(model)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Military aircraft\nAircraft type: {AircraftTypeId}\n");
        }
    }
}

