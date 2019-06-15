using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Data;
using SearchEngine.Data.Repos;
using SearchEngine.Data.Repos.EngineVariables;
using SearchEngine.Data.Repos.Posts;
using SearchEngine_DataService.Utils;

namespace SearchEngine_DataService.SearchManagers
{
    public class ProximityProbabilisticModelSearchManager : SearchManager
    {
        private const double DefaultTermScore = 1;
        private const double DistWeight = 1;
        private const double K1 = 1;
        private const double B = 0.5;

        public ProximityProbabilisticModelSearchManager(IndexRepository indexRepo, EngineVariablesRepository variablesRepo, PostsRepository postsRepo) : base(indexRepo, variablesRepo, postsRepo)
        {
        }

        public Dictionary<string, double> ProcessQueryTemp(string query)
        {
            var termsToCompute = GetTerms(query);
            var termsIndex = IndexRepo.GetIndexOfWords(termsToCompute);
            var termsQueryPositions = GetTermsPosition(termsToCompute);
            var termsWeight = GetTermsWeight(termsIndex);
            var documentsToScore = ComputeDocumentsIndexFromTermsIndex(termsIndex);
            var documentsLen = GetDocumentsLength(termsIndex);
            var result = new Dictionary<string, double>();

            foreach (var docToScore in documentsToScore)
            {
                var docID = docToScore.Key;
                var fti = new Dictionary<string, double>();
                var docLen = documentsLen[docID];
                var termsRelativePositions = CustomMergeSort.MergeKSortedLists(docToScore.Value);
                var docScore = 0.0;

                for (int i = 0; i < termsRelativePositions.Count; ++i)
                {
                    var termPos = termsRelativePositions[i].Key;
                    var term = termsRelativePositions[i].Value;
                    var minDistanceElementIndex = ComputeMinDistanceElementIndex(i, termsRelativePositions);
                    var documentOffset = termPos - termsRelativePositions[minDistanceElementIndex].Key;
                    var queryOffset = termsQueryPositions[term] - termsQueryPositions[termsRelativePositions[minDistanceElementIndex].Value];
                    if (!fti.ContainsKey(term))
                        fti.Add(term, DefaultTermScore);
                    var dist = Math.Abs(documentOffset - queryOffset);

                    fti[term] += termsWeight[term] * termsWeight[termsRelativePositions[minDistanceElementIndex].Value] * ReverseProximity(dist);
                }

                var K = ComputeK(docLen);
                foreach (var item in fti)
                    docScore += termsWeight[item.Key] * item.Value / (K + item.Value);

                result.Add(docID, docScore);
            }

            return result;
        }

        //TODO: REMOVE FROM HERE
        private double ReverseProximity(int x) => (1 / (DistWeight * x + 1));

        //TODO: REMOVE FROM HERE
        private double ComputeK(int documentLength) => (K1 * ((1 - B) + (B * (((double)documentLength) / AverageDocLength))));

        private int ComputeMinDistanceElementIndex(int indexInList, List<KeyValuePair<int, string>> termsPositions)
        {
            if (indexInList == 0)
                return (termsPositions.Count == 1 ? 0 : 1);
            else if (indexInList == termsPositions.Count - 1)
                return termsPositions.Count - 2;

            var leftDistance = Math.Abs(termsPositions[indexInList - 1].Key - termsPositions[indexInList].Key);
            var rightDistance = Math.Abs(termsPositions[indexInList + 1].Key - termsPositions[indexInList].Key);

            return leftDistance <= rightDistance ? (indexInList - 1) : (indexInList + 1);
        }

        private Dictionary<string, Dictionary<string, List<int>>> ComputeDocumentsIndexFromTermsIndex(List<IndexTerm> termsIndex)
        {
            var result = new Dictionary<string, Dictionary<string, List<int>>>();

            foreach (var termIndex in termsIndex)
            {
                var term = termIndex.Term;
                var docs = termIndex.Docs;

                foreach (var doc in docs)
                {
                    if (!result.ContainsKey(doc.ID))
                        result.Add(doc.ID, new Dictionary<string, List<int>>());

                    if (!result[doc.ID].ContainsKey(term))
                        result[doc.ID][term] = doc.Positions;
                }
            }

            return result;
        }

        public override List<Post> ProcessQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
