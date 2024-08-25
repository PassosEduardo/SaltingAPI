

namespace Salting.Api
{
    public interface IAuthService
    {
        string SingUp(SignUpRequest request);
        TokenResponseModel LogIn(LogInRequest request);

        List<UserCredentials> ReturnAllUsers();
    }
}
