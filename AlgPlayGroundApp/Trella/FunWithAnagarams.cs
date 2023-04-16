using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace AlgPlayGroundApp.Trella
{
    public class FunWithAnagarams
    {
        public static List<string> funWithAnagrams(List<string> text)
        {
            if (text == null || text.Count < 2)
                return text;

            if (text.Count == 2)
            {
                if (AreAnagrams(text[0], text[1]))
                {
                    text.RemoveAt(1);
                    return text;
                }
                else
                {
                    text.Sort();
                    return text;
                }
            }

            int index = 0;
            while (index < text.Count)
            {

                if (index < text.Count - 1)
                {
                    var result = RemoveAnagrams(text[index], text, index + 1);
                    text = text.GetRange(0, index + 1);
                    text.AddRange(result);
                }

                index++;
            }

            text.Sort();
            return text;
        }

        private static List<string> RemoveAnagrams(string src, List<string> text, int start)
        {
            if (text == null || text.Count < 2)
                return text;

            List<string> updated = new List<string>(text.Count);
            for (int i = start; i < text.Count; i++)
            {
                if (AreAnagrams(src, text[i]))
                    continue;

                updated.Add(text[i]);
            }
            return updated;
        }

        static bool AreAnagrams(string first, string second)
        {
            if (first == null || second == null
                             || first.Length != second.Length)
                return false;

            const int englishAlphabet = 26;
            // we record/count the frequency of each character [in first string param] in frequencies array
            var frequencies = new int[englishAlphabet];
            first = first.ToLower();
            for (int i = 0; i < first.Length; i++)
            {
                var ch = first[i];
                var index = ch - 'a';
                frequencies[index]++;
            }

            //we iterate over second string char
            // for each char in second - we decrement its counter in frequencies array
            // if count == zero within for loop then 
            // these strings (first & second) does not have same characters and return false
            // otherwise return true
            second = second.ToLower();
            for (int i = 0; i < second.Length; i++)
            {
                var ch = second[i];
                var index = ch - 'a';
                if (frequencies[index] == 0)
                {
                    // Both strings does not have same number of characters
                    return false;
                }
                frequencies[index]--;
            }
            return true;
        }

        public static void Test()
        {
            /*
            var list = new List<string>()
            {
                "code",

                "aaagmnrs",

                "anagrams",

                "doce"
            };

            var result = funWithAnagrams(list);
            */
            using HttpClient client = new();
            var substr = "maze";
            var url = $"https://jsonmock.hackerrank.com/api/moviesdata/search/?Title={substr}";
            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            Console.WriteLine(data);
            JObject rss = JObject.Parse(data);
            var strTotal = (string) rss["total"];
            if (string.IsNullOrEmpty(strTotal))
                return; //0// ;
            if (int.TryParse(strTotal, out var total))
            {
                return; // total;
            }

            return;//  0;
        }
    }
}