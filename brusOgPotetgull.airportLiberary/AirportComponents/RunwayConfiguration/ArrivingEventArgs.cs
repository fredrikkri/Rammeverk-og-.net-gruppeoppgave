namespace BrusOgPotetgull.AirportLiberary;
/// <summary>
/// Contains the arguments needed to handle the event for when an aircraft is landing.
/// </summary>
public class ArrivingEventArgs : EventArgs
{
    /// <summary>
    /// Gets the arriving flight details.
    /// </summary>
    /// <value>
    /// Arriving flight object of flight arriving at runnway
    /// </value>
    public Flight.Arriving Flight { get; private set; }

    /// <summary>
    /// Gets the time associated with the event.
    /// </summary>
    /// <value>
    /// DateTime object of time aircraft arives at runway
    /// </value>
    public DateTime Time { get; private set; }

    /// <summary>
    /// Gets the message related to the event.
    /// </summary>
    /// <value>
    /// string of message related to event
    /// </value>
    public string Message { get; private set; }

	/// <summary>
	/// Sets the arguments for an arriving aircraft so that an event can be handled.
	/// </summary>
	/// <param name="flight">The flight that is being handled by the event</param>
	/// <param name="time">The time of the event</param>
	/// <param name="message">A message of what occured at the time of the event</param>
	public ArrivingEventArgs(Flight.Arriving flight, DateTime time, string message)
	{
		Flight = flight;
		Time = time;
		Message = message;
	}
}