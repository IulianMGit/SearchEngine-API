using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Data
{
    public class EngineVariablesAggregation
    {
        public double TitleAverageLength { get; set; }
        public double BodyAverageLength { get; set; }
        public double CommentsAverageLength { get; set; }
        public double ContentAverageLength { get; set; }
    }
}
