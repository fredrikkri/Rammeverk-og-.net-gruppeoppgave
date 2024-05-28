using brusOgPotetgull.userInterface.Services;
using BrusOgPotetgull.AirportLiberary;
using BrusOgPotetgull.AirportLiberary.AircraftTypes;
using BrusOgPotetgull.AirportLiberary.Simulation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class SimulationModel : ObservableObject
    {
        protected readonly IAirportService _airportService;

        [ObservableProperty]
        private Airport airport;

        [ObservableProperty]
        private ObservableCollection<Gate> gates = [];

        [ObservableProperty]
        private ObservableCollection<Runway> runways = [];

        [ObservableProperty]
        private ObservableCollection<Terminal> terminals = [];

        [ObservableProperty]
        private ObservableCollection<Taxiway> taxiways = [];

        [ObservableProperty]
        private ObservableCollection<Aircraft> aircrafts = [];

        [ObservableProperty]
        private ObservableCollection<Flight> departingFlights = [];

        [ObservableProperty]
        private ObservableCollection<Flight> arrivingFlights = [];

        [ObservableProperty]
        private ObservableCollection<ConnectionPoint> connectionPoints = [];

        [ObservableProperty]
        private Aircraft simAircraft;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private bool frameVisible = false;

        [ObservableProperty]
        DateTime simStartDate;

        [ObservableProperty]
        TimeSpan simStartTime;

        [ObservableProperty]
        DateTime simEndDate;

        [ObservableProperty]
        TimeSpan simEndTime;

        [ObservableProperty]
        string history = "";

        public SimulationModel(IAirportService airportService)
        {
            _airportService = airportService;
            airport = _airportService.CurrentAirport;
            SimStartDate = DateTime.Now;
            SimEndDate = DateTime.Now;
            SimStartTime = DateTime.Now.TimeOfDay;
            SimEndTime = DateTime.Now.TimeOfDay;

            if (airport != null)
            {
                Gates = new ObservableCollection<Gate>(airport.GetListGates());
                Runways = new ObservableCollection<Runway>(airport.GetRunwayList());
                Terminals = new ObservableCollection<Terminal>(airport.GetListTerminals());
                Taxiways = new ObservableCollection<Taxiway>(airport.GetListTaxiways());
                DepartingFlights = new ObservableCollection<Flight>(airport.GetDepartingFlights());
                ArrivingFlights = new ObservableCollection<Flight>(airport.GetArrivingFlights());
                ConnectionPoints = new ObservableCollection<ConnectionPoint>(airport.GetTaxiwaySystem());
            }
        }

        [RelayCommand]
        private async Task RunSimulation() 
        {
            DateTime SimulationStart = new(
            SimStartDate.Year,
            SimStartDate.Month,
            SimStartDate.Day,
            SimStartTime.Hours,
            SimStartTime.Minutes,
            SimStartTime.Seconds);
            DateTime SimulationEnd = new(
            SimEndDate.Year,
            SimEndDate.Month,
            SimEndDate.Day,
            SimEndTime.Hours,
            SimEndTime.Minutes,
            SimEndTime.Seconds);

            if (Airport != null && SimulationStart < SimulationEnd)
            {
                Simulation sim = new(Airport, SimulationStart, SimulationEnd);
                await _airportService.ShowNotificationAsync("Notification", "Running simulation", "Ok");
                sim.RunSimulation();
                LoadData();
                await _airportService.ShowNotificationAsync("Notification", "Simulation Complete", "Ok");
            }
            else
            {
                await _airportService.ShowNotificationAsync("Alert", "Missing params. Start must come before end and airport must be selected and configured", "Ok");
                return;
            }
        }

        [RelayCommand]
        public void LoadData()
        {
            if (_airportService.CurrentAirport == null) { return; }
            else
            {
                Gates = new ObservableCollection<Gate>(_airportService.CurrentAirport.GetListGates());
                Runways = new ObservableCollection<Runway>(_airportService.CurrentAirport.GetRunwayList());
                Terminals = new ObservableCollection<Terminal>(_airportService.CurrentAirport.GetListTerminals());
                Taxiways = new ObservableCollection<Taxiway>(_airportService.CurrentAirport.GetListTaxiways());
                ArrivingFlights = new ObservableCollection<Flight>(_airportService.CurrentAirport.GetArrivingFlights());
                DepartingFlights = new ObservableCollection<Flight>(_airportService.CurrentAirport.GetDepartingFlights());
                ConnectionPoints = new ObservableCollection<ConnectionPoint>(_airportService.CurrentAirport.GetTaxiwaySystem());

                foreach (var item in Airport.GetArrivingFlights())
                {
                    if (Aircrafts.Contains(item.ActiveAircraft)) { continue; }
                    else { Aircrafts.Add(item.ActiveAircraft); }
                }
                foreach (var item in Airport.GetDepartingFlights())
                {
                    if (Aircrafts.Contains(item.ActiveAircraft)) { continue; }
                    else { Aircrafts.Add(item.ActiveAircraft); }
                }
                UpdateHistory();
            }
        }

        private void UpdateHistory()
        {
            if (SimAircraft != null && Aircrafts.Contains(SimAircraft)) { History = SimAircraft.GetFullAircraftHistory(); }
            else { History = "No Aircraft Selected or Simulation not ran yet"; }
        }
    }
}
