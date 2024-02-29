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
        /// <param name="maxSpeedInAirKPH">Maximum speed in air for this aircraft (Kp/h)</param>
        /// <param name="accelerationInAirKPH">Maximum acceleration in air for this aircraft (Kp/h)</param>
        /// <param name="maxSpeedOnGroundKPH">Maximum speed on ground for this aircraft (Kp/h)</param>
        /// <param name="accelerationOnGroundKPH">Maximum acceleration on ground for this aircraft (Kp/h)</param>
        public ShortMediumAircraft(string modelName,
            int maxSpeedInAirKPH,
            int accelerationInAirKPH,
            int maxSpeedOnGroundKPH,
            int accelerationOnGroundKPH) :
            base(modelName,
                maxSpeedInAirKPH,
                accelerationInAirKPH,
                maxSpeedOnGroundKPH,
                accelerationOnGroundKPH)
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
            Console.Write($"\nId: {Halenummer}\n" +
                $"Model: {ModelName}\n" +
                $"Type: Short-medium aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAirKPH}\n" +
                $"Acceleration: {AccelerationInAirKPH}\n");
        }
    }
}

