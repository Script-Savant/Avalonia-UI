using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CustomersCrud.Data;
using CustomersCrud.Models;

namespace CustomersCrud;

public partial class MainWindow : Window
{
    private readonly AppDbContext _context;
    private Customer? _selectedCustomer;
    private ObservableCollection<Customer>? _customers;
    public MainWindow()
    {
        InitializeComponent();
        _context = new AppDbContext();
        
        LoadCustomers();
    }

    private void SaveBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Customer customer = new()
        {
            FirstName = FirstNameTxt.Text,
            LastName = LastNameTxt.Text,
            Email = EmailTxt.Text
        };
        
        _context.Customers.Add(customer);
        _context.SaveChanges();
        
        _customers?.Add(customer);
        LoadCustomers();
        ClearForm();
    }

    private void UpdateBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedCustomer != null)
        {
            _selectedCustomer.FirstName = FirstNameTxt.Text;
            _selectedCustomer.LastName = LastNameTxt.Text;
            _selectedCustomer.Email = EmailTxt.Text;
            
            _context.Customers.Update(_selectedCustomer);
            _context.SaveChanges();
            
            _customers?.Add(_selectedCustomer);
            LoadCustomers();
            ClearForm();
        }
    }

    private void DeleteBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (_selectedCustomer != null)
        {
            _context.Customers.Remove(_selectedCustomer);
            _context.SaveChanges();

            _customers?.Remove(_selectedCustomer);
            ClearForm();
        }
    }

    private void ClearForm()
    {
        FirstNameTxt.Text = LastNameTxt.Text = EmailTxt.Text = string.Empty;
        _selectedCustomer = null;
    }

    private void LoadCustomers()
    {
        var customers = _context.Customers.ToList();
        _customers = new ObservableCollection<Customer>(customers);
        
        CustomersDataGrid.ItemsSource = _customers;
    }

    private void CustomersDataGrid_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        _selectedCustomer = CustomersDataGrid.SelectedItem as Customer;
        
        if (_selectedCustomer != null)
        {
            FirstNameTxt.Text = _selectedCustomer.FirstName;
            LastNameTxt.Text = _selectedCustomer.LastName;
            EmailTxt.Text = _selectedCustomer.Email;
        }
    }
}