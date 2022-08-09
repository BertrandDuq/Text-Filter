using System.Collections.Generic;

namespace TextFilter.Filters
{
    public interface IFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> wordsToFilter);
    }
}
