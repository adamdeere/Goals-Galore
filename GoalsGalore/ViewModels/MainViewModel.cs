using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalsGalore.ViewModels.BaseViewModels;

namespace GoalsGalore.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private int _count = 0;

    [ObservableProperty]
    private string _counterBtnText = "Click me";

    [RelayCommand]
    public void CounterClicked()
    {
        Count++;

        if (Count == 1)
            CounterBtnText = $"Clicked {Count} time";
        else
            CounterBtnText = $"Clicked {Count} times";
    }
}