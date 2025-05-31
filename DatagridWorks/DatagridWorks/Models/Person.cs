namespace DatagridWorks.Models;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int AgeInYears { get; set; }

    public Person(string firstName, string lastName, int  ageInYears)
    {
        FirstName = firstName;
        LastName = lastName;
        AgeInYears = ageInYears;
    }
}