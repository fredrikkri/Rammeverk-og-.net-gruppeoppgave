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
        private PlaceTaxiwayPopup placeTaxiwayPopup;
        private bool isTerminalPopupOpen;
        private bool isGatePopupOpen;
        private bool isRunwayPopupOpen;
        private bool isTaxiwayPopupOpen;
        private bool isAircraftTypePopupOpen;
        private bool isAircraftPopupOpen;
        private bool isConnectionPointPopupOpen;
        private bool isFlightPopupOpen;
        private bool isGateConnectionPopupOpen;
        private bool isPlaceTaxiwayPopupOpen;

        [ObservableProperty]
        private Airport airport;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private ObservableCollection<AircraftType> aircraftTypes = [];

        [ObservableProperty]
        private ObservableCollection<Aircraft> aircrafts = [];

        [ObservableProperty]
        private ObservableCollection<ConnectionPoint> connectionPoints = [];

        [ObservableProperty]
        private ObservableCollection<Terminal> terminals = [];

        [ObservableProperty]
        private ObservableCollection<Runway> runways = [];

        [ObservableProperty]
        private ObservableCollection<Taxiway> taxiways = [];

        [ObservableProperty]
        private ObservableCollection<Gate> gates = [];

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

        [ObservableProperty]
        private ConnectionPoint selectedConnectionPointA;

        [ObservableProperty]
        private ConnectionPoint selectedConnectionPointB;

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
        private async Task AddRunway()
        {
            if (string.IsNullOrWhiteSpace(RunwayName) || RunwayLength <= 0)
            {
                await _airportService.ShowNotificationAsync("Alert", "Needs name and value greater than 0 to add runway", "Ok");
                return;
            }
            Runway _ = new(RunwayName, RunwayLength, _airportService.CurrentAirport);
            LoadControlData();
            CloseRunwayPopup();
            await _airportService.ShowNotificationAsync("Notification", RunwayName + " has been added", "Ok");
            ResetParams();
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
        private async Task AddGate()
        {
            if (string.IsNullOrWhiteSpace(GateName))
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Gatename", "Ok");
                return;
            }
            Gate gate = new Gate(GateName, _airportService.CurrentAirport);
            if (gate != null || SelectedTerminal != null) 
            {
                SelectedTerminal.AddGateToList(gate);
                LoadControlData();
                CloseGatePopup();
                await _airportService.ShowNotificationAsync("Notification", GateName + " has been added", "Ok");
                ResetParams();
            }
            else
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Terminal", "Ok");
                return;
            }
        }

//              @@@@@@@@@@@  TERMINALS  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private async Task AddTerminal()
        {
            if (string.IsNullOrWhiteSpace(TerminalName))
            {
                await _airportService.ShowNotificationAsync("Alert", "Terminal Name is missing", "Ok");
                return;
            }
            Terminal terminal = new Terminal(TerminalName, _airportService.CurrentAirport);
            Terminals.Add(terminal);
            LoadControlData();
            await _airportService.ShowNotificationAsync("Notification", TerminalName + " has been added", "Ok");
            //ResetParams();
            CloseTerminalPopup();
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
        private async Task AddTaxiway()
        {
            if (string.IsNullOrWhiteSpace(TaxiwayName) || TaxiwayLength <= 0 || TaxiwaySpeed <= 0)
            {
                await _airportService.ShowNotificationAsync("Alert", "Needs Name and values greater than 0 to add taxiway", "Ok");
                return;
            }
            Taxiway taxiway = new Taxiway(TaxiwayName, TaxiwayLength, TaxiwaySpeed , _airportService.CurrentAirport);
            LoadControlData();
            CloseTaxiwayPopup();
            await _airportService.ShowNotificationAsync("Notification", TaxiwayName + " has been added", "Ok");
            ResetParams();
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
        private async Task AddConnectionPoint()
        {
            if (string.IsNullOrWhiteSpace(ConnectionPointName))
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Name", "Ok");
                return;
            }
            ConnectionPoint _ = new(ConnectionPointName, _airportService.CurrentAirport);
            LoadControlData();
            await _airportService.ShowNotificationAsync("Notification", ConnectionPointName + " has been added", "Ok");
            CloseConnectionPointPopup();
            ResetParams();
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
        private async Task AddGateConnection()
        {
            if (SelectedGate != null && SelectedTaxiway != null)
            {
                SelectedTaxiway.AddConnectedGate(SelectedGate);
                CloseGateConnectionPopup();
                await _airportService.ShowNotificationAsync("Notification", "Connection ( " + SelectedGate + " -> " + SelectedTaxiway + " ) has been added", "Ok");
                ResetParams();
            }
            else 
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Gate or Taxiway", "Ok");
                return; 
            }
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

        [RelayCommand]
        private void ShowPlaceTaxiwayPopup()
        {
            Debug.WriteLine("Attempting to show GateConnection popup");
            if (placeTaxiwayPopup == null)
            {
                placeTaxiwayPopup = new PlaceTaxiwayPopup(this);
            }
            Shell.Current.ShowPopup(placeTaxiwayPopup);
            isPlaceTaxiwayPopupOpen = true;
        }

        [RelayCommand]
        private void ClosePlaceTaxiwayPopup()
        {
            if (placeTaxiwayPopup != null && isPlaceTaxiwayPopupOpen)
            {
                placeTaxiwayPopup.Close();
                isPlaceTaxiwayPopupOpen = false;
            }
        }

        [RelayCommand]
        private async Task PlaceTaxiway() 
        {
            if (SelectedTaxiway != null && SelectedConnectionPointA != null && SelectedConnectionPointB != null)
            {
                _airportService.CurrentAirport.AddTaxiwayConnection(SelectedTaxiway, SelectedConnectionPointA, SelectedConnectionPointB);
                await _airportService.ShowNotificationAsync("Notification", "Connection ( " + SelectedConnectionPointA + " <-> " + SelectedTaxiway + " <-> " + SelectedConnectionPointB + " ) Created", "Ok");
                ResetParams();
                ClosePlaceTaxiwayPopup();
            }
            else 
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Params", "Ok");
                return ; 
            }
        }
        //              @@@@@@@@@@@  AIRCRAFTS  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        [RelayCommand]
        private async Task AddAircraftType()
        {
            if (string.IsNullOrWhiteSpace(AircraftTypeName))
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Aircrafttype Name", "Ok");
                return;
            }
            AircraftType aircraftType = new AircraftType(AircraftTypeName);
            AircraftTypes.Add(aircraftType);
            await _airportService.ShowNotificationAsync("Notification", AircraftTypeName + " has been added", "Ok");
            ResetParams();
            CloseAircraftTypePopup();
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
        private async Task AddAircraft()
        {
            if (string.IsNullOrWhiteSpace(AircraftName) || MaxSpeedAir <= 0 || MaxSpeedGround <= 0 || AccelerationGround < 0 || AccelerationAir < 0)
            {
                await _airportService.ShowNotificationAsync("Alert", "Needs Aircraft Name and Values greater than 0", "Ok");
                return;
                
            }
            Aircraft aircraft = new Aircraft(AircraftName, SelectedAircraftType, MaxSpeedAir, AccelerationAir, MaxSpeedGround, AccelerationGround);
            Aircrafts.Add(aircraft);
            await _airportService.ShowNotificationAsync("Notification", AircraftName + " has been added", "Ok");
            ResetParams();
            CloseAircraftPopup();
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
        private async Task AddFlight()
        {
            if (FlightTypeSelector == "Arriving")
            {
                Flight.Arriving flight = new(SelectedAircraft, FlightDate, FlightLength, _airportService.CurrentAirport, SelectedGate, SelectedTaxiway, SelectedRunway);
                await _airportService.ShowNotificationAsync("Notification", "Arriving flight with id " + flight.FlightId.ToString() + " added", "Ok");
                ResetParams();
                CloseFlightPopup();
            }
            else if (FlightTypeSelector == "Departing")
            {
                Flight.Departing flight = new(SelectedAircraft, FlightDate, FlightLength, _airportService.CurrentAirport, SelectedGate, SelectedTaxiway, SelectedRunway);
                await _airportService.ShowNotificationAsync("Notification", "Departing flight with id " + flight.FlightId.ToString() + " added", "Ok");
                ResetParams();
                CloseFlightPopup();
            }
            else
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing Paramter", "Ok");
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

        public DateTime FlightDate => new (
            SelectedDate.Year,
            SelectedDate.Month,
            SelectedDate.Day,
            SelectedTime.Hours,
            SelectedTime.Minutes,
            SelectedTime.Seconds
            );

        [RelayCommand]
        public void DummyData()
        {
            // Airport config
            ObservableCollection<Gate> gateList = [new("Gate A1", _airportService.CurrentAirport), new("Gate B1", _airportService.CurrentAirport), new("Gate C1", _airportService.CurrentAirport), new("Gate C2", _airportService.CurrentAirport)];
            ObservableCollection<Runway> runwayList = [new("Runway 1", 1000, _airportService.CurrentAirport), new("Runway 2", 1000, _airportService.CurrentAirport)];
            ObservableCollection<Terminal> terminalList = [new("Terminal 1", _airportService.CurrentAirport), new("Terminal 2", _airportService.CurrentAirport)];
            ObservableCollection<Taxiway> taxiList = [new("Alpha", 200, 30, _airportService.CurrentAirport), new("Bravo", 200, 30, _airportService.CurrentAirport), new("Charlie", 200, 30, _airportService.CurrentAirport), new("Delta", 200, 30, _airportService.CurrentAirport), new("Echo", 200, 30, _airportService.CurrentAirport), new("Foxtrot", 200, 30, _airportService.CurrentAirport), new("Golf", 200, 30, _airportService.CurrentAirport), new("Hotel", 200, 30, _airportService.CurrentAirport),];
            ObservableCollection<ConnectionPoint> connectionPointList = [new("A1", _airportService.CurrentAirport), new("B2", _airportService.CurrentAirport), new("C3", _airportService.CurrentAirport), new("D4", _airportService.CurrentAirport), new("E5", _airportService.CurrentAirport), new("F6", _airportService.CurrentAirport), new("G7", _airportService.CurrentAirport), new("H8", _airportService.CurrentAirport), new("I9", _airportService.CurrentAirport)];

            // Roadsystem setup
            taxiList[0].AddConnectedGate(gateList[0]);
            taxiList[3].AddConnectedGate(gateList[2]);
            taxiList[5].AddConnectedGate(gateList[3]);
            taxiList[0].AddConnectedRunway(runwayList[0]);
            taxiList[5].AddConnectedRunway(runwayList[1]);
            this.Airport.AddTaxiwayConnection(taxiList[0], connectionPointList[0], connectionPointList[1]);
            this.Airport.AddTaxiwayConnection(taxiList[1], connectionPointList[1], connectionPointList[2]);
            this.Airport.AddTaxiwayConnection(taxiList[2], connectionPointList[2], connectionPointList[3]);
            this.Airport.AddTaxiwayConnection(taxiList[3], connectionPointList[3], connectionPointList[4]);
            this.Airport.AddTaxiwayConnection(taxiList[4], connectionPointList[4], connectionPointList[5]);
            this.Airport.AddTaxiwayConnection(taxiList[5], connectionPointList[5], connectionPointList[6]);

            // Flight config
            ObservableCollection<AircraftType> aircraftTypesList = [new("Airbus 480"), new("Boeing 737")];
            ObservableCollection<Aircraft> aircraftsList = [new("D1280", aircraftTypesList[0], 890, 50, 35, 3), new("MH370", aircraftTypesList[1], 800, 30, 30, 3)];
            AircraftTypes = aircraftTypesList;
            Aircrafts = aircraftsList;
            Flight.Arriving Flight1 = new(Aircrafts[0], new DateTime(2024, 5, 28, 00, 05, 00), 10000, _airportService.CurrentAirport, gateList[0], taxiList[2], runwayList[0]);
            Flight.Departing Flight2 = new(Aircrafts[1], new DateTime(2024, 5, 28, 00, 15, 00), 10000, _airportService.CurrentAirport, gateList[3], taxiList[1], runwayList[1]);
        }

        [RelayCommand]
        public void LoadControlData()
        {
            Gates = new ObservableCollection<Gate>(_airportService.CurrentAirport.GetListGates());
            Runways = new ObservableCollection<Runway>(_airportService.CurrentAirport.GetRunwayList());
            Terminals = new ObservableCollection<Terminal>(_airportService.CurrentAirport.GetListTerminals());
            Taxiways = new ObservableCollection<Taxiway>(_airportService.CurrentAirport.GetListTaxiways());
            ConnectionPoints = new ObservableCollection<ConnectionPoint>(_airportService.CurrentAirport.GetTaxiwaySystem());
        }
        private void ResetParams() 
        {
            SelectedGate = null;
            SelectedTaxiway = null;
            SelectedRunway = null;
            SelectedTerminal = null;
            SelectedAircraft = null;
            SelectedAircraftType = null;
            AircraftTypeName = string.Empty;
            
            
            
            ConnectionPointName = string.Empty;
            AircraftName = string.Empty;
            MaxSpeedAir = 0;
            AccelerationAir = 0;
            MaxSpeedGround = 0;
            AccelerationGround = 0;
            TaxiwayName = string.Empty;
            TaxiwayLength = 0;
            TaxiwaySpeed = 0;
            RunwayName = string.Empty;
            RunwayLength = 0;
            GateName = string.Empty;
            TerminalName = string.Empty;
        }
    }
}
