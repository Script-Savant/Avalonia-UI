using System.ComponentModel.DataAnnotations;

namespace PersonCrud.Models;

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email {get; set;}
}