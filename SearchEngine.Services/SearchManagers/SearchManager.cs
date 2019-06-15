using SearchEngine.Data;
using SearchEngine.Data.Repos;
using SearchEngine.Data.Repos.EngineVariables;
using SearchEngine.Data.Repos.Posts;
using SearchEngine_DataService.RulesProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchEngine_DataService.SearchManagers
{
    public abstract class SearchManager
    {
        protected readonly IndexRepository IndexRepo;
        protected readonly PostsRepository PostsRepo;
        protected double AverageDocLength { get; set; }
        protected long CollectionSize { get; set; }


        public SearchManager(IndexRepository indexRepo, EngineVariablesRepository variablesRepo, PostsRepository postsRepo)
        {
            IndexRepo = indexRepo;
            AverageDocLength = variablesRepo.GetEngineVariables().ContentAverageLength;
            CollectionSize = postsRepo.GetCollectionSize();
            PostsRepo = postsRepo;
        }

        public abstract List<Post> ProcessQuery(string query);

        protected Dictionary<string, int> GetDocumentsLength(List<IndexTerm> termsIndex)
        {
            var docIDs = ComputeOR(termsIndex);
            var result = PostsRepo.GetPostsContentLength(docIDs);

            return result;
        }

        protected List<string> GetTerms(string query)
        {
            var result = StringSplitRuleProvider.AlphaNumbericSplitting(query).Select(x => StringStemmingRuleProvider.Snowball(x.Trim().ToLower())).ToList();
            return result;
        }

        protected Dictionary<string, int> GetTermsFrequency(List<string> terms)
        {
            var result = new Dictionary<string, int>();

            foreach (var term in terms)
            {
                if (result.ContainsKey(term))
                    result[term]++;
                else
                    result[term] = 1;
            }

            return result;
        }

        protected List<string> ComputeOR(List<IndexTerm> indexTerms)
        {
            var preResult = new HashSet<string>();

            foreach (var item in indexTerms)
                preResult.UnionWith(item.Docs.Select(x => x.ID));

            return preResult.ToList();
        }

        protected Dictionary<string, int> GetTermsPosition(List<string> terms)
        {
            var result = new Dictionary<string, int>();

            for (int i = 0; i < terms.Count; ++i)
                if (!result.ContainsKey(terms[i]))
                    result.Add(terms[i], i);

            return result;
        }

        protected Dictionary<string, double> GetTermsWeight(List<IndexTerm> termsIndex)
        {
            var N = CollectionSize;
            var result = new Dictionary<string, double>();

            foreach (var termIndex in termsIndex)
            {
                var term = termIndex.Term;
                var dfi = termIndex.Docs.Count;
                var wi = Math.Log((N - dfi + 0.5) / (dfi + 0.5));
                result.Add(term, wi);
            }

            return result;
        }
    }
}
