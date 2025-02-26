using KargoTakip.Backend.Domain.Abstractions;

namespace KargoTakip.Backend.Domain.Employees;
public sealed class Employee : Entity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string FullName => string.Join(" ", FirstName, LastName);
    public DateOnly BirthOfDate { get; set; }
    public decimal Salary { get; set; }
    public PersonelInformation PersonelInformation { get; set; } = default!;
    public Address Address { get; set; } = default!;
}