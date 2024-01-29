using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LongMediumAircraft : Aircraft
	{
        private int aircraftTypeId = 3;
        // (GeeksforGeeks, 2023)
        public LongMediumAircraft(string model, int maxSpeedInAir, int accelerationInAir, int maxSpeedOnGround, int accelerationOnGround) : base(model, maxSpeedInAir, accelerationInAir, maxSpeedOnGround, accelerationOnGround)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\n" +
                $"Model: {Model}\n" +
                $"Type: Long-medium aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }
    }
}

