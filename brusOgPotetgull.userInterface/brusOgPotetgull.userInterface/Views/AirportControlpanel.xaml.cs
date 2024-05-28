using brusOgPotetgull.userInterface.ViewModel;
using CommunityToolkit.Maui.Core;
using brusOgPotetgull.userInterface.Popups;
using BrusOgPotetgull.AirportLiberary;

namespace brusOgPotetgull.userInterface.Views
{
        public partial class AirportControlpanel : ContentPage
    {
        public AirportControlpanel(AirportControlModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.DummyData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as AirportControlModel;
            viewModel?.LoadControlData();
        }
    }
}