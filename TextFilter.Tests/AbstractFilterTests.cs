using System.Collections.Generic;
using TextFilter.Filters;

namespace TextFilter.Tests
{
    public abstract class AbstractFilterTests
    {
        protected IFilter Filter;
        protected readonly IEnumerable<string> SampleWords =
            new List<string> { "I", "as", "are", "four", "what", "rather", "currently" };
    }
}
