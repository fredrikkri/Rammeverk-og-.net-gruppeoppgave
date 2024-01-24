using brusOgPotetgull.airportLiberary;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fly newflight = new Fly("Jet 34", 200);
            newflight.printFlyInformation();

            Fly newflight2 = new Fly("Superjett", 250);
            newflight2.printFlyInformation();

            //Airport newAirport = new Airport("Militærflyplass", "Rygge Flyplass", "Rygge");
            //newAirport.printAirportInformation();
        }
    }
}