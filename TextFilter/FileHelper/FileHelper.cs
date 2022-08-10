using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextFilter.FileHelper
{
    public static class FileHelper
    {
        public static IEnumerable<string> GetFileLines(string filePath)
        {
            try
            {
                var lines = File.ReadLines(filePath);

                return lines;
            }
            catch (Exception e)
            {
                throw new Exception($"Could not get the lines for the file ${filePath}. See exception: {e}");
            }
        }

        public static IEnumerable<string> GetWordsList(IEnumerable<string> lines)
        {
            try
            {
                //this pattern will look up all groups that are not words or numbers. For the purpose of this exercise I do not consider cases like email addresses
                var regexPattern = @"[^\w]+";
                var words = lines.SelectMany(x => Regex.Split(x, regexPattern));

                return words.Where(x => x.Length > 0);
            }
            catch (Exception e)
            {
                throw new Exception($"Could not get the words for the lines of the file. See exception: {e}");
            }
        }
    }
}
