namespace BrusOgPotetgull.AirportLiberary.AirportComponents.Runway;

	public class ArrivingEventArgs : EventArgs
	{
		public Flight.Arriving Flight { get; private set; }
	    public DateTime Time { get; private set; }
		public string Message { get; private set; }

		public ArrivingEventArgs(Flight.Arriving flight, DateTime time,string message)
		{
			Flight = flight;
			Time = time;
			Message = message;
		}
	}