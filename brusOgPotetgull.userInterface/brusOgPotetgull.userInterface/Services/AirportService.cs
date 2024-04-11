using BrusOgPotetgull.AirportLiberary;

namespace brusOgPotetgull.userInterface.Services
{
    public class AirportService
    {
        public static AirportService Instance { get; } = new AirportService();

        public Airport CurrentAirport { get; set; }

        private AirportService() { }
    }
}
