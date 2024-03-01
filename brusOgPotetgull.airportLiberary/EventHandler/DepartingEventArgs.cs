using System;
using BrusOgPotetgull.AirportLiberary;
namespace brusOgPotetgull.airportLiberary.EventHandler;

public class DepartingEventArgs : EventArgs
{
    public Flight.Departing Flight { get; private set; }
    public string Message { get; private set; }

    public DepartingEventArgs(Flight.Departing flight, string message)
    {
        Flight = flight;
        Message = message;
    }
}