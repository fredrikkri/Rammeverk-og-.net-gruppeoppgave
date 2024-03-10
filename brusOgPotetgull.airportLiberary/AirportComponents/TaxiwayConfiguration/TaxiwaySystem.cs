using System;
using System.Xml.Linq;

namespace BrusOgPotetgull.AirportLiberary
{
    public class TaxiwaySystem
    {
        private List<KeyValuePair<int, Taxiway>> connections;

        public TaxiwaySystem()
        {
            connections = new List<KeyValuePair<int, Taxiway>>();
        }
    }
}

