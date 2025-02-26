using FluentValidation;
using GenericRepository;
using KargoTakip.Backend.Domain.Kargolarim;
using Mapster;
using MediatR;
using TS.Result;

namespace KargoTakip.Backend.Application.Kargolarim;
public sealed record KargoCreateCommand(
    Person Gonderen,
    Person Alici,
    Address TeslimAdresi,
    KargoInformationDto KargoInformation) : IRequest<Result<string>>;

public sealed record KargoInformationDto(
    int KargoTipiValue,
    int Agirlik);

public sealed class KargoCreateCommandValidator : AbstractValidator<KargoCreateCommand>
{
    public KargoCreateCommandValidator()
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


internal sealed class KargoCreateCommandHandler(IKargoRepository kargoRepository, IUnitOfWork unitOfWork) : IRequestHandler<KargoCreateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(KargoCreateCommand request, CancellationToken cancellationToken)
    {
        Kargo kargo = request.Adapt<Kargo>();
        KargoInformation kargoInformation = new(KargoTipiEnum.FromValue(request.KargoInformation.KargoTipiValue), request.KargoInformation.Agirlik);
        kargo.KargoInformation = kargoInformation;
        kargo.KargoDurum = KargoDurumEnum.Bekliyor;
        kargoRepository.Add(kargo);

        /* await kargoRepository.AddAsync(kargo, cancellationToken)*/
        ;
        await unitOfWork.SaveChangesAsync(cancellationToken);

        //to do : mail yada sms göndermek için
        //to do : ileride notification domain event kullanılır.
        return "Kargo başarıyla kaydedildi";
    }
}
