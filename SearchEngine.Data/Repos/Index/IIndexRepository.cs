using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Data.Repos.Index
{
    public interface IIndexRepository
    {
        IndexTerm GetIndexOfWord(string term);
        List<IndexTerm> GetIndexOfWords(List<string> terms);
    }
}
