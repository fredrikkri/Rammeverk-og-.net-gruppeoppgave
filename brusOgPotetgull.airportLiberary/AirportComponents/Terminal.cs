﻿using System;
using BrusOgPotetgull.AirportLiberary;
namespace brusOgPotetgull.airportLiberary.AirportComponents
{
    /// <summary>
    /// The terminal class is an area in a airport that contains a number of gates.
    /// </summary>
    public class Terminal
    {
        private static int idCounter = 1;
        private int id;
        private List<Gate> gatesInTerminal;
        private string? airportLocation;

        public Terminal(string terminalName)
        {
            id = idCounter++;
            this.Id = id;
            this.TerminalName = terminalName;
            this.gatesInTerminal = new List<Gate>();
        }

        public int Id { get; private set; }
        public string TerminalName { get; private set; }

        /// <summary>
        /// Updates the information for which airport the terminal is located at.
        /// </summary>
        /// <param name="airportName">Name of the airport that the terminal will be located at.</param>
        public void UpdateGateLocation(string airportName)
        {
            airportLocation = airportName;
        }

        /// <summary>
        /// Gets the list that contains all gates for this Terminal.
        /// </summary>
        /// <returns>A list of gates for this terminal.</returns>
        public List<Gate> GetgatesInTerminal()
        {
            return gatesInTerminal;
        }
    }
}
