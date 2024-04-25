using brusOgPotetgull.userInterface.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using BrusOgPotetgull.AirportLiberary;
using System.Collections.ObjectModel;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class MyAirportModel : ObservableObject
    {
        protected readonly IAirportService _airportService;

        [ObservableProperty]
        private Airport airport;

        [ObservableProperty]
        private ObservableCollection<Gate> gates;

        [ObservableProperty]
        private ObservableCollection<Runway> runways;

        [ObservableProperty]
        private ObservableCollection<Terminal> terminals;

        [ObservableProperty]
        private ObservableCollection<Taxiway> taxiways;

        [ObservableProperty]
        private string name;

        public MyAirportModel(IAirportService airportService)
        {
            _airportService = airportService;

            airport = _airportService.CurrentAirport;

            if (airport != null)
            {
                Gates = new ObservableCollection<Gate>(airport.GetListGates());
                Runways = new ObservableCollection<Runway>(airport.GetRunwayList());
                Terminals = new ObservableCollection<Terminal>(airport.GetListTerminals());
                Taxiways = new ObservableCollection<Taxiway>(airport.GetListTaxiways());
            }
            else
            {
                Runways = new ObservableCollection<Runway>();
                Gates = new ObservableCollection<Gate>();
                Terminals = new ObservableCollection<Terminal>();
                Taxiways = new ObservableCollection<Taxiway>();
            }

        }
        public void LoadData()
        {
            Gates = new ObservableCollection<Gate>(_airportService.CurrentAirport.GetListGates());
            Runways = new ObservableCollection<Runway>(_airportService.CurrentAirport.GetRunwayList());
            Terminals = new ObservableCollection<Terminal>(_airportService.CurrentAirport.GetListTerminals());
            Taxiways = new ObservableCollection<Taxiway>(_airportService.CurrentAirport.GetListTaxiways());
        }
    }
}
