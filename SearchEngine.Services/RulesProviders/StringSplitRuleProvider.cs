using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SearchEngine_DataService.RulesProviders
{
    public static class StringSplitRuleProvider
    {
        public static List<string> AlphaNumbericSplitting(string stringToSplit)
        {
            return Regex.Matches(stringToSplit, @"\w+|<\w+>|</\w+>").Select(x => x.Value).ToList();
        }
    }
}
