using SearchEngine_DataService.SearchManagers;
using SearchEngine_DataService.Utils;
using System;
using System.Collections.Generic;

namespace SearchEngine.Play
{
    class Program
    {
        static void Main(string[] args)
        {

            //var a = new Dictionary<string, List<int>>();
            //a.Add("cacat", new List<int> { 1, 3, 5, 6, 7 });
            //a.Add("pisat", new List<int> { 0, 4 });
            //a.Add("retardat", new List<int> { 2, 8 });
            //CustomMergeSort.MergeKSortedLists(a);

            var f = new ProximityProbabilisticModelSearchManager(new Data.Repos.IndexRepository(), new Data.Repos.EngineVariables.EngineVariablesRepository(), new Data.Repos.Posts.PostsRepository());

            f.ProcessQueryTemp("asking upvote");
        }
    }
}
