using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgPlayGroundApp.Helpers
{
    public class IntToRomanNumberConverter
    {
        public class MySolution
        {
            /// <summary>
            /// https://leetcode.com/problems/integer-to-roman/
            /// </summary>
            /// <param name="num">integer to convert to roman number</param>
            /// <returns>roman number as string</returns>
            public string IntToRoman(int num)
            {
                var builder = new StringBuilder();

                while(num > 0)
                {
                    num = PrintRomanNumIfExist(num, builder, 1000, 900);
                    num = PrintRomanNumIfExist(num, builder, 500, 400);
                    num = PrintRomanNumIfExist(num, builder, 100, 90);
                    num = PrintRomanNumIfExist(num, builder, 50, 40);
                    num = PrintRomanNumIfExist(num, builder, 10, 9);
                    num = PrintRomanNumIfExist(num, builder, 5, 4);
                    num = PrintRomanNumIfExist(num, builder, 1);
                }

                return builder.ToString();
            }

            private static int PrintRomanNumIfExist(int num, StringBuilder builder, int romanNumToPrint, int? specialNumToPrint = null)
            {
                int count = num / romanNumToPrint;
               
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        builder.Append(Values[romanNumToPrint]);
                    }
                    num -= romanNumToPrint * count;
                    
                }

                if (specialNumToPrint.HasValue)
                {
                    num = PrintSpecialNumIfExists(num, builder, specialNumToPrint.Value);
                }
                
                return num;
            }

            private static int PrintSpecialNumIfExists(int num, StringBuilder builder, int val)
            {
                if (num - val >= 0)
                {
                    num -= val;
                    builder.Append(SpecialValues[val]);
                }

                return num;
            }

            private static readonly Dictionary<int, string> Values = new Dictionary<int, string>()
            {
                {1000, "M"},
                {500, "D"},
                {100, "C"},
                {50, "L"},
                {10, "X"},
                {5, "V"},
                {1, "I"}
            };
            private static readonly Dictionary<int, string> SpecialValues = new Dictionary<int, string>() { 
                {900,"CM"},
                {400,"CD"},
                {90,"XC"},
                {40,"XL"},
                { 9, "IX"},
                { 4, "IV"}
            };

        }

        public class LeetSolution
        {
            /*
             In pseudocode, this algorithm is as follows.
            ---------------------------------------------
            define function to_roman(integer):
            roman_numeral = ""
            while integer is non-zero:
                symbol = biggest valued symbol that fits into integer
                roman_numeral = concat roman_numeral and symbol
                integer = integer - value of symbol
            return roman_numeral
            =======================================
            The cleanest way to implement this in code is to loop over each symbol, from largest to smallest, checking how many copies of the current symbol fit into the remaining integer.

            define function to_roman(integer):
            roman_numeral = ""
            for each symbol from largest to smallest:
                if value of symbol is greater than integer:
                    continue
                symbol_count = number of times symbol value fits into integer
                repeat symbol_count times:
                    roman_numeral = concat roman_numeral and symbol
                integer = integer - (value of symbol * symbol_count)

            return roman_numeral
             */

            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            public string IntToRoman(int num)
            {
                StringBuilder sb = new StringBuilder();
                // Loop through each symbol, stopping if num becomes 0.
                for (int i = 0; i < values.Length && num >= 0; i++)
                {
                    // Repeat while the current symbol still fits into num.
                    while (values[i] <= num)
                    {
                        num -= values[i];
                        sb.Append(symbols[i]);
                    }
                }
                return sb.ToString();
            }

            public string MyBetterSolution(int num)
            {
                var builder = new System.Text.StringBuilder();
                while (num > 0)
                {
                    if (num >= 1000)
                    {
                        num -= 1000;
                        builder.Append("M");
                    }
                    else if (num >= 900)
                    {
                        num -= 900;
                        builder.Append("CM");
                    }
                    else if (num >= 500)
                    {
                        num -= 500;
                        builder.Append("D");
                    }
                    else if (num >= 400)
                    {
                        num -= 400;
                        builder.Append("CD");
                    }
                    else if (num >= 100)
                    {
                        num -= 100;
                        builder.Append("C");
                    }
                    else if (num >= 90)
                    {
                        num -= 90;
                        builder.Append("XC");
                    }
                    else if (num >= 50)
                    {
                        num -= 50;
                        builder.Append("L");
                    }
                    else if (num >= 40)
                    {
                        num -= 40;
                        builder.Append("XL");
                    }
                    else if (num >= 10)
                    {
                        num -= 10;
                        builder.Append("X");
                    }
                    else if (num >= 9)
                    {
                        num -= 9;
                        builder.Append("IX");
                    }
                    else if (num >= 5)
                    {
                        num -= 5;
                        builder.Append("V");
                    }
                    else if (num >= 4)
                    {
                        num -= 4;
                        builder.Append("IV");
                    }
                    else
                    {
                        builder.Append(new string('I', num));
                        break;
                    }
                }
                return builder.ToString();
            }
        }
    }
}