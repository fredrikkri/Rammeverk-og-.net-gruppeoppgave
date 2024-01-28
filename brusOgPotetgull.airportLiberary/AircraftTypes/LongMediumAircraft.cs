using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LongMediumAircraft : Aircraft
	{
        private int aircraftTypeId = 3;
        // (GeeksforGeeks, 2023)
        public LongMediumAircraft(string model, int maxSpeed, int acceleration) : base(model, maxSpeed, acceleration)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Long-medium aircraft\nType(id): {AircraftTypeId}\nMax speed: {MaxSpeed}\nAcceleration: {Acceleration}\n");
        }
    }
}

