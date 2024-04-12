using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary.CustomExceptions;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The gate class is used to define how a gate is designed.
    /// It holds fields for the status of the gate and allowed aircraft types.
    /// </summary>
	public class Gate
    {
        private static int idCounter = 1;   
        private int id;
        private bool isOpen;
        private bool isAvailable;
        private List<int> legalAircraftTypesId;
        private string? airportLocation;

        /// <summary>
        /// Creates a gate.
        /// </summary>
		public Gate(string name, Airport airport)
        {
            // (dosnetCore, 2020) 
            id = idCounter++;
            this.Id = id;
            this.Name = name;
            this.isOpen = true;
            this.isAvailable = true;
            this.legalAircraftTypesId = new List<int>();
            airport.AddGateToList(this);

        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Updates the airport the gate is located at.
        /// </summary>
        /// <param name="airportName">Name of the airport that the gate will be updated to.</param>
        public void UpdateLocation(string airportName)
        {
            airportLocation = airportName;
        }

        /// <summary>
        /// Prints out the information about the gate.
        /// </summary>
        public void PrintGateInformation()
        {
            Console.Write($"\nGateNr: {Id}\n" +
                $"Name: {Name}\n" +
                $"IsOpen: {isOpen}\n" +
                $"Airport location: {airportLocation}\n");
            Console.Write("Legal aircraftstypes: ");
            foreach (int typeId in legalAircraftTypesId)
                Console.Write($"{typeId} ");
            Console.Write("\n");
        }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the Gate.</returns>
        public override string ToString()
        {
            return $"\nGateNr: {Id}\n" +
                $"Name: {Name}\n";
        }

        /// <summary>
        /// Returns the airport location aswell as the gatename and id.
        /// </summary>
        /// <returns>String that contain information about the gate.</returns>
        private string GetAirportNameAndGateName() => (string)(airportLocation + ", Gate-id: " + Id + ", Name: " + Name);

        /// <summary>
        /// Adds an aircraft that will be able to use the gate.
        /// </summary>
        /// <param name="aircraftType">An Enum that represents the id of an aircraftType that you want to enable accsess for the gate.</param>
        public void AddAircraftAllowedAtGate(AircraftType aircraftType)
        {
            legalAircraftTypesId.Add(aircraftType.TypeId);
        }

        /// <summary>
        /// Adds multiple aircrafts that will be granted access to use the gate.
        /// </summary>
        /// <param name="aircraftTypeIds">A list of ids of aircrafts that you want to enable accsess for the gate</param>
        public void AddMultipleAircraftAllowedAtGate(List<AircraftType> aircraftTypeIds)
        {
            foreach (AircraftType element in aircraftTypeIds)
            {
                if (legalAircraftTypesId.Contains(element.TypeId))
                    throw new DuplicateOfContentException($"Aircraft with id '{element.TypeId}' already exists in the list of allowed aircrafts for gate with id: '{Id}'.");
                legalAircraftTypesId.Add(element.TypeId);
            }
        }

        /// <summary>
        /// Grants all of the existing aircrafttypes access to use the gate.
        /// </summary>
        public void MakeAllAircraftTypesAllowedForThisGate()
        {
            int numberOfAircraftTypes = 6;
            for (int i = 0; i <= numberOfAircraftTypes; i++)
                //AddAircraftAllowedAtGate(i);
                if (!legalAircraftTypesId.Contains(i))
                    legalAircraftTypesId.Add(i);
        }

        /// <summary>
        /// Removes an aircraft from being able to use the gate.
        /// </summary>
        /// <param name="aircraftTypeId">The id of an type of aircraft that you want to deny accsess to the gate.</param>
        public void RemoveAircraftAllowedAtGate(AircraftType aircraftTypeId)
        {
            if (!legalAircraftTypesId.Contains(aircraftTypeId.TypeId))
                throw new InvalidOperationException($"Aircraft with type {aircraftTypeId.TypeId} cannot be removed from the list of legal aircrafts for gate with id: '{Id}', because it does not exist in the list.");
            legalAircraftTypesId.Remove(aircraftTypeId.TypeId);
        }

        /// <summary>
        /// Checks if an aircraft can use the gate.
        /// </summary>
        /// <param name="aircraft">The aircraft you want to check if it has access or not.</param>
        /// <returns>'true' if it has access or 'false' if it does not.</returns>
        public bool CheckAircraftAllowedAtGate(Aircraft aircraft)
        {
            if (legalAircraftTypesId.Contains(aircraft.AircraftTypeId))
                return true;
            else
                return false;
        }

        /// <summary>
        /// An aircraft leaves the gate.
        /// And saves it in the aircrafthistory for the aircraft.
        /// The gate is now avalible for other aircrafts.
        /// </summary>
        /// <param name="aircraft">The aircraft that is going to leave the gate.</param>
        /// <param name="time">Used to log the history for the aircraft.</param>
        public void LeaveGate(Aircraft aircraft, DateTime time)
        {
            isAvailable = true;
            aircraft.AddHistoryToAircraft(time, GetAirportNameAndGateName(), ", Left Gate");
        }

        /// <summary>
        /// An aircraft occupies a gate.
        /// And saves it in aircrafthistory for the aircraft.
        /// The gate is now unavalible for other aircrafts to use it.
        /// </summary>
        /// <param name="aircraft">The aircraft that is going to book the gate.</param>
        /// <param name="time">Used to log the history for the aircraft.</param>
        public void BookGate(Aircraft aircraft, DateTime time)
        {

            if (isAvailable == true)
            {
                isAvailable = false;
                aircraft.AddHistoryToAircraft(time, GetAirportNameAndGateName(), ", Arrived at Gate");
            }
            else
                Console.Write($"Gate with id: {Id}, is already booked. Aircraft with id: '{aircraft.TailNumber}' cannot book this gate.");
        }
    }
}

