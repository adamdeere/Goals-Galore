using GoalsGalore.ViewModels;

namespace GoalsGalore.Views.ShellViews;

public partial class ItemsPage : ContentPage
{
    public ItemsPage(ItemsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}