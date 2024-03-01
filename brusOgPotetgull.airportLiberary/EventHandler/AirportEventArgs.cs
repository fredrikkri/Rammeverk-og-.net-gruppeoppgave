using System;
namespace brusOgPotetgull.airportLiberary.EventHandler;

	public class AirportEventArgs : EventArgs
	{
		public string Message { get; private set; }

		public AirportEventArgs(string message)
		{
			Message = message;
		}
	}