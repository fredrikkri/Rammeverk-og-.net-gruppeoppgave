using brusOgPotetgull.userInterface.ViewModel;
using CommunityToolkit.Maui.Views;

namespace brusOgPotetgull.userInterface.Views
{
    public partial class RunwayPopup : Popup
    {
        public RunwayPopup(AirportControlModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}