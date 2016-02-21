using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace NameHelper.Polish
{
    public static class StringExtensions
    {
        public static string ReplaceEnding(this string word, string from, string to)
        {
            Debug.Assert(word.EndsWith(from));

            string newWordWithoutEnd = word.Substring(0, word.Length - from.Length);
            string newWord = newWordWithoutEnd + to;
            return newWord;
        }


        public static string RemoveNthLastCharacter(this string word, int character)
        {
            return word.Substring(0, word.Length - character - 1) +
                   word.Substring(word.Length - character);
        }

        public static string GetNthLastCharacter(this string word, int character)
        {
            return word.Substring(word.Length - character -1, 1);
        }

        public static string AppendText(this string word, string text)
        {
            return word + text;
        }

        public static bool EndsWithRegex(this string word, string pattern)
        {
            Debug.Assert(!pattern.EndsWith("$"));

            Regex regex = new Regex(pattern + "$");
            Match match = regex.Match(word);

            return match.Success;

        }
    }
}
