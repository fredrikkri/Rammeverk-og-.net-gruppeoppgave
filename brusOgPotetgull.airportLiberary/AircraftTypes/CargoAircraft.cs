using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class CargoAircraft : Aircraft
	{
        private int aircraftTypeId = 5;
        // (GeeksforGeeks, 2023)
        public CargoAircraft(string model, int maxSpeedInAir, int accelerationInAir, int maxSpeedOnGround, int accelerationOnGround) : base(model, maxSpeedInAir, accelerationInAir, maxSpeedOnGround, accelerationOnGround)
		{
            this.AircraftTypeId = aircraftTypeId;
		}
        public new int AircraftTypeId { get; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\n" +
                $"Model: {Model}\n" +
                $"Type: Cargo aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }

    }
}

