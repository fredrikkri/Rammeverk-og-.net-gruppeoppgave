using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class ShortMediumAircraft : Aircraft
	{
        private int aircraftTypeId = 2;
        // (GeeksforGeeks, 2023)
        public ShortMediumAircraft(string model, int maxSpeedInAir, int accelerationInAir, int maxSpeedOnGround, int accelerationOnGround) : base(model, maxSpeedInAir, accelerationInAir, maxSpeedOnGround, accelerationOnGround)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Short-medium aircraft\nType(id): {AircraftTypeId}\nMax speed: {MaxSpeedInAir}\nAcceleration: {AccelerationInAir}\n");
        }
    }
}

