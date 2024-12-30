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

            var result = JsonConvert.DeserializeObject<List<TEntity>>(json);

            if(result is null)
                return Enumerable.Empty<TEntity>().ToList();

            return result;
        }
    }
}
