using brusOgPotetgull.userInterface.ViewModel;
using CommunityToolkit.Maui.Views;

namespace brusOgPotetgull.userInterface.Popups
{
    public partial class TaxiwayPopup : Popup
    {
        public TaxiwayPopup(AirportControlModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}