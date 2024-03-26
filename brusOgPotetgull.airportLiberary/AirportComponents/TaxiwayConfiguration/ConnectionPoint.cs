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
        public string? Name { get; set; }
        public List<Taxiway> taxiways { get; set; } = new List<Taxiway>();

        /// <summary>
        /// Creates a connection point in the taxiway system.
        /// </summary>
        /// <param name="name">Name of the connection point</param>
        public ConnectionPoint(string name) 
        {
            this.Name = name;
        }
    }
}