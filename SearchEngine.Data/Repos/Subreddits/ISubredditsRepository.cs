using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Data
{
    public interface ISubredditsRepository
    {
        Task<List<Subreddits>> GetAll();
    }
}
