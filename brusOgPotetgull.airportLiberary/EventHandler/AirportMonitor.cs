using System;
namespace brusOgPotetgull.airportLiberary.EventHandler;

public class AirportMonitor
{
    public void OnFlightArrived(object sender, AirportEventArgs e)
    {
        // Kan skrive annen logikk som logging her, i stede for de stedene vi har logget tidligere
        Console.WriteLine("Arrival: " + e.Message);
    }

    public void OnFlightDeparted(object sender, AirportEventArgs e)
    {
        Console.WriteLine("Departure: " + e.Message);
    }
}