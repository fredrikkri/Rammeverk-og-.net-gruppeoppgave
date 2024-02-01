using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class LargeAircraft : Aircraft
	{
        private int aircraftTypeId = 4;
        // (GeeksforGeeks, 2023)
        public LargeAircraft(string model,
            int maxSpeedInAir,
            int accelerationInAir,
            int maxSpeedOnGround,
            int accelerationOnGround) :
            base(model,
                maxSpeedInAir,
                accelerationInAir,
                maxSpeedOnGround,
                accelerationOnGround)
        {
            this.AircraftTypeId = aircraftTypeId;
        }
        public new int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)

        /// <summary>
        /// Prints the information about the aircraft.
        /// </summary>
        override public void PrintAircraftInformation()
        {
            Console.Write($"\nId: {Id}\n" +
                $"Model: {Model}\n" +
                $"Type: Large aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }
    }
}

