﻿using KargoTakip.Backend.Domain.Kargolarim;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KargoTakip.Backend.Infrastructure.Configurations;
internal sealed class KargoConfiguration : IEntityTypeConfiguration<Kargo>
{
    public void Configure(EntityTypeBuilder<Kargo> builder)
    {
        builder.OwnsOne(p => p.Gonderen, builder =>
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
        });
        builder.OwnsOne(p => p.Alici);
        builder.OwnsOne(p => p.TeslimAdresi);
        builder.OwnsOne(p => p.KargoInformation, builder =>
        {
            builder.Property(p => p.KargoTipi).HasConversion(tip => tip.Value, value => KargoTipiEnum.FromValue(value));
        });

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
