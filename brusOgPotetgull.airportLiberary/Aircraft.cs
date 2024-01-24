using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Aircraft : AircraftHistory
    {
        private static int idCounter = 1;
        private int id;
        private string model = "";
        private int length;
        private int height;

        public Aircraft(string model, int length, int height)
		{
            // (dosnetCore, 2020) 
            id = idCounter ++;
            this.Id = id;
            this.Model = model;
            this.Length = length;
            this.Height = height;
            startAircraftHistory(Id);
		}
        public int Id { get; private set; }
        public string Model { get; private set; }
        public int Length { get; private set; }
        public int Height { get; private set; }

        public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nLength: {Length}m\nHeight: {Height}m\n");
        }

        public void startAircraftHistory(int id)
        {
            //Console.Write("not implemented");
        }
    }
}

