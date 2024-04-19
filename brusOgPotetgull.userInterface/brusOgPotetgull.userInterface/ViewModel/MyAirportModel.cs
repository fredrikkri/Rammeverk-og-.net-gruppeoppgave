using brusOgPotetgull.userInterface.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using BrusOgPotetgull.AirportLiberary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public MyAirportModel(IAirportService airportService)
        {
            _airportService = airportService;

            airport = _airportService.CurrentAirport;

            gates = new ObservableCollection<Gate>(airport.GetListGates());

        }
    }
}
