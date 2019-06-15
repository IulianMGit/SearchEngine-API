using System;
using System.Collections.Generic;
using System.Text;
using SearchEngine.Data;

namespace SearchEngine.Data.Repos.EngineVariables
{
    public interface IEngineVariablesRepository
    {
        EngineVariablesAggregation GetEngineVariables();
    }
}
