using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data.Repos
{
    public class Repository : IRepository
    {
        protected readonly IMongoDatabase mongoDB;
        private static IMongoDatabase _mongoDB;

        public Repository()
        {
            if (Repository._mongoDB == null)
            {
                MongoClientSettings settings = new MongoClientSettings();
                settings.Server = new MongoServerAddress("localhost", 27017);
                var mongoClient = new MongoClient(settings);
                _mongoDB = mongoClient.GetDatabase("Indexer-Database");
            }

            mongoDB = _mongoDB;
        }
    }
}
