namespace BrusOgPotetgull.AirportLiberary;
/// <summary>
/// Contains the arguments needed to handle the event for when an aircraft is landing.
/// </summary>
public class ArrivingEventArgs : EventArgs
{
	public Flight.Arriving Flight { get; private set; }
	public DateTime Time { get; private set; }
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