using System.Collections.Generic;
using System.Linq;

namespace TextFilter.Filters
{
    public class LetterFilter : IFilter
    {
        private readonly char _letterToFilter;

        public LetterFilter(char letterToFilter)
        {
            _letterToFilter = letterToFilter;
        }

        public IEnumerable<string> Filter(IEnumerable<string> wordsToFilter)
        {
            return wordsToFilter.Where(word => !word.Contains(_letterToFilter));
        }
    }
}
