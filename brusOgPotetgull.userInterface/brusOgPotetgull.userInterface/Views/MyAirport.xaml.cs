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
    }
}