using System;

namespace BrusOgPotetgull.AirportLiberary
{
    public class Connection
    {
        public int LocationObject1;
        public int LocationObject2;
        public object Object1;
        public object Object2;

        public Connection(int locationObject1, object object1, int locationObject2, object object2)
        {
            this.LocationObject1 = locationObject1;
            this.LocationObject2 = locationObject2;
            this.Object1 = object1;
            this.Object2 = object2;
        }
    }
}
