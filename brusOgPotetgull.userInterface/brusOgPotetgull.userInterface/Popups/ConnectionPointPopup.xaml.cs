using brusOgPotetgull.userInterface.ViewModel;
using CommunityToolkit.Maui.Views;

namespace brusOgPotetgull.userInterface.Popups
{
    public partial class ConnectionPointPopup : Popup
    {
        public ConnectionPointPopup(AirportControlModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}