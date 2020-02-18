using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSystem1._2
{
    class Program
    {
        static readonly char[] base64Table = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
                                              'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d',
                                              'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s',
                                              't','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
                                              '8','9','+','/','=' };

        static string Read(string path) //Метод зчитує текст з файлу

        {
            string filetext;
            using (StreamReader sr = new StreamReader(path))
            {
                filetext = sr.ReadToEnd();

            }
            return filetext;
        }
        static double[] Probability(string path) //Метод підраховує відносну частоту появи символу
        {
            string filetext = Read(path);
            double[] probability = new double[65];
            double[] counter = new double[65];
            for (int m = 0; m < base64Table.Length; m++)
            {
                for (int i = 0; i < filetext.Length; i++)
                {
                    if (filetext[i] == base64Table[m])
                    {
                        counter[m]++;

                    }

                }
                probability[m] = counter[m] / (filetext.Length + 1.0);

            }
            return probability;
        }
        static double AmountOfInformationn(double enthropy, string path) //Метод підраховує значення кількості інформації в тексті
        {
            return enthropy * AllSymbols(path);
        }
        static double AllSymbols(string path) //Метод підраховує загальну кількість символів у файлі
        {
            string filetext = Read(path);
            return filetext.Length + 1.0;

        }
        static double AverageEnthropy(double[] probability) //Метод підраховує середню ентропію нерівноймовірного алфавіту
        {
            double averageEnthropy = 0;
            for (int i = 0; i < probability.Length; i++)
            {
                if (probability[i] > 0)
                {
                    averageEnthropy += (probability[i] * Math.Log(probability[i], 2));

                }
            }
            return (averageEnthropy * -1);
        }
        static void Base64Convert(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            string binaryTextBytes = string.Join("", textBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            int countOfBytes = binaryTextBytes.Count();
            string append = countOfBytes % 3 == 2 ? "==" : countOfBytes % 3 == 1 ? "=" : "";
            int remOfDivision = countOfBytes % 6;
            if (remOfDivision != 0)
                for (int i = 0; i < 6 - remOfDivision; i++)
                {
                    binaryTextBytes = binaryTextBytes.Insert(countOfBytes, "0");
                    countOfBytes++;
                }
            List<string> newList = Enumerable.Range(0, countOfBytes / 6).Select(x => binaryTextBytes.Substring(x * 6, 6)).ToList();
            string myEnText = string.Join("", newList.Select(x => base64Table[Convert.ToByte(x, 2)])) + append;
            Console.WriteLine("Текст закодований методом:\n" + myEnText + "\n");
        }
        static void Base64(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            string enText = Convert.ToBase64String(textBytes);
            using (StreamWriter sw = new StreamWriter(path.Replace(".bz2", "_base64.txt"), false))
            {
                sw.WriteLine(enText);
            }
            Console.WriteLine("За допомогою вбудованої бібліотеки:\n" + enText + "\n\n\n");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Base64Convert(@"D:\Bogdan\1.tar.bz2");
            Base64(@"D:\Bogdan\1.tar.bz2");
            Console.WriteLine(AmountOfInformationn(AverageEnthropy(Probability(@"D:\Bogdan\1.tar_base64.txt")), @"D:\Bogdan\1.tar_base64.txt"));
            Base64Convert(@"D:\Bogdan\2.tar.bz2");
            Base64(@"D:\Bogdan\2.tar.bz2");
            Console.WriteLine(AmountOfInformationn(AverageEnthropy(Probability(@"D:\Bogdan\2.tar_base64.txt")), @"D:\Bogdan\2.tar_base64.txt"));
            Base64Convert(@"D:\Bogdan\3.tar.bz2");
            Base64(@"D:\Bogdan\3.tar.bz2");
            Console.WriteLine(AmountOfInformationn(AverageEnthropy(Probability(@"D:\Bogdan\3.tar_base64.txt")), @"D:\Bogdan\3.tar_base64.txt"));
        }
        
    }
}
