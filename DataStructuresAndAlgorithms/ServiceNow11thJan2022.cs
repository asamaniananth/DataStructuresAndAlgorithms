using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class ServiceNow11thJan2022
    {
        public static int evaluateExp(String s)
        {
            Stack<char> charStack = new Stack<char>();
            Stack<int> intStack = new Stack<int>();
            int op1, op2;
            char oper = ' ';

            int i = 0;
            while (i < s.Length)
            {
                // [&, 0, [!, 1], [&, 0, 0, 1, 0]]
                if (s[i] == '[' || s[i] == ',' || s[i] == ' ')
                {
                    i++;
                }
                else if (s[i] == '|' || s[i] == '&' || s[i] == '!')
                {
                    charStack.Push(s[i]);
                }
                else if (s[i] == ']')
                {
                    if (charStack.Count > 0)
                    {
                        oper = charStack.Pop();
                    }
                    switch (oper)
                    {
                        case '&':
                            {
                                if (intStack.Count > 1)
                                {
                                    op2 = intStack.Pop();
                                    op1 = intStack.Pop();
                                    int result = op1 & op2;
                                    intStack.Push(result);
                                }
                                break;
                            }
                        case '|':
                            {
                                if (intStack.Count > 1)
                                {
                                    op2 = intStack.Pop();
                                    op1 = intStack.Pop();
                                    int result = op1 | op2;
                                    intStack.Push(result);
                                }
                                break;
                            }
                        case '!':
                            {
                                if (intStack.Count > 0)
                                {
                                    op1 = intStack.Pop();
                                    int result = (op1 == 1) ? 0 : 1;
                                    intStack.Push(result);
                                }
                                break;
                            }
                    }
                    //oper='';
                }
                else
                {
                    intStack.Push(s[i] - '0');
                }
                i++;
            }
            return (intStack.Count > 1) ? 0 : intStack.Pop();
        }

        public static List<int> circuitsOutput(List<string> ce)
        {
            List<int> result = new List<int>();
            foreach (string x in ce)
            {
                int z = evaluateExp(x);
                result.Add(z);
            }
            return result;
        }
    }
}
