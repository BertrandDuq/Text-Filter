using System.Collections.Generic;
using System.Linq;

namespace TextFilter.Filters
{
    public class WordLengthFilter : IFilter
    {
        private readonly int _minLengthToKeep;

        public WordLengthFilter(int minLengthToKeep)
        {
            _minLengthToKeep = minLengthToKeep;
        }

        public IEnumerable<string> Filter(IEnumerable<string> wordsToFilter)
        {
            return wordsToFilter.Where(word => word.Length >= _minLengthToKeep);
        }
    }
}
