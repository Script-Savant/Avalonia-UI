using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using MyApp.Data;
using MyApp.Models;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

namespace MyApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
   [ObservableProperty]
   public string Name = string.Empty;
   
   [ObservableProperty]
   public string Email = string.Empty;
   
   [ObservableProperty]
   private Person? SelectedPerson;

   public ObservableCollection<Person> People { get; } = new();
   private readonly AppDbContext _context;

   public MainWindowViewModel()
   {
      _context = new AppDbContext();
      
      LoadPeople();
   }

   private void LoadPeople()
   {
      People.Clear();
      foreach (var p in _context.People.ToList())
      {
         People.Add(p);
      }
   }

   [RelayCommand]
   private void Add()
   {
      var person = new Person
      {
         Name = Name,
         Email = Email
      };
      _context.People.Add(person);
      _context.SaveChanges();
      LoadPeople();
      
      Name = Email = string.Empty;
   }

   [RelayCommand]
   private void Update()
   {
      if (SelectedPerson == null) return;

      var person = _context.People.Find(SelectedPerson.Id);
      if (person != null)
      {
         person.Name = Name;
         person.Email = Email;
         _context.SaveChanges();
         LoadPeople();
      }
   }

   [RelayCommand]
   private void Delete()
   {
      if (SelectedPerson == null) return;
      
      _context.People.Remove(SelectedPerson);
      _context.SaveChanges();
      LoadPeople();
   }

   [RelayCommand]
   private void Select()
   {
      if (SelectedPerson != null)
      {
         Name = SelectedPerson.Name;
         Email = SelectedPerson.Email;
      }
   }
}