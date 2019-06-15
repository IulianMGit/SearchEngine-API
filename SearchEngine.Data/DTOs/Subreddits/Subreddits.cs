using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SearchEngine.Data
{
    public class Subreddits
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("subreddit_name")]
        public string SubredditName { get; set; }
    }
}
