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
            legalAircrafts.Add(aircraft);
        }
    }
}

