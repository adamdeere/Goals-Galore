using GoalsGalore.ViewModels.BaseViewModels;
using GoalsGalore.ViewModels.MainViewModels;
using PlatinumWMSSwiftUtilityLib.Controls;

namespace GoalsGalore.ViewModels;

public partial class MainViewModel(ViewModelA vmA,
                                   ViewModelB vmB,
                                   ViewModelC vmC)
    : BaseViewModel
{
    public PlatTabView PlatTabView { get; set; }
    public ViewModelA VmA { get; } = vmA;
    public ViewModelB VmB { get; } = vmB;
    public ViewModelC VmC { get; } = vmC;

    public override async Task OnAppearingAsync()
    {
        // Run View models in parallel
        await Task.WhenAll(
            VmA.OnAppearingAsync(),
            VmB.OnAppearingAsync(),
            VmC.OnAppearingAsync()
        );
    }
}