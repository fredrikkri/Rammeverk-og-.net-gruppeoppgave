namespace BrusOgPotetgull.AirportLiberary
{
	public class ConnectionTaxiwayTaxiway : Connection
    {
		public ConnectionTaxiwayTaxiway(Taxiway object1, Taxiway object2)
        {
            this.Object1 = object1;
            this.Object2 = object2;

        }
        public Taxiway Object1 { get; private set; }
        public Taxiway Object2 { get; private set; }
    }
}