using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Fly

	{
        private string id = "";
        private string model = "";
        private int capacity = 0;

        public Fly(string id, string model, int capacity)
		{
            Id = id;
            Model = model;
            Capacity = capacity;

		}
        // (Nagel, C, 2021, s. 76)
        public string Id { get; private set; }
        public string Model { get; private set; }
        public int Capacity { get; private set; }

        public void printFlyInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nCapacity: {Capacity}");
        }
	}
}

