using System.Collections.Generic;
using System.Linq;

namespace TextFilter.Filters
{
    public class MiddleWordVowelFilter : IFilter
    {
        private readonly IEnumerable<char> _vowelList = new List<char> { 'a', 'e', 'i', 'o', 'u' }; 

        public IEnumerable<string> Filter(IEnumerable<string> wordsToFilter)
        {
            foreach (var wordToFilter in wordsToFilter)
            {
                var wordLength = wordToFilter.Length;
                var wordToLower = wordToFilter.ToLower();

                switch (wordLength % 2)
                {
                    case 0:
                    {
                        if (!ShouldFilterWordEvenLength(wordToLower, wordLength))
                        {
                            yield return wordToFilter;
                        }

                        break;
                    }
                    case 1:
                    {
                        if (!ShouldFilterWordOddLength(wordToLower, wordLength))
                        {
                            yield return wordToFilter;
                        }

                        break;
                    }
                }
            }
        }

        private bool ShouldFilterWordEvenLength(string word, int wordLength)
        {
            var charPosition = (wordLength/2) - 1;

            var substring = word.Substring(charPosition, 2);

            return substring.Any(_vowelList.Contains);
        }

        private bool ShouldFilterWordOddLength(string word, int wordLength)
        {
            var charPosition = wordLength == 1 ?  
                0 : 
                (wordLength / 2);
            
            return _vowelList.Contains(word[charPosition]);
        }
    }
}
