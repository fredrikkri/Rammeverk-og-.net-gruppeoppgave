using System;
using System.Collections.Generic;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// Aircraft class is a blueprint for how an aircraft would look like. 
    /// </summary>
	public class Aircraft
    {
        private static int idCounter = 1;
        private int id;
        private int aircraftTypeId = 0;
        private bool outOfService = false;
        // (Trupja, 2023)
        
        List<KeyValuePair<DateTime, string>> history;

        /// <summary>
        /// Creates an aircraft.
        /// </summary>
        /// <param name="model">What the model of the aircraft is called.</param>
        /// <param name="maxSpeedInAir">Maximum in-air speed (Km/h).</param>
        /// <param name="accelerationInAir">The accleration in-air (Km/h).</param>
        /// <param name="maxSpeedOnGround">Maximum on-ground speed (Km/h).</param>
        /// <param name="accelerationOnGround">acceleration on ground (Km/h).</param>
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
            history = new List<KeyValuePair<DateTime, string>>();
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
        /// </summary>
        /// <param name="time">When the event took place.</param>
        /// <param name="location">The location of the plane.</param>
        /// <param name="message">The action of the plane.</param>
        public void AddHistoryToAircraft(DateTime time, string location, string message)
        {
            history.Add(new KeyValuePair<DateTime, string>(time, (location + message)));
            
        }

        /// <summary>
        /// Prints the full history of the plane.
        /// </summary>
        public void PrintFullAircraftHistory()
        {
            Console.Write($"\n\n\tHistory for aircraft whith id: '{this.Id}' and model: '{this.Model}'\n");
            // (Nagel, 2022, s. 216)
            foreach ( var line in history)
            {
                Console.WriteLine($"{line.Key}, {line.Value}");
            }
        }

        /// <summary>
        /// Changes the variable 'bool outOfService' from false to true, but only if the status already is set to 'false'. 
        /// </summary>
        private void SetAircraftOutOfService()
        {
            if (OutOfService == false)
            {
                OutOfService = true;
            } 
            
            else
            {
                Console.Write("\nThe aircraft is already out of service.\n");
            }
        }

        /// <summary>
        /// Changes the variable 'bool outOfService' from "true" to "false", but only if the status already is set to 'true'. 
        /// </summary>
        private void SetAircraftInOperation()
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
        /// Reads trough the list of the aircrafts history and prints out the log for that day
        /// </summary>
        /// <param name="year">The year it checks</param>
        /// <param name="month">The month it checks</param>
        /// <param name="day">The day it checks</param>
        public void PrintAircraftHistoryForDay(int year, int month, int day)
        {
            DateTime DayToCheckStart = new DateTime(year, month, day, 0, 0, 0);
            DateTime DayToCheckEnd = new DateTime(year, month, day, 23, 59, 59);
            Console.Write($"\n\n\tHistory for aircraft: '{Model}' and id: '{Id}'\n\tTimespace: '{DayToCheckStart}' - '{DayToCheckEnd}'.\n\n");
            foreach (KeyValuePair<DateTime, string> line in history)
            {
                if (DayToCheckStart <= line.Key && line.Key <= DayToCheckEnd)
                {
                    Console.WriteLine($"Time: {line.Key}, {line.Value}");                  
                }
            }
        }
    }
}