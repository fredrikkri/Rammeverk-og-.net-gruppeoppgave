using brusOgPotetgull.userInterface.ViewModel;

namespace brusOgPotetgull.userInterface.Views
{
        public partial class SimulationView : ContentPage
    {
        public SimulationView(SimulationModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as SimulationModel;
            viewModel?.LoadData();
        }
    }
}