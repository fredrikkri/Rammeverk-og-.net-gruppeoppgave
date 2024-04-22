using brusOgPotetgull.userInterface.Services;
using brusOgPotetgull.userInterface.ViewModel;
using brusOgPotetgull.userInterface.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui;

namespace brusOgPotetgull.userInterface
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
            builder.Services.AddSingleton<IAirportService, AirportService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AirportControlpanel>();
            builder.Services.AddSingleton<MyAirport>();

            builder.Services.AddTransient<MainModel>();
            builder.Services.AddTransient<AirportControlModel>();
            builder.Services.AddSingleton<MyAirportModel>();

            builder.Services.AddTransientPopup<RunwayPopup, AirportControlModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}