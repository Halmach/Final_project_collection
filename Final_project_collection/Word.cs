using System;

namespace Final_project_collection
{
    internal class Word : IComparable<Word>
    {
        public string SomeWord {get;}

        public int WordCnt { get; set; }

        public Word (string someWord)
        {
            this.SomeWord = someWord;
            this.WordCnt++;
        }

        public int CompareTo(Word w)
        {
            return this.WordCnt.CompareTo(w.WordCnt);
        }
    }
}