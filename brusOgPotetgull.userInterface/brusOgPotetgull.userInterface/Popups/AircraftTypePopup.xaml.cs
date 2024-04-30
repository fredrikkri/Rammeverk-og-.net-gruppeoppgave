using brusOgPotetgull.userInterface.ViewModel;
using CommunityToolkit.Maui.Views;

namespace brusOgPotetgull.userInterface.Popups
{
    public partial class AircraftTypePopup : Popup
    {
        public AircraftTypePopup(AirportControlModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}