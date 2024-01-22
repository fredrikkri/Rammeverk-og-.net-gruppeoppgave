using System;
namespace brusOgPotetgull.gruppeoppgave.core
{
	public class Taxiway
    {
		private int taxiwayNr;
		private int length;

		public Taxiway(int length)
		{
			Length = length;
		}
        // (Nagel, C, 2021, s. 76)
        public int Length { get; init; }
    }
}