using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string ID { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("num_comments")]
        public int CommentsCount { get; set; }

        [BsonElement("upvotes")]
        public int UpvotesCount { get; set; }

        [BsonElement("downvotes")]
        public int DownvotesCount { get; set; }

        [BsonElement("created_at")]
        public double CreatedAt { get; set; }

        [BsonElement("title_len")]
        public int TitleLength { get; set; }

        [BsonElement("body_len")]
        public int BodyLength { get; set; }

        [BsonElement("comments_len")]
        public int CommentsLength { get; set; }

        [BsonElement("content_len")]
        public int ContentLength { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }
    }
}
