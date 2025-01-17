﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main()
        {
            var firstFile = File.ReadAllLines("FileOne.txt");
            var secondFile = File.ReadAllLines("FileTwo.txt");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < firstFile.Length; i++)
            {
                sb.Append(firstFile[i] + "\n");
                sb.Append(secondFile[i] + "\n");
            }

            File.WriteAllText("output.txt", sb.ToString());
        }
    }
}
