using System;
using BrusOgPotetgull.AirportLiberary;
using brusOgPotetgull.airportLiberary;
namespace brusOgPotetgull.airportLiberary.EventHandler;

	public class ArrivingEventArgs : EventArgs
	{
		public Flight.Arriving Flight { get; private set; }
		public string Message { get; private set; }

		public ArrivingEventArgs(Flight.Arriving flight,string message)
		{
			Flight = flight;
			Message = message;
		}
	}