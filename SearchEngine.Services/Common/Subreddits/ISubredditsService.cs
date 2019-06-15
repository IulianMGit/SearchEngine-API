using SearchEngine.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Services
{
    public interface ISubredditsService
    {
        Task<List<Subreddits>> GetAllSubreddits();
    }
}
