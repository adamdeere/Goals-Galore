using GoalsGalore.ViewModels;

namespace GoalsGalore.Views.ShellViews;

public partial class TestCardPage
{
    public TestCardPage(TestCardPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}