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
        /// <param name="maxSpeedInAirKMH">Maximum in-air speed (Km/h).</param>
        /// <param name="accelerationInAirKMH">The accleration in-air (Km/h).</param>
        /// <param name="maxSpeedOnGroundKMH">Maximum on-ground speed (Km/h).</param>
        /// <param name="accelerationOnGroundKMH">acceleration on ground (Km/h).</param>
        public LargeAircraft(string modelName,
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
                $"Type: Large aircraft\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAirKMH}\n" +
                $"Acceleration: {AccelerationInAirKMH}\n");
        }
    }
}

