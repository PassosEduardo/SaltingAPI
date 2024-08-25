using Newtonsoft.Json;

namespace Salting.Api
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected List<TEntity> GetDataAsync(string dataFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"Data/{dataFile}Data.json");
            var stream = new StreamReader(path);
            string json = stream.ReadToEnd();
            stream.Close();

            return JsonConvert.DeserializeObject<List<TEntity>>(json);
        }
    }
}
