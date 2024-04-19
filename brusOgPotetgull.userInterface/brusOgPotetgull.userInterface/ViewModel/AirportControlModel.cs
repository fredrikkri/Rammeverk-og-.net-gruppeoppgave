using brusOgPotetgull.userInterface.Services;
using brusOgPotetgull.userInterface.Views;
using BrusOgPotetgull.AirportLiberary;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class AirportControlModel : ObservableObject
    {
        protected readonly IAirportService _airportService;
        private readonly IPopupService popupService;
        private RunwayPopup runwayPopup;
        private bool isRunwayPopupOpen;

        [ObservableProperty]
        private Airport airport;

        [ObservableProperty]
        private string terminalName;

        [ObservableProperty]
        private string gateName;

        [ObservableProperty]
        private string taxiwayName;

        [ObservableProperty]
        private string runwayName;

        [ObservableProperty]
        private int runwayLength;

        public AirportControlModel(IAirportService airportService, IPopupService popupService)
        {
            _airportService = airportService;
            airport = _airportService.CurrentAirport;
            this.popupService = popupService;
        }

        [RelayCommand]
        private void ShowRunwayPopup()
        {
            Debug.WriteLine("Attempting to show popup");
            if (runwayPopup == null)
            {
                runwayPopup = new RunwayPopup(this);
            }
            Shell.Current.ShowPopup(runwayPopup);
            isRunwayPopupOpen = true;
        }

        [RelayCommand]
        private void CloseRunwayPopup()
        {
            if (runwayPopup != null && isRunwayPopupOpen)
            {
                runwayPopup.Close();
                isRunwayPopupOpen = false;
            }
        }


        [RelayCommand]
        private void AddTerminal()
        {
            if (string.IsNullOrWhiteSpace(TerminalName))
            {
                return;
            }
            Terminal terminal = new Terminal(TerminalName, Airport);
            TerminalName = string.Empty;
        }

        [RelayCommand]
        private void AddGate()
        {
            if (string.IsNullOrWhiteSpace(GateName))
            {
                return;
            }
            Gate gate = new Gate(GateName, Airport);
            GateName = string.Empty;
        }

        [RelayCommand]
        private void AddRunway() 
        {
            Debug.WriteLine("Attempting to add runway");
            //Runway _ = new(RunwayName, RunwayLength, Airport);
            //RunwayName = string.Empty;
            //RunwayLength = 0;
            //CloseRunwayPopup();
        }
    }
}
