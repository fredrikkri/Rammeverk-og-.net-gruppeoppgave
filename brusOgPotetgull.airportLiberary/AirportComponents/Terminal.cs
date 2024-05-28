using System;
using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary.CustomExceptions;

namespace BrusOgPotetgull.AirportLiberary;

/// <summary>
/// The terminal class is an area in the airport that can host a set of gates.
/// </summary>
public class Terminal
{
    private static int idCounter = 1;
    private int id;
    private List<Gate> gatesInTerminal;
    private string? airportLocation;

    /// <summary>
    /// Creates a terminal.
    /// </summary>
    /// <param name="name">The name for the terminal.</param>
    /// <param name="airport">The airport that the terminal will be located at.</param>
    public Terminal(string name, Airport airport)
    {
        id = idCounter++;
        this.Id = id;
        this.Name = name;
        this.gatesInTerminal = new List<Gate>();
        airport.AddTerminalToList(this);
    }

    /// <summary>
    /// Gets Id of Terminal
    /// </summary>
    /// <value>
    /// int value of the id of the terminal
    /// </value>
    public int Id { get; private set; }

    /// <summary>
    /// Gets Name of Terminal
    /// </summary>
    /// <value>
    /// string of name of terminal
    /// </value>
    public string Name { get; private set; }

    /// <summary>
    /// Prints out information about the terminal.
    /// </summary>
    public void PrintTaxiwayInformation()
    {
        Console.Write($"\nTaxiwayId: {Id}\n" +
            $"Taxiway lenght: {Name}\n" +
            $"Airport location: {airportLocation}\n");
        Console.WriteLine($"List of gates: ");
        foreach (Gate gate in gatesInTerminal)
            Console.WriteLine($"{gate.Name + ", id: " + Id} ");
    }

    /// <summary>
    /// This override the ToString() method that exists in all objects in c#
    /// </summary>
    /// <returns>A String with simple details about the Terminal.</returns>
    public override string ToString()
    {
        return $"\nTaxiwayId: {Id}\n";
    }

    /// <summary>
    /// Adds an aircraft that will be able to use all of the gates in this terminal.
    /// </summary>
    /// <param name="aircraftType">An Enum that represents the id of an aircraftType that you want to enable accsess for the gate.</param>
    public void AddAircraftAllowedAtGatesAtTerminal(AircraftType aircraftType)
    {
        foreach (Gate gate in gatesInTerminal)
            gate.AddAircraftAllowedAtGate(aircraftType);
    }

    /// <summary>
    /// Updates the information for which airport the terminal is located at.
    /// </summary>
    /// <param name="airportName">Name of the airport that the terminal will be located at.</param>
    public void UpdateLocation(string airportName)
    {
        airportLocation = airportName;
    }

    /// <summary>
    /// Updates the airport the terminal is located at.
    /// </summary>
    /// <param name="airportName">Name of the airport that the terminal will be updated to.</param>
    public void UpdateGateLocation(string airportName)
    {
        airportLocation = airportName;
    }

    /// <summary>
    /// Gets the list that contains all gates for this Terminal.
    /// </summary>
    /// <returns>A list of gates for this terminal.</returns>
    public List<Gate> GetgatesInTerminal() => gatesInTerminal;

    /// <summary>
    /// Adds a gate to the list of gates on this terminal.
    /// </summary>
    /// <param name="gate">The gate that will be added to the list.</param>
    public void AddGateToList(Gate gate)
    {
        gatesInTerminal.Add(gate);
    }

    /// <summary>
    /// Creating multiple gates and adding them to this terminal.
    /// </summary>
    /// <param name="gateLetter">The letter thats a part of the gatename.</param>
    /// <param name="startNumber">The start-number for generating all the gates. This is gonna be the first generated gate.</param>
    /// <param name="numberOfGates">The number of gates thats gonna be created.</param>
    /// <param name="airport">The airport that these gates will be added to.</param>
    public void CreateMultipleGatesToTerminal(string gateLetter, int startNumber, int numberOfGates, Airport airport)
    {
        int currentIndex = startNumber;
        for (int i = currentIndex; i <= numberOfGates; i++)
        {
            string gateName = ((string)gateLetter + i);
            if (airport.GetListGates().Find(currentGate => currentGate.Name == gateName) != null)
                AddGateToList(airport.GetListGates().Find(currentGate => currentGate.Name == gateName));
            else
            {
                Gate gateNameObject = new Gate(gateName, airport);
                AddGateToList(gateNameObject);
                
            }
        }
    }

    /// <summary>
    /// Returns the airport location aswell as the terminalname and id.
    /// </summary>
    /// <returns>String that contain information about the terminal.</returns>
    private string GetAirportNameAndTerminalId() => (string)(airportLocation + ", " + "Terminal-id: " + Id + ", Name: " + Name);
}

