using System.Collections.ObjectModel;
using DatagridWorks.Models;
using System.Collections.Generic;

namespace DatagridWorks.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Person> People { get; }

    public MainWindowViewModel()
    {
        var people = new List<Person>
        {
            new Person("Neil", "Armstrong", 55),
            new Person("Jane", "Smith", 23),
            new Person("John", "Doe", 25)
        };

        People = new ObservableCollection<Person>(people);
    }
}