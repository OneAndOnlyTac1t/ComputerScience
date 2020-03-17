using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ComputerSysftems2._1
{
    class Program
    {
        private static void FillLA(char[] A, string input, int bytes)
        {
            for (int i = 0; i< input.Length; i++)
            {
                A[i] = input[i];
            }
        }
        private static void FillS(char[] A, string input)
        {
            for (int i = 0; i< input.Length; i++)
            {
                A[i] = input[i];
            }
        }

        private static void FillP(char[] P, string input, int temp)
        {
            for (int i = 0; i < input.Length; i++)
            {
                P[temp + i] = input[i];
            }
        }

        private static void RepeatShit(char[] A, char[] S, char[] P, int y)
        {
            for (int i = 0; i < y; i++)
            {
                char[] last = new char[2];
                last[0] = P[P.Length - 2];
                last[1] = P[P.Length - 1];
                if (last[0] == last[1])
                {
                    ShiftRight(P);
                    Console.WriteLine(P);

                }
                else
                {
                    if (last[0] == '0')
                    {

                        Sum(P, A);
                        Console.Write(P);
                        ShiftRight(P);
                        Console.WriteLine(P);
                    }
                    else
                    {

                        Sum(P, S);
                        Console.WriteLine(P);

                        ShiftRight(P);
                        Console.WriteLine(P);
                    }
                }
            }
        }

        private static void Sum(char[] A, char[] B)
        {           
            bool checker = false;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] == '1' && B[i] == '1')
                {
                    if (checker)
                    {
                        A[i] = '1';
                    }
                    else
                    {
                        A[i] = '0';
                        checker = true;
                    }
                }

                if (A[i] == '0' && B[i] == '0')
                {
                    if (checker)
                    {
                        A[i] = '1';
                    }
                    else
                    {
                        A[i] = '0';
                    }

                    checker = false;
                }

                if (A[i] == '1' && B[i] == '0')
                {
                    if (checker)
                    {
                        A[i] = '0';
                    }
                    else
                    {
                        A[i] = '1';
                    }
                }

                if (A[i] == '0' && B[i] == '1')
                {
                    if (checker)
                    {
                        A[i] = '0';
                    }
                    else
                    {
                        A[i] = '1';
                    }
                }
            }
        }

        private static void ShiftRight(char[] input)
        {
            for (int i = input.Length - 1; i > 0; i--)
            {
                input[i] = input[i - 1];
            }
        }
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            string m = Convert.ToString(x, 2);
            m = m.Insert(0, "0");
            Console.Write("m = ");
            Console.WriteLine(m);
            //string advancedm = Convert.ToString(-x, 2);
            char[] minus = Convert.ToString(x, 2).ToCharArray();
            for (int i = 0; i < minus.Length; i++)
            {
                if (minus[i] == '0')
                {
                    minus[i] = '1';
                }
                else
                {
                    minus[i] = '0';
                }
            }

            string advancedm = new string(minus);
            Console.WriteLine(advancedm);
            Console.Write("-m = ");
            int number = advancedm.LastIndexOf('0');
            if (number != -1)
            {
                advancedm= advancedm.Insert(number, "1");
                advancedm = advancedm.Remove(number + 1);
            }
            else
            {
                advancedm = advancedm.Replace('1','0');
                advancedm = advancedm.Insert(0, "1");
            }
            advancedm = advancedm.Insert(0, "1");
            Console.WriteLine(advancedm);
            string r = Convert.ToString(y, 2);
            Console.Write("r = ");
            Console.WriteLine(r);
            char[] A = new char[m.Length + r.Length + 1];
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = '0';
            }
            FillLA(A, m, r.Length + 1);
            Console.Write("A = ");
            Console.WriteLine(A);
            char[] S = new char[m.Length + r.Length + 1];
            for (int i = 0; i < S.Length; i++)
            {
                S[i] = '0';
            }
            FillS(S, advancedm);
            Console.Write("S = ");
            Console.WriteLine(S);
            char[] P = new char[m.Length + r.Length + 1];
            for (int i = 0; i < P.Length; i++)
            {
                P[i] = '0';
            }
            FillP(P, r, m.Length);
            Console.Write("P = ");
            Console.WriteLine(P);
            RepeatShit(A, S, P, m.Length);
            Console.Write("result = ");
            Console.WriteLine(P);

        }
    }
}
