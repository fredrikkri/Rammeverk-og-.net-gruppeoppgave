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
        private string name;

        public MyAirportModel(IAirportService airportService)
        {
            _airportService = airportService;

            airport = _airportService.CurrentAirport;

            if (airport != null)
            {
                Gates = new ObservableCollection<Gate>(airport.GetListGates());
            }
            else
            {
                Gates = new ObservableCollection<Gate>();
            }

        }
        public void LoadData()
        {
            Gates = new ObservableCollection<Gate>(_airportService.CurrentAirport.GetListGates());
        }
    }
}
