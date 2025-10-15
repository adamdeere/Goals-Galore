using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoalsGalore.Model;
using System.Collections.ObjectModel;

namespace GoalsGalore.ViewModels;

public partial class ItemsViewModel : ObservableObject
{
    public ObservableCollection<ItemModel> Items { get; set; } = [];

    [RelayCommand]
    private void Appearing()
    {
        Items.Add(new ItemModel { Code = "OE-BAG-BASSE", Description = "Basse Bag", Quantity = 1.0, Pieces = 1, Location = "ADAM" });
        Items.Add(new ItemModel { Code = "OE-BOX-123", Description = "Storage Box", Quantity = 3.0, Pieces = 2, Location = "MAIN" });
        Items.Add(new ItemModel { Code = "OE-CRATE-9", Description = "Plastic Crate", Quantity = 2.0, Pieces = 4, Location = "WH1" });
        Items.Add(new ItemModel { Code = "OE-BAG-LARGE", Description = "Large Bag", Quantity = 4.0, Pieces = 1, Location = "ADAM" });
        Items.Add(new ItemModel { Code = "OE-PALLET-45", Description = "Wooden Pallet", Quantity = 5.0, Pieces = 5, Location = "WH2" });
    }

    // Card tap
    [RelayCommand]
    private void CardTapped(ItemModel item)
    {
        // Handle tap action (navigate, open detail page, etc.)
        App.Current.MainPage.DisplayAlert("Tapped", $"You tapped {item.Code}", "OK");
    }

    // Options button 1
    [RelayCommand]
    private void OpenOptions(ItemModel item)
    {
        // Show popup menu or context actions
        App.Current.MainPage.DisplayActionSheet("Options", "Cancel", null,
            "Close", "Re-Open", "Stage");
    }

    // Options button 2
    [RelayCommand]
    private void OpenMoreOptions(ItemModel item)
    {
        // Show popup menu or context actions
        App.Current.MainPage.DisplayActionSheet("More Options", "Cancel", null,
            "Copy", "Print", "Delete");
    }
}