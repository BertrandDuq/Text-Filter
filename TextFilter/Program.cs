using System;
using System.Linq;
using TextFilter.Filters;

namespace TextFilter
{
    class Program
    {
        private const string FilePath = @"..\..\..\..\Input\input1.txt";

        static void Main(string[] args)
        {
            //reading the file and getting a list of all the words in there, removing any punctuation and anything that isn't letters or numbers
            Console.WriteLine("Reading the input file and getting the lines...");
            var lines = FileHelper.FileHelper.GetFileLines(FilePath);
            Console.WriteLine("Finished reading and getting the lines from the input file");

            Console.WriteLine("Cleaning out punctuation and making words list...");
            var wordList = FileHelper.FileHelper.GetWordsList(lines);
            Console.WriteLine("Finished cleaning punctuation and getting the list of words from the input file");

            if (!wordList.Any())
            {
                Console.WriteLine("There isn't any word left!");
                return;
            }

            //initializing the filters
            Console.WriteLine("Creating filters...");
            var letterFilter = new LetterFilter('t');
            var wordLengthFilter = new WordLengthFilter(3);
            var middleWordVowelFilter = new MiddleWordVowelFilter();
            Console.WriteLine("Finished creating filters");

            //and now we're filtering
            Console.WriteLine("Starting the filter processes...");
            wordList = letterFilter.Filter(wordList);
            wordList = wordLengthFilter.Filter(wordList);
            wordList = middleWordVowelFilter.Filter(wordList).ToList();
            Console.WriteLine($"Finished the filtering processes, there is now {wordList.Count()} word(s) left:");
            
            //printing result
            Console.WriteLine(string.Join(';', wordList));
        }
    }
}
