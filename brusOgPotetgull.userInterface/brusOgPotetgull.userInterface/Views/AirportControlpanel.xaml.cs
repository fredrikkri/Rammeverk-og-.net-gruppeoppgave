using brusOgPotetgull.userInterface.ViewModel;
using CommunityToolkit.Maui.Core;
using brusOgPotetgull.userInterface.Popups;

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