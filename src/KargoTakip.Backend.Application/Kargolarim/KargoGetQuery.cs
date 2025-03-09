﻿using KargoTakip.Backend.Domain.Kargolarim;
using MediatR;
using TS.Result;

namespace KargoTakip.Backend.Application.Kargolarim;

public sealed record KargoGetQuery(Guid Id) : IRequest<Result<Kargo>>;

internal sealed class KargoGetQueryHandler(
    IKargoRepository kargoRepository) : IRequestHandler<KargoGetQuery, Result<Kargo>>
{
    public async Task<Result<Kargo>> Handle(KargoGetQuery request, CancellationToken cancellationToken)
    {
        Kargo? kargo = await kargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (kargo is null)
            return Result<Kargo>.Failure("Kargo bulunamadı");
        return kargo;
    }
}
