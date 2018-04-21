using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace CommonWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence1 = "The quick brown fox jumps over the lazy dog.";
            string sentence2 = "black cat black cat";
            string sentence3 = "The quick the big the lazy dog";
            var word1 = FindCommonWord(sentence1);
            var word2 = FindCommonWord(sentence2);
            var word3 = FindCommonWord(sentence3);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(word1.Item1 + " " + word1.Item2);
            Console.WriteLine(word2.Item1 + " " + word2.Item2);
            Console.WriteLine(word3.Item1 + " " + word3.Item2);
            Thread.Sleep(500);
            Console.WriteLine("----------------------------------------------");
            Thread.Sleep(1000);

        }

        private static (string,int) FindCommonWord(string sentence)
        {
            Dictionary<string, int> common = new Dictionary<string, int>();
            string[] words = sentence.Split(' ');
            foreach (var word in words)
            {
                if (common.ContainsKey(word))
                {
                    common[word] += 1;
                }
                else
                {
                    common[word] = 1;
                }
            }
            int maxValue = common.Max(v => v.Value);

            //find the max value from the 2nd field of Dictionary
            var strCommon = from x in common where x.Value == common.Max(v => v.Value)
                            select x.Key;
            return   (strCommon.FirstOrDefault(), maxValue);
        }
    }
}
