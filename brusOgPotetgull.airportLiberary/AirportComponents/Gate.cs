using System;
using System.Linq;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Gate
	{
        private static int idCounter = 1;
        private int id;
        private bool isOpen;
        private bool isAvailable;
        // Variable under baserer seg på at en flytype har en unik id med int og ikke en string-verdi. Se mappe med flytyper.
        private List<int> legalAircraftTypesId;

        // bruker egentlig ikke isOpen ????
		public Gate(string gateName, Airport locatedAtAirport)
		{
            // (dosnetCore, 2020) 
            id = idCounter++;
            this.Id = id;
            this.GateName = gateName;
            this.LocatedAtAirport = locatedAtAirport;
            this.isOpen = true;
            this.isAvailable = true;
            this.legalAircraftTypesId = new List<int>();

        }
        public int Id { get; private set; }
        public string GateName { get; private set; }
        public Airport LocatedAtAirport { get; private set; }
        public bool IsAvailable { get; private set; }

        /// <summary>
        /// Prints the information about the gate.
        /// </summary>
        public void PrintGateInformation()
        {
            Console.Write($"\nGateNr: {Id}\n" +
                $"Name: {GateName}\n" +
                $"IsOpen: {isOpen}\n" +
                $"Name: {LocatedAtAirport.AirportCode}\n");
            Console.Write("Legal aircraftstypes: ");
            foreach (int typeId in legalAircraftTypesId)
            {
                Console.Write($"{typeId} ");
            }
        }
        /// <summary>
        /// returns the id and the nickname for the airport that this gate is located at.
        /// </summary>
        /// <returns></returns>
        public string GetIdAndAirportNickname()
        {
            string returnString = (string) (Id + " " + LocatedAtAirport.AirportCode);
            return returnString;
        }
        /// <summary>
        /// Adds an aircraft that will be able to use the gate.
        /// Parameter 'aircraftTypeId' is the id of an type of aircraft that you want to enable accsess for the gate.
        /// </summary>
        /// <param name="aircraftTypeId"></param>
        public void AddAircraftAllowedAtGate(int aircraftTypeId)
        {
            if (!legalAircraftTypesId.Contains(aircraftTypeId))
            {
                legalAircraftTypesId.Add(aircraftTypeId);
            }
            else
            {
                Console.Write($"{aircraftTypeId} is already in list of legal aicrafts for this gate.");
            }
        }
        /// <summary>
        /// Adds multiple aircrafts that will be able to use the gate.
        /// Parameter 'aircraftTypeIds' is a list of ids of aircrafts that you want to enable accsess for the gate
        /// </summary>
        /// <param name="aircraftTypeIds"></param>
        public void AddMultipleAircraftAllowedAtGate(List<int> aircraftTypeIds)
        {
            foreach (int typeId in aircraftTypeIds)
            {
                if (!legalAircraftTypesId.Contains(typeId))
                {
                    legalAircraftTypesId.Add(typeId);                    
                }
                else
                {
                    Console.Write($"{typeId} is already in list of legal aicrafts for this gate.");
                }
            }
        }
        /// <summary>
        /// Removes an aircraft from being able to use the gate.
        /// Parameter 'aircraftTypeId' is the id of an type of aircraft that you want to deny accsess to the gate.
        /// </summary>
        /// <param name="aircraft"></param>
        public void RemoveAircraftAllowedAtGate(int aircraftTypeId)
        {
            if (legalAircraftTypesId.Contains(aircraftTypeId))
            {
                legalAircraftTypesId.Remove(aircraftTypeId);
            }
            else
            {
                Console.Write($"Aircraft with type {aircraftTypeId} cannot be removed from the list of legal aircrafts for this gate because it does not exist in the list.");
            }
        }
        /// <summary>
        /// Checks if an aircraft can use the gate.
        /// Parameter 'aircraft' is the aircraft you want to check if it has access or not.
        /// Returns 'true' if it has access or 'false' if it does not.
        /// </summary>
        /// <param name="aircraft"></param>
        /// <returns></returns>
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
        ///  An aircraft leaves the gate. And saves it in aircrafthistory. The gate is now avalible for other aircrafts.
        ///  Parameter 'aircraft' is the plane that is going to leave the gate.
        /// </summary>
        /// <param name="aircraft"></param>
        public void leaveGate(Aircraft aircraft)
        {
            isAvailable = true;
            aircraft.AddHistoryToAircraft("Gate " + GetIdAndAirportNickname(), ", Left Gate");
        }
        /// <summary>
        /// An aircraft occupies a gate. And saves it in aircrafthistory. The gate is now unavalible for other aircrafts to use it.
        /// Parameter 'aircraft' is the plane that is going to book the gate.
        /// </summary>
        /// <param name="aircraft"></param>
        public void bookGate(Aircraft aircraft)
        {
            if (isAvailable == true)
            {
                isAvailable = false;
                aircraft.AddHistoryToAircraft("Gate " + GetIdAndAirportNickname(), ", Arrived at Gate");
            } else
            {
                Console.Write($"Gate with id: {Id}, is already booked. You cannot book this gate.");
            }
        }
    }
}

