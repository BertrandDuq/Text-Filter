using System.Collections.Generic;
using TextFilter.Filters;

namespace TextFilter.Tests.Filters
{
    public abstract class AbstractFilterTests
    {
        protected IFilter Filter;
        protected readonly IEnumerable<string> SampleWords =
            new List<string> { "I", "as", "are", "you", "four", "whaT", "Only", "rather", "currently" };
    }
}
