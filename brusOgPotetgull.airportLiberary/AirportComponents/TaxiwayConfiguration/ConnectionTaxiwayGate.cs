namespace BrusOgPotetgull.AirportLiberary
{
    public class ConnectionTaxiwayGate : Connection
    {
        public ConnectionTaxiwayGate(Taxiway object1, Gate object2)
        {
            this.Object1 = object1;
            this.Object2 = object2;

        }
        public Taxiway Object1 { get; private set; }
        public Gate Object2 { get; private set; }
    }
}

