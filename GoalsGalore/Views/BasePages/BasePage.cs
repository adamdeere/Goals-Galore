using GoalsGalore.Extensions;
using GoalsGalore.Interfaces;
using System.Diagnostics;

namespace GoalsGalore.Views.BasePages;

/// <summary>
/// Having a base page like this totally negates the need to add the toolkit library, significantly reducing code base
/// Also lets us have parallelism, it's totally cleaner, easier to manage, just better in general.
/// </summary>
/// <typeparam name="TViewModel"></typeparam>
public partial class BasePage<TViewModel> : ContentPage
    where TViewModel : class, IAppearingViewModelAsync
{
    protected TViewModel? ViewModel => BindingContext as TViewModel;

    protected override async void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            if (ViewModel != null)
            {
                await ViewModel.InitializeRecursiveAppearingAsync();
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    protected override async void OnDisappearing()
    {
        try
        {
            base.OnDisappearing();

            if (ViewModel != null)
            {
                await ViewModel.OnDisappearingAsync();
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}