using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data
{
    public class IndexDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string ID { get; set; }

        [BsonElement("freq")]
        public int Frequency { get; set; }

        [BsonElement("pos")]
        public List<int> Positions { get; set; }
    }
}
