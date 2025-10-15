using GoalsGalore.Interfaces;

namespace GoalsGalore.Extensions;

public static class ViewModelExtensions
{
    public static async Task InitializeRecursiveAppearingAsync(this IAppearingViewModelAsync vm)
    {
        // First, call this VM’s OnAppearingAsync
        await vm.OnAppearingAsync();
    }

    public static async Task InitializeRecursiveDisappearingAsync(this IAppearingViewModelAsync vm)
    {
        // First, call this VM’s OnAppearingAsync
        await vm.OnAppearingAsync();
    }
}