using Accord.MachineLearning.Text.Stemmers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine_DataService.RulesProviders
{
    public static class StringStemmingRuleProvider
    {
        static EnglishStemmer SnowballStemmer;

        static StringStemmingRuleProvider()
        {
            SnowballStemmer = new EnglishStemmer();
        }
        public static string Snowball(string strToStem)
        {
            return SnowballStemmer.Stem(strToStem);
        }
    }
}
