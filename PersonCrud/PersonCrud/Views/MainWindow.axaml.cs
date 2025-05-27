using Avalonia.Controls;
using Avalonia.Interactivity;

namespace PersonCrud.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var openWindow = new PersonWindow();
        openWindow.Show();
    }
}