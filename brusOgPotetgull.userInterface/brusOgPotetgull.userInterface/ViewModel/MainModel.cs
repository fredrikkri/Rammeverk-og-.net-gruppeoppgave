using brusOgPotetgull.userInterface.Services;
using BrusOgPotetgull.AirportLiberary;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class MainModel : ObservableObject
    {
        protected readonly IAirportService _airportService;

        [ObservableProperty]
        private string? code;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private string? location;

        public MainModel(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [RelayCommand]
        void CreateAirport()
        {
            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Location))
            {
                return;
            }
            else 
            {
                _airportService.CurrentAirport = new Airport(Code, Name, Location);
                Code = string.Empty;
                Name = string.Empty;
                Location = string.Empty;

            }
            OnPropertyChanged(nameof(CurrentAirportDisplay));
        }

        public string CurrentAirportDisplay => _airportService.CurrentAirport != null
            ? $"Current Airport: {_airportService.CurrentAirport.Name} at {_airportService.CurrentAirport.Location} ({_airportService.CurrentAirport.AirportCode})"
            : "No airport selected";
    }
}
