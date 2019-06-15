using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using SearchEngine.Data.Repos.Index;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Data.Repos
{
    public class IndexRepository : Repository, IIndexRepository
    {
        private IMongoCollection<IndexTerm> IndexCollection { get; }

        public IndexRepository()
        {
            var settings = new MongoCollectionSettings();
            IndexCollection = mongoDB.GetCollection<IndexTerm>("index", settings);
        }

        public IndexTerm GetIndexOfWord(string term)
        {
            var result = IndexCollection.Find(x => x.Term == term).FirstOrDefault();
            return result;
        }

        public List<IndexTerm> GetIndexOfWords(List<string> terms)
        {
            var result = IndexCollection.Find(x => terms.Contains(x.Term)).ToList();
            return result;
        }

        public Dictionary<string, List<IndexDocument>> GetIndexOfWordsAsDictionary(List<string> terms)
        {
            var result = new Dictionary<string, List<IndexDocument>>();
            var termsIndex = GetIndexOfWords(terms);

            foreach (var item in termsIndex)
                result.TryAdd(item.Term, item.Docs);

            return result;
        }
    }
}

