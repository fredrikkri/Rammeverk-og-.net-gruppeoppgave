using System;

namespace BrusOgPotetgull.AirportLiberary
{
    /// <summary>
    /// This class represents a point of connection on the airport roadsystem.
    /// This can hold the connection one taxiway has to several others.
    /// Each taxiway has two connection points.
    /// </summary>
    public class ConnectionPoint
    {
        /// <summary>
        /// Gets the name of the connection poin
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the list of taxiways connected to the connectionPoint.
        /// </summary>
        public List<Taxiway> taxiways { get; set; } = new List<Taxiway>();

        /// <summary>
        /// Creates a connection point in the taxiway system.
        /// </summary>
        /// <param name="name">Name of the connection point</param>
        /// <param name="airport">The airport that the ConnectionPoint will be located at.</param>
        public ConnectionPoint(string name, Airport airport) 
        {
            this.Name = name;
            airport.AddConnectionPoint(this);
        }

        /// <summary>
        /// This override the ToString() method that exists in all objects in c#
        /// </summary>
        /// <returns>A String with simple details about the ConnectionPoint.</returns>
        public override string ToString()
        {
            return $"\nName:  {Name}\n";
        }
    }
}