namespace AlgPlayGroundApp.LeetCode.Arrays
{
    // https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
    public class OnePlus
    {
        public int[] PlusOne(int[] digits)
        {
            bool shouldAddOneToNextDigit = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (i < digits.Length - 1 && shouldAddOneToNextDigit)
                {
                    var addingResult = AddOne(digits[i]);
                    digits[i] = addingResult.Item1;
                    shouldAddOneToNextDigit = addingResult.Item2;
                    if (!shouldAddOneToNextDigit)
                        break;
                    else
                    {
                        if (i == 0)
                        {
                            var data = new int[digits.Length + 1];
                            data[0] = 1;
                            System.Array.Copy(digits,0, data,1,digits.Length);
                            digits = data;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                        
                    }
                } 
                var result = AddOne(digits[i]);
               digits[i] = result.Item1;
               shouldAddOneToNextDigit = result.Item2;
               if (!shouldAddOneToNextDigit)
                   break;
               else
               {
                   if (i == 0)
                   {
                       var data = new int[digits.Length + 1];
                       data[0] = 1;
                       System.Array.Copy(digits, 0, data, 1, digits.Length);
                       digits = data;
                       break;
                   }

               }
            }

            return digits;
        }

        private (int , bool) AddOne(int num)
        {
            if (num + 1 == 10)
            {
                return (0, true);
            }

            return (num + 1, false);
        }

        public int[] LeetCodeSolution(int[] digits)
        {
            int n = digits.Length;

            // move along the input array starting from the end
            for (int idx = n - 1; idx >= 0; --idx)
            {
                // set all the nines at the end of array to zeros
                if (digits[idx] == 9)
                {
                    digits[idx] = 0;
                }
                // here we have the rightmost not-nine
                else
                {
                    // increase this rightmost not-nine by 1 
                    digits[idx]++;
                    // and the job is done
                    return digits;
                }
            }
            // we're here because all the digits are nines
            digits = new int[n + 1];
            digits[0] = 1;
            return digits;
        }
    }
}