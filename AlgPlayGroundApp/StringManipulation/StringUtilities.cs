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
    }
}