using System;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.Simulation;
namespace brusOgPotetgull.airportLiberary.EventHandler;

public class AirportMonitor
{
    public void SubcribeToRunwayEvents(Runway runway)
    {
        runway.FlightArrived += OnFlightArrived;
        runway.FlightDeparted += OnFlightDeparted;
    }
    public void OnFlightArrived(object sender, ArrivingEventArgs e)
    {
        e.Flight.ActiveAircraft.AddHistoryToAircraft(e.Time, e.Flight.ArrivalRunway.GetAirportNameAndRunwayId(), " Enters the runway");
        Console.WriteLine("Arrival: " + e.Message);
    }

    public void OnFlightDeparted(object sender, DepartingEventArgs e)
    {
        e.Flight.ActiveAircraft.AddHistoryToAircraft(e.Time, e.Flight.DepartureRunway.GetAirportNameAndRunwayId(), " Leaves the runway");
        Console.WriteLine("Departure: " + e.Message);
    }
} 