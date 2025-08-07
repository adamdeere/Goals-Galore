using CommunityToolkit.Mvvm.ComponentModel;

namespace GoalsGalore.ViewModels.BaseViewModels;

public partial class  BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private bool _isLoading;
    
}
