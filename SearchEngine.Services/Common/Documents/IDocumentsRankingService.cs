using SearchEngine.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine_DataService.Common.Documents
{
    public interface IDocumentsRankingService
    {
        List<Post> GetDocumentsRankedPPM(string query);
    }
}
