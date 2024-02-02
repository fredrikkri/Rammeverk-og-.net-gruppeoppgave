using System;
using System.Collections.Generic;

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
        public void AddHistoryToAircraft(string location, string message)
        {
            history.Add(DateTime.Now, (location + message));
        }
        /// <summary>
        /// Returns a string that contains the previous location of the plane. Value of the return can be "Gate", "Runway" or "Taxiway".
        /// </summary>
        /// <returns></returns>
        public string CheckPreviousLocation()
        {
            var last = history.Values.Last();
            string[] singleWord = last.Split(" ");
            string firstWord = singleWord.First();
            return firstWord;
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
                Console.WriteLine($"{line.Key}, {line.Value}");
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
        /// <summary>
        /// reads trough the list of the aircrafts history and prints out the log for that day
        /// </summary>
        public void PrintAircraftHistoryForDay(int year, int month, int day)
        {
            DateTime DayToCheckStart = new DateTime(year, month, day, 0, 0, 0);
            DateTime DayToCheckEnd = new DateTime(year, month, day, 23, 59, 59);
            foreach (var line in history)
            {
                if (DayToCheckStart <= line.Key && line.Key <= DayToCheckEnd)
                {
                    Console.WriteLine($"Time: {line.Key}, {line.Value}");                  
                }
            }
        }
    }
}