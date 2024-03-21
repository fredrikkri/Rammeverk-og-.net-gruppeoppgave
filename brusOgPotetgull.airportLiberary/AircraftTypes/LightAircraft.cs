//using System;
//using System.Reflection;

//namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
//{
//    /// <summary>
//    /// Light aircraft is a smaller aircraft. It can be an private plane.
//    /// </summary>
//	public class LightAircraft : Aircraft
//	{
//        private int aircraftTypeId = 1;
//        // (GeeksforGeeks, 2023)

//        /// <summary>
//        /// Creates an light aircraft.
//        /// </summary>
//        /// <param name="modelName">Name of the model for this aircraft</param>
//        /// <param name="maxSpeedInAir">Maximum speed in air for this aircraft (Kp/h)</param>
//        /// <param name="accelerationInAir">Maximum acceleration in air for this aircraft (Kp/h)</param>
//        /// <param name="maxSpeedOnGround">Maximum speed on ground for this aircraft (Kp/h)</param>
//        /// <param name="accelerationOnGround">Maximum acceleration on ground for this aircraft (Kp/h)</param>
//        public LightAircraft(string modelName,
//            int maxSpeedInAir,
//            int accelerationInAir,
//            int maxSpeedOnGround,
//            int accelerationOnGround) :
//            base(modelName,
//                maxSpeedInAir,
//                accelerationInAir,
//                maxSpeedOnGround,
//                accelerationOnGround)
//        {
//            this.AircraftTypeId = aircraftTypeId;
//        }

//        public new int AircraftTypeId { get; private set; }
//        // (Microsoft , 2021)

//        /// <summary>
//        /// Prints the information about the aircraft.
//        /// </summary>
//        override public void PrintAircraftInformation()
//        {
//            Console.Write($"\nId: {TailNumber}\n" +
//                $"Model: {ModelName}\n" +
//                $"Type: Light aircraft\n" +
//                $"Type(id): {AircraftTypeId}\n" +
//                $"Out of service: {OutOfService}\n" +
//                $"Max speed: {MaxSpeedInAir}\n" +
//                $"Acceleration: {AccelerationInAir}\n");
//        }
//    }
//}

