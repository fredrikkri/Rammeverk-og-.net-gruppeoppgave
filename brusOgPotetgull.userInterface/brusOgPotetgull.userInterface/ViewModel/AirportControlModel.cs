using brusOgPotetgull.userInterface.Services;
using brusOgPotetgull.userInterface.Views;
using brusOgPotetgull.userInterface.Popups;
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
        private RunwayPopup runwayPopup;
        private GatePopup gatePopup;
        private TerminalPopup terminalPopup;
        private TaxiwayPopup taxiwayPopup;
        private bool isTerminalPopupOpen;
        private bool isGatePopupOpen;
        private bool isRunwayPopupOpen;
        private bool isTaxiwayPopupOpen;

        [ObservableProperty]
        private Airport airport;

        [ObservableProperty]
        private string terminalName;

        [ObservableProperty]
        private string gateName;

        [ObservableProperty]
        private string taxiwayName;

        [ObservableProperty]
        private int taxiwayLength;

        [ObservableProperty]
        private int taxiwaySpeed;

        [ObservableProperty]
        private string runwayName;

        [ObservableProperty]
        private int runwayLength;

        public AirportControlModel(IAirportService airportService)
        {
            _airportService = airportService;
            airport = _airportService.CurrentAirport;
        }

//              @@@@@@@@@@@  RUNWAYS  @@@@@@@@@@@

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
        private void AddRunway()
        {
            Debug.WriteLine("Attempting to add runway");
            Runway _ = new(RunwayName, RunwayLength, Airport);
            RunwayName = string.Empty;
            RunwayLength = 0;
            CloseRunwayPopup();
        }

//              @@@@@@@@@@@  GATES  @@@@@@@@@@@

        [RelayCommand]
        private void ShowGatePopup()
        {
            Debug.WriteLine("Attempting to show popup");
            if (gatePopup == null)
            {
                gatePopup = new GatePopup(this);
            }
            Shell.Current.ShowPopup(gatePopup);
            isGatePopupOpen = true;
        }

        [RelayCommand]
        private void CloseGatePopup()
        {
            if (gatePopup != null && isGatePopupOpen)
            {
                gatePopup.Close();
                isGatePopupOpen = false;
            }
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
            CloseGatePopup();
        }

//              @@@@@@@@@@@  TERMINALS  @@@@@@@@@@@

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
        private void ShowTerminalPopup()
        {
            Debug.WriteLine("Attempting to show popup");
            if (terminalPopup == null)
            {
                terminalPopup = new TerminalPopup(this);
            }
            Shell.Current.ShowPopup(terminalPopup);
            isTerminalPopupOpen = true;
        }

        [RelayCommand]
        private void CloseTerminalPopup()
        {
            if (terminalPopup != null && isTerminalPopupOpen)
            {
                terminalPopup.Close();
                isTerminalPopupOpen = false;
            }
        }

        //              @@@@@@@@@@@  TAXIWAYS  @@@@@@@@@@@

        [RelayCommand]
        private void AddTaxiway()
        {
            if (string.IsNullOrWhiteSpace(TaxiwayName) || TaxiwayLength <= 0 || TaxiwaySpeed <= 0)
            {
                return;
            }
            Taxiway taxiway = new Taxiway(TaxiwayName, TaxiwayLength, TaxiwaySpeed , Airport); // trenger parametere her og i toppen
            TaxiwayName = string.Empty;
            TaxiwayLength = 0;
            TaxiwaySpeed = 0;
        }

        [RelayCommand]
        private void ShowTaxiwayPopup()
        {
            Debug.WriteLine("Attempting to show popup");
            if (taxiwayPopup == null)
            {
                taxiwayPopup = new TaxiwayPopup(this);
            }
            Shell.Current.ShowPopup(taxiwayPopup);
            isTaxiwayPopupOpen = true;
        }

        [RelayCommand]
        private void CloseTaxiwayPopup()
        {
            if (taxiwayPopup != null && isTaxiwayPopupOpen)
            {
                taxiwayPopup.Close();
                isTaxiwayPopupOpen = false;
            }
        }
    }
}
