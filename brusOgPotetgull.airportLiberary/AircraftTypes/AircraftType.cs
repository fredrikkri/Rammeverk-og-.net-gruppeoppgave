using System;
namespace brusOgPotetgull.airportLiberary.AircraftTypes
{
    /// <summary>
    /// Specifies all the possible aircraft types.
    /// </summary>
    public enum AircraftType
	{
        /// <summary>
        /// Represents an aircraft that does not have special traits.
        /// The number '0' is the aircrafttype for Aircraft.
        /// </summary>
		Undefined = 0,

        /// <summary>
        /// Represents an aircraft that is of 'LightAircraft' type.
        /// The number '1' is the aircrafttype for LightAircraft.
        /// </summary>
		Light = 1,

        /// <summary>
        /// Represents an aircraft that is of 'ShortMedium' type.
        /// The number '2' is the aircrafttype for ShortMediumAircraft.
        /// </summary>
        ShortMedium = 2,

        /// <summary>
        /// Represents an aircraft that is of 'LongMedium' type.
        /// The number '3' is the aircrafttype for LongMediumAircraft.
        /// </summary>
        LongMedium = 3,

        /// <summary>
        /// Represents an aircraft that is of 'Large' type.
        /// The number '4' is the aircrafttype for LargeAircraft.
        /// </summary>
        Large = 4,

        /// <summary>
        /// Represents an aircraft that is of 'Cargo' type.
        /// The number '5' is the aircrafttype for CargoAircraft.
        /// </summary>
        Cargo = 5,

        /// <summary>
        /// Represents an aircraft that is of 'Military' type.
        /// The number '6' is the aircrafttype for MilitaryAircraft.
        /// </summary>
		Military = 6
	}
}

