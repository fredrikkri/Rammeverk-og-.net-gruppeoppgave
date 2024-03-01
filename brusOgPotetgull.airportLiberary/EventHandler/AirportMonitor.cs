using System;
using BrusOgPotetgull.AirportLiberary;
namespace brusOgPotetgull.airportLiberary.EventHandler;

public class AirportMonitor
{
    public void subcribeRunwayEvents(Runway runway)
    {
        runway.FlightArrived += OnFlightArrived;
        runway.FlightDeparted += OnFlightDeparted;
    }
    public void OnFlightArrived(object sender, ArrivingEventArgs e)
    {
        // Kan skrive annen logikk som logging her, i stede for de stedene vi har logget tidligere
        e.Flight.ActiveAircraft.AddHistoryToAircraft(System.DateTime.Now, e.Flight.ArrivalRunway.GetIdRunwayAndAirportCode(), " Enters the runway");
        Console.WriteLine("Arrival: " + e.Message);
    }

    public void OnFlightDeparted(object sender, DepartingEventArgs e)
    {
        Console.WriteLine("Departure: " + e.Message);
    }
}