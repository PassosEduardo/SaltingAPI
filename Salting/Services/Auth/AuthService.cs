
namespace Salting.Api
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public string SingUp(SignUpRequest request)
        {
            var data = _authRepository.GetData();

            var alreadyExists = data.Where(instance =>
            string.Equals(request.Email.Trim(), instance.email))
                .FirstOrDefault() != null;

            if (alreadyExists)
                return null;

            var userDto = MapToInputDto(request, data.Count + 1);

            return _authRepository.WriteDataAndReturn(data, userDto);

        }
        public TokenResponseModel LogIn(LogInRequest request)
        {
            var credentials = _authRepository.GetData()
                                             .Where(auth => auth.email.Equals(request.Email))
                                             .FirstOrDefault();

            if (credentials is null)
                return null; //usuario nao encontrado

            var encrypPassword = SaltHandler.EncrypPassword(request.Password, credentials.base64Salt);

            if (string.Equals(credentials.saltedPassword, encrypPassword))
                return TokenHandler.GenerateToken();


            return null;

        }
        private static UserCredentials MapToInputDto(SignUpRequest request, int userId)
        {
            var userCredentials = SaltHandler.CreateUserCredentials(request.Password);

            return new UserCredentials(userId,
                                       request.Email,
                                       userCredentials.EncryptedPassword,
                                       userCredentials.EncryptedSalt);
        }

        public List<UserCredentials> ReturnAllUsers()
        {
            return _authRepository.GetData().ToList();
        }
    }
}
