using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Threading;
using Microsoft.Win32;

namespace CoputeSystems2._3
{
    class Program
    {
        static void ThirdTask()
        {

            Console.WriteLine("First number int");
            Int32 integer1 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("First number fraction");
            double fractional1 = Convert.ToDouble(Console.ReadLine());
            //знак
            int sign1 = Sign(integer1);
            //экспонента
            int exp1 = Exponent(integer1);
            //мантисса
            string integ1 = Convert.ToString(integer1, 2);
            string fr1 = Convert.ToString(Fractonal(fractional1));
            string Mantissa1 = "";
            if (fr1.Length > (24 - integ1.Length))
            {
                Mantissa1 = integ1.Substring(1) + fr1.Substring(0, 24 - integ1.Length);
            }
            else
            {
                Mantissa1 = integ1.Substring(1) + fr1 + new string('0', (23 - Mantissa1.Length));
            }

            Console.WriteLine("1, " + Mantissa1);

            Console.WriteLine("Second number int");
            Int32 integer2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Second number fraction");
            double fractional2 = Convert.ToDouble(Console.ReadLine());
            //знак
            int sign2 = Sign(integer2);
            //экспонента
            int exp2 = Exponent(integer2);
            //мантисса
            string integ2 = Convert.ToString(integer2, 2);
            string fr2 = Convert.ToString(Fractonal(fractional2));
            string Mantissa2 = "";
            if (fr2.Length > (24 - integ2.Length))
            {
                Mantissa2 = integ2.Substring(1) + fr2.Substring(0, 24 - integ2.Length);
            }
            else
            {
                Mantissa2 = integ2.Substring(1) + fr2 + new string('0', (23 - Mantissa2.Length));
            }
            Console.WriteLine("1, " + Mantissa2);
            int resdif = exp1 - exp2;
            Console.WriteLine($"Exponetnts difference {resdif}");
            int number2 = ShiftMantissa(integer2, resdif);
            string number2string = Convert.ToString(number2, 2);
            if (fr2.Length > (24 - number2string.Length))
            {
                Mantissa2 = number2string.Substring(1) + fr2.Substring(0, 24 - integ2.Length);
            }
            else
            {
                Mantissa2 = number2string.Substring(1) + fr2 + new string('0', (23 - Mantissa2.Length));
            }
            Console.WriteLine("1, " + Mantissa2);
            //вычисления знака результата
            int resSign = sign1 | sign2;
            Console.WriteLine("Multiply significands {0} = {1}^{2}", resSign, sign1, sign2);
           
            string resmantissa = Sum("1"+Mantissa1, "1"+Mantissa2);
            Console.WriteLine($"Result {resSign}, {resmantissa}");
            
        }

        public static int ShiftMantissa(int input, int resexp)
        {
            input <<= resexp;
            return input;
        }        

        static int Sign(int A)
        {
            int sign;
            if (A > 0)
            {
                sign = 1;
            }
            else
            {
                sign = 0;
            }

            return sign;
        }

        static int Exponent(int A)
        {
            string str = Convert.ToString(A, 2);
            return 127 + (str.Length - 1);
        }

        static string Fractonal(double B)
        {
            string str = "";
            while (B != 1)
            {
                B *= 2;
                if (B > 1)
                {
                    B -= 1;
                    str += "1";
                }
                else if (B < 1)
                {
                    str += "0";
                }

            }

            str += "1";

            return str;
        }

        private static string Sum(string A, string B)
        {
            string result = "";
            bool checker = false;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (A[i] == '1' && B[i] == '1')
                {
                    if (checker)
                    {
                        result += "1";
                        // A[i] = '1';
                    }
                    else
                    {
                        result += "0";
                        //A[i] = '0';
                        checker = true;
                    }
                }

                if (A[i] == '0' && B[i] == '0')
                {
                    if (checker)
                    {
                        result += "1";

                        //A[i] = '1';
                    }
                    else
                    {
                        result += "0";

                        //A[i] = '0';
                    }

                    checker = false;
                }

                if (A[i] == '1' && B[i] == '0')
                {
                    if (checker)
                    {
                        result += "0";

                        //A[i] = '0';
                    }
                    else
                    {
                        result += "1";
                        //                        A[i] = '1';
                    }
                }

                if (A[i] == '0' && B[i] == '1')
                {
                    if (checker)
                    {
                        result += "0";

                        //A[i] = '0';
                    }
                    else
                    {
                        result += "1";

                        //                        A[i] = '1';
                    }
                }
            }
            result = new string(result.ToCharArray().Reverse().ToArray());
            if (checker)
            {
                result = result.Remove(0, 1);                
                result = result.Insert(0, "1");
            }
            return result;
        }
        static void Main()
        {
             ThirdTask();

        }
           
    }
}