using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Aircraft
    {
        private static int idCounter = 1;
        private int id;
        private int aircraftTypeId = 0;
        private bool outOfService = false;
        // (Trupja, 2023)
        Dictionary<DateTime, string> history;

        public Aircraft(string model,
            int maxSpeedInAir,
            int accelerationInAir,
            int maxSpeedOnGround,
            int accelerationOnGround)
		{
            // (dosnetCore, 2020) 
            id = idCounter ++;
            this.Id = id;
            this.AircraftTypeId = aircraftTypeId;
            this.OutOfService = outOfService;
            this.Model = model;
            history = new Dictionary<DateTime, string>();
            this.MaxSpeedInAir = maxSpeedInAir;
            this.AccelerationInAir = accelerationInAir;
            this.MaxSpeedOnGround = maxSpeedOnGround;
            this.AccelerationOnGround = accelerationOnGround;

        }
        public int Id { get; private set; }
        public int AircraftTypeId { get; private set; }
        public bool OutOfService { get; private set; }
        public string Model { get; private set; }
        public int MaxSpeedInAir { get; private set; }
        public int AccelerationInAir { get; private set; }
        public int MaxSpeedOnGround { get; private set; }
        public int AccelerationOnGround { get; private set; }

        /// <summary>
        /// Prints the information about the Aircraft.
        /// </summary>
        virtual public void PrintAircraftInformation()
        {
            Console.Write($"\nId: {Id}\n" +
                $"Model: {Model}\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }
        /// <summary>
        /// logging an event to the history of the aircraft.
        /// 'time' is when the event took place.
        /// 'message' is where the plane was and the action of the plane.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="message"></param>
        public void AddHistoryToAircraft(string time, string message)
        {
            history.Add(DateTime.Now, time + message);
        }
        /// <summary>
        /// Prints the full history of the plane.
        /// </summary>
        public void PrintFullAircraftHistory()
        {
            Console.Write($"\n\n\tHistory for aircraft whith id: '{this.Id}'\n");
            // (Nagel, 2022, s. 216)
            foreach ( var line in history)
            {
                Console.WriteLine($"Time: {line.Key}, {line.Value}");
            }
        }
        /// <summary>
        /// Changes the variable 'bool outOfService' from false to true, but only if the status already is set to 'false'. 
        /// </summary>
        public void SetAircraftOutOfService()
        {
            if (OutOfService == false)
            {
                OutOfService = true;
            } else
            {
                Console.Write("\nThe aircraft is already out of service.\n");
            }
        }
        /// <summary>
        /// Changes the variable 'bool outOfService' from "true" to "false", but only if the status already is set to 'true'. 
        /// </summary>
        public void SetAircraftInOperation()
        {
            if (OutOfService == true)
            {
                OutOfService = false;
            }
            else
            {
                Console.Write("\nThe aircraft is already in operation.\n");
            }
        }
    }
}