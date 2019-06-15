using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchEngine.Data.Repos.Posts
{
    public class PostsRepository : Repository, IPostsRepository
    {
        private IMongoCollection<Post> PostsCollection { get; }

        public PostsRepository()
        {
            var settings = new MongoCollectionSettings();
            PostsCollection = mongoDB.GetCollection<Post>("posts", settings);
        }

        public long GetCollectionSize()
        {
            return PostsCollection.EstimatedDocumentCount();
        }

        public Dictionary<string, int> GetPostsContentLength(List<string> postsIDs)
        {
            var result = PostsCollection.Find(x => postsIDs.Contains(x.ID)).ToEnumerable().ToDictionary(x => x.ID, x => x.ContentLength);
            return result;
        }
    }
}
