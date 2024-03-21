using System;
namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
{
    public class AircraftType
	{
        private static int idCounter = 1;
        private int typeId;

        public AircraftType(string name)
        {
            typeId = idCounter++;
            this.TypeId = typeId;
            this.Name = name;

        }
        public int TypeId { get; private set; }
        public string Name { get; private set; }
    }
}