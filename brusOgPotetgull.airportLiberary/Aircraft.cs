using System;
using System.Collections.Generic;
using brusOgPotetgull.airportLiberary.CustomExceptions;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The Aircraft-class is a blueprint for how an aircraft would look like. 
    /// </summary>
	public class Aircraft
    {
        private static int idCounter = 1;
        private int tailNumber;
        private int aircraftTypeId = 0;
        private bool outOfService = false;
        // (Trupja, 2023)
        
        List<KeyValuePair<DateTime, string>> history;

        /// <summary>
        /// Creates an aircraft.
        /// </summary>
        /// <param name="modelName">What the model of the aircraft is called.</param>
        /// <param name="maxSpeedInAir">Maximum in-air speed (Kp/h).</param>
        /// <param name="accelerationInAir">The accleration in-air (Kp/h).</param>
        /// <param name="maxSpeedOnGround">Maximum on-ground speed (Kp/h).</param>
        /// <param name="accelerationOnGround">acceleration on ground (Kp/h).</param>
        public Aircraft(string modelName,
            int maxSpeedInAir,
            int accelerationInAir,
            int maxSpeedOnGround,
            int accelerationOnGround)
		{
            // (dosnetCore, 2020) 
            tailNumber = idCounter ++;
            this.TailNumber = tailNumber;
            this.AircraftTypeId = aircraftTypeId;
            this.OutOfService = outOfService;
            this.ModelName = modelName;
            history = new List<KeyValuePair<DateTime, string>>();
            this.MaxSpeedInAir = maxSpeedInAir;
            this.AccelerationInAir = accelerationInAir;
            this.MaxSpeedOnGround = maxSpeedOnGround;
            this.AccelerationOnGround = accelerationOnGround;
        }

        public int TailNumber { get; private set; }
        public int AircraftTypeId { get; private set; }
        public bool OutOfService { get; private set; }
        public string ModelName { get; private set; }
        public int MaxSpeedInAir { get; private set; }
        public int AccelerationInAir { get; private set; }
        public int MaxSpeedOnGround { get; private set; }
        public int AccelerationOnGround { get; private set; }

        /// <summary>
        /// Prints the information about the Aircraft.
        /// </summary>
        virtual public void PrintAircraftInformation()
        {
            Console.Write($"\nId: {TailNumber}\n" +
                $"Model: {ModelName}\n" +
                $"Type(id): {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }

        // TODO: Undersøke hvordan vi kan hente ulike TimeStamp fremfor DateTime, slik at: for hver gang et aircraft endrer lokasjon, registreres det TimeStamp -> og tilhørende location + message
        /// <summary>
        /// logging an event to the history of the aircraft.
        /// </summary>
        /// <param name="time">When the event took place.</param>
        /// <param name="location">The location of the plane.</param>
        /// <param name="message">The action of the plane.</param>
        public void AddHistoryToAircraft(DateTime time, string location, string message)
        {
            foreach (KeyValuePair<DateTime, string> pair in history)
            {
                if (pair.Key == time && pair.Value == (location + message))
                {
                    throw new DuplicateOfContentException($"{time}, {location} {message} could not be added to history for plane with talenumber: '{TailNumber}'. The excact same line of history already exists for this plane.");
                }
            }
            history.Add(new KeyValuePair<DateTime, string>(time, (location + message)));
            
        }

        /// <summary>
        /// Prints the full history of the plane.
        /// </summary>
        public void PrintFullAircraftHistory()
        {
            Console.Write($"\n\n\tHistory for aircraft whith id: '{this.TailNumber}' and model: '{this.ModelName}'\n");
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
                throw new InvalidOperationException($"bool variable 'OutOfService' for aircraft with talenumber '{tailNumber}' is already set to 'true'.");
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
                throw new InvalidOperationException($"bool variable 'OutOfService' for aircraft with talenumber '{tailNumber}' is already set to 'false'.");
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
            Console.Write($"\n\n\tHistory for aircraft: '{ModelName}' and id: '{TailNumber}'\n\tTimespace: '{DayToCheckStart}' - '{DayToCheckEnd}'.\n\n");
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