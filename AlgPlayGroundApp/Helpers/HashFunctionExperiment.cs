using System;

namespace AlgPlayGroundApp.Helpers
{
    public class HashFunctionExperiment
    {
        public static int GenerateHashKey(string key, int hashTableSize)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            if(hashTableSize <= 0)
                throw new ArgumentException(nameof(hashTableSize), $"{nameof(hashTableSize)} should be positive value");
            //sum numerical value for each char
            // hash value = total % hashTableSize
            var total = 0;
            var charArr = key.ToCharArray();
            foreach (var ch in charArr)
            {
                total += ch;
            }

            return total % hashTableSize;
        }
    }
}