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
        public string Id { get; init; }
        public string Model { get; init; }
        public int Capacity { get; init; }

        public void printFlyInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nCapacity: {Capacity}");
        }
	}
}

