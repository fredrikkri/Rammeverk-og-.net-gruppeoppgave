using brusOgPotetgull.userInterface.ViewModel;

namespace brusOgPotetgull.userInterface.Views
{
    public partial class MyAirport : ContentPage
    {
        public MyAirport(MyAirportModel vm)
	    {
		    InitializeComponent();
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as MyAirportModel;
            viewModel?.LoadData();
        }
    }
}