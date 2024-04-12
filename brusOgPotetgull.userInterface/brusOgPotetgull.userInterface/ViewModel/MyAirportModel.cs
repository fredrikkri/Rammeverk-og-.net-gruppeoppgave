using brusOgPotetgull.userInterface.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace brusOgPotetgull.userInterface.ViewModel
{
    public partial class MyAirportModel : ObservableObject
    {
        protected readonly IAirportService _airportService;

        [ObservableProperty]
        private string airportName;
        public MyAirportModel(IAirportService airportService)
        {
            _airportService = airportService;
        }
    }
}
