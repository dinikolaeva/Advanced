using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DirectoryTraversal
{
    public class ItemFile
    {

        public ItemFile(string name, string extension, double size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }

        public string Name { get; set; }
        public string Extension { get; set; }
        public double Size { get; set; }
    }
}
