using System.ComponentModel.DataAnnotations;

namespace CustomersCrud.Models;

public class Customer
{
    [Key]
    public long Id {get; set; }
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    [EmailAddress]
    public string? Email {get; set;}
}