using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSystems1
{
    internal class Program
    {
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
            char[] symbol = { 'А', 'а', 'Б', 'б', 'В', 'в', 'Г', 'г', 'Ґ', 'ґ', 'Д', 'д', 'Е', 'е', 'Є', 'є', 'Ж', 'ж', 'З', 'з', 'И', 'и', 'І', 'і', 'Ї', 'ї', 'Й', 'й', 'К', 'к', 'Л', 'л', 'М', 'м', 'Н', 'н', 'О', 'о', 'П', 'п', 'С', 'р', 'С', 'с', 'Т', 'т', 'У', 'у', 'Ф', 'ф', 'Х', 'х', 'Ц', 'ц', 'Ч', 'ч', 'Ш', 'ш', 'Щ', 'щ', 'ь', 'Ю', 'ю', 'Я', 'я' };
            for (int m = 0; m < symbol.Length; m++)
            {
                for (int i = 0; i < filetext.Length; i++)
                {
                    if (filetext[i] == symbol[m])
                    {
                        counter[m]++;

                    }

                }
                probability[m] = counter[m] / (filetext.Length + 1.0);

            }
            return probability;
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
        static double AllSymbols(string path) //Метод підраховує загальну кількість символів у файлі
        {
            string filetext = Read(path);
            return filetext.Length + 1.0;

        }

        static double AmountOfInformationn(double enthropy, string path) //Метод підраховує значення кількості інформації в тексті
        {
            return enthropy * AllSymbols(path);
        }
        static void AmountOut(double amount, string path) //Виводить порівняння кількості інформації в бітах з загальним розміром файлу
        {
            FileInfo file = new FileInfo(path);
            double size = file.Length;
            Console.WriteLine("Кількість інформації в тексті - {0} біт\nЗагальний розмір файлу - {1} біт\nРозмір файлу в - {2} рази більший за кількість інформації", amount, size * 8, size * 8 / amount);
        }
        static void ProbabilityOut(double[] probability) //Виводить у консоль символ та відносну частоту його появи
        {
            char[] symbol = { 'А', 'а', 'Б', 'б', 'В', 'в', 'Г', 'г', 'Ґ', 'ґ', 'Д', 'д', 'Е', 'е', 'Є', 'є', 'Ж', 'ж', 'З', 'з', 'И', 'и', 'І', 'і', 'Ї', 'ї', 'Й', 'й', 'К', 'к', 'Л', 'л', 'М', 'м', 'Н', 'н', 'О', 'о', 'П', 'п', 'С', 'р', 'С', 'с', 'Т', 'т', 'У', 'у', 'Ф', 'ф', 'Х', 'х', 'Ц', 'ц', 'Ч', 'ч', 'Ш', 'ш', 'Щ', 'щ', 'ь', 'Ю', 'ю', 'Я', 'я' };
            Console.WriteLine("Відносна частота появи символу ");
            for (int i = 0; i < symbol.Length; i++)
            {
                Console.WriteLine("{0,-5}{1}", symbol[i], probability[i]);
            }
        }
        static void EnthropyOut(double enthropy) //Виводить у консоль середню ентропію
        {
            Console.WriteLine("Середня ентропія нерівноймовірного алфавіту\n{0}", enthropy);

        }
        static void AllOut(double amount, string path, double[] probability, double enthropy) //Виводить у консоль значення частот, ентропії та кількості інформації
        {
            ProbabilityOut(probability);
            EnthropyOut(enthropy);
            AmountOut(amount, path);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string path1file = @"D:\Bogdan\1.tar_base64.txt";
            string path2file = @"D:\Bogdan\2.tar_base64.txt";
            string path3file = @"D:\Bogdan\1.tar_base64.txt";
            Console.WriteLine("Перший файл");
            double[] probability1 = Probability(path1file);
            double enthropy1 = AverageEnthropy(probability1);
            double amount1 = AmountOfInformationn(enthropy1, path1file);
            AllOut(amount1, path1file, probability1, enthropy1);
            Console.WriteLine("Другий файл");
            double[] probability2 = Probability(path2file);
            double enthropy2 = AverageEnthropy(probability2);
            double amount2 = AmountOfInformationn(enthropy2, path2file);
            AllOut(amount2, path2file, probability2, enthropy2);
            Console.WriteLine("Третій файл");
            double[] probability3 = Probability(path3file);
            double enthropy3 = AverageEnthropy(probability3);
            double amount3 = AmountOfInformationn(enthropy3, path3file);
            AllOut(amount3, path3file, probability3, enthropy3);
    
        }
    }
}
