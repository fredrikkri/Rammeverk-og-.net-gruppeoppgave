//using System;
//using System.Reflection;

//namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
//{
//    /// <summary>
//    /// Cargo aircraft is an aircrafttype that has its mainpourpose to carry cargo.
//    /// </summary>
//	public class CargoAircraft : Aircraft
//	{
//        private int aircraftTypeId = 5;
//        // (GeeksforGeeks, 2023)

//        /// <summary>
//        /// Creates an cargo-aircraft.
//        /// </summary>
//        /// <param name="modelName">What the model of the aircraft is called.</param>
//        /// <param name="maxSpeedInAir">Maximum in-air speed (Kp/h).</param>
//        /// <param name="accelerationInAir">The accleration in-air (Kp/h).</param>
//        /// <param name="maxSpeedOnGround">Maximum on-ground speed (Kp/h).</param>
//        /// <param name="accelerationOnGround">acceleration on ground (Kp/h).</param>
//        public CargoAircraft(string modelName,
//            int maxSpeedInAir,
//            int accelerationInAir,
//            int maxSpeedOnGround,
//            int accelerationOnGround) :
//            base(modelName,
//                maxSpeedInAir,
//                accelerationInAir,
//                maxSpeedOnGround,
//                accelerationOnGround)
//		{
//            this.AircraftTypeId = aircraftTypeId;
//		}

//        public new int AircraftTypeId { get; private set; }
//        // (Microsoft , 2021)

//        /// <summary>
//        /// Prints the information about the aircraft as a string.
//        /// </summary>
//        override public void PrintAircraftInformation()
//        {
//            Console.Write($"\nId: {TailNumber}\n" +
//                $"Model: {ModelName}\n" +
//                $"Type: Cargo aircraft\n" +
//                $"Type(id): {AircraftTypeId}\n" +
//                $"Out of service: {OutOfService}\n" +
//                $"Max speed: {MaxSpeedInAir}\n" +
//                $"Acceleration: {AccelerationInAir}\n");
//        }

//    }
//}

