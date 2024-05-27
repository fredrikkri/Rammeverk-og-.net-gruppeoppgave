using brusOgPotetgull.userInterface.ViewModel;

namespace brusOgPotetgull.userInterface.Views
{
        public partial class Simulation : ContentPage
    {
        public Simulation(SimulationModel vm)
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