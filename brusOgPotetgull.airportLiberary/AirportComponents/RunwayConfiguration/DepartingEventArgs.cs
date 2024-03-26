namespace BrusOgPotetgull.AirportLiberary;

/// <summary>
/// Contains the arguments needed to handle the event for when an aircraft is departing.
/// </summary>
public class DepartingEventArgs : EventArgs
{
    public Flight.Departing Flight { get; private set; }
    public DateTime Time { get; private set; }
    public string Message { get; private set; }

    /// <summary>
    /// Sets the arguments for a departing aircraft so that an event can be handled.
    /// </summary>
    /// <param name="flight">The flight that is being handled by the event</param>
    /// <param name="time">The time of the event</param>
    /// <param name="message">A message of what occured at the time of the event</param>
    public DepartingEventArgs(Flight.Departing flight, DateTime time, string message)
    {
        Flight = flight;
        Time = time;
        Message = message;
    }
}