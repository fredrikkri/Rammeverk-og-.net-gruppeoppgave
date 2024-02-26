using System;
using System.Reflection;

namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
{
    /// <summary>
    /// Long medium aircraft is a madium sized aircraft with greate length.
    /// </summary>
	public class LongMediumAircraft : Aircraft
	{
        private int aircraftTypeId = 3;
        // (GeeksforGeeks, 2023)

        /// <summary>
        /// Creates an long-medium aircraft.
        /// </summary>
        /// <param name="model">Name of the model for this aircraft</param>
        /// <param name="maxSpeedInAir">Maximum speed in air for this aircraft</param>
        /// <param name="accelerationInAir">Maximum acceleration in air for this aircraft</param>
        /// <param name="maxSpeedOnGround">Maximum speed on ground for this aircraft</param>
        /// <param name="accelerationOnGround">Maximum acceleration on ground for this aircraft</param>
        public LongMediumAircraft(string model,
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
                $"Type: Long-medium aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }
    }
}

