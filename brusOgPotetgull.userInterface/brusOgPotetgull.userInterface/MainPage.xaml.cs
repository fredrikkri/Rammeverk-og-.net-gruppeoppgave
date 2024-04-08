using BrusOgPotetgull.AirportLiberary;
namespace brusOgPotetgull.userInterface
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        
        private void OnAirportClicked(object sender, EventArgs e)
        {
            var airportCode = Paramentry1.Text;
            var name = Paramentry2.Text;
            var location = Paramentry3.Text;
            _ = new Airport(airportCode, name, location);
        }
    }
}
