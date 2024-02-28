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
        /// <param name="modelName">Name of the model for this aircraft</param>
        /// <param name="maxSpeedInAirKMH">Maximum speed in air for this aircraft</param>
        /// <param name="accelerationInAirKMH">Maximum acceleration in air for this aircraft</param>
        /// <param name="maxSpeedOnGroundKMH">Maximum speed on ground for this aircraft</param>
        /// <param name="accelerationOnGroundKMH">Maximum acceleration on ground for this aircraft</param>
        public LongMediumAircraft(string modelName,
            int maxSpeedInAirKMH,
            int accelerationInAirKMH,
            int maxSpeedOnGroundKMH,
            int accelerationOnGroundKMH) :
            base(modelName,
                maxSpeedInAirKMH,
                accelerationInAirKMH,
                maxSpeedOnGroundKMH,
                accelerationOnGroundKMH)
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
                $"Type: Long-medium aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAirKMH}\n" +
                $"Acceleration: {AccelerationInAirKMH}\n");
        }
    }
}

