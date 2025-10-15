using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalsGalore.Model;
using GoalsGalore.ViewModels.BaseViewModels;
using System.Collections.ObjectModel;

namespace GoalsGalore.ViewModels;

public partial class TestCardPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private bool _isOpen;

    [ObservableProperty]
    private bool _canPrint;

    public ObservableCollection<ItemModel> UnloadedItems { get; set; } = [];

    public ObservableCollection<Person> Items { get; set; } =
    [
        new ("Freda", "Curtis"),
        new ("Jeffery", "Francis"),
        new ("Ema", "Lawson"),
        new ("Niki", "Samaniego"),
        new ("Jenny", "Santos"),
        new ("Eric", "Wheeler"),
        new ("Emmett", "Fuller"),
        new ("Brian", "Johnas")
    ];

    [RelayCommand]
    private void Appearing()
    {
        UnloadedItems.Add(new ItemModel { Code = "Adam", Description = "Basse Bag", Quantity = 1.0, Pieces = 1, Location = "ADAM" });
        UnloadedItems.Add(new ItemModel { Code = "Bob", Description = "Storage Box", Quantity = 3.0, Pieces = 2, Location = "MAIN" });
        UnloadedItems.Add(new ItemModel { Code = "Jon", Description = "Plastic Crate", Quantity = 2.0, Pieces = 4, Location = "WH1" });
    }

    [RelayCommand]
    private void MenuClicked()
    {
        IsOpen = !IsOpen;
    }

    [RelayCommand(CanExecute = nameof(CanPrint))]
    public void PrintAction()
    {
        Shell.Current.DisplayAlert("Print", "Print action executed", "OK");
        IsOpen = false;

        // Your print logic here
    }

    [RelayCommand]
    private void DeleteAction()
    {
        IsOpen = false;
        // Your delete logic here
    }
}