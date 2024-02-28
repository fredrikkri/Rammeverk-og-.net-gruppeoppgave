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

        /// <summary>
        /// Creates an short-medium aircraft.
        /// </summary>
        /// <param name="modelName">Name of the model for this aircraft</param>
        /// <param name="maxSpeedInAir">Maximum speed in air for this aircraft</param>
        /// <param name="accelerationInAir">Maximum acceleration in air for this aircraft</param>
        /// <param name="maxSpeedOnGround">Maximum speed on ground for this aircraft</param>
        /// <param name="accelerationOnGround">Maximum acceleration on ground for this aircraft</param>
        public ShortMediumAircraft(string modelName,
            int maxSpeedInAir,
            int accelerationInAir,
            int maxSpeedOnGround,
            int accelerationOnGround) :
            base(modelName,
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
                $"Model: {ModelName}\n" +
                $"Type: Short-medium aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }
    }
}

