using System;
namespace BrusOgPotetgull.AirportLiberary.AircraftTypes
{
    /// <summary>
    /// This class represents a spesific type of aircraft.
    /// </summary>
    /// <remarks>
    /// This is used together with the creation of aircrafts to define their type.
    /// </remarks>
    /// <example>
    /// This is how you can instansiate the aircraft type for a boeing 737.
    /// <c>AircraftType boeing737 = new AircraftType("Boeing 737");</c>
    /// </example>
    public class AircraftType
	{
        private static int idCounter = 1;
        private int typeId;

        /// <summary>
        /// Creates an Aircraft type to be used in the creation of aircraft objects
        /// </summary>
        /// <param name="name">This is the name of the aircraft type. An Example could be "Airbus A330"</param>
        public AircraftType(string name)
        {
            typeId = idCounter++;
            this.TypeId = typeId;
            this.Name = name;

        }
        public int TypeId { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the AircraftType.</returns>
        public override string ToString()
        {
            return $"\nTypeId: {TypeId} " +
                $"\nName: {Name}\n";
        }
    }
}