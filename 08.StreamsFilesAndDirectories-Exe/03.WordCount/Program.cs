using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main()
        {
            var words = File.ReadAllLines("words.txt");
            var dict = new Dictionary<string, int>();
            var text = File.ReadAllText("text.txt")
                           .ToLower()
                           .Split(new char[] { '.', ' ', '!', '?', '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                dict.Add(words[i].ToLower(), 0);
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (dict.ContainsKey(text[i]))
                {
                    dict[text[i]]++;
                }
            }

            StringBuilder unsortedSb = new StringBuilder();
            StringBuilder sortedSb = new StringBuilder();

            foreach (var item in dict)
            {
                unsortedSb.Append(item.Key + " - " + item.Value + "\n");
            }

            foreach (var item in dict.OrderByDescending(x => x.Value))
            {
                sortedSb.Append(item.Key + " - " + item.Value + "\n");
            }

            File.WriteAllText("actualResult.txt", unsortedSb.ToString());
            File.WriteAllText("expectedResult.txt", sortedSb.ToString());
        }
    }
}
