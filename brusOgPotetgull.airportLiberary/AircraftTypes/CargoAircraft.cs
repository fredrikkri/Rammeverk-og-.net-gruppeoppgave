using System;
using System.Reflection;

namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
	public class CargoAircraft : Aircraft
	{
        private int aircraftTypeId = 5;
        // (GeeksforGeeks, 2023)
        public CargoAircraft(string model, int maxSpeed, int acceleration) : base(model, maxSpeed, acceleration)
		{
            this.AircraftTypeId = aircraftTypeId;
		}
        public int AircraftTypeId { get; }
        // (Microsoft , 2021)
        override public void printAircraftInformation()
        {
            Console.Write($"\nId: {Id}\nModel: {Model}\nType: Cargo aircraft\nType(id): {AircraftTypeId}\nMax speed: {MaxSpeed}\nAcceleration: {Acceleration}\n");
        }

    }
}

