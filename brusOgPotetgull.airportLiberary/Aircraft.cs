using BrusOgPotetgull.AirportLiberary.CustomExceptions;
using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using System.Text;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The Aircraft-class is a blueprint for how an aircraft would look like. 
    /// </summary>
	public class Aircraft
    {
        private static int idCounter = 1;
        private int tailNumber;
        private bool outOfService = false;
        // (Trupja, 2023)
        private List<KeyValuePair<DateTime, string>> history;

        /// <summary>
        /// Creates an aircraft.
        /// </summary>
        /// <param name="name">What the aircraft is called.</param>
        /// <param name="aircraftType">The model of the aircraft.</param>
        /// <param name="maxSpeedInAir">Maximum in-air speed (Kp/h).</param>
        /// <param name="accelerationInAir">The accleration in-air (Kp/h).</param>
        /// <param name="maxSpeedOnGround">Maximum on-ground speed (Kp/h).</param>
        /// <param name="accelerationOnGround">acceleration on ground (Kp/h).</param>
        public Aircraft(string name, AircraftType aircraftType,
            int maxSpeedInAir,
            int accelerationInAir,
            int maxSpeedOnGround,
            int accelerationOnGround)
		{
            // (dosnetCore, 2020) 
            tailNumber = idCounter ++;
            this.TailNumber = tailNumber;
            this.AircraftType = aircraftType.Name;
            this.AircraftTypeId = aircraftType.TypeId;
            this.OutOfService = outOfService;
            this.Name = name;
            history = new List<KeyValuePair<DateTime, string>>();
            this.MaxSpeedInAir = maxSpeedInAir;
            this.AccelerationInAir = accelerationInAir;
            this.MaxSpeedOnGround = maxSpeedOnGround;
            this.AccelerationOnGround = accelerationOnGround;
        }

        /// <summary>
        /// Gets aircraft tail number
        /// </summary>
        public int TailNumber { get; private set; }

        /// <summary>
        /// Gets aircraft type
        /// </summary>
        public string AircraftType { get; private set; }
        
        /// <summary>
        /// Gets aircraft type Id
        /// </summary>
        public int AircraftTypeId { get; private set; }

        /// <summary>
        /// Gets if aircraft is in service with bool
        /// </summary>
        public bool OutOfService { get; private set; }

        /// <summary>
        /// Gets aircraft name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets airraft max speed in air
        /// </summary>
        public int MaxSpeedInAir { get; private set; }

        /// <summary>
        /// Gets aircraft acceleration in air
        /// </summary>
        public int AccelerationInAir { get; private set; }

        /// <summary>
        /// Gets aircraft max speed on ground
        /// </summary>
        public int MaxSpeedOnGround { get; private set; }

        /// <summary>
        /// Gets aircraft acceleration on ground
        /// </summary>
        public int AccelerationOnGround { get; private set; }

        /// <summary>
        /// Prints the information about the Aircraft.
        /// </summary>
        virtual public void PrintAircraftInformation()
        {
            Console.Write($"\nId: {TailNumber}\n" +
                $"Name: {Name}\n" +
                $"AircraftType: {AircraftType}\n" +
                $"AircraftTypeId: {AircraftTypeId}\n" +
                $"Out of service: {OutOfService}\n" +
                $"Max speed: {MaxSpeedInAir}\n" +
                $"Acceleration: {AccelerationInAir}\n");
        }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the aircraft.</returns>
        public override string ToString()
        {
            return $"\nId: {TailNumber} " +
                $"\nName: {Name} " +
                $"\nAircraftType: {AircraftType}\n";
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
            //foreach (KeyValuePair<DateTime, string> pair in history)
            //    if (pair.Key == time && pair.Value == (location + message))
            //        throw new DuplicateOfContentException($"{time}, {location} {message} could not be added to history for plane with talenumber: '{TailNumber}'. The excact same line of history already exists for this plane. ");

            history.Add(new KeyValuePair<DateTime, string>(time, (location + message))); 
        }

        /// <summary>
        /// Prints the full history of the plane.
        /// </summary>
        public void PrintFullAircraftHistory()
        {
            Console.Write($"\n\n\tHistory for aircraft with id: '{TailNumber}' and model: '{Name}'\n");
            // (Nagel, 2022, s. 216)
            foreach ( var line in history)
                Console.WriteLine($"{line.Key}, {line.Value}");
        }

        /// <summary>
        /// Gets the history of the aircraft
        /// </summary>
        /// <returns>returns aircraft history in string</returns>
        public string GetFullAircraftHistory()
        {
            StringBuilder historyText = new();
            historyText.AppendLine($"\nHistory for aircraft with id: '{TailNumber}' and model: '{Name}':\n");
            foreach (var entry in history)
            {
                historyText.AppendLine($"{entry.Key.ToString("yyyy-MM-dd HH:mm:ss")}: {entry.Value}");
            }
            return historyText.ToString();
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
            Console.Write($"\n\n\tHistory for aircraft: '{Name}' and id: '{TailNumber}'\n\tTimespace: '{DayToCheckStart}' - '{DayToCheckEnd}'.\n\n");
            foreach (KeyValuePair<DateTime, string> line in history)
                if (DayToCheckStart <= line.Key && line.Key <= DayToCheckEnd)
                    Console.WriteLine($"Time: {line.Key}, {line.Value}");                  
        }

        /// <summary>
        /// Changes the variable 'bool outOfService' from false to true, but only if the status already is set to 'false'. 
        /// </summary>
        private void SetAircraftOutOfService()
        {
            if (OutOfService == true)
                throw new InvalidOperationException($"bool variable 'OutOfService' for aircraft with talenumber '{tailNumber}' is already set to 'true'.");

            OutOfService = true;
        }

        /// <summary>
        /// Changes the variable 'bool outOfService' from "true" to "false", but only if the status already is set to 'true'. 
        /// </summary>
        private void SetAircraftInOperation()
        {
            if (OutOfService == false)
                throw new InvalidOperationException($"bool variable 'OutOfService' for aircraft with talenumber '{tailNumber}' is already set to 'false'.");

            OutOfService = false;
        }
    }
}