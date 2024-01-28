using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Gate
	{
        private static int idCounter = 1;
        private int gateNr;
        private bool isOpen = true;
        // Variable under baserer seg på at en flytype har en unik id med int og ikke en string-verdi. Se mappe med flytyper.
        private List<int> legalAircraftTypes;

		public Gate()
		{
            // (dosnetCore, 2020) 
            gateNr = idCounter++;
            this.GateNr = gateNr;
            this.isOpen = true;
            this.legalAircraftTypes = new List<int>();

        }
        public int GateNr { get; private set; }

        public void printGateInformation()
        {
            Console.Write($"\nGateNr: {GateNr}\nIsOpen: {isOpen}\n");
            Console.Write("Legal aircraftstypes: ");
            foreach (int aircraft in legalAircraftTypes)
            {
                Console.Write($"{aircraft} ");
            }
        }
        public void addLegalAircraftToGate(int aircraft)
        {
            if (!legalAircraftTypes.Contains(aircraft))
            {
                legalAircraftTypes.Add(aircraft);
            } else
            {
                Console.Write($"{aircraft} is already in list of legal aicrafts for this gate.");
            }
            
        }
        public void removeLegalAircraftFromGate(int aircraft)
        {
            if (legalAircraftTypes.Contains(aircraft))
            {
                legalAircraftTypes.Remove(aircraft);
            } else
            {
                Console.Write($"Aircraft: {aircraft} cannot be removed from the list of legal aircrafts for this gate because it does not exist in the list.");
            }
        }
    }
}

