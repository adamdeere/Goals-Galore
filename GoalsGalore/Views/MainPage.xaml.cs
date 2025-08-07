using GoalsGalore.ViewModels;

namespace GoalsGalore;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    
}