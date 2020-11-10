using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.Amazon.Jordan
{
    public class FindMostUsedWords
    {
        private readonly char[] _seperators = new[] {' ', ',', '?', ':', ';', '!', '.', '–', '~', '[', ']', '{', '}', '\'', '"'};

        public List<string> RetrieveMostFrequentlyUsedWords(string helpText, List<string> wordsToExclude)
        {
            var words = GetWords(helpText, wordsToExclude);
            Dictionary<string, int> counter = new Dictionary<string, int>(words.Count);
            var maxCounterValue = 0;
            foreach (var word in words)
            {
                if (counter.ContainsKey(word))
                {
                    counter[word] += 1;
                }
                else
                {
                    counter[word] = 1;
                }

                if (maxCounterValue < counter[word])
                {
                    maxCounterValue = counter[word];
                }
            }

            List<string> mostUsedWords = new List<string>();
            foreach (var pair in counter)
            {
                if (pair.Value == maxCounterValue)
                {
                    mostUsedWords.Add(pair.Key);
                }
            }

            return mostUsedWords;
        }

        private List<string> GetWords(string helpText, List<string> wordsToExclude)
        {
            wordsToExclude = wordsToExclude.Select(w => w.ToLowerInvariant()).ToList();
            var words = helpText.Split(_seperators, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLowerInvariant())
                .Where(w => !wordsToExclude.Contains(w))
                .ToList();
            return words;
        }
    }
}