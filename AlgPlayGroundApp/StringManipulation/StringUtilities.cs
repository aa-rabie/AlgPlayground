using System.Text;

namespace AlgPlayGroundApp.StringManipulation
{
    public class StringUtilities
    {
        public static int CountVowels(string input)
        {
            var count = 0;
            if (string.IsNullOrEmpty(input))
                return count;

            input = input.ToLowerInvariant();

            var vowels = "aeoui";
            foreach (var ch in input)
            {
                if (vowels.Contains(ch))
                    count++;
            }
            return count;
        }

        public static string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            StringBuilder builder = new StringBuilder();

            for (var i = str.Length -1; i >= 0 ; i--)
            {
                builder.Append(str[i]);
            }

            return builder.ToString();
        }
    }
}