using brusOgPotetgull.userInterface.ViewModel;

namespace brusOgPotetgull.userInterface.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
