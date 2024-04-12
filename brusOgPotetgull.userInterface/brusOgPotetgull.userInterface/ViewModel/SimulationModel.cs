using brusOgPotetgull.userInterface.Services;
using BrusOgPotetgull.AirportLiberary;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace brusOgPotetgull.userInterface.ViewModel;

public partial class SimulationModel : ObservableObject
{

    protected readonly IAirportService _airportService;

    [ObservableProperty]
    private string airportName;

    [ObservableProperty]
    private string startTime;

    [ObservableProperty]
    private string endTime;




    public SimulationModel(IAirportService airportService)
    {
        _airportService = airportService;
    }

    [RelayCommand]
    private void CreateSimulation()
    {
        
        _airportService.CurrentAirport = new Airport(AirportName, StartTime, EndTime);
        AirportName = string.Empty;
        StartTime = string.Empty;
        EndTime = string.Empty;
    }


 ///       Content = new VerticalStackLayout
 ///       {
 ///           Children = {
 ///               new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
 ///               }
 ///           }
 ///       };
    
};
