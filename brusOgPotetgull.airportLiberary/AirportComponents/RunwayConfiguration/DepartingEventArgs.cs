namespace BrusOgPotetgull.AirportLiberary;

/// <summary>
/// Contains the arguments needed to handle the event for when an aircraft is departing.
/// </summary>
public class DepartingEventArgs : EventArgs
{
    /// <summary>
    /// Gets the departing flight details.
    /// </summary>
    /// <value>
    /// departing flight object of flight departing runway
    /// </value>
    public Flight.Departing Flight { get; private set; }

    /// <summary>
    /// Gets the time associated with the event.
    /// </summary>
    /// <value>
    /// datetime object of time aircraft leaves runway
    /// </value>
    public DateTime Time { get; private set; }

    /// <summary>
    /// Gets the message related to the event.
    /// </summary>
    /// <value>
    /// string of message related to the event
    /// </value>
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