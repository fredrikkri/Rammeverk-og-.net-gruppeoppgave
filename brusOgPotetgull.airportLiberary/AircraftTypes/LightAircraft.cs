using System;
using System.Reflection;

namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
{
    /// <summary>
    /// Light aircraft is a smaller aircraft. It can be an private plane.
    /// </summary>
	public class LightAircraft : Aircraft
	{
        private int aircraftTypeId = 1;
        // (GeeksforGeeks, 2023)

        /// <summary>
        /// Creates an light aircraft.
        /// </summary>
        /// <param name="modelName">Name of the model for this aircraft</param>
        /// <param name="maxSpeedInAirKMH">Maximum speed in air for this aircraft</param>
        /// <param name="accelerationInAirKMH">Maximum acceleration in air for this aircraft</param>
        /// <param name="maxSpeedOnGroundKMH">Maximum speed on ground for this aircraft</param>
        /// <param name="accelerationOnGroundKMH">Maximum acceleration on ground for this aircraft</param>
        public LightAircraft(string modelName,
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
                $"Type: Light aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAirKMH}\n" +
                $"Acceleration: {AccelerationInAirKMH}\n");
        }
    }
}

