namespace brusOgPotetgull.userInterface.ViewModel;

public class AircraftAndFlightsView : ContentPage
{
	public AircraftAndFlightsView()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}
