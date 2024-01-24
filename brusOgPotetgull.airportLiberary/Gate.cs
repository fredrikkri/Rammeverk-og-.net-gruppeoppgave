using System;
namespace brusOgPotetgull.airportLiberary
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
        // (Nagel, C, 2021, s. 76)
        public int GateNr { get; init; }
    }
}

