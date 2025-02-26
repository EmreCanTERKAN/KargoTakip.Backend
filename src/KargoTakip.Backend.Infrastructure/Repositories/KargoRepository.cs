using GenericRepository;
using KargoTakip.Backend.Domain.Kargolarim;
using KargoTakip.Backend.Infrastructure.Context;

namespace KargoTakip.Backend.Infrastructure.Repositories;
internal sealed class KargoRepository : Repository<Kargo, ApplicationDbContext> , IKargoRepository
{
    public KargoRepository(ApplicationDbContext context) : base(context)
    {
    }
}
