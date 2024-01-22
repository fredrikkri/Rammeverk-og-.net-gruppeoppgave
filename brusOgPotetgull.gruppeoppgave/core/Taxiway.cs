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
        public int Length { get; init; }
    }
}