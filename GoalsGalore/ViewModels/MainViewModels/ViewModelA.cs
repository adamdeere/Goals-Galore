using System.Collections.ObjectModel;
using GoalsGalore.Model;
using PlatinumWMSSwiftUtilityLib.Base;
using PlatinumWMSSwiftUtilityLib.Extentions;

namespace GoalsGalore.ViewModels.MainViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


public partial class ViewModelA  : BaseViewModel
{
    [ObservableProperty]
    private bool _isOriginal = true;

    [ObservableProperty]
    private bool _showContextMenu = true;

    [ObservableProperty]
    private Color _cardBackgroundColor = Colors.Gray;

    public ObservableRangeCollection<StockItem> StockItems { get; set; } = [];

    public ViewModelA()
    {
        var t = new List<StockItem>();
        for (int i = 0; i < 10; i++)
        {
            t.Add(new StockItem
            {
                SKUCode = $"SKU0{i}",
                SKUDescription = "testing",
                GRN = $"1234/{i}",
                LocationCode = $"A01-01-{i}",
                Batch = $"BATCH{i}",
                StockStatus = "Available",
                QtyFree = 100 + i,
            });
        }
        StockItems.SetCollection(t);
      
    }
    [RelayCommand]
    private void CardClick()
    {
       
    }

    [RelayCommand]
    private void ShowMenu()
    {
        // Show context menu in your page logic (e.g. popup)
    }

   
}
