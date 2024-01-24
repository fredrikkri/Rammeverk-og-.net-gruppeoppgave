using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Taxiway
    {
        private static int idCounter = 1;
        private int id;
		private int length;

		public Taxiway(int length)
		{
            // (dosnetCore, 2020) 
            id = idCounter++;
            this.Id = id;
            this.Length = length;
		}
        public int Length { get; private set; }
        public int Id { get; private set; }

        public void printTaxiwayInformation()
		{
            Console.Write($"\nTaxiwayId: {Id}\nTaxiway lenght: {Length}\n");

        }
    }
}