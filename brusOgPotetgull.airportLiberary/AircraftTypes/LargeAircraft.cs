using System;
using System.Reflection;

namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
{
    /// <summary>
    /// Large Aircraft is a bigger aircraft with bigger capacity.
    /// </summary>
	public class LargeAircraft : Aircraft
	{
        private int aircraftTypeId = 4;
        // (GeeksforGeeks, 2023)

        /// <summary>
        /// Creates an large aircraft.
        /// </summary>
        /// <param name="modelName">What the model of the aircraft is called.</param>
        /// <param name="maxSpeedInAirKPH">Maximum in-air speed (Kp/h).</param>
        /// <param name="accelerationInAirKPH">The accleration in-air (Kp/h).</param>
        /// <param name="maxSpeedOnGroundKPH">Maximum on-ground speed (Kp/h).</param>
        /// <param name="accelerationOnGroundKPH">acceleration on ground (Kp/h).</param>
        public LargeAircraft(string modelName,
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
                $"Type: Large aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAirKPH}\n" +
                $"Acceleration: {AccelerationInAirKPH}\n");
        }
    }
}

