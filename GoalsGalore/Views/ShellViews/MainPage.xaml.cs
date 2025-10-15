using GoalsGalore.ViewModels;

namespace GoalsGalore.Views.ShellViews;

public partial class MainPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        vm.PlatTabView = PlatTabView;
        BindingContext = vm;
    }
}