using brusOgPotetgull.userInterface.Services;
using BrusOgPotetgull.AirportLiberary;
namespace brusOgPotetgull.userInterface.Views
{
    public partial class MainPage : ContentPage
    {
        Airport airport = AirportService.Instance.CurrentAirport;
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void OnAirportClicked(object sender, EventArgs e)
        {
            var airportCode = Paramentry1.Text;
            var name = Paramentry2.Text;
            var location = Paramentry3.Text;
            AirportService.Instance.CurrentAirport = new Airport(airportCode, name, location);
            airport = AirportService.Instance.CurrentAirport;

            DisplayAlert("Airport Created", $"You have created: {airport.Name} located in {airport.Location}.", "OK");
            AirportInfo.Text = $"Your created airport: {airport.Name}\nConfigure your airport in the next tab 'Controlpanel'";
        }
    }
}
