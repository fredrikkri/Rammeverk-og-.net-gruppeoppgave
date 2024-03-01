using System;
using BrusOgPotetgull.AirportLiberary;
namespace brusOgPotetgull.airportLiberary.EventHandler;

public class AirportMonitor
{
    public void subcribeRunwayEvents(Runway runway)
    {
        runway.FlightArrived += RaiseFlightArrived;
        runway.FlightDeparted += RaiseFlightDeparted;
    }
    public void RaiseFlightArrived(object sender, ArrivingEventArgs e)
    {
        // Kan skrive annen logikk som logging her, i stede for de stedene vi har logget tidligere
        e.Flight.ActiveAircraft.AddHistoryToAircraft(System.DateTime.Now, e.Flight.ArrivalRunway.GetIdRunwayAndAirportCode(), " Enters the runway");
        Console.WriteLine("Arrival: " + e.Message);
    }

    public void RaiseFlightDeparted(object sender, DepartingEventArgs e)
    {
        e.Flight.ActiveAircraft.AddHistoryToAircraft(System.DateTime.Now, e.Flight.DepartureRunway.GetIdRunwayAndAirportCode(), " Leaves the runway");
        Console.WriteLine("Departure: " + e.Message);
    }
}