using brusOgPotetgull.userInterface.Services;
using brusOgPotetgull.userInterface.Popups;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class AirportControlModel : ObservableObject
    {
        protected readonly IAirportService _airportService;
        private RunwayPopup runwayPopup;
        private GatePopup gatePopup;
        private TerminalPopup terminalPopup;
        private TaxiwayPopup taxiwayPopup;
        private AircraftTypePopup aircraftTypePopup;
        private AircraftPopup aircraftPopup;
        private ConnectionPointPopup connectionPointPopup;
        private FlightPopup flightPopup;
        private GateConnectionPopup gateConnectionPopup;
        private bool isTerminalPopupOpen;
        private bool isGatePopupOpen;
        private bool isRunwayPopupOpen;
        private bool isTaxiwayPopupOpen;
        private bool isAircraftTypePopupOpen;
        private bool isAircraftPopupOpen;
        private bool isConnectionPointPopupOpen;
        private bool isFlightPopupOpen;
        private bool isGateConnectionPopupOpen;

        [ObservableProperty]
        private Airport airport;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ObservableCollection<AircraftType> aircraftTypes = new ObservableCollection<AircraftType>();

        [ObservableProperty]
        private ObservableCollection<Aircraft> aircrafts = new ObservableCollection<Aircraft>();

        [ObservableProperty]
        private ObservableCollection<ConnectionPoint> connectionPoints = new ObservableCollection<ConnectionPoint>();

        [ObservableProperty]
        private ObservableCollection<Terminal> terminals = new ObservableCollection<Terminal>();

        [ObservableProperty]
        private ObservableCollection<Runway> runways;

        [ObservableProperty]
        private ObservableCollection<Taxiway> taxiways;

        [ObservableProperty]
        private ObservableCollection<Gate> gates;

        [ObservableProperty]
        private string terminalName;

        [ObservableProperty]
        private Terminal selectedTerminal;

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

        [ObservableProperty]
        private string aircraftTypeName;

        [ObservableProperty]
        private string aircraftName;

        [ObservableProperty]
        private AircraftType selectedAircraftType;

        [ObservableProperty]
        private int maxSpeedAir;

        [ObservableProperty]
        private int accelerationAir;

        [ObservableProperty]
        private int maxSpeedGround;

        [ObservableProperty]
        private int accelerationGround;

        [ObservableProperty]
        private string connectionPointName;

        [ObservableProperty]
        private ObservableCollection<string> flightTypeOptions = new ObservableCollection<string>{"Arriving", "Departing"};

        [ObservableProperty]
        private string flightTypeSelector;

        [ObservableProperty]
        DateTime selectedDate;

        [ObservableProperty]
        TimeSpan selectedTime;

        [ObservableProperty]
        private int flightLength;

        [ObservableProperty]
        private Taxiway selectedTaxiway;

        [ObservableProperty]
        private Runway selectedRunway;

        [ObservableProperty]
        private Gate selectedGate;

        [ObservableProperty]
        private Aircraft selectedAircraft;

        public AirportControlModel(IAirportService airportService)
        {
            _airportService = airportService;
            airport = _airportService.CurrentAirport;
            selectedDate = DateTime.Now;
            selectedTime = DateTime.Now.TimeOfDay;
        }

        //              @@@@@@@@@@@  RUNWAYS  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
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
            LoadControlData();
            CloseRunwayPopup();
        }

//              @@@@@@@@@@@  GATES  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
            if (gate != null || SelectedTerminal != null) 
            {
                GateName = string.Empty;
                SelectedTerminal.AddGateToList(gate);
                SelectedTerminal = null;
                LoadControlData();
                CloseGatePopup();
            }
            else
            {
                SelectedTerminal = null;
                Debug.WriteLine($"Gate is missing name or terminal");
                return;
            }
        }

//              @@@@@@@@@@@  TERMINALS  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private void AddTerminal()
        {
            if (string.IsNullOrWhiteSpace(TerminalName))
            {
                return;
            }
            Terminal terminal = new Terminal(TerminalName, Airport);
            TerminalName = string.Empty;
            Terminals.Add(terminal);
            LoadControlData();
        }

        [RelayCommand]
        private void ShowTerminalPopup()
        {
            Debug.WriteLine("Attempting to show terminal popup");
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

        //              @@@@@@@@@@@  TAXIWAYS  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private void AddTaxiway()
        {
            if (string.IsNullOrWhiteSpace(TaxiwayName) || TaxiwayLength <= 0 || TaxiwaySpeed <= 0)
            {
                return;
            }
            Taxiway taxiway = new Taxiway(TaxiwayName, TaxiwayLength, TaxiwaySpeed , Airport);
            TaxiwayName = string.Empty;
            TaxiwayLength = 0;
            TaxiwaySpeed = 0;
            LoadControlData();
        }

        [RelayCommand]
        private void ShowTaxiwayPopup()
        {
            Debug.WriteLine("Attempting to show taxiway popup");
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

        //              @@@@@@@@@@@  CONNECTION POINT   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private void AddConnectionPoint()
        {
            if (string.IsNullOrWhiteSpace(ConnectionPointName))
            {
                return;
            }
            ConnectionPoint connectionPoint = new(ConnectionPointName, Airport);
            Airport.AddConnectionPoint(connectionPoint);
            ConnectionPointName = string.Empty;
            // Får ikke tilgang til listen med connectionpoints i airport (private)
        }

        [RelayCommand]
        private void ShowConnectionPointPopup()
        {
            Debug.WriteLine("Attempting to show ConnectionPoint popup");
            if (connectionPointPopup == null)
            {
                connectionPointPopup = new ConnectionPointPopup(this);
            }
            Shell.Current.ShowPopup(connectionPointPopup);
            isConnectionPointPopupOpen = true;
        }

        [RelayCommand]
        private void CloseConnectionPointPopup()
        {
            if (connectionPointPopup != null && isConnectionPointPopupOpen)
            {
                connectionPointPopup.Close();
                isConnectionPointPopupOpen = false;
            }
        }

        [RelayCommand]
        private void AddGateConnection()
        {
            SelectedTaxiway.AddConnectedGate(SelectedGate);
            SelectedTaxiway = null;
            SelectedGate = null;
        }

        [RelayCommand]
        private void ShowGateConnectionPopup()
        {
            Debug.WriteLine("Attempting to show GateConnection popup");
            if (gateConnectionPopup == null)
            {
                gateConnectionPopup = new GateConnectionPopup(this);
            }
            Shell.Current.ShowPopup(gateConnectionPopup);
            isGateConnectionPopupOpen = true;
        }

        [RelayCommand]
        private void CloseGateConnectionPopup()
        {
            if (gateConnectionPopup != null && isGateConnectionPopupOpen)
            {
                gateConnectionPopup.Close();
                isGateConnectionPopupOpen = false;
            }
        }
        //              @@@@@@@@@@@  AIRCRAFTS  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private void AddAircraftType()
        {
            if (string.IsNullOrWhiteSpace(AircraftTypeName))
            {
                return;
            }
            AircraftType aircraftType = new AircraftType(AircraftTypeName);
            AircraftTypeName = string.Empty;
            AircraftTypes.Add(aircraftType);
        }

        [RelayCommand]
        private void ShowAircraftTypePopup()
        {
            Debug.WriteLine("Attempting to show aircrafttype popup");
            if (aircraftTypePopup == null)
            {
                aircraftTypePopup = new AircraftTypePopup(this);
            }
            Shell.Current.ShowPopup(aircraftTypePopup);
            isAircraftTypePopupOpen = true;
        }

        [RelayCommand]
        private void CloseAircraftTypePopup()
        {
            if (aircraftTypePopup != null && isAircraftTypePopupOpen)
            {
                aircraftTypePopup.Close();
                isAircraftTypePopupOpen = false;
            }
        }

        [RelayCommand]
        private void AddAircraft()
        {
            if (string.IsNullOrWhiteSpace(AircraftName) || MaxSpeedAir <= 0 || MaxSpeedGround <= 0 || AccelerationGround < 0 || AccelerationAir < 0)
            {
                Debug.WriteLine($"Missing input or invalid fields");
                return;
                
            }
            Aircraft aircraft = new Aircraft(AircraftName, SelectedAircraftType, MaxSpeedAir, AccelerationAir, MaxSpeedGround, AccelerationGround);
            Aircrafts.Add(aircraft);
            ResetAircraftFields();
        }

        private void ResetAircraftFields()
        {
            AircraftName = string.Empty;
            SelectedAircraftType = null;
            MaxSpeedAir = 0;
            AccelerationAir = 0;
            MaxSpeedGround = 0;
            AccelerationGround = 0;
        }

        [RelayCommand]
        private void ShowAircraftPopup()
        {
            Debug.WriteLine("Attempting to show aircraftpopup");
            if (aircraftPopup == null)
            {
                aircraftPopup = new AircraftPopup(this);
            }
            Shell.Current.ShowPopup(aircraftPopup);
            isAircraftPopupOpen = true;
        }

        [RelayCommand]
        private void CloseAircraftPopup()
        {
            if (aircraftPopup != null && isAircraftPopupOpen)
            {
                aircraftPopup.Close();
                isAircraftPopupOpen = false;
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@ FLIGHTS @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private void AddFlight()
        {
            if (FlightTypeSelector == "Arriving")
            {
                Flight.Arriving flight = new(SelectedAircraft, FlightDate, FlightLength, Airport, SelectedGate, SelectedTaxiway, SelectedRunway);
                CloseFlightPopup();
            }
            else if (FlightTypeSelector == "Departing")
            {
                Flight.Departing flight = new(SelectedAircraft, FlightDate, FlightLength, Airport, SelectedGate, SelectedTaxiway, SelectedRunway);
                CloseFlightPopup();
            }
            else
            {
                return;
            }
            
        }

        [RelayCommand]
        private void ShowFlightPopup()
        {
            Debug.WriteLine("Attempting to show Flight popup");
            if (flightPopup == null)
            {
                flightPopup = new FlightPopup(this);
            }
            Shell.Current.ShowPopup(flightPopup);
            isFlightPopupOpen = true;
        }

        [RelayCommand]
        private void CloseFlightPopup()
        {
            if (flightPopup != null && isFlightPopupOpen)
            {
                flightPopup.Close();
                isFlightPopupOpen = false;
            }
        }

        public DateTime FlightDate => new DateTime(
            SelectedDate.Year,
            SelectedDate.Month,
            SelectedDate.Day,
            SelectedTime.Hours,
            SelectedTime.Minutes,
            SelectedTime.Seconds
            );

        public void LoadControlData()
        {
            Gates = new ObservableCollection<Gate>(_airportService.CurrentAirport.GetListGates());
            Runways = new ObservableCollection<Runway>(_airportService.CurrentAirport.GetRunwayList());
            Terminals = new ObservableCollection<Terminal>(_airportService.CurrentAirport.GetListTerminals());
            Taxiways = new ObservableCollection<Taxiway>(_airportService.CurrentAirport.GetListTaxiways());
        }
    }
}