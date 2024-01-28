using System;
namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class CargoAircraft : Aircraft
	{
        private int aircraftTypeId = 5;
        // (GeeksforGeeks, 2023)
        public CargoAircraft(string model) : base(model)
		{
            this.AircraftTypeId = aircraftTypeId;
		}
        public int AircraftTypeId { get; private set; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Cargo aircraft\nAircraft type: {AircraftTypeId}\n");
        }

    }
}

