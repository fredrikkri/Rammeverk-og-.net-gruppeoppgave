using System;
using BrusOgPotetgull.AirportLiberary.Simulation;
namespace brusOgPotetgull.airportLiberary.EventHandler;

public class AirportMonitor
{
    public void subcribeAirportEvents(Simulation simulation) 
    {
        simulation.FlightArrived += OnFlightArrived;
        simulation.FlightDeparted += OnFlightDeparted;
    }
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