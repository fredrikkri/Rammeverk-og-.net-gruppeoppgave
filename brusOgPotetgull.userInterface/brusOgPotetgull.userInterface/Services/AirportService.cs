using BrusOgPotetgull.AirportLiberary;

namespace brusOgPotetgull.userInterface.Services
{
    public class AirportService : IAirportService
    {
        public Airport CurrentAirport { get; set; }
        public AirportService() { }
        public async Task ShowNotificationAsync(string title, string message, string buttonText)
        {
            if (Shell.Current != null)
            {
                await Shell.Current.DisplayAlert(title, message, buttonText);
            }
        }
    }
}
