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
            new Person("Neil", "Armstrong"),
            new Person("Jane", "Smith"),
            new Person("John", "Doe")
        };

        People = new ObservableCollection<Person>(people);
    }
}