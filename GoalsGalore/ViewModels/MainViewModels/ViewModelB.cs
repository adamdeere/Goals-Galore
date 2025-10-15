using CommunityToolkit.Mvvm.ComponentModel;
using GoalsGalore.ViewModels.BaseViewModels;

namespace GoalsGalore.ViewModels.MainViewModels;

public partial class ViewModelB : BaseViewModel
{
    [ObservableProperty]
    private string _bString;

    public override async Task OnAppearingAsync()
    {
        BString = "VmB appearing";
        await Task.CompletedTask;
    }
}