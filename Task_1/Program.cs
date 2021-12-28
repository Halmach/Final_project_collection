using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"TextForAnalysys.txt"; // Укажем путь 
            List<string> ls = new List<string>();
            List<double> workTimeValues = new List<double>();
            for (int i = 0; i < 100; i++)
            {
                var stopWatch = Stopwatch.StartNew();

                if (File.Exists(filePath)) // Проверим, существует ли файл по данному пути
                {
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string str = "";
                        while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                        {
                            ls.Add(str);
                            workTimeValues.Add(stopWatch.Elapsed.TotalMilliseconds);
                        }
                    }
                }
            }

            Console.WriteLine("Среднее время работы списка:" + workTimeValues.Average());   
        }
    }
}
