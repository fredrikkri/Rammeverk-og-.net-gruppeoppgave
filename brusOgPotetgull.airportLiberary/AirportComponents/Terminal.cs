using System;
namespace BrusOgPotetgull.AirportLiberary;

/// <summary>
/// The terminal class is an area in a airport that contains a number of gates.
/// </summary>
public class Terminal
{
    private static int idCounter = 1;
    private int id;
    private List<Gate> gatesInTerminal;
    private string? airportLocation;

    public Terminal(string name)
    {
        id = idCounter++;
        this.Id = id;
        this.Name = name;
        this.gatesInTerminal = new List<Gate>();
    }

    public int Id { get; private set; }
    public string Name { get; private set; }

    public void PrintTaxiwayInformation()
    {
        Console.Write($"\nTaxiwayId: {Id}\n" +
            $"Taxiway lenght: {Name}\n" +
            $"Airport location: {airportLocation}\n");
        Console.WriteLine($"List of gates: ");
        foreach (Gate gate in gatesInTerminal)
        {
            Console.WriteLine($"{gate.Name + ", id: " + Id} ");
        }
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
    /// returns the id and name for the airport that this terminal is located at.
    /// </summary>
    /// <returns>String that contain information about the terminal.</returns>
    private string GetAirportNameAndTerminalId() => (string)(airportLocation + ", " + "Terminal-id: " + Id + ", Name: " + Name);

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
    public List<Gate> GetgatesInTerminal() => gatesInTerminal;

    public void AddGatesToList(Gate gate)
    {
        gatesInTerminal.Add(gate);
    }
}

