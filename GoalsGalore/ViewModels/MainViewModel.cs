using CommunityToolkit.Mvvm.Input;
using GoalsGalore.Model;
using GoalsGalore.ViewModels.BaseViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GoalsGalore.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [RelayCommand]
    private void Appearing()
    {
        Debug.WriteLine("lololo");
    }

    [RelayCommand]
    private void Disappearing()
    {
        // Handle any cleanup or state saving if necessary
        Debug.WriteLine("MainViewModel is disappearing");
    }

    [RelayCommand]
    private void TabSelected(string tabSelected)
    {
    }
}