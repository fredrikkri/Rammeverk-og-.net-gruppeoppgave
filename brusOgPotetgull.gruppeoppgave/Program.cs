using brusOgPotetgull.gruppeoppgave.core;
namespace brusOgPotetgull.gruppeoppgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fly newflight = new Fly("SAS", "Jet 34", 200);
            newflight.printFlyInformation();

            Airport newAirport = new Airport("Militærflyplass", "Rygge Flyplass", "Rygge");
            newAirport.printAirportInformation();
        }
    }
}