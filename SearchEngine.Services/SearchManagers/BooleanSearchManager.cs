using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchEngine.Data;
using SearchEngine.Data.Repos;
using SearchEngine.Data.Repos.EngineVariables;
using SearchEngine.Data.Repos.Posts;

namespace SearchEngine_DataService.SearchManagers
{
    public class BooleanSearchManager : SearchManager
    {
        public BooleanSearchManager(IndexRepository indexRepo, EngineVariablesRepository variablesRepo, PostsRepository postsRepo) : base(indexRepo, variablesRepo, postsRepo)
        {
        }

        public override List<Post> ProcessQuery(string query)
        {
            throw new NotImplementedException();
        }

        public List<string> TempProcessQuery(string query)
        {
            return AND(GetTerms(query));
        }

        public List<string> AND(List<string> termsToCompute)
        {
            var termsIndex = IndexRepo.GetIndexOfWords(termsToCompute);
            var preResult = new HashSet<string>();
            if (termsIndex.Count == 0) return preResult.ToList();

            preResult.UnionWith(termsIndex[0].Docs.Select(x => x.ID));
            foreach (var item in termsIndex.Skip(1))
                preResult.IntersectWith(item.Docs.Select(x => x.ID));

            return preResult.ToList();
        }

        public List<string> OR(List<string> termsToCompute)
        {
            var termsIndex = IndexRepo.GetIndexOfWords(termsToCompute);

            return ComputeOR(termsIndex);
        }
    }
}
