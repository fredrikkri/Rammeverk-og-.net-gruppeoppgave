using System;

namespace BrusOgPotetgull.AirportLiberary
{
    public class Connection
    {
        public object Object1;
        public int LocationObject1;
        public object Object2;
        public int LocationObject2;

        public Connection(object object1, int locationObject1, object object2, int locationObject2)
        {
            this.Object1 = object1;
            this.LocationObject1 = locationObject1;
            this.Object2 = object2;
            this.LocationObject2 = locationObject2;
        }
    }
}
