using System;
using System.Reflection;

namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
{
    /// <summary>
    /// Short medium aircraft is an aircraft with bigger size than light aircraft, but smaller than long medium aircraft.
    /// </summary>
	public class ShortMediumAircraft : Aircraft
	{
        private int aircraftTypeId = 2;
        // (GeeksforGeeks, 2023)
        public ShortMediumAircraft(string model,
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
                $"Type: Short-medium aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }
    }
}

