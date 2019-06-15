using SearchEngine.Data;
using SearchEngine.Data.Repos.Index;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine_DataService.Common.Documents
{
    public class DocumentsRankingService : IDocumentsRankingService
    {
        private IIndexRepository IndexRepository { get; }

        public DocumentsRankingService(IIndexRepository IndexRepository)
        {
            this.IndexRepository = IndexRepository;
        }

        public List<Post> GetDocumentsRankedPPM(string query)
        {
            var a = IndexRepository.GetIndexOfWords(new List<string> { "upvot","ask" });
            return new List<Post>();
        }
    }
}
