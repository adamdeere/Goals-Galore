using GoalsGalore.ViewModels;

namespace GoalsGalore.Views.ShellViews;

public partial class MainPage : ContentPage
{
    private bool isHomeComplete = false;
    private bool isProfileComplete = false;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();

        CustomTabs.CanSelectTab = (index) =>
        {
            // sequential logic
            if (index == 1) return isHomeComplete;       // tab 1 blocked until tab 0 done
            if (index == 2) return isProfileComplete;    // tab 2 blocked until tab 1 done
            return true;
        };

        CompleteHomeTab();
    }

    private void CompleteHomeTab()
    {
        isHomeComplete = true;
    }

    private void CompleteProfileTab()
    {
        isProfileComplete = true;
    }
}