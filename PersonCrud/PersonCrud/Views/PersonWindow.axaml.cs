using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PersonCrud.Data;
using PersonCrud.Models;

namespace PersonCrud.Views;

public partial class PersonWindow : Window
{
    private readonly AppDbContext _context;
    private Person? _selectedPerson;
    
    public PersonWindow()
    {
        InitializeComponent();
        _context = new AppDbContext();

        LoadPeople();
        UpdateBtn.IsEnabled = false;
        DeleteBtn.IsEnabled = false;
    }

    private void LoadPeople()
    {
        var people = _context.People.ToList();
        PeopleDataGrid.ItemsSource = people;
        
        PeopleDataGrid.Columns[0].IsVisible = false;
        
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Email.Text))
        {
           // MessageBox.Show("Name and email are required");
            return;
        }
        Person newPerson = new()
        {
            Name = Name.Text,
            Email = Email.Text
        };
        
        _context.People.Add(newPerson);
        _context.SaveChanges();
        LoadPeople();
        
        ClearForm();
    }

    private void UpdateBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedPerson is not null)
        {
            _selectedPerson.Name = Name.Text;
            _selectedPerson.Email = Email.Text;

            _context.People.Update(_selectedPerson);
            _context.SaveChanges();
            LoadPeople();

            ClearForm();
        }
    }

    private void DeleteBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedPerson is not null)
        {
            _context.People.Remove(_selectedPerson);
            _context.SaveChanges();
            LoadPeople();
            
            ClearForm();
        }
    }

    private void DataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (PeopleDataGrid.SelectedItem is Person person)
        {
            _selectedPerson = person;
            Name.Text = person.Name;
            Email.Text = person.Email;

            AddBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
        }
    }
    
    private void ClearForm()
    {
        Name.Text = Email.Text = string.Empty;
        AddBtn.IsEnabled = true;
        _selectedPerson = null;
    }
}