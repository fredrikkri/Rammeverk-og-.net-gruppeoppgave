
namespace BrusOgPotetgull.AirportLiberary.AirportComponents.Runway;

public class DepartingEventArgs : EventArgs
{
    public Flight.Departing Flight { get; private set; }
    public DateTime Time { get; private set; }
    public string Message { get; private set; }

    public DepartingEventArgs(Flight.Departing flight, DateTime time, string message)
    {
        Flight = flight;
        Time = time;
        Message = message;
    }
}