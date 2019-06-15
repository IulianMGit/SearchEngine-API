using MongoDB.Bson;
using MongoDB.Driver;
using SearchEngine.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Services
{
    public class SubredditsService : ISubredditsService
    {
        private ISubredditsRepository SubredditsRepository { get; }

        public SubredditsService(ISubredditsRepository subredditsRepository)
        {
            SubredditsRepository = subredditsRepository;
        }

        public async Task<List<Subreddits>> GetAllSubreddits()
        {
            return await SubredditsRepository.GetAll();
        }
    }
}
