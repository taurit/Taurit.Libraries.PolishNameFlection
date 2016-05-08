using System;
using System.Text.RegularExpressions;

namespace Taurit.NameHelper.Polish
{
    /// <summary>
    ///     String manipulation functions useful in describing rules of how words change in Polish language.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Replace text occuring at the end of a given string <paramref name="word" /> with another.
        /// </summary>
        /// <param name="word">Word to modify</param>
        /// <param name="from">
        ///     Characters that will be replaced with <paramref name="to" />. Characters must appear at the end of a
        ///     string
        /// </param>
        /// <param name="to">Character that will replace <paramref name="from" /> at the end of a given string</param>
        /// <returns>Modified word</returns>
        public static string ReplaceEnding(this string word, string from, string to)
        {
            if (!word.EndsWith(from))
                throw new ArgumentException("Given word doesn't end with a specified string", nameof(from));

            string newWordWithoutEnd = word.Substring(0, word.Length - from.Length);
            string newWord = newWordWithoutEnd + to;
            return newWord;
        }

        /// <summary>
        ///     Removes n-th last character of a string.
        /// </summary>
        /// <example>
        ///     "Hello, World".RemoveNthLastCharacter(1); // Hello, Word
        /// </example>
        /// <param name="word">String to modify</param>
        /// <param name="character">Index of character to remove, counting backwards.</param>
        /// <returns>Modified string</returns>
        public static string RemoveNthLastCharacter(this string word, int character)
        {
            return word.Substring(0, word.Length - character - 1) +
                   word.Substring(word.Length - character);
        }

        /// <summary>
        ///     Returns n-th last character of a string
        /// </summary>
        /// <param name="word">A string to test</param>
        /// <param name="character">Index of character to return, counting backwards. Eg. 0 = last character</param>
        /// <returns>Nth last character of a string or an empty string if index exceeds given string length.</returns>
        public static string GetNthLastCharacter(this string word, int character)
        {
            return word.Substring(word.Length - character - 1, 1);
        }

        /// <summary>
        ///     Appends text to a given string. Null values are treated as empty strings.
        /// </summary>
        /// <param name="word">Original string</param>
        /// <param name="text">String to append at the end of <paramref name="word" /></param>
        /// <returns>Concatenation of two given strings</returns>
        public static string AppendText(this string word, string text)
        {
            return word + text;
        }

        /// <summary>
        ///     Tests whether a string ends with a pattern described with a regex string.
        /// </summary>
        /// <param name="word">A word to test.</param>
        /// <param name="pattern">
        ///     Pattern to test. This pattern must not end with "$" character.
        /// </param>
        /// <returns>True if <paramref name="word" /> ends with <paramref name="pattern" />, false otherwise.</returns>
        public static bool EndsWithRegex(this string word, string pattern)
        {
            var regex = new Regex(pattern + "$");
            var match = regex.Match(word);

            return match.Success;
        }
    }
}