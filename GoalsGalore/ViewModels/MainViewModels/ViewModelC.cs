using CommunityToolkit.Mvvm.Input;
using GoalsGalore.Model;
using GoalsGalore.ViewModels.BaseViewModels;
using Newtonsoft.Json;
using PlatinumWMSSwiftUtilityLib.Extentions;
using PlatinumWMSSwiftUtilityLib.Interface;

namespace GoalsGalore.ViewModels.MainViewModels;

public partial class ViewModelC(INotificationService ser) : BaseViewModel
{
    public ObservableRangeCollection<WizardAttributes> Characters { get; set; } = [];

    public override async Task OnAppearingAsync()
    {
        try
        {
            // Open the text file using a stream reader.
            await using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync("HarryP.json");
            using StreamReader reader = new StreamReader(fileStream);

            // Read the stream as a string.
            string json = await reader.ReadToEndAsync();

            var results = JsonConvert.DeserializeObject<CharacterRoot>(json);

            List<WizardAttributes> list = [];

            for (int i = 0; i < 1000; i++)
            {
                list.AddRange(results?.Data.Select(attribute => attribute.Attributes));
            }

            Characters.SetCollection(list);

            ser.ConsoleLog("Count", $"{Characters.Count}");
            // Write the text to the console.
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        await Task.CompletedTask;
    }

    [RelayCommand]
    private void OpenWiki(string url)
    {
        ser.ConsoleLog("Count", url);
    }
}