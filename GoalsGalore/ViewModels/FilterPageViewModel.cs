using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalsGalore.ViewModels.BaseViewModels;
using System.Collections.ObjectModel;
using Telerik.Maui.Controls;

namespace GoalsGalore.ViewModels;

public partial class FilterPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _condition;

    public ObservableCollection<FilterOption> FilterOptions { get; set; }
    public FilterOption SelectedOption { get; set; }

    public ObservableCollection<ListString> Items { get; set; } =
    [
        new("Carton"),
        new("Inner"),
        new("Piece")
    ];

    public ObservableCollection<ListString> ConditionItems { get; set; } =
    [
        new("Good"),
        new("Damaged")
    ];

    public FilterPageViewModel()
    {
        FilterOptions =
        [
            new FilterOption { Name="All", Icon="dotnet_bot.png" },
            new FilterOption { Name="Unload", Icon="dotnet_bot.png" },
            new FilterOption { Name="Put Away", Icon="dotnet_bot.png" },
            new FilterOption { Name="Replen", Icon="dotnet_bot.png" },
            new FilterOption { Name="Stock Transfer", Icon="dotnet_bot.png" },
            new FilterOption { Name="Location Count", Icon="dotnet_bot.png" },
            new FilterOption { Name="Pick List", Icon="dotnet_bot" },
        ];

        SelectedOption = FilterOptions[0];
    }

    [RelayCommand]
    private void ConditionSelectionChanged(RadListPicker picker)
    {
        Condition = picker.DisplayString;
    }
}

public class ListString(string text, string icon)
{
    public ListString(string text) : this(text, null)
    {
    }

    public string Text { get; set; } = text;
    public string Icon { get; set; } = icon;

    public override string ToString()
    {
        return Text;
    }
}

public class FilterOption
{
    public string Name { get; set; }
    public string Icon { get; set; }
}