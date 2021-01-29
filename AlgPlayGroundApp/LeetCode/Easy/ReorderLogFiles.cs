using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// problem : https://leetcode.com/problems/reorder-data-in-log-files/
    /// </summary>
    public class ReorderLogFilesProblem
    {
        private abstract class LogEntry
        {
            public string OriginalString { get; set; }

            public string Identifier { get; set; }
            public string[] Words { get; set; } = new string[] { };
        }

        private class DigitLogEntry : LogEntry
        {
            public int[] Numbers => (Words.Select(int.Parse)).ToArray();
        }

        /// <summary>
        /// the comparer should order entries lexicographically, ignoring identifiers, with the identifier used in case of ties
        /// </summary>
        private class TextLogEntryComparer : IComparer<TextLogEntry>
        {
            public int Compare(TextLogEntry x, TextLogEntry y)
            {
                if (x == null && y == null)
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return 1;
                return x.CompareTo(y);
            }
        }
        private class TextLogEntry : LogEntry, IComparable<TextLogEntry>
        {
            private const char _blank = ' ';

            public int CompareTo(TextLogEntry other)
            {
                var i = 0;
                var o = 0;
                while (i < Words.Length || o < other.Words.Length)
                {
                    var first = i == Words.Length ? string.Empty : Words[i++];
                    var second = o == other.Words.Length ? string.Empty : other.Words[o++];
                    var isSorted = IsWordsSorted(first, second, out var isEqual);
                    if (!isEqual)
                    {
                        if (isSorted)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }

                //if we reached here, then we need to compare using identifiers
                if (IsWordsSorted(Identifier, other.Identifier, out var isIdentifierEqual))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }

            // assuming that all chars are lower case or digits

            bool IsWordsSorted(string w1, string w2, out bool isEqual)
            {
                isEqual = false;
                if (w2.Length < w1.Length)
                    w2 = w2.PadRight(w1.Length, _blank);

                for (int i = 0; i < w1.Length; i++)
                {
                    if (w1[i] < w2[i])
                        return true;
                    else
                    {
                        if (w1[i] != w2[i] && w2[i] == _blank)
                            return false;

                        if (w1[i] > w2[i])
                            return false;
                    }
                }

                if (w1.Length < w2.Length)
                {
                    // if same character but w1 is less in length then w1 should be ordered before w2 & we should return true
                    return true;
                }

                //both words have same characters & length
                isEqual = true;
                return true;
            }
        }
        public string[] ReorderLogFiles(string[] logs)
        {
            if (logs?.Length == 0)
                return logs;

            List<TextLogEntry> txtEntries = new List<TextLogEntry>();
            List<DigitLogEntry> digitEntries = new List<DigitLogEntry>();
            // we need to iterate and differentiate digit logs from letter logs
            foreach (var log in logs)
            {
                var entry = CreateEntry(log);
                if (entry is DigitLogEntry)
                {
                    digitEntries.Add(entry as DigitLogEntry);
                }
                else
                {
                    txtEntries.Add(entry as TextLogEntry);
                }
            }
            // we need to sort out letter logs
            txtEntries.Sort(new TextLogEntryComparer());
            List<string> result = new List<string>(logs.Length);
            result.AddRange(txtEntries.Select(t => t.OriginalString));
            result.AddRange(digitEntries.Select(d => d.OriginalString));
            var arr = result.ToArray();
            result.Clear();
            return arr;
        }

        private LogEntry CreateEntry(string input)
        {
            var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var identifier = values[0];
            var isDigit = values[1].All(char.IsDigit);
            var words = new string[values.Length - 1];
            Array.Copy(values, 1, words, 0, words.Length);
            if (isDigit)
            { 
                return new DigitLogEntry()
                {
                    OriginalString = input,
                    Identifier = identifier,
                    Words = words
                };
            }

            return new TextLogEntry()
            {
                OriginalString = input,
                Identifier = identifier,
                Words = words
            };
        }
    }
}