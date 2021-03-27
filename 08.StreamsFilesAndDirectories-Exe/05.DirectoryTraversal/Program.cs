using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] filesList = Directory.GetFiles(currentDirectory);
            var catalog = ImportFilesInfo(filesList);

            catalog = catalog.OrderByDescending(x => x.Value.Count)
                             .ThenBy(x => x.Key)
                             .ToDictionary(x => x.Key, y => y.Value);
            PrintFiles(catalog);
            SaveToDesktop(catalog);
        }

        private static void SaveToDesktop(Dictionary<string, List<ItemFile>> catalog)
        {
            var pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";

            StringBuilder sb = PrepareDataForFile(catalog);
            File.WriteAllText(pathDesktop, sb.ToString());
        }

        private static StringBuilder PrepareDataForFile(Dictionary<string, List<ItemFile>> catalog)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in catalog)
            {
                sb.Append(item.Key + "\n");

                foreach (ItemFile it in item.Value.OrderBy(x => x.Size)
                                                  .ToList())
                {
                    sb.Append($"--{it.Name} - {it.Size:f3}kb\n");
                }
            }
            return sb;
        }

        private static Dictionary<string, List<ItemFile>> ImportFilesInfo(string[] filesList)
        {
            var dict = new Dictionary<string, List<ItemFile>>();

            for (int i = 0; i < filesList.Length; i++)
            {
                FileInfo info = new FileInfo(filesList[i]);
                var fileName = info.Name;
                var fileExtension = info.Extension;
                var fileSize = info.Length / 1024.0;

                ItemFile newFile = new ItemFile(fileName, fileExtension, fileSize);

                if (dict.Any(x => x.Key.Contains(fileExtension)))
                {
                    dict[fileExtension].Add(newFile);
                }
                else
                {
                    var newList = new List<ItemFile>();
                    newList.Add(newFile);
                    dict.Add(fileExtension, newList);
                }
            }
            return dict;
        }

        private static void PrintFiles(Dictionary<string, List<ItemFile>> catalog)
        {
            foreach (var item in catalog)
            {
                Console.WriteLine(item.Key);

                foreach (ItemFile it in item.Value
                                            .OrderBy(x => x.Size)
                                            .ToList())
                {
                    Console.WriteLine($"--{it.Name} - {it.Size:f3}kb");
                }
            }
        }
    }
}
