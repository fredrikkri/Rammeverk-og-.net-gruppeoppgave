using brusOgPotetgull.userInterface.Services;
using BrusOgPotetgull.AirportLiberary;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class AirportControlModel : ObservableObject
    {
        protected readonly IAirportService _airportService;

        [ObservableProperty]
        private string terminalName;

        [ObservableProperty]
        private string gateName;

        [ObservableProperty]
        private string taxiwayName;

        [ObservableProperty]
        private string runwayName;

        public AirportControlModel(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [RelayCommand]
        private void AddTerminal()
        {
            var airport = _airportService.CurrentAirport;
            Terminal terminal = new Terminal(TerminalName, airport);
            TerminalName = string.Empty;
        }

        [RelayCommand]
        private void AddGate()
        {
            var airport = _airportService.CurrentAirport;
            Gate gate = new Gate(GateName, airport);
            GateName = string.Empty;
        }

        //[RelayCommand]
        //private void AddTaxiWay(string name, int length, int maxspeed)
        //{
        //    var airport = _airportService.CurrentAirport;
        //    Taxiway taxiway = new Taxiway(name, length, maxspeed, airport);
        //    TaxiwayName = string.Empty;
            
            
        //}

        //[RelayCommand]
        //private void AddRunway()
        //{
        //    var airport = _airportService.CurrentAirport;
        //    Gate gate = new Gate(GateName, airport);
        //    GateName = string.Empty;
        //}
    }
}
