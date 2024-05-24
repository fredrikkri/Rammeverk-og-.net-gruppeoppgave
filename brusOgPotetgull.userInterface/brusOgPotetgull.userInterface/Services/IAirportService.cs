using BrusOgPotetgull.AirportLiberary;

namespace brusOgPotetgull.userInterface.Services
{
    public interface IAirportService
    {
        Airport CurrentAirport { get; set; }
        Task ShowNotificationAsync(string title, string message, string buttonText);
    }
}