using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data
{
    public class IndexTerm
    {
        //[BsonId]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Term { get; set; }

        [BsonElement("documents")]
        public List<IndexDocument> Docs { get; set; }
    }
}
