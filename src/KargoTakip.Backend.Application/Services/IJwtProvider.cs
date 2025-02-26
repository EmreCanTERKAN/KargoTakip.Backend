using KargoTakip.Backend.Domain.Users;

namespace KargoTakip.Backend.Application.Services;
public interface IJwtProvider
{
    public Task<string> CreateTokenAsync(AppUser user, string password, CancellationToken cancellationToken = default);
}
