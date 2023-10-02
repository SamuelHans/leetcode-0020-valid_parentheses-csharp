using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace LeetCode___0020___Valid_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

            An input string is valid if:
            
            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.
            Every close bracket has a corresponding open bracket of the same type.
             
            Example 1:
            Input: s = "()"
            Output: true

            Example 2:
            Input: s = "()[]{}"
            Output: true

            Example 3:
            Input: s = "(]"
            Output: false
            
            Constraints:
            1 <= s.length <= 104
            s consists of parentheses only '()[]{}'.
            */

            // START

            //var s = "()";
            //var s = "()[]{}";
            var s = "(]";
            //var s = "}";

            var isStringValidInput = IsValidMethod2(s);

            Console.WriteLine("The string {0} a valid parentheses? This is {1}", s, isStringValidInput);
        }

        // Method 1 - Slow replace
        private static bool IsValidMethod1(string s)
        {
            string changeFlag;

            while (s.Length > 0)
            {
                changeFlag = s;
                s = s.Replace("()", "");
                s = s.Replace("[]", "");
                s = s.Replace("{}", "");
                if (changeFlag == s)
                {
                    break;
                }
            }

            return (s.Length > 0) ? false : true;
        }

        // Method 1 - With Dictionary and Stack
        private static bool IsValidMethod2(string s)
        {
            // Valid open bracket options
            var openBrackets = new List<char> { '{', '(', '[' };

            // Dictionary of brackets
            var bracketMap = new Dictionary<char, char>
            {
                {'{', '}' },
                {'(', ')' },
                {'[', ']' }
            };

            // Create stack
            var stack = new Stack<char>();

            foreach (var character in s)
            {
                // If char is an open bracket, push to stack
                if (openBrackets.Contains(character))
                {
                    stack.Push(character);
                }
                else
                {
                    // If char is a closed bracket, pop and check via dictionary what matching closed bracket is
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var popOpenBracket = stack.Pop();
                    var matchingCloseBracket = bracketMap[popOpenBracket];

                    if (matchingCloseBracket != character)
                        return false;
                }
            }

            return stack.Count == 0;
        }

    }
}