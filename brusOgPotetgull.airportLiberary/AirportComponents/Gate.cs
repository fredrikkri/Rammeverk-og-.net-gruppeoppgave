using System;
using System.Linq;
using System.Reflection;
using brusOgPotetgull.airportLiberary.AircraftTypes;
using brusOgPotetgull.airportLiberary.CustomExceptions;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// The gate class is defining how a gate is designed.
    /// </summary>
	public class Gate
    {
        private static int idCounter = 1;
        private int id;
        private bool isOpen;
        private bool isAvailable;
        // Variable under baserer seg på at en flytype har en unik id med int og ikke en string-verdi. Se mappe med flytyper.
        private List<int> legalAircraftTypesId;
        private string? airportLocation;

        /// <summary>
        /// Creates a gate.
        /// </summary>
        /// <param name="gateName">The name of the gate.</param>
		public Gate(string gateName)
        {
            // (dosnetCore, 2020) 
            id = idCounter++;
            this.Id = id;
            this.GateName = gateName;
            this.isOpen = true;
            this.isAvailable = true;
            this.legalAircraftTypesId = new List<int>();

        }

        public int Id { get; private set; }
        public string GateName { get; private set; }
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Updates the information for which airport the gate is located at.
        /// </summary>
        /// <param name="airportName">Name of the airport that the gate will be located at.</param>
        public void UpdateGateLocation(string airportName)
        {
            airportLocation = airportName;
        }

        /// <summary>
        /// Prints out the information about the gate.
        /// </summary>
        public void PrintGateInformation()
        {
            Console.Write($"\nGateNr: {Id}\n" +
                $"Name: {GateName}\n" +
                $"IsOpen: {isOpen}\n" +
                $"Airport location: {airportLocation}\n");
            Console.Write("Legal aircraftstypes: ");
            foreach (int typeId in legalAircraftTypesId)
            {
                Console.Write($"{typeId} ");
            }
            Console.Write("\n");
        }

        /// <summary>
        /// Gets the id and the nickname for the airport that this gate is located at.
        /// </summary>
        /// <returns>The id and the nickname combined as string.</returns>
        private string GetAirportNameAndGateName()
        {
            string returnString = (string)(airportLocation + ", " + GateName + ", Id: " + Id);
            return returnString;
        }

        /// <summary>
        /// Adds an aircraft that will be able to use the gate.
        /// </summary>
        /// <param name="aircraftType">An Enum that represents the id of an aircraftType that you want to enable accsess for the gate.</param>
        public void AddAircraftAllowedAtGate(AircraftType aircraftType)
        {
            if (legalAircraftTypesId.Contains((int)aircraftType))
            {
                throw new DuplicateOfContentException($"{aircraftType} already exists in the list of allowed aircrafts for gate with id: '{Id}'.");
            }
            legalAircraftTypesId.Add((int)aircraftType);
        }

        /// <summary>
        /// Adds multiple aircrafts that will be granted access to use the gate.
        /// </summary>
        /// <param name="aircraftTypeIds">A list of ids of aircrafts that you want to enable accsess for the gate</param>
        public void AddMultipleAircraftAllowedAtGate(List<AircraftType> aircraftTypeIds)
        {
            foreach (int typeId in aircraftTypeIds)
            {
                if (legalAircraftTypesId.Contains(typeId))
                {
                    throw new DuplicateOfContentException($"Aircraft with id '{typeId}' already exists in the list of allowed aircrafts for gate with id: '{Id}'.");
                }
                legalAircraftTypesId.Add(typeId);
            }
        }

        /// <summary>
        /// Grants all of the existing aircrafttypes access to use the gate.
        /// </summary>
        public void MakeAllAircraftTypesAllowedForThisGate()
        {
            int numberOfAircraftTypes = 6;
            for (int i = 0; i <= numberOfAircraftTypes; i++)
            {
                //AddAircraftAllowedAtGate(i);
                if (!legalAircraftTypesId.Contains(i))
                {
                    legalAircraftTypesId.Add(i);
                }
            }
        }

        /// <summary>
        /// Removes an aircraft from being able to use the gate.
        /// </summary>
        /// <param name="aircraftTypeId">The id of an type of aircraft that you want to deny accsess to the gate.</param>
        public void RemoveAircraftAllowedAtGate(AircraftType aircraftTypeId)
        {
            if (!legalAircraftTypesId.Contains((int)aircraftTypeId))
            {
                throw new InvalidOperationException($"Aircraft with type {aircraftTypeId} cannot be removed from the list of legal aircrafts for gate with id: '{Id}', because it does not exist in the list.");
            }
            legalAircraftTypesId.Remove((int)aircraftTypeId);
        }

        /// <summary>
        /// Checks if an aircraft can use the gate.
        /// </summary>
        /// <param name="aircraft">The aircraft you want to check if it has access or not.</param>
        /// <returns>'true' if it has access or 'false' if it does not.</returns>
        public bool CheckAircraftAllowedAtGate(Aircraft aircraft)
        {
            if (legalAircraftTypesId.Contains(aircraft.AircraftTypeId))
            {
                return true;
            }

            else
            {
                return false;
            }
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
            {
                Console.Write($"Gate with id: {Id}, is already booked. Aircraft with id: '{aircraft.TailNumber}' cannot book this gate.");
            }
        }
    }
}

