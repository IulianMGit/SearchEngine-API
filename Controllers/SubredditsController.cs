using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Services;
using SearchEngine_DataService.Common.Documents;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchEngineAPI.Controllers
{
    [Route("api/[controller]")]
    public class SubredditsController : Controller
    {
        private readonly ISubredditsService subredditsService;
        private readonly IDocumentsRankingService documentsRankingService;

        public SubredditsController(ISubredditsService subredditsService,
                                    IDocumentsRankingService documentsRankingService
                                    )
        {
            this.subredditsService = subredditsService;
            this.documentsRankingService = documentsRankingService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var allSubreddits = documentsRankingService.GetDocumentsRankedPPM("upvote");

            return Json(allSubreddits);
        }
    }
}
