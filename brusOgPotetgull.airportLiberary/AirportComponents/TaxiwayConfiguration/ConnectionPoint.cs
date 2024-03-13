using System;

namespace BrusOgPotetgull.AirportLiberary
{
    public class ConnectionPoint
    {
        public string? Name { get; set; }
        public List<Taxiway> taxiways { get; set; } = new List<Taxiway>();

        public ConnectionPoint(string name) 
        {
            this.Name = name;
        }
    }
}