using MAUIFlexSkills.ViewModels;

namespace MAUIFlexSkills
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;

        public MainPage()
        {
            InitializeComponent();

            vm = new MainPageViewModel();
            BindingContext = vm;
        }
    }
}