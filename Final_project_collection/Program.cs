using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Final_project_collection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите путь к текстовому файлу");
            string path = @"TextForAnalysys.txt";

            var textCollection = AnalysisTextFromFile(ref path);

            Console.WriteLine();
            Console.WriteLine("Топ 10 повторяющихся слов:" + Environment.NewLine);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(textCollection[i].SomeWord + " - " + textCollection[i].WordCnt);
            }         
        }

        private static List<Word> AnalysisTextFromFile (ref string path)
        {
            char[] sepChars = { ' ', '\n', '\r' };
            List<Word> textCollection = new List<Word>();

            var text = File.ReadAllText(path);
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = noPunctuationText.Split(sepChars, StringSplitOptions.RemoveEmptyEntries);


            float cnt = 1;

            foreach (var word in words)
            {
                AddWord(word.ToLower(), ref textCollection);

                Console.SetCursorPosition(0,0);
                Console.WriteLine("Процент обработанных слов: " + Math.Round((cnt / words.Length) * 100, 0) + "%");

                cnt++;
            }

            textCollection.Sort();
            textCollection.Reverse();

            return textCollection;            
        }

        private static void AddWord (string word, ref List<Word> textCollection)
        {
            for (int i = 0; i < textCollection.Count; i++)
            {
                if (textCollection[i].SomeWord == word)
                {
                    textCollection[i].WordCnt++;
                    return;
                }
            }

            textCollection.Add(new Word(someWord:word));
        }
    }
}
