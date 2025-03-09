using FluentValidation;
using GenericRepository;
using KargoTakip.Backend.Domain.Kargolarim;
using KargoTakip.Server.Domain.Kargolarim;
using Mapster;
using MediatR;
using TS.Result;

namespace KargoTakip.Backend.Application.Kargolarim;

public sealed record KargoUpdateCommand(
    Guid Id,
    Person Gonderen,
    Person Alici,
    Address TeslimAdresi,
    KargoInformationDto KargoInformation) : IRequest<Result<string>>;

public sealed class KargoUpdateCommandValidator : AbstractValidator<KargoCreateCommand>
{
    public KargoUpdateCommandValidator()
    {
        RuleFor(x => x.Gonderen.FirstName).NotEmpty().WithMessage("Geçerli bir gönderen adı giriniz");
        RuleFor(x => x.Gonderen.LastName).NotEmpty().WithMessage("Geçerli bir gönderen soyadı giriniz");
        RuleFor(x => x.Alici.FirstName).NotEmpty().WithMessage("Geçerli bir alıcı adı giriniz");
        RuleFor(x => x.Alici.LastName).NotEmpty().WithMessage("Geçerli bir alıcı adı giriniz");
        RuleFor(x => x.TeslimAdresi.City).NotEmpty().WithMessage("Geçerli bir şehir giriniz");
        RuleFor(x => x.TeslimAdresi.Town).NotEmpty().WithMessage("Geçerli bir ilçe giriniz");
        RuleFor(x => x.TeslimAdresi.Mahalle).NotEmpty().WithMessage("Geçerli bir mahalle giriniz");
        RuleFor(x => x.TeslimAdresi.FullAddress).NotEmpty().WithMessage("Geçerli bir adres giriniz");
        RuleFor(x => x.KargoInformation.KargoTipiValue)
              .Must(value => KargoTipiEnum.List.Any(e => e.Value == value))
              .WithMessage("Geçerli kargo tipi giriniz");
    }
}


internal sealed class KargoUpdateCommandHandler(IKargoRepository kargoRepository, IUnitOfWork unitOfWork) : IRequestHandler<KargoUpdateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(KargoUpdateCommand request, CancellationToken cancellationToken)
    {
        Kargo? kargo = await kargoRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (kargo is null)
            return Result<string>.Failure("Kargo bulunamadı");

        if (kargo.KargoDurum != KargoDurumEnum.Bekliyor)
            return Result<string>.Failure("Sadece bekleyen kargoları güncelleyebilirsiniz");
        request.Adapt(kargo);
        KargoInformation kargoInformation = new()
        {
            KargoTipi = KargoTipiEnum.FromValue(request.KargoInformation.KargoTipiValue),
            Agirlik = request.KargoInformation.Agirlik
        };
        kargo.KargoInformation = kargoInformation;
        kargo.KargoDurum = KargoDurumEnum.Bekliyor;
        kargo.Alici = request.Alici;
        kargo.Gonderen = request.Gonderen;
        kargoRepository.Update(kargo);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        //to do : mail yada sms göndermek için
        //to do : ileride notification domain event kullanılır.
        return "Kargo başarıyla güncellendi";
    }
}
