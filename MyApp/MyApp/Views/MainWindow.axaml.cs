using Avalonia.Controls;
using Avalonia.Interactivity;
using MyApp.ViewModels;

namespace MyApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void PersonSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.SelectCommand.Execute(null);
        }
    }
}