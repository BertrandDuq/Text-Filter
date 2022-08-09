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
                
                if (wordLength % 2 == 0 && ShouldFilterWordEvenLength(wordToFilter, wordLength))
                {
                    yield return wordToFilter;
                }

                if (wordLength % 2 == 1 && ShouldFilterWordOddLength(wordToFilter, wordLength))
                {
                    yield return wordToFilter;
                }
            }
        }

        private bool ShouldFilterWordEvenLength(string word, int wordLength)
        {
            var charPosition = (wordLength/2) - 1;
            var substring = word.Substring(charPosition, charPosition + 1);

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
