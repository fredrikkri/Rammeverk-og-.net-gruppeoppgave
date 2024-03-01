using System;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.Simulation;
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
        e.Flight.ActiveAircraft.AddHistoryToAircraft(e.Time, e.Flight.ArrivalRunway.GetIdRunwayAndAirportCode(), " Enters the runway");
        Console.WriteLine("Arrival: " + e.Message);
    }

    public void RaiseFlightDeparted(object sender, DepartingEventArgs e)
    {
        e.Flight.ActiveAircraft.AddHistoryToAircraft(e.Time, e.Flight.DepartureRunway.GetIdRunwayAndAirportCode(), " Leaves the runway");
        Console.WriteLine("Departure: " + e.Message);
    }
}