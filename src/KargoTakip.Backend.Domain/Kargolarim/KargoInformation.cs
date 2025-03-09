namespace KargoTakip.Backend.Domain.Kargolarim;

public sealed record KargoInformation
{
    public KargoTipiEnum KargoTipi { get; set; } = default!;
    public int KargoTipiValue => KargoTipi.Value; // computed prop
    public int Agirlik {  get; set; }
}
