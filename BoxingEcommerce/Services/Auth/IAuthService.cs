

namespace Salting.Api
{
    public interface IAuthService
    {
        Task<string> SingUpAsync(SignUpRequest request);
        TokenResponseModel LogInAsync(LogInRequest request);
    }
}
