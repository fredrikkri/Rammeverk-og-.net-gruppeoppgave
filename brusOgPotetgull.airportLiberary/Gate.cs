using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Gate
	{
        private static int idCounter = 1;
        private int gateNr;
        private bool isOpen = true;
        private List<string> legalAircrafts;

		public Gate()
		{
            // (dosnetCore, 2020) 
            gateNr = idCounter++;
            this.GateNr = gateNr;
            this.isOpen = true;
            this.legalAircrafts = new List<string>();

        }
        public int GateNr { get; private set; }

        public void printGateInformation()
        {
            Console.Write($"\nGateNr: {GateNr}\nIsOpen: {isOpen}\n");
            Console.Write("Legal aircraftstypes: ");
            foreach (string aircraft in legalAircrafts)
            {
                Console.Write($"{aircraft} ");
            }
        }
        public void addLegalAircraftToGate(string aircraft)
        {
            if (!legalAircrafts.Contains(aircraft))
            {
                legalAircrafts.Add(aircraft);
            } else
            {
                Console.Write($"{aircraft} is already in list of legal aicrafts for this gate.");
            }
            
        }
        public void removeLegalAircraftFromGate(string aircraft)
        {
            if (legalAircrafts.Contains(aircraft))
            {
                legalAircrafts.Remove(aircraft);
            } else
            {
                Console.Write($"Aircraft: {aircraft} cannot be removed from the list of legal aircrafts for this gate because it does not exist in the list.");
            }
        }
    }
}

