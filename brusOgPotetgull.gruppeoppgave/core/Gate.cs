using System;
namespace brusOgPotetgull.gruppeoppgave.core
{
	public class Gate
	{
		private int gateNr;
        private bool isOpen;
        private List<string> allowedAircrafts;

		public Gate(int gateNr)
		{
			GateNr = gateNr;
            isOpen = true;
            allowedAircrafts = new List<string>();
        }
        public int GateNr { get; init; }
    }
}

