namespace brusOgPotetgull.userInterface.ViewModel;

public class TaxiwaySystemView : ContentView
{
	public TaxiwaySystemView()
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
