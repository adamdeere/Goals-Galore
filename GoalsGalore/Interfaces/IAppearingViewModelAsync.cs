namespace GoalsGalore.Interfaces;

public interface IAppearingViewModelAsync
{
    Task OnAppearingAsync();

    Task OnDisappearingAsync();
}