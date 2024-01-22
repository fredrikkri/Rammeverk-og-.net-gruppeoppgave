using System;
namespace brusOgPotetgull.gruppeoppgave.core
{
	public class Gate
	{
		private int gateNr;
		private List<string> allowedAircrafts;
		private bool isOpen;


		public Gate(int gateNr)
		{
			GateNr = gateNr;
            isOpen = true;
        }
        public int GateNr { get; init; }
    }
}

