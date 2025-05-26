using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace GetStartedApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(Celsius.Text, out double c))
        {
            var f = c * (9d / 5d) + 32;
            Fahrenheit.Text = f.ToString("0.0");
        }
        else
        {
            Celsius.Text = "0";
            Fahrenheit.Text = "0";
        }
    }

    private void Celsius_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (double.TryParse(Celsius.Text, out double c))
        {
            var f = c * (9d / 5d) + 32;
            Fahrenheit.Text = f.ToString("0.0");
        }
        else
        {
            Celsius.Text = "0";
            Fahrenheit.Text = "0";
        }
    }
}