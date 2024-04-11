using brusOgPotetgull.userInterface.Services;
using BrusOgPotetgull.AirportLiberary;

namespace brusOgPotetgull.userInterface.Views;

public partial class AirportInterface : ContentPage
{
    private readonly Airport airport;
    public AirportInterface()
	{
		InitializeComponent();
        airport = AirportService.Instance.CurrentAirport;
    }

    private void AddTerminal(object sender, EventArgs e)
    {
        var name = TermName.Text;
        airport.AddTerminalToList(new Terminal(name));
    }

    private void AddGate(object sender, EventArgs e)
    {
        var name = GateName.Text;
        Gate gate = new Gate(name);
        airport.AddGateToList(gate);
        DisplayAlert("Gate added", $"{gate.Name} added to {airport.Name}", "OK");
    }

}