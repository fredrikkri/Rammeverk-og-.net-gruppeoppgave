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
        /// <param name="maxSpeedInAirKPH">Maximum speed in air for this aircraft (Kp/h)</param>
        /// <param name="accelerationInAirKPH">Maximum acceleration in air for this aircraft (Kp/h)</param>
        /// <param name="maxSpeedOnGroundKPH">Maximum speed on ground for this aircraft (Kp/h)</param>
        /// <param name="accelerationOnGroundKPH">Maximum acceleration on ground for this aircraft (Kp/h)</param>
        public LightAircraft(string modelName,
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
                $"Type: Light aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAirKPH}\n" +
                $"Acceleration: {AccelerationInAirKPH}\n");
        }
    }
}

