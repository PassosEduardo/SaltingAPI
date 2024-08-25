
namespace Salting.Api
{
    public interface IAuthRepository
    {
        List<UserCredentials> GetData();
        string WriteDataAndReturn(List<UserCredentials> listDtos ,UserCredentials dto);
    }
}
