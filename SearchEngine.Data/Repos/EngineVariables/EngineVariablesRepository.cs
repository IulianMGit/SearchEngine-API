using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data.Repos.EngineVariables
{
    public class EngineVariablesRepository : Repository, IEngineVariablesRepository
    {
        private IMongoCollection<EngineVariable> EngineVariablesCollection { get; }

        public EngineVariablesRepository()
        {
            var settings = new MongoCollectionSettings();
            EngineVariablesCollection = mongoDB.GetCollection<EngineVariable>("variables", settings);
        }

        public EngineVariablesAggregation GetEngineVariables()
        {
            var engineVariables = EngineVariablesCollection.Find(x => true).ToList();
            var result = new EngineVariablesAggregation();

            foreach (var item in engineVariables)
            {
                switch (item.ID)
                {
                    case "title_avg_len":
                        result.TitleAverageLength = item.Value;
                        break;
                    case "body_avg_len":
                        result.BodyAverageLength = item.Value;
                        break;
                    case "comments_avg_len":
                        result.CommentsAverageLength = item.Value;
                        break;
                    case "content_avg_len":
                        result.ContentAverageLength = item.Value;
                        break;
                }
            }

            return result;
        }
    }
}
