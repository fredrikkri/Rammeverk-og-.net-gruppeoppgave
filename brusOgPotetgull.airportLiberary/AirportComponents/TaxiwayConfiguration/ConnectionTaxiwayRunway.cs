namespace BrusOgPotetgull.AirportLiberary
{
    public class ConnectionTaxiwayRunway : Connection
    {
        public ConnectionTaxiwayRunway(Taxiway object1, Runway object2)
        {
            this.Object1 = object1;
            this.Object2 = object2;

        }
        public Taxiway Object1 { get; private set; }
        public Runway Object2 { get; private set; }
    }
}

