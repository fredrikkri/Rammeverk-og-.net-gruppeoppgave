using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Fly : AircraftHistory

	{
        private static int idCounter = 1;
        private int id;
        private string model = "";
        private int capacity = 0;
        //private AircraftHistory history; Denne må implementeres hvis vi skal ha det som instansevariabel.

        public Fly(string model, int capacity)
		{
            // (dosnetCore, 2020) 
            id = idCounter ++;
            this.Id = id;
            this.Model = model;
            this.Capacity = capacity;
            startAircraftHistory(Id);
      

		}
        public int Id { get; private set; }
        public string Model { get; private set; }
        public int Capacity { get; private set; }

        public void printFlyInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nCapacity: {Capacity}");
        }

        public void startAircraftHistory(int id)
        {
            Console.Write("not implemented");
        }
    }
}

