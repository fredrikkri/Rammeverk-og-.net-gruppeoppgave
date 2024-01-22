using System;
namespace brusOgPotetgull.gruppeoppgave.core
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
        public string Id { get; init; }
        public string Model { get; init; }
        public int Capacity { get; init; }

        public void GetFlyInformation()
        {
            Console.Write($"Id: {Id}\nModel: {Model}\nCapacity: {Capacity}");
        }
	}
}

