namespace KargoTakip.Backend.Domain.Kargolarim;

public sealed record Address(
    string City,
    string Town,
    string Mahalle,
    string Street,
    string FullAddress);
