using CommunityToolkit.Mvvm.ComponentModel;
using GoalsGalore.Interfaces;

namespace GoalsGalore.ViewModels.BaseViewModels;

public abstract partial class BaseViewModel : ObservableObject, IAppearingViewModelAsync
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private bool _isLoading;

    public virtual Task OnAppearingAsync() => Task.CompletedTask;

    public virtual Task OnDisappearingAsync() => Task.CompletedTask;
}