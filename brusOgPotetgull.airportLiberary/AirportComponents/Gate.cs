using System;
using System.Linq;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Gate
	{
        private static int idCounter = 1;
        private int id;
        private bool isOpen = true;
        // Variable under baserer seg på at en flytype har en unik id med int og ikke en string-verdi. Se mappe med flytyper.
        private List<int> legalAircraftTypesId;

		public Gate(string gateName, Airport locatedAtAirport)
		{
            // (dosnetCore, 2020) 
            id = idCounter++;
            this.Id = id;
            this.GateName = gateName;
            this.LocatedAtAirport = locatedAtAirport;
            this.isOpen = true;
            this.legalAircraftTypesId = new List<int>();

        }
        public int Id { get; private set; }
        public string GateName { get; private set; }
        public Airport LocatedAtAirport { get; private set; }

        public void printGateInformation()
        {
            Console.Write($"\nGateNr: {Id}\n" +
                $"Name: {GateName}\n" +
                $"IsOpen: {isOpen}\n" +
                $"Name: {LocatedAtAirport.AirportNickname}\n");
            Console.Write("Legal aircraftstypes: ");
            foreach (int typeId in legalAircraftTypesId)
            {
                Console.Write($"{typeId} ");
            }
        }
        public string getIdAndAirportNickname()
        {
            string returnString = (string) (Id + ", " + LocatedAtAirport.AirportNickname);
            return returnString;
        }
        public void addLegalAircraftThatCanUseGate(Aircraft aircraft)
        {
            if (!legalAircraftTypesId.Contains(aircraft.AircraftTypeId))
            {
                legalAircraftTypesId.Add(aircraft.AircraftTypeId);
            } else
            {
                Console.Write($"{aircraft} is already in list of legal aicrafts for this gate.");
            }
            
        }
        public void removeLegalAircraftThatCanUseGate(Aircraft aircraft)
        {
            if (legalAircraftTypesId.Contains(aircraft.AircraftTypeId))
            {
                legalAircraftTypesId.Remove(aircraft.AircraftTypeId);
            } else
            {
                Console.Write($"Aircraft with type {aircraft.AircraftTypeId} cannot be removed from the list of legal aircrafts for this gate because it does not exist in the list.");
            }
        }
        public bool checkIfAircraftCanUseGate(Aircraft aircraft)
        {
            if (legalAircraftTypesId.Contains(aircraft.AircraftTypeId)) {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

