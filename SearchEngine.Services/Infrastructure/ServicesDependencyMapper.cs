using Microsoft.Extensions.DependencyInjection;
using SearchEngine.Data.Infrastructure;
using SearchEngine_DataService.Common.Documents;

namespace SearchEngine.Services.Infrastructure
{
    public static class ServicesDependencyMapper
    {
        public static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            DataDependencyMapper.RegisterDependencies(serviceCollection);
            serviceCollection.AddScoped<ISubredditsService, SubredditsService>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
            serviceCollection.AddScoped<IDocumentsRankingService, DocumentsRankingService>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
        }
    }
}
