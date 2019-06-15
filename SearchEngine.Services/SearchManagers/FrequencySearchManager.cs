using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Data;
using SearchEngine.Data.Repos;
using SearchEngine.Data.Repos.EngineVariables;
using SearchEngine.Data.Repos.Posts;

namespace SearchEngine_DataService.SearchManagers
{
    public class FrequencySearchManager : SearchManager
    {
        private const double K = 0.5;

        public FrequencySearchManager(IndexRepository indexRepo, EngineVariablesRepository variablesRepo, PostsRepository postsRepo) : base(indexRepo, variablesRepo, postsRepo)
        {
        }

        public Dictionary<string, double> ProcessQueryTemp(string query)
        {
            var termsToCompute = GetTerms(query);
            var termsQueryFrequency = GetTermsFrequency(termsToCompute);
            var nrTermsToCompute = termsToCompute.Count;
            var termsIndex = IndexRepo.GetIndexOfWords(termsToCompute);
            var documentsLength = GetDocumentsLength(termsIndex);
            var documentsScoresAccumulator = new Dictionary<string, double>();

            foreach (var termIndex in termsIndex)
            {
                var term = termIndex.Term;
                var docs = termIndex.Docs;
                var nrDocs = docs.Count;

                foreach (var doc in docs)
                {
                    var tf = ComputeTermFrequency(doc.Frequency, documentsLength[doc.ID]);
                    var idf = ComputeInverseDocumentFrequency(nrDocs);

                    if (!documentsScoresAccumulator.ContainsKey(doc.ID))
                        documentsScoresAccumulator.Add(doc.ID, 0);

                    documentsScoresAccumulator[doc.ID] += (((double)termsQueryFrequency[term]) / nrTermsToCompute) * tf * idf;
                }
            }

            return documentsScoresAccumulator;
        }

        private double ComputeTermFrequency(int tf, int documentLength)
        {
            return tf / (tf + K * (documentLength / AverageDocLength));
        }

        private double ComputeInverseDocumentFrequency(int dfw)
        {
            return Math.Log(((double)CollectionSize) / dfw);
        }

        public override List<Post> ProcessQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
