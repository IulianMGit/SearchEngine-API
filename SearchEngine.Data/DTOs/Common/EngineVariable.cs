using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data
{
    public class EngineVariable
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string ID { get; set; }

        [BsonElement("value")]
        public double Value { get; set; }
    }
}
