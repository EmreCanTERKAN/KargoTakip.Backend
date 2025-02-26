namespace KargoTakip.Backend.Domain.Kargolarim;

public sealed record Person(
    string FirstName,
    string LastName,
    string TcNumarasi,
    string Email,
    string PhoneNumber);
