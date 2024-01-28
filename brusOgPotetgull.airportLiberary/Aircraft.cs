using System;
namespace brusOgPotetgull.airportLiberary
{
	public class Aircraft
    {
        private static int idCounter = 1;
        private int id;
        private int aircraftTypeId = 0;
        private string model = "";
        // (Trupja, 2023)
        Dictionary<int, string> history;

        public Aircraft(string model)
		{
            // (dosnetCore, 2020) 
            id = idCounter ++;
            this.Id = id;
            this.AircraftTypeId = aircraftTypeId;
            this.Model = model;
            history = new Dictionary<int, string>();
		}
        public int Id { get; private set; }
        public int AircraftTypeId { get; private set; }
        public string Model { get; private set; }

        virtual public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\n");
        }
        public void addHistoryToAircraft(int time, string anEvent)
        {
            history.Add(time, anEvent);
        }
        public void printFullAircraftHistory()
        {
            Console.Write($"\nHistory for aircraft whith id: '{this.Id}'\n");
            // (Nagel, 2022, s. 216)
            foreach ( var line in history)
            {
                Console.WriteLine($"Time: {line.Key}, {line.Value}");
            }
        }
    }
}