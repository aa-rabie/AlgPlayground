using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlgPlayGroundApp.Helpers
{
    public class ExpressionChecker
    {
        private readonly List<char> _openingBrackets = new List<char>(new []{'(','<','[','{'});
        private readonly List<char> _closingBrackets = new List<char>(new []{')','>',']','}'});
        public bool IsBalanced(string input)
        {
            //consider input is balanced if there is zero brackets
            if (string.IsNullOrEmpty(input))
                return true;

            Stack<char> brackets = new Stack<char>();
            foreach (var ch in input)
            {
                if(IsOpeningBracketCharacter(ch))
                    brackets.Push(ch);

                if (IsClosingBracketCharacter(ch))
                {
                    if (brackets.Count == 0)
                        return false;

                    char top = brackets.Pop();
                    if (!BracketsMatch(top, ch))
                        return false;
                }
            }

            return brackets.Count == 0;
        }

        private bool IsOpeningBracketCharacter(char ch)
        {
            return _openingBrackets.IndexOf(ch) > -1;
        }

        private bool IsClosingBracketCharacter(char ch)
        {
            return _closingBrackets.IndexOf(ch) > -1;
        }

        private bool BracketsMatch(char left, char right)
        {
            return _openingBrackets.IndexOf(left) == _closingBrackets.IndexOf(right);
        }
    }
}