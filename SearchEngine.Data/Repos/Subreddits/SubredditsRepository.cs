using MongoDB.Bson;
using MongoDB.Driver;
using SearchEngine.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Data
{
    public class SubredditsRepository : Repository, ISubredditsRepository
    {
        private IMongoCollection<Subreddits> SubredditsCollection { get; }

        public SubredditsRepository()
        {
            SubredditsCollection = mongoDB.GetCollection<Subreddits>("subreddits");
        }

        public async Task<List<Subreddits>> GetAll()
        {
            var subreddits = new List<Subreddits>();

            var allDocs = await SubredditsCollection.FindAsync(new BsonDocument());
            await allDocs.ForEachAsync(doc => subreddits.Add(doc));

            return subreddits;
        }
    }
}
