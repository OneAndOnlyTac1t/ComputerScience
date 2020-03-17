using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSystems2._2
{
    class Program
    {
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

        private static string DivideShit(int remainder, int divisor)
        {
            do
            {
                remainder -= divisor;
            }
            while (remainder > 0);

            return "";
        }
        static string ShowBinary(int num)
        {
            string str = Convert.ToString(num, 2);
            str = str.PadLeft(32, '0');
            return str;
        }
        private static void FillZeros(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = '0';
            }
        }
        private static void FillArray(char[] array, string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                array[array.Length - input.Length + i] = input[i];
            }
        }

        public static string GetRemainderAndQuotient(int remainder, int quotient)
        {
            return ShowBinary(remainder) + ShowBinary(quotient);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int remainder = int.Parse(Console.ReadLine());
            int divisor = int.Parse(Console.ReadLine());
            string remainderString = ShowBinary(remainder);
            Console.WriteLine(remainderString);
            string divisorString = ShowBinary(divisor);
            Console.WriteLine(divisorString);
            int temp = 0;
            do
            {
                if(remainder-divisor<0)
                    break;
                Console.WriteLine($"Номер ітерації {temp}");
                remainder -= divisor;
                temp++;
                Console.WriteLine("Регістр з остачею та часткою");
                Console.WriteLine(GetRemainderAndQuotient(remainder, temp));
            }
            while (remainder > 0);           
            Console.WriteLine("Остача");
            Console.WriteLine(remainder);
            Console.WriteLine("Частка");
            Console.WriteLine(temp);
        }
    }
    /*  class Program
      {
          static string generate_number(Int64 num)
          {
              string str = Convert.ToString(num, 2);
              str = str.PadLeft(32, '0');
              return str;
          }

          static string GenerateQuotientAndRemainder(Int64 number)
          {
              string str = Convert.ToString(number, 2);
              str = str.PadLeft(32, '0');
              str = str.PadRight(64, '0');
              return str;
          }
          static void Main(string[] args)
          {
              Console.WriteLine("Enter a first number ");
              string remainder = Console.ReadLine();
              Console.WriteLine("Enter a second number");
              string divisior = Console.ReadLine();
              Int64 ff = Int32.Parse(remainder);
              int ss = Int32.Parse(divisior);
              Console.WriteLine($"Remainder \n {GenerateQuotientAndRemainder(ff)}");
              Console.WriteLine($"Divisor \n {generate_number(ss)} \n");
             // ff <<= 32;
              //Console.WriteLine($"Divisor \n {generate_number(ss)} \n");
              bool setRemLSBToOne = false;
              for (int i = 0; i <= 16; i++)
              {
                  Console.WriteLine($"Step {i + 1} ");
                  if (ss <= ff)
                  {
                      ff -= ss;
                      setRemLSBToOne = true;
                      Console.Write("less");
                  }
                  else
                      Console.Write("more");

                  Console.WriteLine(" than remainder.");
                  Console.WriteLine("Shift remainder left one bit.");
                  ff <<= 1;
                  if (setRemLSBToOne)
                  {
                      setRemLSBToOne = false;
                      ff |= 1; //lsb - 1
                      Console.WriteLine("Set remainder lsb to 1");
                  }

                  Console.WriteLine();
                  Console.WriteLine($"Remaiderandquatient \n {GenerateQuotientAndRemainder(ff)}");
                  Console.WriteLine($"Divisior \n {generate_number(ss)}");
              }

              long quotient = ff & ((long) Math.Pow(2, 33) - 1);
              long rem = ff >> 33;
              Console.WriteLine("Quotient:\n" + generate_number(quotient) +
                                " ( " + quotient + " )\n");

              Console.WriteLine("Remainder:\n" + generate_number(rem) +
                                " ( " + rem + " )");
          }
      }*/
}