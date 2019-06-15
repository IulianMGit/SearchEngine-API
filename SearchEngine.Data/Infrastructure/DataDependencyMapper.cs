using Microsoft.Extensions.DependencyInjection;
using SearchEngine.Data.Repos;
using SearchEngine.Data.Repos.EngineVariables;
using SearchEngine.Data.Repos.Index;
using SearchEngine.Data.Repos.Posts;

namespace SearchEngine.Data.Infrastructure
{
    public static class DataDependencyMapper
    {
        public static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISubredditsRepository, SubredditsRepository>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
            serviceCollection.AddScoped<IIndexRepository, IndexRepository>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
            serviceCollection.AddScoped<IEngineVariablesRepository, EngineVariablesRepository>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
            serviceCollection.AddScoped<IPostsRepository, PostsRepository>(); //->https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences
        }
    }
}
