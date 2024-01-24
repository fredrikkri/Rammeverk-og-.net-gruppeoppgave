using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary
{
	public class Gate
	{
        private static int idCounter = 1;
        private int gateNr;
        private bool isOpen = true;

		public Gate()
		{
            // (dosnetCore, 2020) 
            gateNr = idCounter++;
            this.GateNr = gateNr;
            this.isOpen = true;
        }
        public int GateNr { get; private set; }

        public void printGateInformation()
        {
            Console.Write($"\nGateNr: {GateNr}\nIsOpen: {isOpen}\n");
        }
    }
}

