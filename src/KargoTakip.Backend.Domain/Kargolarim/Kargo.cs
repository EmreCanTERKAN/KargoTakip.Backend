using KargoTakip.Backend.Domain.Abstractions;

namespace KargoTakip.Backend.Domain.Kargolarim;
public sealed class Kargo : Entity
{
    public Person Gonderen { get; set; } = default!;
    public Person Alici { get; set; } = default!;
    public Address TeslimAdresi { get; set; } = default!;
    public KargoInformation KargoInformation { get; set; } = default!;

}
