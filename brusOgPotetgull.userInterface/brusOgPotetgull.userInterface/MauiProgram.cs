using brusOgPotetgull.userInterface.Services;
using brusOgPotetgull.userInterface.ViewModel;
using brusOgPotetgull.userInterface.Views;
using Microsoft.Extensions.Logging;

namespace brusOgPotetgull.userInterface
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IAirportService, AirportService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainModel>();
            builder.Services.AddSingleton<AirportControlpanel>();
            builder.Services.AddSingleton<AirportControlModel>();
            builder.Services.AddSingleton<MyAirport>();
            builder.Services.AddSingleton<MyAirportModel>();
            builder.Services.AddSingleton<Simulation>();
            builder.Services.AddSingleton<SimulationModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
