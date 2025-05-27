using CommunityToolkit.Mvvm.ComponentModel;
using ToDo.Models;

namespace ToDo.ViewModels;

public partial class ToDoItemViewModel : ViewModelBase
{
    public ToDoItemViewModel()
    {
    }

    public ToDoItemViewModel(ToDoItem item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
    }
    
    [ObservableProperty] 
    private bool _isChecked;
    
    [ObservableProperty]
    private string? _content;

    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content
        };
    }
}