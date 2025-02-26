using Ardalis.SmartEnum;
using KargoTakip.Backend.Domain.Abstractions;

namespace KargoTakip.Backend.Domain.Kargolarim;
public sealed class Kargo : Entity
{
    public Person Gonderen { get; set; } = default!;
    public Person Alici { get; set; } = default!;
    public Address TeslimAdresi { get; set; } = default!;
    public KargoInformation KargoInformation { get; set; } = default!;
    public KargoDurumEnum KargoDurum { get; set; } = default!;

}

public sealed class KargoDurumEnum : SmartEnum<KargoDurumEnum>
{
    public static KargoDurumEnum Bekliyor = new("Bekliyor", 0);
    public static KargoDurumEnum AracaTeslimEdildi = new("Araca Teslim Edildi", 1);
    public static KargoDurumEnum YolaCikti = new("Yola Çıktı", 2);
    public static KargoDurumEnum TeslimSubesineUlasti = new("Teslim Şubesine Ulaştı.", 3);
    public static KargoDurumEnum TeslimIcinYolaCikti = new("Teslim için yola Çıktı.", 4);
    public static KargoDurumEnum TeslimEdildi = new("Teslim Edildi.", 5);
    public static KargoDurumEnum AdresteKimseBulunamadı = new("Adreste Kimse Bulunamadı.", 6);
    public static KargoDurumEnum IptalEdildi = new("İptal Edildi.", 7);
    public KargoDurumEnum(string name, int value) : base(name, value)
    {
    }
}