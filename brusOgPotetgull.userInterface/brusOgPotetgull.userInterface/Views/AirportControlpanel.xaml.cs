using brusOgPotetgull.userInterface.ViewModel;

namespace brusOgPotetgull.userInterface.Views
{
    public partial class AirportControlpanel : ContentPage
    {
        public AirportControlpanel(AirportControlModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}