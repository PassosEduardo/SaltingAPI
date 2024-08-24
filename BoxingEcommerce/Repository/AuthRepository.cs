using Newtonsoft.Json;

namespace Salting.Api
{
    public class AuthRepository : BaseRepository<UserCredentials>, IAuthRepository
    {
        private const string JSON_FILE_NAME = "LogIn";

        public List<UserCredentials> GetData()
        {
            return base.GetDataAsync(JSON_FILE_NAME);
        }

        public async Task<string> WriteDataAndReturn(List<UserCredentials> dtos, UserCredentials dto)
        {
            dtos = dtos.Append(dto).ToList();

            var json = JsonConvert.SerializeObject(dtos);

            var path = Path.Combine(Directory.GetCurrentDirectory(), $"Data/{JSON_FILE_NAME}Data.json");

            var writer = new StreamWriter(path);

            await writer.WriteAsync(json);

            writer.Close();
            writer.Dispose();

            return dto.email;
        }
    }
}
