using GoalsGalore.Model;
using System.Collections.ObjectModel;

namespace GoalsGalore.ViewModels;

public class PeopleViewModel
{
    public ObservableCollection<Person> Items { get; set; }

    public PeopleViewModel()
    {
        Items =
        [
            new("Freda","Curtis"),
            new("Jeffery","Francis"),
            new("Ema","Lawson"),
            new("Niki","Samaniego"),
            new("Jenny","Santos"),
            new("Eric","Wheeler"),
            new("Emmett","Fuller"),
            new("Brian","Johnas"),
        ];
    }
}