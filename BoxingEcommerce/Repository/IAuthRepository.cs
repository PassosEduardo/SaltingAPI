
namespace Salting.Api
{
    public interface IAuthRepository
    {
        List<UserCredentials> GetData();
        Task<string> WriteDataAndReturn(List<UserCredentials> listDtos ,UserCredentials dto);
    }
}
