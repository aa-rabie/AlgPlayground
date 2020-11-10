namespace AlgPlayGroundApp.Amazon.Demo
{
    public class GCDCalculator
    {
        public int CalculateGcd(int[] numbers)
        {
            var result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = CalculateGCD(result, numbers[i]);
                if (result == 1)
                    return 1;
            }

            return result;
        }
        /// <summary>
        /// Calculate GCD using  Euclidean algorithm https://en.wikipedia.org/wiki/Euclidean_algorithm
        /// GCD of more than two (or array) numbers @ https://www.geeksforgeeks.org/gcd-two-array-numbers/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int CalculateGCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }
}