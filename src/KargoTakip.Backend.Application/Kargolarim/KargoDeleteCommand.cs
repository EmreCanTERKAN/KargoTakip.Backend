using GenericRepository;
using KargoTakip.Backend.Domain.Kargolarim;
using MediatR;
using TS.Result;

namespace KargoTakip.Backend.Application.Kargolarim;
public sealed record KargoDeleteCommand(Guid Id) : IRequest<Result<string>>;

internal sealed class KargoDeleteCommandHandler(IKargoRepository kargoRepository, IUnitOfWork unitOfWork) : IRequestHandler<KargoDeleteCommand, Result<string>>
{
    public async Task<Result<string>> Handle(KargoDeleteCommand request, CancellationToken cancellationToken)
    {
        Kargo? kargo = await kargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (kargo is null)
            return Result<string>.Failure("Kargo bulunamadı");
        if (kargo.KargoDurum == KargoDurumEnum.Bekliyor)
            return Result<string>.Failure("Sadece bekleyen kargoları silebilirsin");
        kargo.IsDeleted = true;
        kargoRepository.Update(kargo);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Kargo başarıyla silindi";

    }
}
